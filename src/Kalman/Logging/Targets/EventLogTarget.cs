using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Xml;
using System.Configuration;
using Kalman.Utilities;

namespace Kalman.Logging.Targets
{
    /// <summary>
    /// Windows事件日志
    /// </summary>
    public class EventLogTarget : ITarget
    {
        public EventLogTarget(IFormatter formatter)
        {
            if (formatter == null)
                throw new ArgumentNullException("formatter");

            Formatter = formatter;
        }

        #region ITarget 成员

        public void LoadConfig(TargetConfig config)
        {
            if (config == null)
                throw new ArgumentNullException("config");

            Name = config.Name;
            foreach (XmlNode node in config.ChildConfig)
            {
                try
                {
                    if (node.ChildNodes.Count != 1)
                        throw new ConfigurationErrorsException("EventLogTarget子元素 " + node.Name + "只能为单值元素");

                    switch (node.Name)
                    {
                        case "maxSize":
                            MaxSize = ConvertUtil.ToInt64(node.FirstChild.Value, 1024);
                            break;
                        case "eventLogName":
                            EventLogName = node.FirstChild.Value;
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    throw new ConfigurationErrorsException("解析EventLogTarget子元素值 '" + node.FirstChild.Value + "'失败", ex);
                }
            }
        }

        public string Name { get; private set; }

        public IFormatter Formatter { get; set; }

        public void Write(LogEntry logEntry)
        {
            EventLog eventLog = new EventLog();

            if (string.IsNullOrEmpty(this.EventLogName))
            {
                eventLog.Log = "Kalman.Logging";
            }
            else
            {
                eventLog.Log = this.EventLogName;
            }

            if (!EventLog.SourceExists(logEntry.Logger.Name))
            {
                EventLog.CreateEventSource(logEntry.Logger.Name, EventLogName);
            }

            string logMsg = this.Formatter.Format(logEntry);

            eventLog.MaximumKilobytes = this.MaxSize;
            eventLog.Source = logEntry.Logger.Name;
            eventLog.WriteEntry(logMsg, GetEventLogEntryType(logEntry.Level));
        }

        #endregion

        /// <summary>
        /// 事件日志名称
        /// </summary>
        public string EventLogName { get; set; }

        /// <summary>
        /// 事件日志显示名称
        /// </summary>
        public string EventLogDisplayName { get; set; }

        /// <summary>
        /// 日志文件最大尺寸[kb]
        /// </summary>
        public long MaxSize { get; set; }

        EventLogEntryType GetEventLogEntryType(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Trace:
                case LogLevel.Debug:
                case LogLevel.Info:
                    return EventLogEntryType.Information;
                case LogLevel.Warning:
                    return EventLogEntryType.Warning;
                case LogLevel.Error:
                case LogLevel.Fatal:
                    return EventLogEntryType.Error;
                default:
                    return EventLogEntryType.Information;
            }
        }
    }
}
