using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Kalman.Data.SchemaObject;

namespace Kalman.Data.DbProvider
{
    public class SQLiteDatabase : Database
    {
        #region 构造函数

        /// <summary>
        /// 构造函数，指定数据提供程序工厂实例
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="dbProviderFactory"></param>
        public SQLiteDatabase(string connectionString, DbProviderFactory dbProviderFactory) : base(connectionString,dbProviderFactory)
        {
        }

        /// <summary>
        /// 构造函数，指定数据提供程序固定名称，用于创建数据提供程序工厂实例
        /// </summary>
        /// <param name="connectionString"></param>
        public SQLiteDatabase(string connectionString)
            : base("System.Data.SQLite", connectionString)
        {
        }

        #endregion

        //public override SODatabase Schema
        //{
        //    get { throw new NotImplementedException(); }
        //}

        public override DatabaseType DatabaseType
        {
            get { return DatabaseType.SQLite; }
        }

        protected override void DeriveParameters(System.Data.Common.DbCommand discoveryCommand)
        {
            throw new NotImplementedException();
        }
    }
}
