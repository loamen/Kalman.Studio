using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Xml;
using Kalman.Utilities;

namespace Kalman.Logging.Targets
{
    /// <summary>
    /// 将日志输出到文件
    /// </summary>
    public class FileTarget : ITarget
    {
		private TargetConfig _Config;
		private readonly Queue<LogEntry> _Queue = new Queue<LogEntry>();
		private bool _IsWriting;

        public FileTarget(IFormatter formatter)
        {
            CheckUtil.ArgumentNotNull(formatter, "formatter");

            Formatter = formatter;
            DaysToKeepLogs = 0;

            //路径规则相关
            YearInPath = false;
            MonthInPath = true;
            DayInPath = false;
            LoggerNameInPath = false;
            LogLevelInPath = false;

            //文件名规则相关，优先级Hour>Day>Month>Year，其他附加在日期时间后面
            WritePerYear = false;
            WritePerMonth = false;
            WritePerDay = true;
            WritePerHour = false;
            LoggerNameInFilename = false;
            LogLevelInFilename = false;
        }

        /// <summary>
        /// 获取或设置Target名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置格式化器
        /// </summary>
        public IFormatter Formatter { get; set; }


        #region 可配置属性
        /// <summary>
        /// 获取或设置日志文件名，如果配置了这个参数，则文件名规则失效
        /// </summary>
        public string FileName { get; set; }

    	/// <summary>
    	/// 获取或设置日志保留天数（0表示永久保留）
    	/// </summary>
        public int DaysToKeepLogs { get; set; }

        /// <summary>
        /// 年份作为写日志路径的一部分(yyyy)
        /// </summary>
        public bool YearInPath { get; set; }

        /// <summary>
        /// 月份作为写日志路径的一部分(yyyyMM)，默认true
        /// </summary>
        public bool MonthInPath { get; set; }

        /// <summary>
        /// 日期作为写日志路径的一部分(yyyyMMdd)
        /// </summary>
        public bool DayInPath { get; set; }

        /// <summary>
        /// 是否将日志记录器名称作为写日志路径的一部分
        /// </summary>
        public bool LoggerNameInPath { get; set; }

        /// <summary>
        /// 是否将日志级别作为写日志路径的一部分
        /// </summary>
        public bool LogLevelInPath { get; set; }
        
        /// <summary>
    	/// 获取或设置是否直接写日志，不通过队列和线程池
    	/// </summary>
    	public bool WriteDirectly { get; set; }

        /// <summary>
        /// 每年写一个日志文件，文件名包含年份(yyyy)
        /// </summary>
        public bool WritePerYear { get; set; }

        /// <summary>
        /// 每月写一个日志文件，文件名包含月份(yyyyMM)
        /// </summary>
        public bool WritePerMonth { get; set; }

        /// <summary>
        /// 每天写一个日志文件，文件名包含日期(yyyyMMdd)，默认true
        /// </summary>
        public bool WritePerDay { get; set; }

        /// <summary>
        /// 每小时写一个日志文件，文件名包含小时(yyyyMMdd_HH)
        /// </summary>
        public bool WritePerHour { get; set; }

        /// <summary>
        /// 是否将日志记录器名称作为日志文件名的一部分，文件名包含日志记录器名称
        /// </summary>
        public bool LoggerNameInFilename { get; set; }

        /// <summary>
        /// 是否将日志级别作为日志文件名的一部分，文件名包含日志级别
        /// </summary>
        public bool LogLevelInFilename { get; set; }

        private string _BaseDirectory = string.Empty;
    	/// <summary>
    	/// 获取写日志的基础目录
    	/// </summary>
    	public string BaseDirectory
    	{
            get
            {
                if (_BaseDirectory == string.Empty || Directory.Exists(_BaseDirectory) == false)
                {
                    string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log");
                    if (Directory.Exists(dir) == false) Directory.CreateDirectory(dir);
                    return dir;
                }
                else
                {
                    return _BaseDirectory;
                }
            }
        }

        #endregion

        #region 加载配置
        /// <summary>
        /// 加载配置
        /// </summary>
        /// <param name="config"></param>
        /// <exception cref="InvalidOperationException">配置已经被加载</exception>
        /// <exception cref="ArgumentNullException">参数<c>config</c> 不能为空</exception>
        /// <exception cref="ConfigurationErrorsException">配置无法正确加载</exception>
		public void LoadConfig(TargetConfig config)
    	{
            CheckUtil.ArgumentNotNull(config,"config");

			_Config = config;
    		Name = _Config.Name;
			foreach (XmlNode node in config.ChildConfig)
			{
				try
				{
					if (node.ChildNodes.Count != 1)
						throw new ConfigurationErrorsException("FileTarget子元素 " + node.Name + "只能为单值元素");

					switch (node.Name)
					{
                        case "daysToKeepLogs":
                            DaysToKeepLogs = int.Parse(node.FirstChild.Value);
                            break;
						case "writeDirectly":
							WriteDirectly = node.FirstChild.Value.ToLower() == "true";
                            break;
                        case "baseDirectory":
                            _BaseDirectory = node.FirstChild.Value;
							break;
                        case "yearInPath":
                            YearInPath = node.FirstChild.Value.ToLower() == "true";
                            break;
                        case "monthInPath":
                            MonthInPath = node.FirstChild.Value.ToLower() == "true";
                            break;
                        case "dayInPath":
                            DayInPath = node.FirstChild.Value.ToLower() == "true";
                            break;
                        case "loggerNameInPath":
                            LoggerNameInPath = node.FirstChild.Value.ToLower() == "true";
                            break;
                        case "logLevelInPath":
                            LogLevelInPath = node.FirstChild.Value.ToLower() == "true";
                            break;
                        case "fileName":
                            FileName = node.FirstChild.Value;
                            break;
                        case "writePerYear":
                            WritePerYear = node.FirstChild.Value.ToLower() == "true";
                            break;
                        case "writePerMonth":
                            WritePerMonth = node.FirstChild.Value.ToLower() == "true";
                            break;
                        case "writePerDay":
                            WritePerDay = node.FirstChild.Value.ToLower() == "true";
                            break;
                        case "writePerHour":
                            WritePerHour = node.FirstChild.Value.ToLower() == "true";
                            break;
                        case "loggerNameInFilename":
                            LoggerNameInFilename = node.FirstChild.Value.ToLower() == "true";
                            break;
                        case "logLevelInFilename":
                            LogLevelInFilename = node.FirstChild.Value.ToLower() == "true";
                            break;
                        default: break;
					}
				}
				catch (FormatException ex)
				{
					throw new ConfigurationErrorsException("解析FileTarget子元素值 '" + node.FirstChild.Value + "'失败", ex);
				}
			}

            try
            {
                if (string.IsNullOrEmpty(_BaseDirectory) == false && Directory.Exists(_BaseDirectory) == false)
                {
                    Directory.CreateDirectory(_BaseDirectory);
                }
            }
            catch (Exception ex)
            {
                LogManager.TriggerEvent(this, ex);
            }
        }
        #endregion

        #region 写文件日志
        /// <summary>
        /// 写日志实体
        /// </summary>
		public void Write(LogEntry logEntry)
		{
			if (WriteDirectly)
			{
				lock (_Queue)
					WriteLog(logEntry);
				return;
			}

			lock (_Queue)
			{
				_Queue.Enqueue(logEntry);
				if (_IsWriting) return;

				System.Threading.ThreadPool.QueueUserWorkItem(DoWrite);
				_IsWriting = true;
			}
		}

		private void DoWrite(object state)
		{
			LogEntry entry;
			lock (_Queue)
				entry = _Queue.Dequeue();

			WriteLog(entry);

			lock (_Queue)
			{
				if (_Queue.Count == 0)
				{
					_IsWriting = false;
					return;
				}
			}

			DoWrite(null);
		}

    	private void WriteLog(LogEntry entry)
    	{
    		try
    		{
                string path = this.BaseDirectory;
    			string msg = Formatter.Format(entry);
                
                if(YearInPath) path = Path.Combine(path, DateTime.Now.ToString("yyyy"));
                if (MonthInPath) path = Path.Combine(path, DateTime.Now.ToString("yyyyMM"));
                if (DayInPath) path = Path.Combine(path, DateTime.Now.ToString("yyyyMMdd"));
                if (LoggerNameInPath) path = Path.Combine(path, entry.Logger.Name);
                if (LogLevelInPath) path = Path.Combine(path, entry.Level.ToString());

                if (Directory.Exists(path) == false) Directory.CreateDirectory(path);

                string filename = GenerateFilename(entry);
                path = Path.Combine(path, filename);
                File.AppendAllText(path, msg + Environment.NewLine);
    		}
    		catch (Exception ex)
    		{
    			LogManager.TriggerEvent(this, ex);
    		}
        }

        /// <summary>
        /// 按规则生成日志文件名，不包含路径
        /// </summary>
        /// <returns></returns>
        private string GenerateFilename(LogEntry entry)
        {
            string filename = FileName;

            if (string.IsNullOrEmpty(filename))
            {
                if (WritePerYear) filename = DateTime.Now.ToString("yyyy");
                if (WritePerMonth) filename = DateTime.Now.ToString("yyyyMM");
                if (WritePerDay) filename = DateTime.Now.ToString("yyyyMMdd");
                if (WritePerHour) filename = DateTime.Now.ToString("yyyyMMdd_HH");

                if (LoggerNameInFilename) filename = string.Format("{0}_{1}", filename, entry.Logger.Name);
                if(LogLevelInFilename) filename = string.Format("{0}_{1}", filename, entry.Level.ToString());

                filename = filename + ".log";
            }

            return filename;
        }
        #endregion
    }
}
