using System;
using System.Configuration;

namespace Kalman.Logging
{
	/// <summary>
	/// Logger target.
	/// </summary>
	public interface ITarget
	{
		/// <summary>
		/// 加载配置
		/// </summary>
		/// <param name="config"></param>
		/// <exception cref="InvalidOperationException">配置已经被加载</exception>
        /// <exception cref="ArgumentNullException">参数<c>config</c> 不能为空</exception>
		/// <exception cref="ConfigurationErrorsException">配置无法正确加载</exception>
		void LoadConfig(TargetConfig config);

		/// <summary>
		/// 获取或设置Target名称
		/// </summary>
		string Name { get; }

		/// <summary>
		/// 获取或设置格式化器
		/// </summary>
		IFormatter Formatter { get; }


		/// <summary>
		/// 写日志实体
		/// </summary>
		void Write(LogEntry logEntry);
	}
}