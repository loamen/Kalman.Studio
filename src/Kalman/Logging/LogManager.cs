using System;
using System.Configuration;
using System.Diagnostics;

namespace Kalman.Logging
{
    /// <summary>
    /// 日志管理类
    /// </summary>
    public class LogManager
    {
        private static ILogProvider _provider;
        private static Type _providerAssigner;

        public static readonly NullLogger NullLogger = new NullLogger();

        static LogManager()
        {
        }

        /// <summary>
        /// 获取指定名称的日志记录器
        /// </summary>
        public static ILogger GetLogger(string name)
        {
            if (_provider == null) SetProvider(new LogProvider());
            return _provider.GetLogger(name);
        }

        /// <summary>
        /// 获取日志记录器（为当前类找出匹配的日志记录器）
        /// </summary>
        public static ILogger GetCurrentClassLogger()
        {
            if (_provider == null) SetProvider(new LogProvider());
            return _provider.GetCurrentClassLogger();
        }

        /// <summary>
        /// 设置一个日志记录器提供者
        /// </summary>
        /// <exception cref="InvalidOperationException">日志记录器提供者已经被指定</exception>
        internal static void SetProvider(ILogProvider provider)
        {
            if (_provider != null)
                throw new InvalidOperationException("日志记录器提供者已经被指定给" + _providerAssigner.FullName);

            _providerAssigner = new StackFrame(1).GetMethod().ReflectedType;
            _provider = provider;
        }

        /// <summary>
        /// 用于触发异常抛出事件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="exception"></param>
        internal static void TriggerEvent(object source, Exception ex)
        {
            ExceptionThrown(source, new ExceptionEventArgs {Exception = ex});
        }

        /// <summary>
        /// 日志组件异常抛出事件
        /// </summary>
        public static event EventHandler<ExceptionEventArgs> ExceptionThrown = delegate{};
    }
}
