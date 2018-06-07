namespace Kalman.Logging.Formatters
{
	/// <summary>
    /// LogLevelFormatter
	/// </summary>
	public class LogLevelFormatter : IPartFormatter
	{
		public string Format(LogEntry entry)
		{
            //将LogLevel字符串长度控制为7个字符，不足的左边用空格填充
			return entry.Level.ToString().PadLeft(7, ' ');
		}
	}
}
