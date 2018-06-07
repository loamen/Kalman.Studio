using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Kalman.Data.SchemaObject
{
    /// <summary>
    /// 列架构对象
    /// </summary>
    [Serializable]
    public class SOColumn : SOBase
    {
        /// <summary>
        /// 父对象，所属表或视图
        /// </summary>
        public SOTableViewBase Parent { get; set; }

        /// <summary>
        /// 是否主键
        /// </summary>
        public bool PrimaryKey { get; set; }

        /// <summary>
        /// 是否外键
        /// </summary>
        public bool ForeignKey { get; set; }

        /// <summary>
        /// 是否标志字段
        /// </summary>
        public bool Identify { get; set; }

        /// <summary>
        /// 原生类型，数据库定义的类型
        /// </summary>
        public string NativeType { get; set; }

        /// <summary>
        /// 数据类型，原生类型所对应的.Net Framework所定义的数据类型
        /// </summary>
        public DbType DataType { get; set; }

        /// <summary>
        /// 是否允许空值
        /// </summary>
        public bool Nullable { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 精度[字段长度]
        /// </summary>
        public int Precision { get; set; }

        /// <summary>
        /// 小数位数
        /// </summary>
        public int Scale { get; set; }

        /// <summary>
        /// 长度，nchar(10)，char(10)长度都是10，但nchar(10)的Size为20
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// .net framework 类型
        /// </summary>
        public Type Type
        {
            get
            {
                return Kalman.Utilities.TypeUtil.DbType2Type(DataType);
            }
        }
        
        /// <summary>
        /// .net framework 类型的字符串表示，如"int"、"long"
        /// </summary>
        public string TypeString
        {
            get
            {
                return Kalman.Utilities.TypeUtil.DbType2TypeString(DataType);
            }
        }

        /// <summary>
        /// 获取所属数据库对象
        /// </summary>
        public override SODatabase Database
        {
            get { return Parent.Parent; }
        }

        /// <summary>
        /// 判断当前列是否数字类型
        /// </summary>
        /// <returns></returns>
        public bool IsNumeric()
        {
            if (
                this.DataType == DbType.Int16 ||
                this.DataType == DbType.Int32 ||
                this.DataType == DbType.Int64 ||
                this.DataType == DbType.UInt16 ||
                this.DataType == DbType.UInt32 ||
                this.DataType == DbType.UInt64 ||
                this.DataType == DbType.Decimal ||
                this.DataType == DbType.Double ||
                this.DataType == DbType.SByte ||
                this.DataType == DbType.Byte ||
                this.DataType == DbType.Currency ||
                this.DataType == DbType.Single
              )
                return true;

            return false;
        }

        /// <summary>
        /// 判断当前列是否整数类型
        /// </summary>
        /// <returns></returns>
        public bool IsInt()
        {
            if (
                this.DataType == DbType.Int16 ||
                this.DataType == DbType.Int32 ||
                this.DataType == DbType.Int64 ||
                this.DataType == DbType.UInt16 ||
                this.DataType == DbType.UInt32 ||
                this.DataType == DbType.UInt64 ||
                this.DataType == DbType.SByte ||
                this.DataType == DbType.Byte
              )
                return true;

            return false;
        }

        /// <summary>
        /// 判断当前列是否小数类型
        /// </summary>
        /// <returns></returns>
        public bool IsDecimal()
        {
            if (
                this.DataType == DbType.Decimal ||
                this.DataType == DbType.Double ||
                this.DataType == DbType.Currency ||
                this.DataType == DbType.Single
              )
                return true;

            return false;
        }

        /// <summary>
        /// 判断当前列是否日期类型
        /// </summary>
        /// <returns></returns>
        public bool IsDateTime()
        {
            if (
                this.DataType == DbType.Date ||
                this.DataType == DbType.DateTime ||
                this.DataType == DbType.DateTime2 ||
                this.DataType == DbType.DateTimeOffset ||
                this.DataType == DbType.Time 
              )
                return true;

            return false;
        }

        /// <summary>
        /// 判断当前列是否字符串类型
        /// </summary>
        /// <returns></returns>
        public bool IsString()
        {
            if (
                this.DataType == DbType.AnsiString ||
                this.DataType == DbType.AnsiStringFixedLength ||
                this.DataType == DbType.String ||
                this.DataType == DbType.StringFixedLength
              )
                return true;

            return false;
        }
    }
}
