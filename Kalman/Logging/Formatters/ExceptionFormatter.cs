namespace Kalman.Logging.Formatters
{
	/// <summary>
	/// 异常信息格式化器
	/// </summary>
	public class ExceptionFormatter : IPartFormatter
	{
		public string Format(LogEntry entry)
		{
			return entry.Exception.ToString();
		}
	}
}
