using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Kalman.Data.SchemaObject;
using Kalman.Utilities;

namespace Kalman.Data.DbSchemaProvider
{
    public class DB2Schema : DbSchema
    {
        public DB2Schema()
        {

        }

        public DB2Schema(Database db)
        {
            base.DbProvider = db;
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
            return TypeUtil.DB2DataType2DbType(nativeType);
        }
    }
}
