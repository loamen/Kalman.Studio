using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;

namespace Kalman.Logging
{
	/// <summary>
	/// 默认的日志记录器提供者
	/// </summary>
	public class LogProvider : ILogProvider
	{
		private readonly List<IFormatter> _formatters = new List<IFormatter>();
		private readonly List<ILogger> _loggers = new List<ILogger>();
		private readonly List<ITarget> _targets = new List<ITarget>();

        public LogProvider()
        {
            LoadConfig();
        }
        
		#region ILogProvider Members

		/// <summary>
		/// 获取日志记录器（根据指定名称）
		/// </summary>
		public ILogger GetLogger(string name)
		{
			foreach (ILogger logger in _loggers)
			{
				if (string.Compare(logger.Name, name, true) == 0)
					return logger;
			}

			return LogManager.NullLogger;
		}

		/// <summary>
		/// 获取日志记录器（为当前类找出匹配的日志记录器）
		/// </summary>
		public ILogger GetCurrentClassLogger()
		{
			var frame = new StackFrame(2);  //调用日志记录器的类所在的堆栈帧
			Type classType = frame.GetMethod().ReflectedType;

			// 查找配置中所有匹配的日志记录器
			IList<ILogger> loggers = FindLoggers(classType);
			if (loggers.Count == 0)
			{
				return LogManager.NullLogger;
			}
			if (loggers.Count == 1)
				return loggers[0];

			MultiLogger logger = new MultiLogger(loggers);
			LogLevel minLevel = LogLevel.Fatal;
			foreach (var logger1 in loggers)
			{
				if (logger1.MinLevel < minLevel)
					minLevel = logger1.MinLevel;
			}

			logger.LoadConfig(new LoggerConfig{MinLevel = minLevel, Name = "MultiLogger"});
			return logger;
		}

		#endregion

        /// <summary>
        /// 加载配置
        /// </summary>
		void LoadConfig()
		{
			var config = LoggingConfig.Instance;
			LoadFormatters(config.Formatters);
			LoadTargets(config.Targets);
			LoadLoggers(config.Loggers);
		}

		private void LoadFormatters(IEnumerable<FormatterConfig> formatterConfigurations)
		{
			foreach (FormatterConfig formatter in formatterConfigurations)
			{
				var instance = (IFormatter) Activator.CreateInstance(formatter.Type);
				instance.LoadConfig(formatter);
				_formatters.Add(instance);
			}
		}

		private void LoadTargets(IEnumerable<TargetConfig> targetConfigurations)
		{
            foreach (TargetConfig targetConfig in targetConfigurations)
            {
                IFormatter formatter = GetFormatter(targetConfig.FormatterName);
                if (formatter == null)
                    throw new InvalidOperationException(string.Format("不能找到格式化器[{0}]", targetConfig.FormatterName));

                var target = (ITarget)Activator.CreateInstance(targetConfig.TargetType, new object[] { formatter });
                target.LoadConfig(targetConfig);
                _targets.Add(target);
            }
		}

		protected void LoadLoggers(IEnumerable<LoggerConfig> loggerConfigurations)
		{
			foreach (LoggerConfig loggerConfig in loggerConfigurations)
			{
				IList<ITarget> targets = new List<ITarget>();
				foreach (string targetName in loggerConfig.TargetNames)
				{
					ITarget target = GetTarget(targetName);
					if (target == null)
						throw new ConfigurationErrorsException(string.Format("不能找到Target[{0}]",targetName));
					targets.Add(target);
				}
				loggerConfig.Targets = targets;

				ILogger logger = new Logger();
				logger.LoadConfig(loggerConfig);
				_loggers.Add(logger);
			}
		}

		private ITarget GetTarget(string name)
		{
			foreach (ITarget target in _targets)
			{
				if (target.Name == name)
					return target;
			}

			return null;
		}

		protected virtual IFormatter GetFormatter(string name)
		{
			foreach (IFormatter formatter in _formatters)
			{
				if (formatter.Name == name)
					return formatter;
			}

			return null;
		}

		private IList<ILogger> FindLoggers(Type classType)
		{
			var loggers = new List<ILogger>();
			foreach (ILogger logger in _loggers)
			{
				if (logger.CanLog(classType.Namespace))
					loggers.Add(logger);
			}
			return loggers;
		}
	}
}