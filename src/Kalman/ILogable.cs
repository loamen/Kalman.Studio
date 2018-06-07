using System;
using System.Collections.Generic;
using System.Text;

namespace Kalman
{
    /// <summary>
    /// 日志处理委托
    /// </summary>
    /// <param name="msg">日志消息</param>
    public delegate void LogHandler(string msg);

    /// <summary>
    /// 需要记录日志的类必须继承该接口
    /// </summary>
    public interface ILogable
    {
        /// <summary>
        /// 日志事件
        /// </summary>
        event LogHandler OnLog;
    }
}
