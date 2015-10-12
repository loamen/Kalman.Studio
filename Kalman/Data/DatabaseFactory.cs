using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Kalman.Data.DbProvider;
using Kalman.Utilities;
using System.Data.Common;

namespace Kalman.Data
{
    /// <summary>
    /// 数据库工厂
    /// </summary>
    public static class DatabaseFactory
    {
        /// <summary>
        /// 创建一个数据提供程序实例
        /// </summary>
        /// <param name="connectionStringName"></param>
        /// <returns></returns>
        public static Database Create(string connectionStringName)
        {
            CheckUtil.ArgumentNotNullOrEmpty(connectionStringName, "connectionStringName");

            ConnectionStringSettings css = ConfigurationManager.ConnectionStrings[connectionStringName];
            if (css == null) throw new Exception(string.Format(Resources.Data.ConnectionStringNameNotFound, connectionStringName));

            string connectionString = css.ConnectionString;
            string providerName = css.ProviderName;
            Database db = new SqlServerDatabase(connectionString);
            DbProviderFactory providerFactory = null;

            if(string.IsNullOrEmpty(providerName))return db;

            providerFactory = DbProviderFactories.GetFactory(css.ProviderName);
            if (providerFactory == null) throw new Exception(string.Format(Resources.Data.DataProviderNotFound, css.ProviderName));

            switch (providerName)
            {
                //case "System.Data.SqlClient":
                //    break;
                case "System.Data.Odbc":
                    db = new OdbcDatabase(connectionString);
                    break;
                case "System.Data.OleDb":
                    db = new OleDbDatabase(connectionString);
                    break;
                case "System.Data.OracleClient":
                    db = new OracleDatabase(connectionString);
                    break;
                case "System.Data.SQLite":
                    db = new SQLiteDatabase(connectionString, providerFactory);
                    break;
                case "MySql.Data.MySqlClient":
                    db = new MySqlDatabase(connectionString, providerFactory);
                    break;
                case "IBM.Data.DB2":
                    db = new DB2Database(connectionString, providerFactory);
                    break;
                case "FirebirdSql.Data.FirebirdClient":
                    db = new FirebirdDatabase(connectionString, providerFactory);
                    break;
                default:
                    break;
            }

            return db;
        }

        public static Database Create()
        {
            string connectionStringName = string.Empty;
            int count = ConfigurationManager.ConnectionStrings.Count;

            //machine.config默认有个名为LocalSqlServer的连接字符串
            for (int i = 0; i < count; i++)
            {
                connectionStringName = ConfigurationManager.ConnectionStrings[i].Name;
            }

            if(connectionStringName == string.Empty) throw new Exception(Resources.Data.ConnectionStringNotConfig);
            return Create(connectionStringName);
        }
    }//end class
}
