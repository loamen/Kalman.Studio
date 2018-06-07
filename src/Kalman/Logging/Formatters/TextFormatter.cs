namespace Kalman.Logging.Formatters
{
	/// <summary>
	/// 当不包含任何格式化器的时候直接输出文本
	/// </summary>
	public class TextFormatter : IPartFormatter
	{
		public TextFormatter(string text)
		{
			Text = text;
		}
		public TextFormatter()
		{
		}

		/// <summary>
		/// 获取或设置要输出的文本
		/// </summary>
		public string Text { get; set; }

		public string Format(LogEntry entry)
		{
			return Text;
		}
	}
}
