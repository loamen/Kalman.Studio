using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kalman.Data.SchemaObject;
using System.Data;
using System.Data.Common;
using Kalman.Utilities;

namespace Kalman.Data
{
    public abstract class DbSchema : IDbSchema
    {
        #region 元数据集合名称定义，不同的数据提供程序对元数据集合名称的定义都可能不同，可以通过重写属性来解决
        
        /// <summary>
        /// [数据库]
        /// </summary>
        public virtual string MetaDataCollectionName_Databases { get { return "Databases"; } }
        /// <summary>
        /// 元数据集合名称[表]
        /// </summary>
        public virtual string MetaDataCollectionName_Tables { get { return "Tables"; } }
        /// <summary>
        /// 元数据集合名称[列]
        /// </summary>
        public virtual string MetaDataCollectionName_Columns { get { return "Columns"; } }
        /// <summary>
        /// 元数据集合名称[视图]
        /// </summary>
        public virtual string MetaDataCollectionName_Views { get { return "Views"; } }
        /// <summary>
        /// 元数据集合名称[视图列]
        /// </summary>
        public virtual string MetaDataCollectionName_ViewColumns { get { return "ViewColumns"; } }
        /// <summary>
        /// 元数据集合名称[索引]
        /// </summary>
        public virtual string MetaDataCollectionName_Indexes { get { return "Indexes"; } }
        /// <summary>
        /// 元数据集合名称[索引列]
        /// </summary>
        public virtual string MetaDataCollectionName_IndexColumns { get { return "IndexColumns"; } }
        /// <summary>
        /// 元数据集合名称[存储过程]
        /// </summary>
        public virtual string MetaDataCollectionName_Procedures { get { return "Procedures"; } }
        /// <summary>
        /// 元数据集合名称[存储过程参数]
        /// </summary>
        public virtual string MetaDataCollectionName_Parameters { get { return "Parameters"; } }

        #endregion

        DbCommandBuilder cmdBuilder;
        /// <summary>
        /// 以正确的目录大小写给定一个不带引号的标识符，返回该标识符的带引号的正确形式，包括正确转义该标识符中嵌入的任何引号。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual string QuoteIdentifier(string name)
        {
            if(cmdBuilder == null) cmdBuilder = this.DbProvider.DbProviderFactory.CreateCommandBuilder();
            string s = string.Concat(cmdBuilder.QuotePrefix, name, cmdBuilder.QuoteSuffix);
            return s;
        }

        /// <summary>
        /// 在指定数据库上执行一个查询，返回一个结果集
        /// </summary>
        /// <param name="db"></param>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public virtual DataSet ExecuteQuery(SODatabase db, string cmdText)
        {
            this.DbProvider.CurrentDatabaseName = db.Name;
            DataSet ds = this.DbProvider.ExecuteDataSet(CommandType.Text, cmdText);
            return ds;
        }

        #region IDbSchema 成员

        /// <summary>
        /// 获取或设置数据提供者实例
        /// </summary>
        public virtual Database DbProvider { get; set; }

        /// <summary>
        /// 获取数据库列表
        /// </summary>
        /// <returns></returns>
        public virtual List<SODatabase> GetDatabaseList()
        {
            List<SODatabase> list = new List<SODatabase>();
            DataTable dt = GetSchema(MetaDataCollectionName_Databases);

            foreach (DataRow dr in dt.Rows)
            {
                SODatabase db = new SODatabase();
                db.Name = dr["database_name"].ToString();
                db.Comment = db.Name;
                db.Parent = this;

                list.Add(db);
            }

            return list;
        }

        public virtual SODatabase GetDatabase(string dbName)
        {
            var db = GetDatabaseList().Find(p=>p.Name == dbName);
            return db;
        }

        /// <summary>
        /// 获取表列表
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public virtual List<SOTable> GetTableList(SODatabase db)
        {
            List<SOTable> list = new List<SOTable>();

            string[] restrictions = new string[4];
            restrictions[0] = db.Name;
            DataTable dt = GetSchema(MetaDataCollectionName_Tables, restrictions);

            foreach (DataRow dr in dt.Rows)
            {
                SOTable table = new SOTable();
                table.Name = dr["table_name"].ToString();
                table.Comment = table.Name;
                table.Parent = db;

                list.Add(table);
            }

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public virtual List<SOTable> GetTableList(string dbName)
        {
            SODatabase db = GetDatabase(dbName);
            return GetTableList(db);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public virtual SOTable GetTable(string dbName, string tableName)
        {
            var table = GetTableList(dbName).Find(p => p.Name == tableName);
            return table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public virtual SOTable GetTable(SODatabase db, string tableName)
        {
            var table = GetTableList(db).Find(p => p.Name == tableName);
            return table;
        }

        /// <summary>
        /// 获取表所拥有的列列表
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public virtual List<SOColumn> GetTableColumnList(SOTable table)
        {
            List<SOColumn> list = new List<SOColumn>();

            string[] restrictions = new string[4];
            restrictions[0] = table.Database.Name;
            restrictions[2] = table.Name;
            DataTable dt = GetSchema(MetaDataCollectionName_Columns, restrictions);

            foreach (DataRow dr in dt.Rows)
            {
                SOColumn c = new SOColumn();
                c.Name = dr["column_name"].ToString();
                c.Comment = c.Name;
                c.Parent = table;
                c.DefaultValue = ConvertUtil.ToString(dr["column_default"]);
                c.Nullable = dr["is_nullable"].ToString() == "YES" ? true : false;
                c.NativeType = dr["data_type"].ToString();
                c.Length = ConvertUtil.ToInt32(dr["character_maximum_length"], -1);
                c.Precision = ConvertUtil.ToInt32(dr["numeric_precision"], -1);
                c.Scale = ConvertUtil.ToInt32(dr["numeric_scale"], -1);

                c.DataType = this.GetDbType(c.NativeType);

                list.Add(c);
            }

            return list;
        }

        /// <summary>
        /// 获取表所拥有的索引列表
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public virtual List<SOIndex> GetTableIndexList(SOTable table)
        {
            List<SOIndex> list = new List<SOIndex>();

            string[] restrictions = new string[4];
            restrictions[0] = table.Database.Name;
            //restrictions[4] = table.Name;
            DataTable dt = GetSchema(MetaDataCollectionName_Indexes, restrictions);

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TABLE_NAME"].ToString() != table.Name) continue;

                SOIndex index = new SOIndex();
                index.Name = dr["INDEX_NAME"].ToString();
                index.IndexColumnName = dr["COLUMN_NAME"].ToString();
                index.IsPrimaryKey = dr["PRIMARY_KEY"].ToString().ToLower() == "true" ? true : false;
                index.IsUnique = dr["UNIQUE"].ToString().ToLower() == "true" ? true : false;
                index.IsCluster = dr["CLUSTERED"].ToString().ToLower() == "true" ? true : false;
                index.IsIdentity = dr["NULLS"].ToString() == "1" ? true : false;    //这里判断自增列默认情况下是没问题的
                index.Comment = index.Name;
                index.Parent = table;

                list.Add(index);
            }

            return list;
        }

        /// <summary>
        /// 获取视图列表
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public virtual List<SOView> GetViewList(SODatabase db)
        {
            List<SOView> list = new List<SOView>();

            string[] restrictions = new string[3];
            restrictions[0] = db.Name;
            DataTable dt = GetSchema(MetaDataCollectionName_Views, restrictions);

            foreach (DataRow dr in dt.Rows)
            {
                SOView view = new SOView();
                view.Name = dr["table_name"].ToString();
                view.Comment = view.Name;
                view.Parent = db;

                list.Add(view);
            }

            return list;
        }

        public virtual List<SOView> GetViewList(string dbName)
        {
            SODatabase db = GetDatabase(dbName);
            return GetViewList(db);
        }

        public virtual SOView GetView(SODatabase db, string viewName)
        {
            var view = GetViewList(db).Find(p => p.Name == viewName);
            return view;
        }

        public virtual SOView GetView(string dbName, string viewName)
        {
            var view = GetViewList(dbName).Find(p => p.Name == viewName);
            return view;
        }

        /// <summary>
        /// 获取视图所拥有的列列表
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public virtual List<SOColumn> GetViewColumnList(SOView view)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取视图所拥有的索引列表
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public virtual List<SOIndex> GetViewIndexList(SOView view)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取存储过程列表
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public virtual List<SOCommand> GetCommandList(SODatabase db)
        {
            List<SOCommand> list = new List<SOCommand>();

            string[] restrictions = new string[4];
            restrictions[0] = db.Name;
            DataTable dt = GetSchema(MetaDataCollectionName_Procedures, restrictions);

            foreach (DataRow dr in dt.Rows)
            {
                SOCommand cmd = new SOCommand();
                cmd.Name = dr["routine_name"].ToString();
                cmd.Comment = cmd.Name;
                cmd.Parent = db;

                list.Add(cmd);
            }

            return list;
        }

        public virtual List<SOCommand> GetCommandList(string dbName)
        {
            SODatabase db = GetDatabase(dbName);
            return GetCommandList(db);
        }

        public virtual SOCommand GetCommand(SODatabase db, string spName)
        {
            var sp = GetCommandList(db).Find(p => p.Name == spName);
            return sp;
        }

        public virtual SOCommand GetCommand(string dbName, string spName)
        {
            var sp = GetCommandList(dbName).Find(p => p.Name == spName);
            return sp;
        }

        /// <summary>
        /// 获取存储过程参数列表
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public virtual List<SOCommandParameter> GetCommandParameterList(SOCommand command)
        {
            List<SOCommandParameter> list = new List<SOCommandParameter>();

            string[] restrictions = new string[4];
            restrictions[0] = command.Database.Name;
            restrictions[2] = command.Name;
            DataTable dt = GetSchema(MetaDataCollectionName_Parameters, restrictions);

            //todo:转换数据

            return list;
        }

        /// <summary>
        /// 获取表的Sql脚本
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public virtual string GetTableSqlText(SOTable table)
        {
            return "该方法目前还没有实现";
        }

        /// <summary>
        /// 获取视图的Sql脚本
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public virtual string GetViewSqlText(SOView view)
        {
            return "该方法目前还没有实现";
        }

        /// <summary>
        /// 获取存储过程的Sql脚本
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public virtual string GetCommandSqlText(SOCommand command)
        {
            return "该方法目前还没有实现";
        }

        /// <summary>
        /// 基于DbConnection对象的元数据对象获取方法
        /// </summary>
        /// <param name="metaDataCollectionName">元数据集合名</param>
        /// <returns></returns>
        public virtual DataTable GetSchema(string metaDataCollectionName)
        {
            return GetSchema(metaDataCollectionName, null);
        }

        /// <summary>
        /// 基于DbConnection对象的元数据对象获取方法
        /// </summary>
        /// <param name="metaDataCollectionName">元数据集合名</param>
        /// <param name="restrictions">过滤条件</param>
        /// <returns></returns>
        public virtual DataTable GetSchema(string metaDataCollectionName, string[] restrictions)
        {
            DataTable dt;

            using (DbConnection cn = DbProvider.CreateConnection())
            {
                cn.ConnectionString = DbProvider.ConnectionString;
                cn.Open();

                if (string.IsNullOrEmpty(metaDataCollectionName))
                {
                    dt = cn.GetSchema();
                }
                else
                {
                    if (restrictions == null || restrictions.All(s => s == null))
                        dt = cn.GetSchema(metaDataCollectionName);
                    else
                        dt = cn.GetSchema(metaDataCollectionName, restrictions);
                }
            }

            return dt;
        }

        ///// <summary>
        ///// 获取数据库原生类型，这里可能存在一对多的关系，只取一个默认原生类型
        ///// </summary>
        ///// <param name="dbType"></param>
        ///// <returns></returns>
        //public abstract string GetNativeType(System.Data.DbType dbType);

        /// <summary>
        /// 获取.Net Framework数据类型
        /// </summary>
        /// <param name="nativeType"></param>
        /// <returns></returns>
        public abstract DbType GetDbType(string nativeType);

        /// <summary>
        /// 获取System.Type类型
        /// </summary>
        /// <param name="nativeType"></param>
        /// <returns></returns>
        public virtual Type GetType(string nativeType)
        {
            DbType dbType = GetDbType(nativeType);
            return TypeUtil.DbType2Type(dbType);
        }

        #endregion
    }
}
