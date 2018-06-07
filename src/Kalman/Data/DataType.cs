using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.Data
{
    /// <summary>
    /// 数据类型（将数据类型分文本、数字、日期时间、布尔四类）
    /// </summary>
    public enum DataType
    {
        /// <summary>
        /// 文本
        /// </summary>
        Text = 1,
        /// <summary>
        /// 数字
        /// </summary>
        NUM = 2,
        /// <summary>
        /// 日期时间
        /// </summary>
        Time = 3,
        /// <summary>
        /// 布尔
        /// </summary>
        Bool = 4
    }
}
