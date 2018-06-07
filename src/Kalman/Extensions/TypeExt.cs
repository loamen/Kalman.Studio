using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Reflection;
using Kalman.Utilities;

namespace Kalman.Extensions
{
    /// <summary>
    /// 数据库相关扩展方法
    /// </summary>
    public static class TypeExt
    {
        /// <summary>
        /// 获取对应的SqlServer特定数据类型
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public static SqlDbType ToSqlDbType(this DbType dbType)
        {
            return TypeUtil.DbType2SqlDbType(dbType);
        }

        /// <summary>
        /// 获取对应的数据类型
        /// </summary>
        /// <param name="type">type由数据库元数据中定义的DataType转换而来</param>
        /// <returns></returns>
        public static DbType ToDbType(this Type dataType)
        {
            return TypeUtil.Type2DbType(dataType);
        }

        /// <summary>
        /// 将System.Data.DbType类型转换为对应System.Type类型字符串
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public static string ToTypeString(this DbType dbType)
        {
            return TypeUtil.DbType2TypeString(dbType);
        }

        /// <summary>
        /// 将System.Data.DbType类型转换为对应System.Type类型
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public static Type ToType(this DbType dbType)
        {
            return TypeUtil.DbType2Type(dbType);
        }

    }
}
