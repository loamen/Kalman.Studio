using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Kalman.Utilities;

namespace Kalman.Extensions
{
    /// <summary>
    /// Html相关的字符串处理方法
    /// </summary>
    public static partial class StringExt
    {
        /// <summary>
        /// 对Html文本字符串进行编码
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string HtmlEncode(this string s)
        {
            return StringUtil.HtmlEncode(s);
        }

        /// <summary>
        /// 对Html文本字符串进行解码
        /// </summary>
        public static string HtmlDecode(this string s)
        {
            return StringUtil.HtmlDecode(s);
        }

        /// <summary>
        /// 移除字符串中所有的HTML标签
        /// </summary>
        public static string RemoveHtml(this string s)
        {
            return StringUtil.RemoveHtml(s);
        }

        /// <summary>
        /// 移除字符串中在指定集合中所包含的HTML标签，标签名称不区分大小写
        /// </summary>
        /// <param name="s"></param>
        /// <param name="removeTags"></param>
        /// <returns></returns>
        public static string RemoveHtml(this string s, IList<string> removeTags)
        {
            return StringUtil.RemoveHtml(s, removeTags);
        }

        /// <summary>
        /// 移除字符串不安全的HTML代码，例如"script,iframe"等
        /// </summary>
        public static string RemoveUnsafeHtml(this string s)
        {
            return StringUtil.RemoveUnsafeHtml(s);
        }
    }
}
