using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kalman.Data.SchemaObject;
using System.Data;
using System.Data.Common;
using Kalman.Utilities;

namespace Kalman.Data.DbSchemaProvider
{
    public class SQLiteSchema : DbSchema
    {
        public SQLiteSchema()
        {

        }

        public SQLiteSchema(Database db)
        {
            base.DbProvider = db;
        }

        public override string MetaDataCollectionName_Databases
        {
            get { return "Catalogs"; }
        }

        public override DataSet ExecuteQuery(SODatabase db, string cmdText)
        {
            DataSet ds = new DataSet();
            using (DbConnection cn = base.DbProvider.DbProviderFactory.CreateConnection())
            {
                cn.ConnectionString = base.DbProvider.ConnectionString;
                cn.Open();

                DbCommand cmd = base.DbProvider.DbProviderFactory.CreateCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = cmdText;

                DbDataAdapter adapter = base.DbProvider.DbProviderFactory.CreateDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds, 0, 100000, "temp");
            }

            return ds;
        }

        public override List<SODatabase> GetDatabaseList()
        {
            return new List<SODatabase>
            {
                new SODatabase
                {
                    Name = "Main",
                    Parent = this,
                    Comment = "Main"
                }
            };
        }

        public override List<SOCommand> GetCommandList(SODatabase db)
        {
            return new List<SOCommand>();
        }

        public override List<SOCommandParameter> GetCommandParameterList(SOCommand command)
        {
            return new List<SOCommandParameter>();
        }

        /// <summary>
        /// 获取表的Sql脚本
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public override string GetTableSqlText(SOTable table)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取视图的Sql脚本
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public override string GetViewSqlText(SOView view)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取存储过程的Sql脚本
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public override string GetCommandSqlText(SOCommand command)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取.Net Framework数据类型
        /// </summary>
        /// <param name="nativeType"></param>
        /// <returns></returns>
        public override DbType GetDbType(string nativeType)
        {
            return TypeUtil.SQLiteDataType2DbType(nativeType);
        }

    }//end class
}

