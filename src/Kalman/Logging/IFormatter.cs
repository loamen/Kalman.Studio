using System;

namespace Kalman.Logging
{
    /// <summary>
    /// 日志实体格式化器接口
    /// </summary>
    public interface IFormatter
    {
		/// <summary>
		/// 加载配置
		/// </summary>
		/// <param name="config"></param>
		/// <exception cref="InvalidOperationException">配置已经被加载</exception>
		/// <exception cref="ArgumentNullException">参数<c>config</c> 不能为空</exception>
		void LoadConfig(FormatterConfig config);

        /// <summary>
        /// 获取或设置格式化器名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 获取或设置格式化字符串
        /// </summary>
        string FormatString { get; }

        /// <summary>
        /// 格式化日志实体
        /// </summary>
		string Format(LogEntry entry);

        /// <summary>
        /// 格式化日期和时间
        /// </summary>
		string FormatDateTime(DateTime dateTime);

		/// <summary>
		/// 格式化日期
		/// </summary>
		string FormatDate(DateTime dateTime);

    }
}
