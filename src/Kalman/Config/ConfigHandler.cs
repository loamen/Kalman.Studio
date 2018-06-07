using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Kalman
{
    /// <summary>
    /// Kalman框架组件通用配置处理类，返回配置节XML字符串给具体的组件配置类解析
    /// </summary>
    public class ConfigHandler : IConfigurationSectionHandler
    {
        #region IConfigurationSectionHandler 成员

        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            return section;
        }

        #endregion
    }
}
