using System;

namespace Kalman.Logging
{
    /// <summary>
    /// 日志组件抛出异常的时候使用
    /// </summary>
    public class ExceptionEventArgs : EventArgs
    {
        /// <summary>
        /// 获取或设置抛出的异常
        /// </summary>
        public Exception Exception { get; set; }
    }
}
