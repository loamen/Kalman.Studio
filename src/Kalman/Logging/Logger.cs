using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Kalman.Logging
{
	/// <summary>
	/// 日志记录器
	/// </summary>
	public class Logger : ILogger
	{
		private readonly ICollection<ITarget> _targets;
		private LoggerConfig _config;

		/// <summary>
		/// 
		/// </summary>
		/// <exception cref="ArgumentNullException">参数<c>targets</c> 不能为空</exception>
		public Logger(ICollection<ITarget> targets)
		{
			if (targets == null)
				throw new ArgumentNullException("targets");
			_targets = targets;
		}

		/// <summary>
		/// 
		/// </summary>
		public Logger()
		{
			_targets = new List<ITarget>();
		}

		#region ILogger Members

		/// <summary>
        /// 用来跟踪程序的执行情况
		/// </summary>
		public void Trace(string msg)
		{
			WriteEntry(LogLevel.Trace, msg);
		}

		/// <summary>
        /// 用来跟踪程序的执行情况
		/// </summary>
		public void Trace(string msg, Exception ex)
		{
			WriteEntry(LogLevel.Trace, msg, ex);
		}

		/// <summary>
		/// 记录调试信息
		/// </summary>
		public void Debug(string msg)
		{
			WriteEntry(LogLevel.Debug, msg);
		}

		/// <summary>
        /// 记录调试信息
		/// </summary>
		public void Debug(string msg, Exception ex)
		{
			WriteEntry(LogLevel.Debug, msg, ex);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Info(string msg)
		{
			WriteEntry(LogLevel.Info, msg);
		}

		/// <summary>
        /// 
		/// </summary>
		public void Info(string msg, Exception ex)
		{
			WriteEntry(LogLevel.Info, msg, ex);
		}

		/// <summary>
		/// 记录警告信息
		/// </summary>
		public void Warning(string msg)
		{
			WriteEntry(LogLevel.Warning, msg);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Warning(string msg, Exception ex)
		{
			WriteEntry(LogLevel.Warning, msg, ex);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Error(string msg)
		{
			WriteEntry(LogLevel.Error, msg);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Error(string msg, Exception ex)
		{
			WriteEntry(LogLevel.Error, msg, ex);
		}

		/// <summary>
        /// 
		/// </summary>
		public void Fatal(string msg)
		{
			WriteEntry(LogLevel.Fatal, msg);
		}

		/// <summary>
        /// 
		/// </summary>
		public void Fatal(string msg, Exception ex)
		{
			WriteEntry(LogLevel.Fatal, msg, ex);
		}

		/// <summary>
		/// 加载配置
		/// </summary>
		/// <param name="config"></param>
		/// <remarks>
		/// 只能在启动时调用
		/// </remarks>
		/// <exception cref="InvalidOperationException">配置已经被指定</exception>
		public void LoadConfig(LoggerConfig config)
		{
			if (_config != null)
				throw new InvalidOperationException("配置已经被指定.");

			_config = config;
			Name = _config.Name;
			NameSpace = _config.Namespace;

			if (_targets.Count != 0) 
				return;

			foreach (var target in _config.Targets)
				_targets.Add(target);
		}

		/// <summary>
        /// 获取可以被记录日志的最小级别
		/// </summary>
		public LogLevel MinLevel
		{
			get { return _config.MinLevel; }
		}

		/// <summary>
        /// 获取或设置日志记录器的名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
        /// 获取或设置日志记录器所作用的命名空间
		/// </summary>
		public string NameSpace { get; set; }

		/// <summary>
        /// 限制日志记录器只能在指定的命名空间记录日志，根据命名空间来判断日志记录器是否能记录日志
		/// </summary>
		/// <param name="value">要检测的命名空间</param>
		public bool CanLog(string value)
		{
			if (_config.IsWildCard)
			{
				if (_config.Namespace == string.Empty)//没有限制命名空间
					return true;

				if (value.Length < _config.Namespace.Length)//指定命名空间长度只能大于或等于配置的命名空间长度
					return false;

				string ns = value == _config.Namespace
				            	? value
				            	: value.Substring(0, _config.Namespace.Length);
				if (ns == _config.Namespace)
					return true;
			}

			return value == _config.Namespace;
		}

		/// <summary>
		/// Targets
		/// </summary>
		public IEnumerable<ITarget> Targets
		{
			get { return _targets; }
		}

		#endregion

		internal void AddTarget(ITarget target)
		{
			_targets.Add(target);
		}

		internal bool ContainsTarget(ITarget target)
		{
			return _targets.Contains(target);
		}

		protected virtual void WriteEntry(LogLevel level, string msg)
		{
			if (level < _config.MinLevel)
				return;

			LogEntry entry = CreateEntry(level, msg);
			WriteToTargets(entry, _targets);
		}

		protected virtual void WriteEntry(LogLevel level, string msg, Exception ex)
		{
			if (level < _config.MinLevel)
				return;

			LogEntry entry = CreateEntry(level, msg, ex);
			WriteToTargets(entry, _targets);
		}

		protected virtual void WriteToTargets(LogEntry entry, IEnumerable<ITarget> targets)
		{
			foreach (ITarget target in _targets)
				target.Write(entry);
		}

        /// <summary>
        /// 创建一个日志实体对象
        /// </summary>
		protected virtual LogEntry CreateEntry(LogLevel level, string msg)
		{
			return new LogEntry
			       	{
			       		CreatedAt = DateTime.Now,
			       		Level = level,
			       		Message = msg,
                        StackFrames = new StackTrace(SkipCount).GetFrames(),
			       		ThreadID = Thread.CurrentThread.ManagedThreadId,
						Logger = this
			       	};
		}

		/// <summary>
		/// 创建一个日志实体对象
		/// </summary>
		protected virtual LogEntry CreateEntry(LogLevel level, string msg, Exception ex)
		{
			return new LogEntry
			       	{
			       		CreatedAt = DateTime.Now,
			       		Exception = ex,
			       		Level = level,
			       		Message = msg,
                        StackFrames = new StackTrace(SkipCount).GetFrames(),
			       		ThreadID = Thread.CurrentThread.ManagedThreadId,
						Logger = this
			       	};
		}

        /// <summary>
        /// 获取跳过的堆栈帧数
        /// </summary>
	    protected virtual int SkipCount
	    {
            get { return 3; }
	    }
	}
}