using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kalman.Utilities;
using System.Xml;
using Kalman.Remoting;
using System.Configuration;
using System.IO;

namespace Kalman.Logging.Targets
{
    public class RemotingTarget : ITarget
    {
        public RemotingTarget(IFormatter formatter)
        {
            CheckUtil.ArgumentNotNull(formatter, "formatter");
            this.Formatter = formatter;
            this.ClientName = string.Empty;
        }

        #region ITarget 成员

        /// <summary>
        /// 加载配置
        /// </summary>
        /// <param name="config"></param>
        /// <exception cref="InvalidOperationException">配置已经被加载</exception>
        /// <exception cref="ArgumentNullException">参数<c>config</c> 不能为空</exception>
        /// <exception cref="ConfigurationErrorsException">配置无法正确加载</exception>
        public void LoadConfig(TargetConfig config)
        {
            CheckUtil.ArgumentNotNull(config, "config");

            this.Name = config.Name;
            foreach (XmlNode node in config.ChildConfig)
            {
                try
                {
                    if (node.ChildNodes.Count != 1)
                        throw new ConfigurationErrorsException("RemotingTarget子元素 " + node.Name + "只能为单值元素");

                    switch (node.Name)
                    {
                        case "clientName":
                            ClientName = node.FirstChild.Value;
                            break;
                        case "appName":
                            AppName = node.FirstChild.Value;
                            break;
                        default: break;
                    }
                }
                catch (FormatException ex)
                {
                    throw new ConfigurationErrorsException("解析RemotingTarget子元素值 '" + node.FirstChild.Value + "'失败", ex);
                }
            }
        }

        /// <summary>
        /// 获取或设置Target名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置格式化器
        /// </summary>
        public IFormatter Formatter { get; set; }

        /// <summary>
        /// 写日志实体
        /// </summary>
        public void Write(LogEntry logEntry)
        {
            string msg = Formatter.Format(logEntry);

            try
            {
                LoggingService logger;

                if (string.IsNullOrEmpty(ClientName))
                {
                    logger = RemotingClientProxy.Instance.GetObject<LoggingService>();
                }
                else
                {
                    logger = RemotingClientProxy.Instance.GetObjectByClient<LoggingService>(ClientName);
                }

                logger.WriteLog(AppName, msg);

            }
            catch (Exception ex)
            {
                //写Remoting日志失败时改写本地文件
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log");
                if (Directory.Exists(path) == false) Directory.CreateDirectory(path);
                string logPath = Path.Combine(path, DateTime.Now.ToString("yyyy-MM-dd") + ".log");
                string errPath = Path.Combine(path, "logging_error.log");

                string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string log = string.Format("{0} {1}\r\n", time, msg);
                File.AppendAllText(logPath, log, Encoding.UTF8);

                string err = string.Format("{0} 写Remoting日志失败，错误信息：{1}\r\n", time, ex.ToString());
                File.AppendAllText(errPath, err, Encoding.UTF8);
            }
        }

        #endregion

        /// <summary>
        /// Remoting ClientName
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// 应用程序名称（用来区分不同应用程序的写日志路径）
        /// </summary>
        public string AppName { get; set; }
    }
}
