using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Security.Permissions;
using System.Transactions;
using System.Xml;
using Kalman.Data.DbSchemaProvider;
using Kalman.Data.SchemaObject;

namespace Kalman.Data.DbProvider
{
    public class SqlServerDatabase : Database
	{
        public SqlServerDatabase(string connectionString)
            : base(connectionString, SqlClientFactory.Instance)
        {
        }

		protected char ParameterToken
		{
			get { return '@'; }
		}

        /// <summary>
        /// 数据库类型
        /// </summary>
        public override DatabaseType DatabaseType
        {
            get { return DatabaseType.SqlServer; }
        }

        /// <summary>
        /// 数据库架构对象
        /// </summary>
        //public override SODatabase Schema
        //{
        //    get
        //    {
        //        SODatabase schema = new SODatabase(new SqlServerSchema(this));
        //        schema.Name = this.CreateConnection().Database;
        //        schema.Comment = schema.Name;
        //        return schema;
        //    }
        //}

		public XmlReader ExecuteXmlReader(DbCommand command)
		{
			SqlCommand sqlCommand = CheckIfSqlCommand(command);

			ConnectionWrapper wrapper = GetOpenConnection(false);
			PrepareCommand(command, wrapper.Connection);
			return DoExecuteXmlReader(sqlCommand);
		}

		public XmlReader ExecuteXmlReader(DbCommand command, DbTransaction transaction)
		{
			SqlCommand sqlCommand = CheckIfSqlCommand(command);

			PrepareCommand(sqlCommand, transaction);
			return DoExecuteXmlReader(sqlCommand);
		}

		private XmlReader DoExecuteXmlReader(SqlCommand sqlCommand)
		{
			try
			{
				XmlReader reader = sqlCommand.ExecuteXmlReader();
				return reader;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		private static SqlCommand CheckIfSqlCommand(DbCommand command)
		{
			SqlCommand sqlCommand = command as SqlCommand;
			if (sqlCommand == null) throw new ArgumentException(Resources.Data.CommandNotSqlCommand, "command");
			return sqlCommand;
		}

        //为一个支持UpdateBehavior.Continue的DataAdapter对象监听RowUpdate事件
        private void OnSqlRowUpdated(object sender, SqlRowUpdatedEventArgs rowThatCouldNotBeWritten)
		{
			if (rowThatCouldNotBeWritten.RecordsAffected == 0)
			{
				if (rowThatCouldNotBeWritten.Errors != null)
				{
                    rowThatCouldNotBeWritten.Row.RowError = Resources.Data.RowUpdateFailed;
					rowThatCouldNotBeWritten.Status = UpdateStatus.SkipCurrentRow;
				}
			}
		}

		/// <summary>
        /// 检索从DbCommand指定存储过程的参数信息，并填充指定DbCommand对象的Parameters集合。
		/// </summary>
		protected override void DeriveParameters(DbCommand discoveryCommand)
		{
			SqlCommandBuilder.DeriveParameters((SqlCommand)discoveryCommand);
		}

		/// <summary>
		/// Returns the starting index for parameters in a command.
		/// </summary>
		/// <returns>The starting index for parameters in a command.</returns>
		protected override int UserParametersStartIndex()
		{
			return 1;
		}

		/// <summary>
		/// 生成一个带前缀的参数名
		/// </summary>
		public override string BuildParameterName(string name)
		{
			if (name[0] != this.ParameterToken)
			{
				return name.Insert(0, new string(this.ParameterToken, 1));
			}
			return name;
		}

		/// <summary>
		/// Sets the RowUpdated event for the data adapter.
		/// </summary>
		protected override void SetUpRowUpdatedEvent(DbDataAdapter adapter)
		{
			((SqlDataAdapter)adapter).RowUpdated += OnSqlRowUpdated;
		}

		/// <summary>
		/// Determines if the number of parameters in the command matches the array of parameter values.
		/// </summary>
		/// <param name="command">The <see cref="DbCommand"/> containing the parameters.</param>
		/// <param name="values">The array of parameter values.</param>
		/// <returns><see langword="true"/> if the number of parameters and values match; otherwise, <see langword="false"/>.</returns>
		protected override bool SameNumberOfParametersAndValues(DbCommand command, object[] values)
		{
			int returnParameterCount = 1;
			int numberOfParametersToStoredProcedure = command.Parameters.Count - returnParameterCount;
			int numberOfValuesProvidedForStoredProcedure = values.Length;
			return numberOfParametersToStoredProcedure == numberOfValuesProvidedForStoredProcedure;
		}
     
		public virtual void AddParameter(DbCommand command, string name, SqlDbType dbType, int size, ParameterDirection direction, bool nullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
		{
			DbParameter parameter = CreateParameter(name, dbType, size, direction, nullable, precision, scale, sourceColumn, sourceVersion, value);
			command.Parameters.Add(parameter);
		}
  
		public void AddParameter(DbCommand command, string name, SqlDbType dbType, ParameterDirection direction, string sourceColumn, DataRowVersion sourceVersion, object value)
		{
			AddParameter(command, name, dbType, 0, direction, false, 0, 0, sourceColumn, sourceVersion, value);
		}
     
		public void AddOutParameter(DbCommand command, string name, SqlDbType dbType, int size)
		{
			AddParameter(command, name, dbType, size, ParameterDirection.Output, true, 0, 0, String.Empty, DataRowVersion.Default, DBNull.Value);
		}
     
		public void AddInParameter(DbCommand command, string name, SqlDbType dbType)
		{
			AddParameter(command, name, dbType, ParameterDirection.Input, String.Empty, DataRowVersion.Default, null);
		}
  
		public void AddInParameter(DbCommand command, string name, SqlDbType dbType, object value)
		{
			AddParameter(command, name, dbType, ParameterDirection.Input, String.Empty, DataRowVersion.Default, value);
		}

		public void AddInParameter(DbCommand command, string name, SqlDbType dbType, string sourceColumn, DataRowVersion sourceVersion)
		{
			AddParameter(command, name, dbType, 0, ParameterDirection.Input, true, 0, 0, sourceColumn, sourceVersion, null);
		}

		protected DbParameter CreateParameter(string name, SqlDbType dbType, int size, ParameterDirection direction, bool nullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
		{
			SqlParameter param = CreateParameter(name) as SqlParameter;
			ConfigureParameter(param, name, dbType, size, direction, nullable, precision, scale, sourceColumn, sourceVersion, value);
			return param;
		}

		protected virtual void ConfigureParameter(SqlParameter param, string name, SqlDbType dbType, int size, ParameterDirection direction, bool nullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
		{
			param.SqlDbType = dbType;
			param.Size = size;
			param.Value = (value == null) ? DBNull.Value : value;
			param.Direction = direction;
			param.IsNullable = nullable;
			param.SourceColumn = sourceColumn;
			param.SourceVersion = sourceVersion;
		}
	}
}
