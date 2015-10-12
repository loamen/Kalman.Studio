using System.Collections.Generic;

namespace Kalman.Logging
{
	/// <summary>
	/// 多日志记录器
	/// </summary>
	/// <remarks>
    /// 当配置中的命名空间匹配多个日志记录器的时候使用
	/// </remarks>
    class MultiLogger : Logger
    {
		private readonly Dictionary<ITarget, ILogger> _loggerMapping = new Dictionary<ITarget, ILogger>();

		/// <summary>
		/// 初始化，合并多个日志记录器的Target
		/// </summary>
		/// <param name="loggers">所有匹配的日志记录器</param>
        public MultiLogger(IEnumerable<ILogger> loggers)
        {
        	foreach (var logger in loggers)
        	{
        		foreach (var target in logger.Targets)
        		{
        			if (ContainsTarget(target)) continue;
        			_loggerMapping.Add(target, logger);
        			AddTarget(target);
        		}
        	}
        }

		/// <summary>
		/// 将日志实体写入到所有Target
		/// </summary>
		/// <param name="entry"></param>
		/// <param name="targets"></param>
		protected override void WriteToTargets(LogEntry entry, IEnumerable<ITarget> targets)
		{
			foreach (var target in targets)
			{
				entry.Logger = _loggerMapping[target];
				target.Write(entry.Clone() as LogEntry);
			}
		}

        /// <summary>
        /// 获取跳过的堆栈帧数
        /// </summary>
        protected override int SkipCount
        {
            get { return 3; }
        }
    }
}
