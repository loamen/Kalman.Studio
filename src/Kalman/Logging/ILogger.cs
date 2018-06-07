using System;
using System.Collections.Generic;

namespace Kalman.Logging
{
	/// <summary>
	/// 日志记录器接口
	/// </summary>
	public interface ILogger
	{
        /// <summary>
        /// 获取可以被记录日志的最小级别
        /// </summary>
		LogLevel MinLevel { get; }

        /// <summary>
        /// 获取或设置日志记录器的名称
        /// </summary>
		string Name { get; set; }

        /// <summary>
        /// 获取或设置日志记录器所作用的命名空间
        /// </summary>
		string NameSpace { get; set; }

		/// <summary>
		/// Targets
		/// </summary>
		IEnumerable<ITarget> Targets { get; }

		void Trace(string message);
		void Trace(string message, Exception exception);
		void Debug(string message);
		void Debug(string message, Exception exception);
		void Info(string message);
		void Info(string message, Exception exception);
		void Warning(string message);
		void Warning(string message, Exception exception);
		void Error(string message);
		void Error(string message, Exception exception);
		void Fatal(string message);
		void Fatal(string message, Exception exception);

        /// <summary>
        /// 加载配置
        /// </summary>
        /// <param name="config"></param>
        /// <remarks>
        /// 只能在启动时调用
        /// </remarks>
        /// <exception cref="InvalidOperationException">配置已经被指定</exception>
		void LoadConfig(LoggerConfig config);

        /// <summary>
        /// 限制日志记录器只能在指定的命名空间记录日志，根据命名空间来判断日志记录器是否能记录日志
        /// </summary>
        /// <param name="value">要检测的命名空间</param>
		bool CanLog(string value);
	}
}