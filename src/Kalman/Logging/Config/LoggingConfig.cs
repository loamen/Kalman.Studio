using System;
using System.Collections.Generic;
using System.Xml;
using System.Configuration;

namespace Kalman.Logging
{
	/// <summary>
	/// 日志组件配置
	/// </summary>
    public class LoggingConfig : ConfigBase
	{
        public static readonly LoggingConfig Instance = new LoggingConfig();

		List<FormatterConfig> _Formatters = new List<FormatterConfig>();
		List<LoggerConfig> _Loggers = new List<LoggerConfig>();
		List<TargetConfig> _Targets = new List<TargetConfig>();

        public LoggingConfig()
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            XmlNode root = (XmlNode)ConfigurationManager.GetSection("kalman/logging");
            if (root == null)
            {
                return;
            }

            foreach (XmlNode node in root.ChildNodes)
            {
                switch (node.Name)
                {
                    case "targets":
                        ParseTargets(node.ChildNodes);
                        break;
                    case "loggers":
                        ParseLoggers(node.ChildNodes);
                        break;
                    case "formatters":
                        ParseFormatters(node.ChildNodes);
                        break;
                }
            }
        }

        #region Properties

        /// <summary>
		/// 获取或设置Target列表
		/// </summary>
		public List<TargetConfig> Targets
		{
			get { return _Targets; }
		}

		/// <summary>
        /// 获取或设置日志记录器列表
		/// </summary>
		public List<LoggerConfig> Loggers
		{
			get { return _Loggers; }
		}

		/// <summary>
        /// 获取或设置格式化器列表
		/// </summary>
		public List<FormatterConfig> Formatters
		{
			get { return _Formatters; }
        }

        #endregion

        //解析formatters节点
        private void ParseFormatters(XmlNodeList nodes)
        {
            foreach (XmlNode node in nodes)
            {
                if (node is XmlComment) continue;

                var config = new FormatterConfig
                {
                    Name = GetAttribute(node, "name", true),
                    Format = GetAttribute(node,"format", false)
                };

                string typeName = GetAttribute(node, "type", true);
                if (!typeName.Contains("."))
                    typeName = "Kalman.Logging." + typeName;

                config.Type = Type.GetType(typeName, false);
                if (config.Type == null)
                    throw new ConfigurationErrorsException(string.Format("找不到类型名称为{0}的格式化器",typeName));

                config.ChildConfig = node.ChildNodes;
                _Formatters.Add(config);
            }
        }

        //解析loggers节点
        private void ParseLoggers(XmlNodeList nodes)
        {
            foreach (XmlNode node in nodes)
            {
                if (node is XmlComment) continue;

                var config = new LoggerConfig
                {
                    ChildConfig = node.ChildNodes,
                    Namespace = GetAttribute(node, "namespace","*"),//若namespace属性没配置，则默认为“*”，表示该Logger可以在任意地方写日志
                    Name = GetAttribute(node, "name", true)
                };

                string[] names = GetAttribute(node, "targets", true).Split(',');
                foreach (string name in names)
                    config.TargetNames.Add(name.Trim());

                try
                {
                    string minLevel = GetAttribute(node, "minLevel", false);
                    if (!string.IsNullOrEmpty(minLevel))
                        config.MinLevel = (LogLevel)Enum.Parse(typeof(LogLevel), minLevel);
                    else
                        config.MinLevel = LogLevel.Trace;
                }
                catch (Exception ex)
                {
                    throw new ConfigurationErrorsException(string.Format("解析minLevel属性时出错，错误信息：{0}", ex.Message));
                }

                _Loggers.Add(config);
            }
        }

        //解析Targets节点
        private void ParseTargets(XmlNodeList nodes)
        {
            foreach (XmlNode node in nodes)
            {
                if (node is XmlComment)                    continue;

                var config = new TargetConfig();
                config.Name = GetAttribute(node, "name", true);
                config.ChildConfig = node.ChildNodes;

                config.FormatterName = GetAttribute(node, "formatter", false);
                if (string.IsNullOrEmpty(config.FormatterName))
                    config.FormatterName = "DefaultFormatter";

                string typeName = GetAttribute(node, "type", true);
                if (!typeName.Contains("."))
                    typeName = "Kalman.Logging.Targets." + typeName;

                config.TargetType = Type.GetType(typeName, false);
                if (config.TargetType == null)
                    throw new ConfigurationErrorsException(string.Format("找不到类型名称为{0}的Target",typeName));

                _Targets.Add(config);
            }
        }
    }
}