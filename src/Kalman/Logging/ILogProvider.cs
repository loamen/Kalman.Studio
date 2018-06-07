namespace Kalman.Logging
{
	/// <summary>
	/// Provides loggers.
	/// </summary>
	public interface ILogProvider
	{
        /// <summary>
        /// 获取日志记录器（根据指定名称）
        /// </summary>
		ILogger GetLogger(string name);

        /// <summary>
        /// 获取日志记录器（为当前类找出匹配的日志记录器）
        /// </summary>
		ILogger GetCurrentClassLogger();
	}
}