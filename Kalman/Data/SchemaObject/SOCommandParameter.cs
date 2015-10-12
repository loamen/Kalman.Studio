using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Kalman.Data.SchemaObject
{
    /// <summary>
    /// 存储过程参数
    /// </summary>
    [Serializable]
    public class SOCommandParameter : SOBase
    {
        /// <summary>
        /// 父对象，所属存储过程
        /// </summary>
        public SOCommand Parent { get; set; }

        /// <summary>
        /// 原生类型，数据库定义的类型
        /// </summary>
        public string NativeType { get; set; }

        /// <summary>
        /// 数据类型，原生类型所对应的.Net Framework所定义的数据类型
        /// </summary>
        public DbType DataType { get; set; }

        /// <summary>
        /// 参数方向
        /// </summary>
        public ParameterDirection Direction { get; set; }

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
        /// 获取所属数据库对象
        /// </summary>
        public override SODatabase Database
        {
            get { return Parent.Parent; }
        }
    }
}
