using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Kalman.Utilities
{
    /// <summary>
    /// 连接字符串管理
    /// </summary>
    public class ConnectionStringUtil
    {
        /// <summary>
        /// Sql Server Provider
        /// </summary>
        public const string MSSQL_PROVIDER_NAME = "System.Data.SqlClient";
        /// <summary>
        /// My Sql Provider
        /// </summary>
        public const string MYSQL_PROVIDER_NAME = "MySql.Data.MySqlClient";
        /// <summary>
        /// Sqlite Provider
        /// </summary>
        public const string SQLITE_PROVIDER_NAME = "System.Data.SQLite";
        /// <summary>
        /// Access Oledb Provider
        /// </summary>
        public const string OLEDB_PROVIDER_NAME = "System.Data.OleDb";
        /// <summary>
        /// Oracle Provider
        /// </summary>
        public const string ORACLE_PROVIDER_NAME = "Devart.Data.Oracle";
        /// <summary>
        /// Oracle MS Provider
        /// </summary>
        public const string ORACLE_MS_PROVIDER_NAME = "System.Data.OracleClient";


        /// <summary>
        /// 获取ConnectionStrings
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string connectionName)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
                return connectionString;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 驱动名称
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        public static string GetProviderName(string connectionName)
        {
            try
            {
                string providerName = ConfigurationManager.ConnectionStrings[connectionName].ProviderName;
            return providerName;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 更新连接字符串
        /// </summary>
        /// <param name="newName"></param>
        /// <param name="newConString"></param>
        /// <param name="newProviderName"></param>
        public static void UpdateConnectionString(string newName, string newConString, string newProviderName)
        {
            bool isModified = false;    //记录该连接串是否已经存在 
            if (ConfigurationManager.ConnectionStrings[newName] != null)
            {
                isModified = true;
            }
            //新建一个连接字符串实例 
            ConnectionStringSettings mySettings = new ConnectionStringSettings(newName, newConString, newProviderName);

            // 打开可执行的配置文件*.exe.config 
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // 如果连接串已存在，首先删除它 
            if (isModified)
            {
                config.ConnectionStrings.ConnectionStrings.Remove(newName);
                // 将新的连接串添加到配置文件中. 
                config.ConnectionStrings.ConnectionStrings.Add(mySettings);
                // 保存对配置文件所作的更改 
                config.Save(ConfigurationSaveMode.Modified);
                // 强制重新载入配置文件的ConnectionStrings配置节  
                ConfigurationManager.RefreshSection("ConnectionStrings");
            }
            else
            {
                config.ConnectionStrings.ConnectionStrings.Add(mySettings);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("ConnectionStrings");
            }
        }

        /// <summary>
        /// 删除ConnectString
        /// </summary>
        /// <param name="name"></param>
        public static void RemoveConnectionString(string name)
        {
            if (ConfigurationManager.ConnectionStrings[name] == null)
            {
                return;
            }

            // 打开可执行的配置文件*.exe.config 
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // 如果连接串已存在，首先删除它 
            config.ConnectionStrings.ConnectionStrings.Remove(name);
            // 保存对配置文件所作的更改 
            config.Save(ConfigurationSaveMode.Modified);
            // 强制重新载入配置文件的ConnectionStrings配置节  
            ConfigurationManager.RefreshSection("ConnectionStrings");
        }
    }
}
