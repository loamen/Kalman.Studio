using System;
using System.Collections.Generic;
using System.Reflection;
using Kalman.Logging.Formatters;
using System.Text;

namespace Kalman.Logging
{
	/// <summary>
	/// 默认格式化器
	/// </summary>
	public class DefaultFormatter : IFormatter
	{
		private readonly DateTimeFormatter _dateTimeFormatter = new DateTimeFormatter();
		private string _formatString;
		private List<IPartFormatter> _lineFormatters = new List<IPartFormatter>();

		public DefaultFormatter()
		{
			Name = "Default";
			_dateTimeFormatter.FormatString = "yyyy-MM-dd HH:mm:ss.fff";

			_lineFormatters.Add(_dateTimeFormatter);
			_lineFormatters.Add(new TextFormatter(" "));
			_lineFormatters.Add(new ThreadIdFormatter());
			_lineFormatters.Add(new TextFormatter(" "));
			_lineFormatters.Add(new LogLevelFormatter());
			_lineFormatters.Add(new TextFormatter(" "));
			_lineFormatters.Add(new MessageFormatter());
			_lineFormatters.Add(new TextFormatter(" "));
			_lineFormatters.Add(new StackTraceFormatter());
			_lineFormatters.Add(new TextFormatter(" "));
		}

		#region IFormatter Members

        /// <summary>
        /// 加载配置
        /// </summary>
        /// <param name="config"></param>
        /// <exception cref="InvalidOperationException">配置已经被加载</exception>
        /// <exception cref="ArgumentNullException">参数<c>config</c> 不能为空</exception>
		public void LoadConfig(FormatterConfig config)
		{
			if (config == null)
				throw new ArgumentNullException("config");
			Name = config.Name;
			FormatString = config.Format;
		}


        /// <summary>
        /// 获取或设置格式化器名称
        /// </summary>
		public string Name { get; private set; }

        /// <summary>
        /// 获取或设置格式化字符串
        /// </summary>
		public string FormatString
		{
			get { return _formatString; }
			set
			{
				if (!string.IsNullOrEmpty(value))
					_lineFormatters = ParseFormat(value);
				_formatString = value;
			}
		}

        /// <summary>
        /// 格式化日志实体
        /// </summary>
		public string Format(LogEntry entry)
		{
            if (entry == null)
                return "NullEntry";

            StringBuilder sb = new StringBuilder();

            foreach (IPartFormatter formatter in _lineFormatters)
            {
                sb.Append(formatter.Format(entry));
            }

            if (entry.Exception != null)
            {
                sb.Append(Environment.NewLine);
                sb.Append(entry.Exception);
            }

            return sb.ToString();
		}

        /// <summary>
        /// 格式化日期和时间
        /// </summary>
		public string FormatDateTime(DateTime dateTime)
		{
			return _dateTimeFormatter.Format(dateTime);
		}

        /// <summary>
        /// 格式化日期
        /// </summary>
		public string FormatDate(DateTime dateTime)
		{
			return dateTime.ToString("yyyy-MM-dd");
		}

		#endregion

		/// <summary>
		/// 解析格式化字符串
		/// </summary>
		/// <param name="format"></param>
		/// <returns></returns>
		public static List<IPartFormatter> ParseFormat(string format)
		{
			int start = -1;
            int tag = 0;
			var parts = new List<string>();
            int len = format.Length;
            int idx = format.IndexOf('{');

            parts.Add(format.Substring(0, idx));
			for (int i = idx; i < len; ++i)
			{
				switch (format[i])
				{
					case '{':
						if (start != -1)
							parts.Add(format.Substring(start, i - start));
						start = i;
						break;
					case '}':
						parts.Add(format.Substring(start, i - start));
						start = i + 1;
                        tag = start;//标记最后面的填充字符的开始位置
						break;
				}
			}
            parts.Add(format.Substring(tag, len - tag));

			// {Date:yyyy-MM-dd HH:mm:ss.ffff} {ThreadId} {StackTrace:3,40} {Message}
			var formatters = new List<IPartFormatter>();
			foreach (string part in parts)
			{
				if (part.StartsWith("{DateTime"))
				{
					if (part.Length > 9 && part[9] == ':')
						formatters.Add(new DateTimeFormatter { FormatString = part.Substring(10) });
					else
						formatters.Add(new DateTimeFormatter());
				}
				else if (part.StartsWith("{ThreadId"))
					formatters.Add(new ThreadIdFormatter());
				else if (part.StartsWith("{StackTrace"))
				{
					if (!part.StartsWith("{StackTrace:"))
					{
						formatters.Add(new StackTraceFormatter());
						continue;
					}

					string[] subparts = part.Substring(12).Split(',');
					var formatter = new StackTraceFormatter();
					if (subparts.Length > 0)
						formatter.Count = int.Parse(subparts[0]);
					if (subparts.Length > 1)
						formatter.PadLength = int.Parse(subparts[1]);
					if (subparts.Length > 2)
						formatter.SkipCount = int.Parse(subparts[2]);
					formatters.Add(formatter);
				}
				else if (part.StartsWith("{Message"))
					formatters.Add(new MessageFormatter());
				else if (part.StartsWith("{LogLevel"))
					formatters.Add(new LogLevelFormatter());
				else
					formatters.Add(new TextFormatter {Text = part});
			}
			return formatters;
		}
	}
}