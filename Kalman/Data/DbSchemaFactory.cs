using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kalman.Data.DbSchemaProvider;

namespace Kalman.Data
{
    /// <summary>
    /// 数据库架构工厂类
    /// </summary>
    public static class DbSchemaFactory
    {
        /// <summary>
        /// 创建一个数据库架构实例
        /// </summary>
        /// <param name="connectionStringName">连接字符串名称</param>
        /// <returns></returns>
        public static DbSchema Create(string connectionStringName)
        {
            Database db = DatabaseFactory.Create(connectionStringName);
            return Create(db);
        }

        /// <summary>
        /// 创建一个数据库架构实例
        /// </summary>
        /// <param name="db">数据提供程序实例</param>
        /// <returns></returns>
        public static DbSchema Create(Database db)
        {
            DbSchema schema = null;

            switch (db.DatabaseType)
            {
                case DatabaseType.SqlServer:
                    schema = new SqlServerSchema(db);
                    break;
                case DatabaseType.Oracle:
                    schema = new OracleSchema(db);
                    break;
                case DatabaseType.MySql:
                    schema = new MySqlSchema(db);
                    break;
                case DatabaseType.DB2:
                    schema = new DB2Schema(db);
                    break;
                case DatabaseType.SQLite:
                    schema = new SQLiteSchema(db);
                    break;
                case DatabaseType.OleDb:
                    schema = new OleDbSchema(db);
                    break;
                default:
                    break;
            }

            return schema;
        }
    }
}
