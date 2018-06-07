using System;

namespace Kalman.Logging.Formatters
{
	/// <summary>
	/// 日期和时间格式化器
	/// </summary>
	public class DateTimeFormatter : IPartFormatter
	{
		/// <summary>
		/// 获取或设置日期时间格式化字符串
		/// </summary>
		public string FormatString { get; set; }

        /// <summary>
        /// 格式化日期和时间属性
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
		public string Format(LogEntry entry)
		{
			return entry.CreatedAt.ToString(FormatString);
		}

		public string Format(DateTime dateTime)
		{
			return dateTime.ToString(FormatString);
		}
	}
}
