using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Globalization;
using System.Transactions;
using Kalman.Utilities;
using Kalman.Data.DbSchemaProvider;
using Kalman.Data.SchemaObject;
using Kalman.Mapping;
using Kalman.Extensions;

namespace Kalman.Data
{
    /// <summary>
    /// 抽象数据库类
    /// </summary>
    public abstract class Database
    {
        #region Property&Field
        //参数缓存
        static readonly ParameterCache parameterCache = new ParameterCache();

        /// <summary>
        /// 数据库架构
        /// </summary>
        //public abstract SODatabase Schema { get; }

        DbProviderFactory _DbProviderFactory;
        /// <summary>
        /// 获取数据提供程序工厂实例
        /// </summary>
        public DbProviderFactory DbProviderFactory
        {
            get { return _DbProviderFactory; }
        }

        /// <summary>
        /// 获取数据库类型
        /// </summary>
        public abstract DatabaseType DatabaseType { get; }

        string _ConnectionString;
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString
        {
            get { return _ConnectionString; }
        }

        /// <summary>
        /// 获取或设置已切换的当前数据库名称
        /// </summary>
        public string CurrentDatabaseName { get; set; }
        #endregion

        #region constructor
        /// <summary>
        /// 构造函数，默认使用Sql Server数据提供程序
        /// </summary>
        /// <param name="connectionString"></param>
        public Database(string connectionString)
            : this(connectionString, SqlClientFactory.Instance)
        {
        }

        /// <summary>
        /// 构造函数，指定数据提供程序工厂实例
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="dbProviderFactory"></param>
        public Database(string connectionString, DbProviderFactory dbProviderFactory)
        {
            CheckUtil.ArgumentNotNullOrEmpty(connectionString, "connectionString");
            CheckUtil.ArgumentNotNull(dbProviderFactory, "dbProviderFactory");

            this._ConnectionString = connectionString;
            this._DbProviderFactory = dbProviderFactory;
        }

        /// <summary>
        /// 构造函数，指定数据提供程序固定名称，用于创建数据提供程序工厂实例
        /// </summary>
        /// <param name="providerInvariantName">数据提供程序固定名称，用来标志和调用数据提供程序</param>
        /// <param name="connectionString"></param>
        public Database(string providerInvariantName, string connectionString)
        {
            this._DbProviderFactory = DbProviderFactories.GetFactory(providerInvariantName);
            this._ConnectionString = connectionString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">数据提供程序名称</param>
        /// <param name="description">数据提供程序说明</param>
        /// <param name="invariantName">数据提供程序固定名称，用来标志和调用数据提供程序</param>
        /// <param name="assemblyQualifiedName">数据提供程序所属程序集的限定名，如</param>
        /// <param name="connectionString">数据库连接字符串</param>
        public Database(string name, string description, string invariantName, string assemblyQualifiedName, string connectionString)
        {
            DataRow providerRow;
            DataTable dt = DbProviderFactories.GetFactoryClasses(); //获取已安装数据提供程序列表
            providerRow = dt.Rows.Find(invariantName);

            //若指定的数据提供程序没有安装，则向已安装数据提供程序列表增加一条该数据提供程序的安装信息
            if (providerRow == null)
            {
                providerRow = dt.NewRow();
                providerRow[0] = name;
                providerRow[1] = description;
                providerRow[2] = invariantName;
                providerRow[3] = assemblyQualifiedName;

                dt.Rows.Add(providerRow);
            }

            this._DbProviderFactory = DbProviderFactories.GetFactory(invariantName);
            this._ConnectionString = connectionString;
        }
        #endregion

        #region Add Parameter Method
        public void AddInParameter(DbCommand command, string name, DbType dbType)
        {
            AddParameter(command, name, dbType, ParameterDirection.Input, String.Empty, DataRowVersion.Default, null);
        }
        public void AddInParameter(DbCommand command, string name, DbType dbType, object value)
        {
            AddParameter(command, name, dbType, ParameterDirection.Input, String.Empty, DataRowVersion.Default, value);
        }
        public void AddInParameter(DbCommand command, string name, DbType dbType, string sourceColumn, DataRowVersion sourceVersion)
        {
            AddParameter(command, name, dbType, 0, ParameterDirection.Input, true, 0, 0, sourceColumn, sourceVersion, null);
        }
        public void AddOutParameter(DbCommand command, string name, DbType dbType, int size)
        {
            AddParameter(command, name, dbType, size, ParameterDirection.Output, true, 0, 0, String.Empty, DataRowVersion.Default, DBNull.Value);
        }
        public virtual void AddParameter(DbCommand command, string name, DbType dbType, int size, ParameterDirection direction, bool nullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
        {
            //每个子类需要重写该方法，提供不同数据库提供程序所定义的DbType，比如Sql Server的SqlDbType，否则可能出现性能上的问题
            DbParameter parameter = CreateParameter(name, dbType, size, direction, nullable, precision, scale, sourceColumn, sourceVersion, value);
            command.Parameters.Add(parameter);
        }
        public void AddParameter(DbCommand command, string name, DbType dbType, ParameterDirection direction, string sourceColumn, DataRowVersion sourceVersion, object value)
        {
            AddParameter(command, name, dbType, 0, direction, false, 0, 0, sourceColumn, sourceVersion, value);
        }
        #endregion

        void AssignParameterValues(DbCommand command, object[] values)
        {
            int parameterIndexShift = UserParametersStartIndex(); // DONE magic number, depends on the database
            for (int i = 0; i < values.Length; i++)
            {
                IDataParameter parameter = command.Parameters[i + parameterIndexShift];
                SetParameterValue(command, parameter.ParameterName, values[i]);
            }
        }

        static DbTransaction BeginTransaction(DbConnection connection)
        {
            DbTransaction tran = connection.BeginTransaction();
            return tran;
        }

        /// <summary>
        /// 为当前数据库生成一个带前缀的参数名
        /// </summary>
        /// <param name="name">不带前缀的参数名</param>
        public virtual string BuildParameterName(string name)
        {
            //子类需要重写该方法，每个数据库的参数前缀可能不同
            return name;
        }

        public static void ClearParameterCache()
        {
            parameterCache.Clear();
        }

        static void CommitTransaction(IDbTransaction tran)
        {
            tran.Commit();
        }

        protected virtual void ConfigureParameter(DbParameter param,
                                                  string name,
                                                  DbType dbType,
                                                  int size,
                                                  ParameterDirection direction,
                                                  bool nullable,
                                                  byte precision,
                                                  byte scale,
                                                  string sourceColumn,
                                                  DataRowVersion sourceVersion,
                                                  object value)
        {
            param.DbType = dbType;
            param.Size = size;
            param.Value = value ?? DBNull.Value;
            param.Direction = direction;
            param.IsNullable = nullable;
            param.SourceColumn = sourceColumn;
            param.SourceVersion = sourceVersion;
        }

        DbCommand CreateCommandByCommandType(CommandType commandType, string commandText)
        {
            DbCommand command = _DbProviderFactory.CreateCommand();
            command.CommandType = commandType;
            command.CommandText = commandText;

            return command;
        }

        public virtual DbConnection CreateConnection()
        {
            DbConnection newConnection = _DbProviderFactory.CreateConnection();
            newConnection.ConnectionString = ConnectionString;

            return newConnection;
        }

        protected DbParameter CreateParameter(string name,
                                              DbType dbType,
                                              int size,
                                              ParameterDirection direction,
                                              bool nullable,
                                              byte precision,
                                              byte scale,
                                              string sourceColumn,
                                              DataRowVersion sourceVersion,
                                              object value)
        {
            DbParameter param = CreateParameter(name);
            ConfigureParameter(param, name, dbType, size, direction, nullable, precision, scale, sourceColumn, sourceVersion, value);
            return param;
        }

        protected DbParameter CreateParameter(string name)
        {
            DbParameter param = _DbProviderFactory.CreateParameter();
            param.ParameterName = BuildParameterName(name);

            return param;
        }

        protected abstract void DeriveParameters(DbCommand discoveryCommand);

        public void DiscoverParameters(DbCommand command)
        {
            using (ConnectionWrapper wrapper = GetOpenConnection())
            {
                using (DbCommand discoveryCommand = CreateCommandByCommandType(command.CommandType, command.CommandText))
                {
                    discoveryCommand.Connection = wrapper.Connection;
                    DeriveParameters(discoveryCommand);

                    foreach (IDataParameter parameter in discoveryCommand.Parameters)
                    {
                        IDataParameter cloneParameter = (IDataParameter)((ICloneable)parameter).Clone();
                        command.Parameters.Add(cloneParameter);
                    }
                }
            }
        }

        protected int DoExecuteNonQuery(DbCommand command)
        {
            try
            {
                //DateTime startTime = DateTime.Now;
                int rowsAffected = command.ExecuteNonQuery();
                //instrumentationProvider.FireCommandExecutedEvent(startTime);
                return rowsAffected;
            }
            catch (Exception)
            {
                //instrumentationProvider.FireCommandFailedEvent(command.CommandText, ConnectionStringNoCredentials, e);
                throw;
            }
        }

        IDataReader DoExecuteReader(DbCommand command, CommandBehavior cmdBehavior)
        {
            try
            {
                //DateTime startTime = DateTime.Now;
                IDataReader reader = command.ExecuteReader(cmdBehavior);
                //instrumentationProvider.FireCommandExecutedEvent(startTime);
                return reader;
            }
            catch (Exception)
            {
                //instrumentationProvider.FireCommandFailedEvent(command.CommandText, ConnectionStringNoCredentials, e);
                throw;
            }
        }

        object DoExecuteScalar(IDbCommand command)
        {
            try
            {
                //DateTime startTime = DateTime.Now;
                object returnValue = command.ExecuteScalar();
                //instrumentationProvider.FireCommandExecutedEvent(startTime);
                return returnValue;
            }
            catch (Exception)
            {
                //instrumentationProvider.FireCommandFailedEvent(command.CommandText, ConnectionStringNoCredentials, e);
                throw;
            }
        }

        void DoLoadDataSet(IDbCommand command, DataSet dataSet, string[] tableNames)
        {
            CheckUtil.ArgumentNotNullOrEmptyForCollection(tableNames, "tableNames");

            for (int i = 0; i < tableNames.Length; i++)
            {
                CheckUtil.ArgumentNotNullOrEmpty(tableNames[i], string.Concat("tableNames[", i, "]"));
                //if (string.IsNullOrEmpty(tableNames[i])) throw new ArgumentException("值不能为空或者空字符串", string.Concat("tableNames[", i, "]"));
            }

            try
            {
                using (DbDataAdapter adapter = GetDataAdapter(UpdateBehavior.Standard))
                {
                    ((IDbDataAdapter)adapter).SelectCommand = command;

                    //DateTime startTime = DateTime.Now;
                    string systemCreatedTableNameRoot = "Table";
                    for (int i = 0; i < tableNames.Length; i++)
                    {
                        string systemCreatedTableName = (i == 0) ? systemCreatedTableNameRoot : systemCreatedTableNameRoot + i;

                        adapter.TableMappings.Add(systemCreatedTableName, tableNames[i]);
                    }

                    adapter.Fill(dataSet);
                    //instrumentationProvider.FireCommandExecutedEvent(startTime);
                }
            }
            catch (Exception)
            {
                throw;
                //instrumentationProvider.FireCommandFailedEvent(command.CommandText, ConnectionStringNoCredentials, e); 
            }
        }

        int DoUpdateDataSet(UpdateBehavior behavior, DataSet dataSet, string tableName, IDbCommand insertCommand, IDbCommand updateCommand, IDbCommand deleteCommand, int? updateBatchSize)
        {
            CheckUtil.ArgumentNotNullOrEmpty(tableName, "tableName");
            CheckUtil.ArgumentNotNull(dataSet, "dataSet");

            if (insertCommand == null && updateCommand == null && deleteCommand == null)
            {
                throw new ArgumentException(Resources.Data.MustInitAtLeastOneCommand);
            }

            using (DbDataAdapter adapter = GetDataAdapter(behavior))
            {
                IDbDataAdapter explicitAdapter = adapter;
                if (insertCommand != null)
                {
                    explicitAdapter.InsertCommand = insertCommand;
                }
                if (updateCommand != null)
                {
                    explicitAdapter.UpdateCommand = updateCommand;
                }
                if (deleteCommand != null)
                {
                    explicitAdapter.DeleteCommand = deleteCommand;
                }

                if (updateBatchSize != null)
                {
                    adapter.UpdateBatchSize = (int)updateBatchSize;
                    if (insertCommand != null)
                        adapter.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
                    if (updateCommand != null)
                        adapter.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
                    if (deleteCommand != null)
                        adapter.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
                }

                try
                {
                    //DateTime startTime = DateTime.Now;
                    int rows = adapter.Update(dataSet.Tables[tableName]);
                    //instrumentationProvider.FireCommandExecutedEvent(startTime);
                    return rows;
                }
                catch (Exception)
                {
                    //instrumentationProvider.FireCommandFailedEvent("DbDataAdapter.Update() " + tableName, ConnectionStringNoCredentials, e);
                    throw;
                }
            }
        }

        #region ExecuteDataSet
        public virtual DataSet ExecuteDataSet(DbCommand command)
        {
            DataSet dataSet = new DataSet();
            dataSet.Locale = CultureInfo.InvariantCulture;
            LoadDataSet(command, dataSet, "Table");
            return dataSet;
        }

        public virtual DataSet ExecuteDataSet(DbCommand command, DbTransaction transaction)
        {
            DataSet dataSet = new DataSet();
            dataSet.Locale = CultureInfo.InvariantCulture;
            LoadDataSet(command, dataSet, "Table", transaction);
            return dataSet;
        }

        public virtual DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
        {
            using (DbCommand command = GetStoredProcCommand(storedProcedureName, parameterValues))
            {
                return ExecuteDataSet(command);
            }
        }

        public virtual DataSet ExecuteDataSet(DbTransaction transaction, string storedProcedureName, params object[] parameterValues)
        {
            using (DbCommand command = GetStoredProcCommand(storedProcedureName, parameterValues))
            {
                return ExecuteDataSet(command, transaction);
            }
        }

        public virtual DataSet ExecuteDataSet(CommandType commandType, string commandText)
        {
            using (DbCommand command = CreateCommandByCommandType(commandType, commandText))
            {
                return ExecuteDataSet(command);
            }
        }

        public virtual DataSet ExecuteDataSet(DbTransaction transaction, CommandType commandType, string commandText)
        {
            using (DbCommand command = CreateCommandByCommandType(commandType, commandText))
            {
                return ExecuteDataSet(command, transaction);
            }
        }
        #endregion

        #region ExecuteNonQuery
        public virtual int ExecuteNonQuery(DbCommand command)
        {
            using (ConnectionWrapper wrapper = GetOpenConnection())
            {
                PrepareCommand(command, wrapper.Connection);
                return DoExecuteNonQuery(command);
            }
        }

        public virtual int ExecuteNonQuery(DbCommand command, DbTransaction transaction)
        {
            PrepareCommand(command, transaction);
            return DoExecuteNonQuery(command);
        }

        public virtual int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
        {
            using (DbCommand command = GetStoredProcCommand(storedProcedureName, parameterValues))
            {
                return ExecuteNonQuery(command);
            }
        }

        public virtual int ExecuteNonQuery(DbTransaction transaction, string storedProcedureName, params object[] parameterValues)
        {
            using (DbCommand command = GetStoredProcCommand(storedProcedureName, parameterValues))
            {
                return ExecuteNonQuery(command, transaction);
            }
        }

        public virtual int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            using (DbCommand command = CreateCommandByCommandType(commandType, commandText))
            {
                return ExecuteNonQuery(command);
            }
        }

        public virtual int ExecuteNonQuery(DbTransaction transaction, CommandType commandType, string commandText)
        {
            using (DbCommand command = CreateCommandByCommandType(commandType, commandText))
            {
                return ExecuteNonQuery(command, transaction);
            }
        }
        #endregion

        #region ExecuteReader
        public virtual IDataReader ExecuteReader(DbCommand command)
        {
            ConnectionWrapper wrapper = GetOpenConnection(false);

            try
            {
                //
                // JS-L: I moved the PrepareCommand inside the try because it can fail.
                //
                PrepareCommand(command, wrapper.Connection);

                //
                // If there is a current transaction, we'll be using a shared connection, so we don't
                // want to close the connection when we're done with the reader.
                //
                if (Transaction.Current != null)
                    return DoExecuteReader(command, CommandBehavior.Default);
                else
                    return DoExecuteReader(command, CommandBehavior.CloseConnection);
            }
            catch
            {
                wrapper.Connection.Close();
                throw;
            }
        }

        public virtual IDataReader ExecuteReader(DbCommand command, DbTransaction transaction)
        {
            PrepareCommand(command, transaction);
            return DoExecuteReader(command, CommandBehavior.Default);
        }

        public IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
        {
            using (DbCommand command = GetStoredProcCommand(storedProcedureName, parameterValues))
            {
                return ExecuteReader(command);
            }
        }

        public IDataReader ExecuteReader(DbTransaction transaction, string storedProcedureName, params object[] parameterValues)
        {
            using (DbCommand command = GetStoredProcCommand(storedProcedureName, parameterValues))
            {
                return ExecuteReader(command, transaction);
            }
        }

        public IDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            using (DbCommand command = CreateCommandByCommandType(commandType, commandText))
            {
                return ExecuteReader(command);
            }
        }

        public IDataReader ExecuteReader(DbTransaction transaction, CommandType commandType, string commandText)
        {
            using (DbCommand command = CreateCommandByCommandType(commandType, commandText))
            {
                return ExecuteReader(command, transaction);
            }
        }
        #endregion

        #region ExecuteScalar
        public virtual object ExecuteScalar(DbCommand command)
        {
            if (command == null) throw new ArgumentNullException("command");

            using (ConnectionWrapper wrapper = GetOpenConnection())
            {
                PrepareCommand(command, wrapper.Connection);
                return DoExecuteScalar(command);
            }
        }

        public virtual object ExecuteScalar(DbCommand command, DbTransaction transaction)
        {
            PrepareCommand(command, transaction);
            return DoExecuteScalar(command);
        }

        public virtual object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
        {
            using (DbCommand command = GetStoredProcCommand(storedProcedureName, parameterValues))
            {
                return ExecuteScalar(command);
            }
        }

        public virtual object ExecuteScalar(DbTransaction transaction, string storedProcedureName, params object[] parameterValues)
        {
            using (DbCommand command = GetStoredProcCommand(storedProcedureName, parameterValues))
            {
                return ExecuteScalar(command, transaction);
            }
        }

        public virtual object ExecuteScalar(CommandType commandType, string commandText)
        {
            using (DbCommand command = CreateCommandByCommandType(commandType, commandText))
            {
                return ExecuteScalar(command);
            }
        }

        public virtual object ExecuteScalar(DbTransaction transaction, CommandType commandType, string commandText)
        {
            using (DbCommand command = CreateCommandByCommandType(commandType, commandText))
            {
                return ExecuteScalar(command, transaction);
            }
        }
        #endregion

        #region ExecuteScalar<T>
        public virtual T ExecuteScalar<T>(DbCommand command)
        {
            object result = ExecuteScalar(command);
            return result.ConvertType<T>();
        }

        public virtual T ExecuteScalar<T>(DbCommand command, DbTransaction transaction)
        {
            object result = ExecuteScalar(command, transaction);
            return result.ConvertType<T>();
        }

        public virtual T ExecuteScalar<T>(string storedProcedureName, params object[] parameterValues)
        {
            object result = ExecuteScalar(storedProcedureName, parameterValues);
            return result.ConvertType<T>();
        }

        public virtual T ExecuteScalar<T>(DbTransaction transaction, string storedProcedureName, params object[] parameterValues)
        {
            object result = ExecuteScalar(transaction, storedProcedureName, parameterValues);
            return result.ConvertType<T>();
        }

        public virtual T ExecuteScalar<T>(CommandType commandType, string commandText)
        {
            object result = ExecuteScalar(commandType, commandText);
            return result.ConvertType<T>();
        }

        public virtual T ExecuteScalar<T>(DbTransaction transaction, CommandType commandType, string commandText)
        {
            object result = ExecuteScalar(transaction, commandType, commandText);
            return result.ConvertType<T>();
        }
        #endregion

        #region ExecuteList<T>
        public virtual List<T> ExecuteList<T>(DbCommand command)
        {
            using (DbDataReader reader = ExecuteReader(command) as DbDataReader)
            {
                return reader.ToObjects<T>().ToList<T>();
            }
        }

        public virtual List<T> ExecuteList<T>(DbCommand command, DbTransaction transaction)
        {
            using (DbDataReader reader = ExecuteReader(command, transaction) as DbDataReader)
            {
                return reader.ToObjects<T>().ToList<T>();
            }
        }

        public List<T> ExecuteList<T>(string storedProcedureName, params object[] parameterValues)
        {
            using (DbDataReader reader = ExecuteReader(storedProcedureName, parameterValues) as DbDataReader)
            {
                return reader.ToObjects<T>().ToList<T>();
            }
        }

        public List<T> ExecuteList<T>(DbTransaction transaction, string storedProcedureName, params object[] parameterValues)
        {
            using (DbDataReader reader = ExecuteReader(transaction, storedProcedureName, parameterValues) as DbDataReader)
            {
                return reader.ToObjects<T>().ToList<T>();
            }
        }

        public List<T> ExecuteList<T>(CommandType commandType, string commandText)
        {
            using (DbDataReader reader = ExecuteReader(commandType, commandText) as DbDataReader)
            {
                return reader.ToObjects<T>().ToList<T>();
            }
        }

        public List<T> ExecuteList<T>(DbTransaction transaction, CommandType commandType, string commandText)
        {
            using (DbDataReader reader = ExecuteReader(transaction, commandType, commandText) as DbDataReader)
            {
                return reader.ToObjects<T>().ToList<T>();
            }
        }
        #endregion

        #region ExecuteObject<T>
        public virtual T ExecuteObject<T>(DbCommand command)
        {
            using (DbDataReader reader = ExecuteReader(command) as DbDataReader)
            {
                return reader.Read() ? reader.ToObject<T>() : default(T);
            }
        }

        public virtual T ExecuteObject<T>(DbCommand command, DbTransaction transaction)
        {
            using (DbDataReader reader = ExecuteReader(command, transaction) as DbDataReader)
            {
                return reader.Read() ? reader.ToObject<T>() : default(T);
            }
        }

        public T ExecuteObject<T>(string storedProcedureName, params object[] parameterValues)
        {
            using (DbDataReader reader = ExecuteReader(storedProcedureName, parameterValues) as DbDataReader)
            {
                //return reader.ToObject<T>();
                return reader.Read() ? reader.ToObject<T>() : default(T);
            }
        }

        public T ExecuteObject<T>(DbTransaction transaction, string storedProcedureName, params object[] parameterValues)
        {
            using (DbDataReader reader = ExecuteReader(transaction, storedProcedureName, parameterValues) as DbDataReader)
            {
                //return reader.ToObject<T>();
                return reader.Read() ? reader.ToObject<T>() : default(T);
            }
        }

        public T ExecuteObject<T>(CommandType commandType, string commandText)
        {
            using (DbDataReader reader = ExecuteReader(commandType, commandText) as DbDataReader)
            {
                //return reader.ToObject<T>();
                return reader.Read() ? reader.ToObject<T>() : default(T);
            }
        }

        public T ExecuteObject<T>(DbTransaction transaction, CommandType commandType, string commandText)
        {
            using (DbDataReader reader = ExecuteReader(transaction, commandType, commandText) as DbDataReader)
            {
                //return reader.ToObject<T>();
                return reader.Read() ? reader.ToObject<T>() : default(T);
            }
        }
        #endregion

        /// <summary>
        /// Get a DbDataAdapter with Standard update behavior.
        /// </summary>
        public DbDataAdapter GetDataAdapter()
        {
            return GetDataAdapter(UpdateBehavior.Standard);
        }

        protected DbDataAdapter GetDataAdapter(UpdateBehavior updateBehavior)
        {
            DbDataAdapter adapter = _DbProviderFactory.CreateDataAdapter();

            if (updateBehavior == UpdateBehavior.Continue)
            {
                SetUpRowUpdatedEvent(adapter);
            }
            return adapter;
        }

        //public object GetInstrumentationEventProvider()
        //{
        //    return instrumentationProvider;
        //}

        //所有打开新连接的操作都在这里进行
        internal DbConnection GetNewOpenConnection()
        {
            DbConnection connection = null;
            try
            {
                try
                {
                    connection = CreateConnection();
                    connection.Open();

                    if (string.IsNullOrEmpty(CurrentDatabaseName) == false && !connection.GetType().Name.ToLower().Contains("oracle"))
                    {
                        connection.ChangeDatabase(this.CurrentDatabaseName);
                    }
                }
                catch (Exception)
                {
                    //instrumentationProvider.FireConnectionFailedEvent(ConnectionStringNoCredentials, ex);
                    throw;
                }

                //instrumentationProvider.FireConnectionOpenedEvent();
            }
            catch
            {
                if (connection != null)
                    connection.Close();

                throw;
            }

            return connection;
        }

        protected ConnectionWrapper GetOpenConnection()
        {
            return GetOpenConnection(true);
        }

        protected ConnectionWrapper GetOpenConnection(bool disposeInnerConnection)
        {
            DbConnection connection = TransactionScopeConnections.GetConnection(this);
            if (connection != null)
                return new ConnectionWrapper(connection, false);
            else
                return new ConnectionWrapper(GetNewOpenConnection(), disposeInnerConnection);
        }

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="command">包含参数的DbCommand对象</param>
        /// <param name="name">参数名称</param>
        /// <returns>返回当前参数的值</returns>
        public virtual object GetParameterValue(DbCommand command, string name)
        {
            return command.Parameters[BuildParameterName(name)].Value;
        }

        #region DbCommand Getter
        /// <summary>
        /// 为SQL查询创建一个DbCommand对象实例
        /// </summary>
        public DbCommand GetSqlStringCommand(string query)
        {
            CheckUtil.ArgumentNotNullOrEmpty(query, "query");
            return CreateCommandByCommandType(CommandType.Text, query);
        }

        /// <summary>
        /// 为指定的存储过程创建一个DbCommand对象实例
        /// </summary> 
        public virtual DbCommand GetStoredProcCommand(string storedProcedureName)
        {
            CheckUtil.ArgumentNotNullOrEmpty(storedProcedureName, "storedProcedureName");
            return CreateCommandByCommandType(CommandType.StoredProcedure, storedProcedureName);
        }

        /// <summary>
        /// 为指定的存储过程创建一个DbCommand对象实例
        /// </summary>   
        public virtual DbCommand GetStoredProcCommand(string storedProcedureName, params object[] parameterValues)
        {
            CheckUtil.ArgumentNotNullOrEmpty(storedProcedureName, "storedProcedureName");

            DbCommand command = CreateCommandByCommandType(CommandType.StoredProcedure, storedProcedureName);

            parameterCache.SetParameters(command, this);

            if (SameNumberOfParametersAndValues(command, parameterValues) == false)
            {
                throw new InvalidOperationException(Resources.Data.ParameterMatchFailure);
            }

            AssignParameterValues(command, parameterValues);
            return command;
        }

        public DbCommand GetStoredProcCommandWithSourceColumns(string storedProcedureName, params string[] sourceColumns)
        {
            CheckUtil.ArgumentNotNullOrEmpty(storedProcedureName, "storedProcedureName");
            if (sourceColumns == null) throw new ArgumentNullException("sourceColumns");

            DbCommand dbCommand = GetStoredProcCommand(storedProcedureName);

            using (DbConnection connection = CreateConnection())
            {
                dbCommand.Connection = connection;
                DiscoverParameters(dbCommand);
            }

            int iSourceIndex = 0;
            foreach (IDataParameter dbParam in dbCommand.Parameters)
            {
                if ((dbParam.Direction == ParameterDirection.Input) | (dbParam.Direction == ParameterDirection.InputOutput))
                {
                    dbParam.SourceColumn = sourceColumns[iSourceIndex];
                    iSourceIndex++;
                }
            }

            return dbCommand;
        }
        #endregion

        #region LoadDataSet
        public virtual void LoadDataSet(DbCommand command, DataSet dataSet, string tableName)
        {
            LoadDataSet(command, dataSet, new string[] { tableName });
        }

        public virtual void LoadDataSet(DbCommand command, DataSet dataSet, string tableName, DbTransaction transaction)
        {
            LoadDataSet(command, dataSet, new string[] { tableName }, transaction);
        }

        public virtual void LoadDataSet(DbCommand command, DataSet dataSet, string[] tableNames)
        {
            using (ConnectionWrapper wrapper = GetOpenConnection())
            {
                PrepareCommand(command, wrapper.Connection);
                DoLoadDataSet(command, dataSet, tableNames);
            }
        }

        public virtual void LoadDataSet(DbCommand command, DataSet dataSet, string[] tableNames, DbTransaction transaction)
        {
            PrepareCommand(command, transaction);
            DoLoadDataSet(command, dataSet, tableNames);
        }

        public virtual void LoadDataSet(string storedProcedureName, DataSet dataSet, string[] tableNames, params object[] parameterValues)
        {
            using (DbCommand command = GetStoredProcCommand(storedProcedureName, parameterValues))
            {
                LoadDataSet(command, dataSet, tableNames);
            }
        }

        public virtual void LoadDataSet(DbTransaction transaction, string storedProcedureName, DataSet dataSet, string[] tableNames, params object[] parameterValues)
        {
            using (DbCommand command = GetStoredProcCommand(storedProcedureName, parameterValues))
            {
                LoadDataSet(command, dataSet, tableNames, transaction);
            }
        }

        public virtual void LoadDataSet(CommandType commandType, string commandText, DataSet dataSet, string[] tableNames)
        {
            using (DbCommand command = CreateCommandByCommandType(commandType, commandText))
            {
                LoadDataSet(command, dataSet, tableNames);
            }
        }

        public void LoadDataSet(DbTransaction transaction, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames)
        {
            using (DbCommand command = CreateCommandByCommandType(commandType, commandText))
            {
                LoadDataSet(command, dataSet, tableNames, transaction);
            }
        }
        #endregion

        ///// <summary>
        ///// <para>Opens a connection.</para>
        ///// </summary>
        ///// <returns>The opened connection.</returns>
        //[Obsolete("Use GetOpenConnection instead.")]
        //protected DbConnection OpenConnection()
        //{
        //    return GetNewOpenConnection();
        //}

        #region PrepareCommand
        protected static void PrepareCommand(DbCommand command, DbConnection connection)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (connection == null) throw new ArgumentNullException("connection");

            command.Connection = connection;
        }

        protected static void PrepareCommand(DbCommand command, DbTransaction transaction)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (transaction == null) throw new ArgumentNullException("transaction");

            PrepareCommand(command, transaction.Connection);
            command.Transaction = transaction;
        }
        #endregion

        static void RollbackTransaction(IDbTransaction tran)
        {
            tran.Rollback();
        }

        /// <summary>
        /// 判断DbCommand的参数个数是否与值数组的长度一致
        /// </summary>
        protected virtual bool SameNumberOfParametersAndValues(DbCommand command, object[] values)
        {
            int numberOfParametersToStoredProcedure = command.Parameters.Count;
            int numberOfValuesProvidedForStoredProcedure = values.Length;
            return numberOfParametersToStoredProcedure == numberOfValuesProvidedForStoredProcedure;
        }

        public virtual void SetParameterValue(DbCommand command, string parameterName, object value)
        {
            command.Parameters[BuildParameterName(parameterName)].Value = value ?? DBNull.Value;
        }

        /// <summary>
        /// Sets the RowUpdated event for the data adapter.
        /// </summary>
        /// <param name="adapter">The <see cref="DbDataAdapter"/> to set the event.</param>
        protected virtual void SetUpRowUpdatedEvent(DbDataAdapter adapter) { }

        #region UpdateDataSet
        public int UpdateDataSet(DataSet dataSet, string tableName, DbCommand insertCommand, DbCommand updateCommand, DbCommand deleteCommand, UpdateBehavior updateBehavior, int? updateBatchSize)
        {
            using (ConnectionWrapper wrapper = GetOpenConnection())
            {
                if (updateBehavior == UpdateBehavior.Transactional && Transaction.Current == null)
                {
                    using (DbTransaction trans = BeginTransaction(wrapper.Connection))
                    {
                        try
                        {
                            int rowsAffected = UpdateDataSet(dataSet, tableName, insertCommand, updateCommand, deleteCommand, trans, updateBatchSize);
                            CommitTransaction(trans);
                            return rowsAffected;
                        }
                        catch
                        {
                            RollbackTransaction(trans);
                            throw;
                        }
                    }
                }
                else
                {
                    if (insertCommand != null)
                    {
                        PrepareCommand(insertCommand, wrapper.Connection);
                    }
                    if (updateCommand != null)
                    {
                        PrepareCommand(updateCommand, wrapper.Connection);
                    }
                    if (deleteCommand != null)
                    {
                        PrepareCommand(deleteCommand, wrapper.Connection);
                    }

                    return DoUpdateDataSet(updateBehavior, dataSet, tableName,
                                           insertCommand, updateCommand, deleteCommand, updateBatchSize);
                }
            }
        }

        public int UpdateDataSet(DataSet dataSet, string tableName, DbCommand insertCommand, DbCommand updateCommand, DbCommand deleteCommand, UpdateBehavior updateBehavior)
        {
            return UpdateDataSet(dataSet, tableName, insertCommand, updateCommand, deleteCommand, updateBehavior, null);
        }

        public int UpdateDataSet(DataSet dataSet, string tableName, DbCommand insertCommand, DbCommand updateCommand, DbCommand deleteCommand, DbTransaction transaction, int? updateBatchSize)
        {
            if (insertCommand != null)
            {
                PrepareCommand(insertCommand, transaction);
            }
            if (updateCommand != null)
            {
                PrepareCommand(updateCommand, transaction);
            }
            if (deleteCommand != null)
            {
                PrepareCommand(deleteCommand, transaction);
            }

            return DoUpdateDataSet(UpdateBehavior.Transactional, dataSet, tableName, insertCommand, updateCommand, deleteCommand, updateBatchSize);
        }

        public int UpdateDataSet(DataSet dataSet, string tableName, DbCommand insertCommand, DbCommand updateCommand, DbCommand deleteCommand, DbTransaction transaction)
        {
            return UpdateDataSet(dataSet, tableName, insertCommand, updateCommand, deleteCommand, transaction, null);
        }
        #endregion

        /// <summary>
        /// 返回参数的开始索引，默认0
        /// </summary>
        protected virtual int UserParametersStartIndex()
        {
            return 0;
        }

        /// <summary>
        /// 包装DbConnection对象的类
        /// </summary>
        protected class ConnectionWrapper : IDisposable
        {
            readonly DbConnection connection;
            readonly bool disposeConnection;

            public ConnectionWrapper(DbConnection connection, bool disposeConnection)
            {
                this.connection = connection;
                this.disposeConnection = disposeConnection;
            }

            public DbConnection Connection
            {
                get { return connection; }
            }

            public void Dispose()
            {
                if (disposeConnection)
                    connection.Dispose();
            }
        }

    }
}
