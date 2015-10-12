using System;
using System.Collections.Generic;
using System.Configuration;
using System.Xml;
using Kalman.Utilities;

namespace Kalman.Logging.Targets
{
    /// <summary>
    /// 将日志输出到控制台
    /// </summary>
    public class ConsoleTarget : ITarget
    {
        private readonly Queue<LogEntry> _queue = new Queue<LogEntry>();
        private bool _isWriting;

        public ConsoleTarget(IFormatter formatter)
        {
			if (formatter == null)
				throw new ArgumentNullException("formatter");

            Formatter = formatter;
        }

        /// <summary>
        /// 加载配置
        /// </summary>
        /// <param name="config"></param>
        /// <exception cref="InvalidOperationException">配置已经被加载</exception>
        /// <exception cref="ArgumentNullException">参数<c>config</c> 不能为空</exception>
        /// <exception cref="ConfigurationErrorsException">配置无法正确加载</exception>
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
                        throw new ConfigurationErrorsException("ConsoleTarget子元素 " + node.Name + "只能为单值元素");

					object value = Enum.Parse(typeof(ConsoleColor), node.FirstChild.Value, true);
                    string fc = node.Name.Substring(0, 1).ToUpper();
					GetType().GetProperty(StringUtil.InitialToUpper(node.Name)).SetValue(this, value, null);
				}
				catch (Exception ex)
				{
                    throw new ConfigurationErrorsException("解析ConsoleTarget子元素值 '" + node.FirstChild.Value + "'失败", ex);
                }
    		}
		}

        /// <summary>
        /// 获取或设置Target名称
        /// </summary>
    	public string Name { get; private set; }

        /// <summary>
        /// 获取或设置格式化器
        /// </summary>
    	public IFormatter Formatter { get; private set; }

        /// <summary>
        /// 写日志实体
        /// </summary>
        public void Write(LogEntry logEntry)
        {
            lock (_queue)
            {
                _queue.Enqueue(logEntry);
                if (_isWriting) return;

                System.Threading.ThreadPool.QueueUserWorkItem(DoWrite);
                _isWriting = true;
            }
        }

        //写日志线程方法，递归
        private void DoWrite(object state)
        {
            LogEntry entry;
            lock (_queue)
                entry = _queue.Dequeue();

            string msg = Formatter.Format(entry);
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = GetColor(entry.Level);
            Console.WriteLine(msg);
            Console.ForegroundColor = color;

            lock (_queue)
            {
                if (_queue.Count == 0)
                {
                    _isWriting = false;
                    return;
                }
            }

            DoWrite(null);
        }

        private ConsoleColor GetColor(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Trace:
                    return TraceColor;
                case LogLevel.Debug:
                    return DebugColor;
                case LogLevel.Info:
                    return InfoColor;
                case LogLevel.Warning:
                    return WarningColor;
                case LogLevel.Error:
                    return ErrorColor;
                case LogLevel.Fatal:
                    return FatalColor;
                default:
                    return ConsoleColor.Gray;
            }
        }

        public ConsoleColor WarningColor { get; set; }

        public ConsoleColor ErrorColor { get; set; }

        public ConsoleColor DebugColor { get; set; }

        public ConsoleColor TraceColor { get; set; }

        public ConsoleColor InfoColor { get; set; }

        public ConsoleColor FatalColor { get; set; }

    }
}