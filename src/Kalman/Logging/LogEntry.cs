using System;
using System.Diagnostics;

namespace Kalman.Logging
{
	/// <summary>
	/// 日志实体类
	/// </summary>
    [Serializable]
	public class LogEntry : ICloneable
	{
		/// <summary>
		/// 获取或设置日志级别
		/// </summary>
		public LogLevel Level { get; set; }

		/// <summary>
		/// 获取或设计日志消息
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// 获取或设置日志创建时间
		/// </summary>
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// 获取或设置写日志的线程ID
		/// </summary>
		public int ThreadID { get; set; }

		/// <summary>
		/// 获取或设置堆栈帧数组
		/// </summary>
		public StackFrame[] StackFrames { get; set; }

		/// <summary>
		/// 获取或设置应用程序抛出的异常
		/// </summary>
		public Exception Exception { get; set; }

		/// <summary>
		/// 获取或设置日志实体所属的日志记录器
		/// </summary>
		public ILogger Logger { get; set; }

        #region ICloneable 成员

        /// <summary>
        /// 克隆一个日志实体
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new LogEntry()
            {
                Level = this.Level,
                Message = this.Message,
                CreatedAt = this.CreatedAt,
                ThreadID = this.ThreadID,
                StackFrames = this.StackFrames,
                Exception = this.Exception,
                Logger = this.Logger
            };
        }

        #endregion
    }
}