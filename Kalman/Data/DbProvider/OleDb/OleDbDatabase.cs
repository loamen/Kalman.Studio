using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using Kalman.Data.SchemaObject;

namespace Kalman.Data.DbProvider
{
    public class OleDbDatabase : Database
    {
        #region 构造函数

        /// <summary>
        /// 构造函数，指定数据提供程序工厂实例
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="dbProviderFactory"></param>
        public OleDbDatabase(string connectionString, DbProviderFactory dbProviderFactory) : base(connectionString,dbProviderFactory)
        {
        }

        /// <summary>
        /// 构造函数，指定数据提供程序固定名称，用于创建数据提供程序工厂实例
        /// </summary>
        /// <param name="connectionString"></param>
        public OleDbDatabase(string connectionString) : base(connectionString, OleDbFactory.Instance)
        {
        }

        #endregion

        //public override SODatabase Schema
        //{
        //    get { throw new NotImplementedException(); }
        //}

        public override DatabaseType DatabaseType
        {
            get { return DatabaseType.OleDb; }
        }

        protected override void DeriveParameters(System.Data.Common.DbCommand discoveryCommand)
        {
            throw new NotImplementedException();
        }
    }
}
