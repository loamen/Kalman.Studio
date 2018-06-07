using System.Collections.Generic;
using System.Xml;

namespace Kalman.Logging
{
    /// <summary>
    /// 日志记录器配置类
    /// </summary>
    public class LoggerConfig
    {
        private string _namespace;

        /// <summary>
        /// 
        /// </summary>
        public LoggerConfig()
        {
            TargetNames = new List<string>();
        }

        /// <summary>
        /// 获取或设置日志记录器所作用的命名空间，只支持唯一的通配符（*）
        /// </summary>
        public string Namespace
        {
            get { return _namespace; }
            set
            {
				if (value == "*")
				{
					IsWildCard = true;
					_namespace = string.Empty;
				}
                else if (value.EndsWith(".*"))
                {
                    IsWildCard = true;
					_namespace = value.Remove(value.Length - 2);
                }
                else
                    _namespace = value;
            }
        }

        /// <summary>
        /// 获取或设置指定命名空间是否包含通配符[*]
        /// </summary>
        public bool IsWildCard { get; private set; }

        /// <summary>
        /// 获取或设置日志记录器的名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取Target名称集合，配置中用逗号隔开
        /// </summary>
        public ICollection<string> TargetNames { get; private set; }

        /// <summary>
        /// 子配置
        /// </summary>
        public XmlNodeList ChildConfig { get; internal set; }

        /// <summary>
        /// 获取可以被记录日志的最小级别
        /// </summary>
        public LogLevel MinLevel { get; set; }

		/// <summary>
		/// 日志记录器Target列表
		/// </summary>
        public IList<ITarget> Targets
        {
            get; internal set;
        }
    }
}
