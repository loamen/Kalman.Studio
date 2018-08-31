using System;
using System.Collections.Generic;
using System.Data;

namespace Kalman.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class TypeUtil
    {
        /// <summary>
        /// 获取对应的SqlServer特定数据类型
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public static SqlDbType DbType2SqlDbType(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.AnsiString:
                    return SqlDbType.VarChar;
                case DbType.AnsiStringFixedLength:
                    return SqlDbType.Char;
                case DbType.Binary:
                    return SqlDbType.VarBinary;
                case DbType.Boolean:
                    return SqlDbType.Bit;
                case DbType.Byte:
                    return SqlDbType.TinyInt;
                case DbType.Currency:
                    return SqlDbType.Money;
                case DbType.Date:
                    return SqlDbType.DateTime;
                case DbType.DateTime:
                    return SqlDbType.DateTime;
                case DbType.Decimal:
                    return SqlDbType.Decimal;
                case DbType.Double:
                    return SqlDbType.Float;
                case DbType.Guid:
                    return SqlDbType.UniqueIdentifier;
                case DbType.Int16:
                    return SqlDbType.Int;
                case DbType.Int32:
                    return SqlDbType.Int;
                case DbType.Int64:
                    return SqlDbType.BigInt;
                case DbType.Object:
                    return SqlDbType.Variant;
                case DbType.SByte:
                    return SqlDbType.TinyInt;
                case DbType.Single:
                    return SqlDbType.Real;
                case DbType.String:
                    return SqlDbType.NVarChar;
                case DbType.StringFixedLength:
                    return SqlDbType.NChar;
                case DbType.Time:
                    return SqlDbType.DateTime;
                case DbType.UInt16:
                    return SqlDbType.Int;
                case DbType.UInt32:
                    return SqlDbType.Int;
                case DbType.UInt64:
                    return SqlDbType.BigInt;
                case DbType.VarNumeric:
                    return SqlDbType.Decimal;

                default:
                    return SqlDbType.VarChar;
            }
        }

        /// <summary>
        /// 获取对应的数据类型
        /// </summary>
        /// <param name="type">type由数据库元数据中定义的DataType转换而来</param>
        /// <returns></returns>
        public static DbType Type2DbType(Type dataType)
        {
            DbType result;

            if (dataType == typeof(Int32))
                result = DbType.Int32;
            else if (dataType == typeof(Int16))
                result = DbType.Int16;
            else if (dataType == typeof(Int64))
                result = DbType.Int64;

            else if (dataType == typeof(DateTime))
                result = DbType.DateTime;
            else if (dataType == typeof(float))
                result = DbType.Decimal;
            else if (dataType == typeof(decimal))
                result = DbType.Decimal;
            else if (dataType == typeof(double))
                result = DbType.Double;
            else if (dataType == typeof(Guid))
                result = DbType.Guid;
            else if (dataType == typeof(bool))
                result = DbType.Boolean;
            else if (dataType == typeof(byte[]))
                result = DbType.Byte;
            else
                result = DbType.String;

            return result;
        }

        public static DbType OleDbADataType2DbType(string nativeType)
        {
            switch (nativeType.ToLower())
            {
                case "11":
                    return DbType.Boolean;

                case "16":
                case "17":
                    return DbType.Byte;

                case "128":
                    return DbType.Binary;

                case "6":
                case "14":
                case "131":
                    return DbType.Decimal;

                case "7":
                case "133":
                case "134":
                case "135":
                case "64":
                    return DbType.DateTime;

                case "5":
                    return DbType.Double;

                case "72":
                    return DbType.Guid;

                case "9":
                case "13":
                case "138":
                case "12":
                    return DbType.Object;

                case "2":
                    return DbType.Int16;

                case "18":
                    return DbType.UInt16;

                case "3":
                    return DbType.Int32;

                case "19":
                    return DbType.UInt32;

                case "20":
                    return DbType.Int64;

                case "21":
                    return DbType.UInt64;

                case "4":
                    return DbType.Single;
            }
            return DbType.String;
        }

        /// <summary>
        /// 将System.Data.DbType类型转换为对应System.Type类型字符串
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public static string DbType2TypeString(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                case DbType.String:
                case DbType.StringFixedLength:
                    return "String";
                case DbType.Binary:
                    return "byte[]";
                case DbType.Boolean:
                    return "Boolean";
                case DbType.Byte://?
                    return "int";
                case DbType.Currency:
                    return "double";
                case DbType.Date:
                    return "Timestamp";
                case DbType.DateTime:
                    return "Timestamp";
                case DbType.DateTime2:
                    return "Timestamp";
                //case DbType.DateTimeOffset:
                //    return "DateTime";
                case DbType.Decimal:
                    return "BigDecimal";
                case DbType.Double:
                    return "double";
                case DbType.Guid:
                    return "Guid";
                case DbType.Int16:
                    return "short";
                case DbType.Int32:
                    return "int";
                case DbType.Int64:
                    return "long";
                case DbType.Object:
                    return "object";
                case DbType.SByte:
                    return "sbyte";
                case DbType.Single:
                    return "Single";
                case DbType.Time:
                    return "Timestamp";
                case DbType.UInt16:
                    return "UInt16";
                case DbType.UInt32:
                    return "UInt32";
                case DbType.UInt64:
                    return "UInt64";
                case DbType.VarNumeric:
                    return "BigDecimal";
                case DbType.Xml:
                    return "String";
                default:
                    return "String";
            }
        }

        /// <summary>
        /// 将System.Data.DbType类型转换为对应Mysql Sequelize类型字符串
        /// </summary>
        /// <param name="dbType"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string DbType2MysqlSequelizeString(DbType dbType,int length=0)
        {
            switch (dbType)
            {
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                case DbType.String:
                case DbType.StringFixedLength:
                    return "STRING" + (length > 0 ? "(" + length + ")" : "");
                case DbType.Xml:
                    return "TEXT";
                case DbType.Binary:
                    return "byte[]";
                case DbType.Boolean:
                    return "BOOLEAN";
                case DbType.Time:
                case DbType.Date:
                case DbType.DateTime:
                case DbType.DateTime2:
                    return "DATE";
                case DbType.Currency:
                case DbType.Decimal:
                case DbType.Double:
                case DbType.VarNumeric:
                    return "DOUBLE";
                case DbType.Guid:
                    return "UUID";
                case DbType.Byte://?
                case DbType.Int16:
                case DbType.Int32:
                case DbType.Int64:
                case DbType.SByte:
                case DbType.Single:
                case DbType.UInt16:
                case DbType.UInt32:
                case DbType.UInt64:
                    return "INTEGER";
                default:
                    return "STRING" + (length > 0 ? "(" + length + ")" : "");
            }
        }

        /// <summary>
        /// 将System.Data.DbType类型转换为对应System.Type类型
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public static Type DbType2Type(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.String:
                    return typeof(string);
                case DbType.UInt64:
                    return typeof(UInt64);
                case DbType.Int64:
                    return typeof(Int64);
                case DbType.Int32:
                    return typeof(Int32);
                case DbType.UInt32:
                    return typeof(UInt32);
                case DbType.Single:
                    return typeof(float);
                case DbType.Date:
                    return typeof(DateTime);
                case DbType.DateTime:
                    return typeof(DateTime);
                case DbType.Time:
                    return typeof(DateTime);
                case DbType.StringFixedLength:
                    return typeof(string);
                case DbType.UInt16:
                    return typeof(UInt16);
                case DbType.Int16:
                    return typeof(Int16);
                case DbType.SByte:
                    return typeof(byte);
                case DbType.Object:
                    return typeof(object);
                case DbType.AnsiString:
                    return typeof(string);
                case DbType.AnsiStringFixedLength:
                    return typeof(string);
                case DbType.VarNumeric:
                    return typeof(decimal);
                case DbType.Currency:
                    return typeof(double);
                case DbType.Binary:
                    return typeof(byte[]);
                case DbType.Decimal:
                    return typeof(decimal);
                case DbType.Double:
                    return typeof(Double);
                case DbType.Guid:
                    return typeof(Guid);
                case DbType.Boolean:
                    return typeof(bool);
                default:
                    return typeof(DBNull);
            } //end switch
        }

        #region 将不同数据库的数据类型转换成System.Data.DbType

        /// <summary>
        /// 将数据库的原生数据类型转换成System.Data.DbType
        /// 参考：http://msdn.microsoft.com/en-us/library/cc716729.aspx
        /// </summary>
        /// <param name="nativeType">数据库原生类型</param>
        /// <returns></returns>
        public static DbType SqlServerDataType2DbType(string nativeType)
        {
            string type = nativeType.ToLower();
            if (nativeType.IndexOf('(') != -1)
            {//如果原始类型类似varchar(50),decimal(10,2)，则去掉括号内容
                type = type.Split('(')[0];
            }

            switch (type)
            {
                case "varchar":
                    return DbType.AnsiString;
                case "nvarchar":
                    return DbType.String;
                case "int":
                    return DbType.Int32;
                case "uniqueidentifier":
                    return DbType.Guid;
                case "datetime":
                case "datetime2":
                    return DbType.DateTime;
                case "bigint":
                    return DbType.Int64;
                case "binary":
                    return DbType.Binary;
                case "bit":
                    return DbType.Boolean;
                case "char":
                    return DbType.AnsiStringFixedLength;
                case "decimal":
                    return DbType.Decimal;
                case "float":
                    return DbType.Double;
                case "image":
                    return DbType.Binary;
                case "money":
                    return DbType.Currency;
                case "nchar":
                    return DbType.String;
                case "ntext":
                    return DbType.String;
                case "numeric":
                    return DbType.Decimal;
                case "real":
                    return DbType.Single;
                case "smalldatetime":
                    return DbType.DateTime;
                case "smallint":
                    return DbType.Int16;
                case "smallmoney":
                    return DbType.Currency;
                case "sql_variant":
                    return DbType.String;
                case "sysname":
                    return DbType.String;
                case "text":
                    return DbType.AnsiString;
                case "timestamp":
                    return DbType.Binary;
                case "tinyint":
                    return DbType.Byte;
                case "varbinary":
                    return DbType.Binary;
                default:
                    return DbType.AnsiString;
            }
        }

        /// <summary>
        /// 将数据库的原生数据类型转换成System.Data.DbType
        /// </summary>
        /// <param name="nativeType">数据库原生类型</param>
        /// <returns></returns>
        public static DbType MySqlDataType2DbType(string nativeType)
        {
            switch (nativeType.ToLower())
            {
                case "bit":
                    return DbType.Boolean;

                case "tinyint":
                    return DbType.SByte;

                case "smallint":
                    return DbType.Int16;

                case "enum":
                    return DbType.UInt16;

                case "mediumint":   //占三个字节
                case "int":
                case "year":    //YYYY
                    return DbType.Int32;

                case "binary":
                case "varbinary":
                case "tinyblob":
                case "mediumblob":
                case "blob":
                case "longblob":
                    return DbType.Binary;

                case "date":
                case "time":
                case "datetime":
                case "timestamp":
                    return DbType.DateTime;

                //case "guid":
                //case "uniqueidentifier":
                //    return DbType.Guid;

                case "decimal":
                    return DbType.Decimal;


                case "bigint":
                    return DbType.Int64;

                case "double":
                case "float":
                case "real":
                    return DbType.Single;

                default:
                    return DbType.String;
            }
        }

        /// <summary>
        /// 将数据库的原生数据类型转换成System.Data.DbType
        /// 参考：http://msdn.microsoft.com/en-us/library/yk72thhd%28VS.80%29.aspx
        ///       http://msdn.microsoft.com/en-us/library/cc716726.aspx
        /// </summary>
        /// <param name="nativeType">数据库原生类型</param>
        /// <returns></returns>
        public static DbType OracleDataType2DbType(string nativeType, int precision = 0, int scale = 0)
        {
            string type = nativeType.ToUpper();
            if (nativeType.IndexOf('(') != -1)
            {
                type = type.Split(new char[] { '(' })[0];
            }
            switch (type)
            {
                case "INTEGER":
                    return DbType.Int32;

                case "NUMBER":
                    return DbType.Decimal;
                case "LOG":
                case "BFILE":
                case "LONG RAW":
                case "RAW":
                case "BLOB":
                    return DbType.Binary;

                case "DATE":
                case "TIMESTAMP":
                    return DbType.DateTime;
            }
            return DbType.String;
        }

        /// <summary>
        /// 将数据库的原生数据类型转换成System.Data.DbType
        /// 参考：
        /// </summary>
        /// <param name="nativeType">数据库原生类型</param>
        /// <returns></returns>
        public static DbType DB2DataType2DbType(string nativeType)
        {
            return DbType.String;
        }

        /// <summary>
        /// 将数据库的原生数据类型转换成System.Data.DbType
        /// 参考：
        /// </summary>
        /// <param name="nativeType">数据库原生类型</param>
        /// <returns></returns>
        public static DbType SQLiteDataType2DbType(string nativeType)
        {
            switch (nativeType.ToLower())
            {
                case "bool":
                case "boolean":
                case "bit":
                case "yesno":
                case "logical":
                    return DbType.Boolean;

                case "tinyint":
                    return DbType.Byte;

                case "binary":
                case "varbinary":
                case "image":
                case "graphic":
                case "blob":
                case "general":
                    return DbType.Binary;

                case "date":
                case "time":
                case "datetime":
                case "datetext":
                case "timestamp":
                    return DbType.DateTime;

                case "guid":
                case "uniqueidentifier":
                    return DbType.Guid;

                case "smallint":
                    return DbType.Int16;

                case "int":
                    return DbType.Int32;

                case "autoinc":
                case "autoincrement":
                case "bigint":
                case "counter":
                case "identity":
                case "int64":
                case "integer":
                case "long":
                    return DbType.Int64;

                case "dec":
                case "decimal":
                case "float":
                case "money":
                case "number":
                case "numeric":
                case "real":
                case "smallmoney":
                    return DbType.Single;

                default:
                    return DbType.String;
            }
        }

        /// <summary>
        /// 将数据库的原生数据类型转换成System.Data.DbType
        /// </summary>
        /// <param name="nativeType">数据库原生类型</param>
        /// <returns></returns>
        //public static DbType DataType2DbType(string nativeType)
        //{
        //}
        #endregion
    }
}
