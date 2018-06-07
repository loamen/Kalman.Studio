using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Kalman.Logging.Formatters
{
	/// <summary>
	/// 格式化堆栈帧
	/// </summary>
	public class StackTraceFormatter : IPartFormatter
	{
		public StackTraceFormatter()
		{
			SkipCount = 0;
			Count = 3;
			PadLength = 0;
		}

		/// <summary>
		/// 获取或设置跳过的帧数
		/// </summary>
		public int SkipCount { get; set; }

		/// <summary>
		/// 获取或设置包含的帧数
		/// </summary>
		public int Count { get; set; }

		/// <summary>
		/// 获取或设置填充字符的长度
		/// </summary>
		public int PadLength { get; set; }

		public string Format(LogEntry entry)
		{
            StringBuilder sb = new StringBuilder();
			int stop = Math.Min(entry.StackFrames.Length, Count);

			for (int i = SkipCount; i < stop; ++i)
			{
				StackFrame frame = entry.StackFrames[i];
				if (frame == null)
				{
                    sb.Append("UnknownFrame <--");
                    continue;
                }

			    MethodBase method = frame.GetMethod();
                if (method == null)
                {
                    sb.Append("UnknownFrame <--");
                    continue;
                }

			    string typeName = method.ReflectedType == null ? "UnknownType" : method.ReflectedType.Name ?? "UnknownTypeName";
			    string methodName = method.Name ?? "UnknownMethodName";
                sb.Append(string.Format("{0}.{1}<--", typeName, methodName));
			}

            string temp = sb.ToString();
            if (temp.Length > 3)
				temp = temp.Remove(temp.Length - 3);

			return PadLength == 0 ? temp : temp.PadRight(PadLength);
		}
	}
}
