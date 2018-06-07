using System;
using System.Diagnostics;

namespace Kalman.Logging
{
    /// <summary>
    /// 日志记录级别
    /// </summary>
    [Serializable]
    public enum LogLevel
    {
        /// <summary>
        /// 记录用来跟踪程序的执行情况的信息
        /// </summary>
        Trace,

        /// <summary>
        /// 记录用来帮助程序调式的信息
        /// </summary>
        Debug,

        /// <summary>
        /// 记录正常信息
        /// </summary>
        Info,

        /// <summary>
        /// 记录警告信息，可能发生了错误，但是不影响程序执行
        /// </summary>
        Warning,

        /// <summary>
        /// 记录错误信息，程序发生了异常，但是没有必要终止程序
        /// </summary>
        Error,

        /// <summary>
        /// 记录致命错误信息，程序发生了致命异常，必须重新启动程序
        /// </summary>
        Fatal
    }
}
