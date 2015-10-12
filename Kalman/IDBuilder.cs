using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman
{
    /// <summary>
    /// 用来生成主键ID
    /// </summary>
    public static class IDBuilder
    {
        /// <summary>
        /// 根据当前时间来生成
        /// </summary>
        /// <param name="format">日期格式，如：yyyyMMddHHmmssfff</param>
        /// <param name="randomStringLength">后面附加的随机字符串长度</param>
        /// <param name="prefix">前缀</param>
        /// <returns></returns>
        public static string BuildByDateTime(string format, int randomStringLength = 0, string prefix = "")
        {
            StringBuilder sb = new StringBuilder(prefix);

            sb.Append(DateTime.Now.ToString(format));

            if (randomStringLength > 0)
            {
                sb.Append(Utilities.RandomUtil.BuildRandomString(randomStringLength, "0123456789"));
            }

            return sb.ToString();
        }

    }
}
