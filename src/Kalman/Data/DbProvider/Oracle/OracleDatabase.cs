using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common; 
using System.Globalization;
using Kalman.Data.DbSchemaProvider;
using Kalman.Data.SchemaObject;
using Oracle.ManagedDataAccess.Client;

namespace Kalman.Data.DbProvider
{
	public class OracleDatabase : Database
	{
		private const string RefCursorName = "cur_OUT";
		private readonly IList<IOraclePackage> packages;
		private static readonly IList<IOraclePackage> emptyPackages = new List<IOraclePackage>(0);
		private readonly IDictionary<string, ParameterTypeRegistry> registeredParameterTypes 
			= new Dictionary<string, ParameterTypeRegistry>();

        public OracleDatabase(string connectionString)
            : this(connectionString, emptyPackages)
        {
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public override DatabaseType DatabaseType
        {
            get { return DatabaseType.Oracle; }
        }

        /// <summary>
        /// 数据库架构对象
        /// </summary>
        //public override SODatabase Schema
        //{
        //    get
        //    {
        //        SODatabase schema = new SODatabase(new OracleSchema(this));
        //        schema.Name = this.CreateConnection().Database;
        //        schema.Comment = schema.Name;
        //        return schema;
        //    }
        //}

        public OracleDatabase(string connectionString,DbProviderFactory dbProviderFactory)
            : base(connectionString, dbProviderFactory)
        {
        }

		public OracleDatabase(string connectionString, IList<IOraclePackage> packages)
			: base(connectionString, OracleClientFactory.Instance)
		{
			if (packages == null) throw new ArgumentNullException("packages");
			this.packages = packages;
		}

		public override void AddParameter(DbCommand command, string name, DbType dbType, int size,
			ParameterDirection direction, bool nullable, byte precision, byte scale, string sourceColumn,
			DataRowVersion sourceVersion, object value)
		{
			if (DbType.Guid.Equals(dbType))
			{
				object convertedValue = ConvertGuidToByteArray(value);

				AddParameter((OracleCommand)command, name, OracleDbType.Raw, 16, direction, nullable, precision,
					scale, sourceColumn, sourceVersion, convertedValue);

				RegisterParameterType(command, name, dbType);
			}
			else
			{
				base.AddParameter(command, name, dbType, size, direction, nullable, precision, scale,
					sourceColumn, sourceVersion, value);
			}
		}
    
		public void AddParameter(OracleCommand command, string name, OracleDbType oracleType, int size,
			ParameterDirection direction, bool nullable, byte precision, byte scale, string sourceColumn,
			DataRowVersion sourceVersion, object value)
		{
			OracleParameter param = CreateParameter(name, DbType.AnsiString, size, direction, nullable, precision, scale, sourceColumn, sourceVersion, value) as OracleParameter;
			param.OracleDbType = oracleType;
			command.Parameters.Add(param);
		}

		public override IDataReader ExecuteReader(DbCommand command)
		{
			PrepareCWRefCursor(command);
			return new OracleDataReaderWrapper((OracleDataReader)base.ExecuteReader(command));
		}

		public override IDataReader ExecuteReader(DbCommand command, DbTransaction transaction)
		{
			PrepareCWRefCursor(command);
			return new OracleDataReaderWrapper((OracleDataReader)base.ExecuteReader(command, transaction));
		}

		public override DataSet ExecuteDataSet(DbCommand command)
		{
			PrepareCWRefCursor(command);
			return base.ExecuteDataSet(command);
		}

		public override DataSet ExecuteDataSet(DbCommand command, DbTransaction transaction)
		{
			PrepareCWRefCursor(command);
			return base.ExecuteDataSet(command, transaction);
		}

		public override void LoadDataSet(DbCommand command, DataSet dataSet, string[] tableNames)
		{
			PrepareCWRefCursor(command);
			base.LoadDataSet(command, dataSet, tableNames);
		}

		public override void LoadDataSet(DbCommand command, DataSet dataSet, string[] tableNames, DbTransaction transaction)
		{
			PrepareCWRefCursor(command);
			base.LoadDataSet(command, dataSet, tableNames, transaction);
		}

		public override object GetParameterValue(DbCommand command, string parameterName)
		{
			object convertedValue = base.GetParameterValue(command, parameterName);

			ParameterTypeRegistry registry = GetParameterTypeRegistry(command.CommandText);
			if (registry != null)
			{
				if (registry.HasRegisteredParameterType(parameterName))
				{
					DbType dbType = registry.GetRegisteredParameterType(parameterName);

					if (DbType.Guid == dbType)
					{
						convertedValue = ConvertByteArrayToGuid(convertedValue);
					}
					else if (DbType.Boolean == dbType)
					{
						convertedValue = Convert.ToBoolean(convertedValue, CultureInfo.InvariantCulture);
					}
				}
			}

			return convertedValue;
		}

		/// <summary>
		/// 设置参数值
		/// </summary>
		/// <param name="command"></param>
		/// <param name="parameterName">参数名称</param>
		/// <param name="value">参数值</param>
		public override void SetParameterValue(DbCommand command, string parameterName, object value)
		{
			object convertedValue = value;

			ParameterTypeRegistry registry = GetParameterTypeRegistry(command.CommandText);
			if (registry != null)
			{
				if (registry.HasRegisteredParameterType(parameterName))
				{
					DbType dbType = registry.GetRegisteredParameterType(parameterName);

					if (DbType.Guid == dbType)
					{
						convertedValue = ConvertGuidToByteArray(value);
					}
				}
			}

			base.SetParameterValue(command, parameterName, convertedValue);
		}

		/// <devdoc>
		/// This is a private method that will build the Oracle package name if your stored procedure
		/// has proper prefix and postfix. 
		/// This functionality is include for
		/// the portability of the architecture between SQL and Oracle datbase.
		/// This method also adds the reference cursor to the command writer if not already added. This
		/// is required for Oracle .NET managed data provider.
		/// </devdoc>        
		private void PrepareCWRefCursor(DbCommand command)
		{
			if (command == null) throw new ArgumentNullException("command");

			if (CommandType.StoredProcedure == command.CommandType)
			{
				// Check for ref. cursor in the command writer, if it does not exist, add a know reference cursor out
				// of "cur_OUT"
				if (QueryProcedureNeedsCursorParameter(command))
				{
					AddParameter(command as OracleCommand, RefCursorName, OracleDbType.RefCursor, 0, ParameterDirection.Output, true, 0, 0, String.Empty, DataRowVersion.Default, Convert.DBNull);
				}
			}
		}

		private ParameterTypeRegistry GetParameterTypeRegistry(string commandText)
		{
			ParameterTypeRegistry registry;
			registeredParameterTypes.TryGetValue(commandText, out registry);
			return registry;
		}


		private void RegisterParameterType(DbCommand command, string parameterName, DbType dbType)
		{
			ParameterTypeRegistry registry = GetParameterTypeRegistry(command.CommandText);
			if (registry == null)
			{
				registry = new ParameterTypeRegistry(command.CommandText);
				registeredParameterTypes.Add(command.CommandText, registry);
			}

			registry.RegisterParameterType(parameterName, dbType);
		}

		private static object ConvertGuidToByteArray(object value)
		{
			return ((value is DBNull) || (value == null)) ? Convert.DBNull : ((Guid)value).ToByteArray();
		}

		private static object ConvertByteArrayToGuid(object value)
		{
			byte[] buffer = (byte[])value;
			if (buffer.Length == 0)
			{
				return DBNull.Value;
			}
			else
			{
				return new Guid(buffer);
			}
		}

		private static bool QueryProcedureNeedsCursorParameter(DbCommand command)
		{
			foreach (OracleParameter parameter in command.Parameters)
			{
                if (parameter.OracleDbType == OracleDbType.RefCursor)
				{
					return false;
				}
			}
			return true;
		}

        //为一个支持UpdateBehavior.Continue的DataAdapter对象监听RowUpdate事件
		private void OnOracleRowUpdated(object sender, OracleRowUpdatedEventArgs args)
		{
			if (args.RecordsAffected == 0)
			{
				if (args.Errors != null)
				{
                    args.Row.RowError = Resources.Data.RowUpdateFailed;
					args.Status = UpdateStatus.SkipCurrentRow;
				}
			}
		}

		/// <summary>
		/// Retrieves parameter information from the stored procedure specified in the <see cref="DbCommand"/> and populates the Parameters collection of the specified <see cref="DbCommand"/> object. 
		/// </summary>
		/// <param name="discoveryCommand">The <see cref="DbCommand"/> to do the discovery.</param>
		/// <remarks>
		/// The <see cref="DbCommand"/> must be an instance of a <see cref="OracleCommand"/> object.
		/// </remarks>
		protected override void DeriveParameters(DbCommand discoveryCommand)
		{
			OracleCommandBuilder.DeriveParameters((OracleCommand)discoveryCommand);
		}

		/// <summary>
		/// <para>Creates a <see cref="DbCommand"/> for a stored procedure.</para>
		/// </summary>
		/// <param name="storedProcedureName"><para>The name of the stored procedure.</para></param>
		/// <param name="parameterValues"><para>The list of parameters for the procedure.</para></param>
		/// <returns><para>The <see cref="DbCommand"/> for the stored procedure.</para></returns>
		/// <remarks>
		/// <para>The parameters for the stored procedure will be discovered and the values are assigned in positional order.</para>
		/// </remarks>        
		public override DbCommand GetStoredProcCommand(string storedProcedureName, params object[] parameterValues)
		{
			// need to do this before of eventual parameter discovery
			string updatedStoredProcedureName = TranslatePackageSchema(storedProcedureName);
			DbCommand command = base.GetStoredProcCommand(updatedStoredProcedureName, parameterValues);
			return command;
		}

		/// <summary>
		/// <para>Creates a <see cref="DbCommand"/> for a stored procedure.</para>
		/// </summary>
		/// <param name="storedProcedureName"><para>The name of the stored procedure.</para></param>		
		/// <returns><para>The <see cref="DbCommand"/> for the stored procedure.</para></returns>
		/// <remarks>
		/// <para>The parameters for the stored procedure will be discovered and the values are assigned in positional order.</para>
		/// </remarks>        
		public override DbCommand GetStoredProcCommand(string storedProcedureName)
		{
			// need to do this before of eventual parameter discovery
			string updatedStoredProcedureName = TranslatePackageSchema(storedProcedureName);
			DbCommand command = base.GetStoredProcCommand(updatedStoredProcedureName);
			return command;
		}

		/// <devdoc>
		/// Looks into configuration and gets the information on how the command wrapper should be updated if calling a package on this
		/// connection.
		/// </devdoc>        
		private string TranslatePackageSchema(string storedProcedureName)
		{
			const string allPrefix = "*";
			string packageName = String.Empty;
			string updatedStoredProcedureName = storedProcedureName;

			if (packages != null && !string.IsNullOrEmpty(storedProcedureName))
			{
				foreach (IOraclePackage oraPackage in packages)
				{
					if ((oraPackage.Prefix == allPrefix) || (storedProcedureName.StartsWith(oraPackage.Prefix)))
					{
						//use the package name for the matching prefix
						packageName = oraPackage.Name;
						//prefix = oraPackage.Prefix;
						break;
					}
				}
			}
			if (0 != packageName.Length)
			{
				updatedStoredProcedureName = String.Format(CultureInfo.InvariantCulture, "{0}.{1}", packageName, storedProcedureName);
			}

			return updatedStoredProcedureName;
		}

		/// <summary>
		/// Sets the RowUpdated event for the data adapter.
		/// </summary>
		/// <param name="adapter">The <see cref="DbDataAdapter"/> to set the event.</param>
		/// <remarks>The <see cref="DbDataAdapter"/> must be an <see cref="OracleDataAdapter"/>.</remarks>
		protected override void SetUpRowUpdatedEvent(DbDataAdapter adapter)
		{
			((OracleDataAdapter)adapter).RowUpdated += OnOracleRowUpdated;
		}
	}

	internal sealed class ParameterTypeRegistry
	{
		private string commandText;
		private IDictionary<string, DbType> parameterTypes;

		internal ParameterTypeRegistry(string commandText)
		{
			this.commandText = commandText;
			this.parameterTypes = new Dictionary<string, DbType>();
		}

		internal void RegisterParameterType(string parameterName, DbType parameterType)
		{
			this.parameterTypes[parameterName] = parameterType;
		}

		internal bool HasRegisteredParameterType(string parameterName)
		{
			return this.parameterTypes.ContainsKey(parameterName);
		}

		internal DbType GetRegisteredParameterType(string parameterName)
		{
			return this.parameterTypes[parameterName];
		}
	}
}
