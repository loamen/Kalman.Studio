using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Kalman.Data.DbProvider;
using Kalman.Utilities;
using System.Data.Common;
using System.Data;
using System.Data.OleDb;
using System.Reflection;

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

            //if (css.ProviderName == "System.Data.OleDb")
            //{
            //    providerFactory = OleDbFactory.Instance;
            //}
            //else
            //{
            //    providerFactory = DbProviderFactories.GetFactory(css.ProviderName);
            //}
            //if (providerFactory == null) throw new Exception(string.Format(Resources.Data.DataProviderNotFound, css.ProviderName));

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
                case "Oracle.ManagedDataAccess.Client":
                    db = new OracleDatabase(connectionString);
                    break;
                case "Devart.Data.Oracle": //http://evget.com/zh-CN/product/954/feature.aspx  http://www.devart.com/ 
                case "DDTek.Oracle": //http://www.datadirect.com/index.html
                    providerFactory = DbProviderFactories.GetFactory(providerName);
                    db = new OracleDatabase(connectionString, providerFactory);
                    break;
                case "System.Data.SQLite":
                    providerFactory = DbProviderFactories.GetFactory(providerName);
                    db = new SQLiteDatabase(connectionString, providerFactory);
                    break;
                case "MySql.Data.MySqlClient":
                    providerFactory = DbProviderFactories.GetFactory(providerName);
                    db = new MySqlDatabase(connectionString, providerFactory);
                    break;
                case "IBM.Data.DB2":
                    providerFactory = DbProviderFactories.GetFactory(providerName);
                    db = new DB2Database(connectionString, providerFactory);
                    break;
                case "FirebirdSql.Data.FirebirdClient":
                    providerFactory = DbProviderFactories.GetFactory(providerName);
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
