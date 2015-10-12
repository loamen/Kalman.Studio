namespace Kalman.Logging.Formatters
{
	public class ThreadIdFormatter : IPartFormatter
	{
		public string Format(LogEntry entry)
		{
            //限定线程ID的位数，不足左边用0填充
			return entry.ThreadID.ToString("000");
		}
	}
}
