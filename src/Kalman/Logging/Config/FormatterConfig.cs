using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Kalman.Logging
{
    /// <summary>
    /// 格式化器配置
    /// </summary>
    public class FormatterConfig
    {
        /// <summary>
        /// 获取或设置格式化器名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置格式化字符串
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// 获取或设置格式化器类型
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// 获取或设置格式化器子配置
        /// </summary>
        public XmlNodeList ChildConfig { get; set; }
    }
}
