using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Kalman.Logging
{
    /// <summary>
    /// Target Configuration
    /// </summary>
    public class TargetConfig
    {
        /// <summary>
        /// 获取或设置Target类型
        /// </summary>
        public Type TargetType { get; set; }

        /// <summary>
        /// 获取或设置Target名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置格式化器名称
        /// </summary>
        public string FormatterName { get; set; }

        /// <summary>
        /// 获取或设置Target子配置
        /// </summary>
        public XmlNodeList ChildConfig { get; set; }
    }
}
