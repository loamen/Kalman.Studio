using System;
using System.Collections.Generic;

namespace Kalman.Logging
{
    /// <summary>
    /// 空日志记录器，不记录任何日志
    /// </summary>
    public class NullLogger : ILogger
    {
    	private string _Name = "NullLogger";
    	private string _NameSpace = string.Empty;
    	private readonly IEnumerable<ITarget> _Targets = new List<ITarget>();

    	/// <summary>
    	/// 获取可以被记录日志的最小级别
    	/// </summary>
    	public LogLevel MinLevel
    	{
			get { return LogLevel.Fatal; }
    	}

    	/// <summary>
    	/// 获取或设置日志记录器的名称
    	/// </summary>
    	public string Name
    	{
    		get { return _Name; }
    		set { _Name = value; }
    	}

    	/// <summary>
    	/// 获取或设置日志记录器所作用的命名空间
    	/// </summary>
    	public string NameSpace
    	{
    		get { return _NameSpace; }
    		set { _NameSpace = value; }
    	}

    	/// <summary>
    	/// 获取日志记录器写入目标集合
    	/// </summary>
    	public IEnumerable<ITarget> Targets
    	{
    		get { return _Targets; }
    	}

    	/// <summary>
        /// 用来跟踪程序的执行情况
        /// </summary>
        public void Trace(string msg)
        {
        }

        /// <summary>
        /// 用来跟踪程序的执行情况
        /// </summary>
        public void Trace(string msg, Exception ex)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void Debug(string msg)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void Debug(string msg, Exception ex)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void Info(string msg)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void Info(string msg, Exception ex)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void Warning(string msg)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void Warning(string msg, Exception ex)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void Error(string msg)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void Error(string msg, Exception ex)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void Fatal(string msg)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void Fatal(string msg, Exception ex)
        {
        }

    	/// <summary>
    	/// 加载配置
    	/// </summary>
    	public void LoadConfig(LoggerConfig config)
    	{
    	}

    	/// <summary>
    	/// 限制日志记录器只能在指定的命名空间记录日志，根据命名空间来判断日志记录器是否能记录日志
    	/// </summary>
    	public bool CanLog(string value)
    	{
            return false;
    	}
    }
}
