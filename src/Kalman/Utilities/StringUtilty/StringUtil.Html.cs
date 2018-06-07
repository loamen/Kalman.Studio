using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Kalman.Utilities
{
    public static partial class StringUtil
    {
        /// <summary>
        /// 对Html文本字符串进行编码
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string HtmlEncode(string s)
        {
            s = s.Replace("&", "&amp;");
            //s = s.Replace("'", "''");
            s = s.Replace("'", "&#039;");
            s = s.Replace("\"", "&quot;");
            s = s.Replace(" ", "&nbsp;");
            s = s.Replace("<", "&lt;");
            s = s.Replace(">", "&gt;");
            s = s.Replace("\n", "<br>");
            return s;
        }

        /// <summary>
        /// 对Html文本字符串进行解码
        /// </summary>
        public static string HtmlDecode(string s)
        {
            s = s.Replace("&amp;", "&");
            s = s.Replace("&#039;", "'");
            s = s.Replace("&quot;", "\"");
            s = s.Replace("&nbsp;", " ");
            s = s.Replace("&gt;", ">");
            s = s.Replace("&lt;", "<");
            s = s.Replace("<br>", "\n");

            return s;
        }

        /// <summary>
        /// 移除字符串中所有的HTML标签
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string RemoveHtml(string s)
        {
            return RemoveHtmlInternal(s, null);
        }

        /// <summary>
        /// 移除字符串中在指定集合中所包含的HTML标签，标签名称不区分大小写
        /// </summary>
        /// <param name="s"></param>
        /// <param name="removeTags"></param>
        /// <returns></returns>
        public static string RemoveHtml(string s, IList<string> removeTags)
        {
            if (removeTags == null)
                throw new ArgumentNullException("removeTags");

            return RemoveHtmlInternal(s, removeTags);
        }

        private static string RemoveHtmlInternal(string s, IList<string> removeTags)
        {
            List<string> removeTagsUpper = null;

            if (removeTags != null)
            {
                removeTagsUpper = new List<string>(removeTags.Count);

                foreach (string tag in removeTags)
                {
                    removeTagsUpper.Add(tag.ToUpperInvariant());
                }
            }

            Regex anyTag = new Regex(@"<[/]{0,1}\s*(?<tag>\w*)\s*(?<attr>.*?=['""].*?[""'])*?\s*[/]{0,1}>", RegexOptions.Compiled);

            return anyTag.Replace(s, delegate(Match match)
            {
                string tag = match.Groups["tag"].Value.ToUpperInvariant();

                if (removeTagsUpper == null)
                    return string.Empty;
                else if (removeTagsUpper.Contains(tag))
                    return string.Empty;
                else
                    return match.Value;
            });
        }

        /// <summary>
        /// 移除字符串不安全的HTML代码，例如"script,iframe"等
        /// </summary>
        public static string RemoveUnsafeHtml(string s)
        {
            StringBuilder builder = new StringBuilder(s);
            Regex regex = new Regex(@"<script[\s\S]*?>[\s\S]*?</script>", RegexOptions.IgnoreCase);
            foreach (Match match in regex.Matches(builder.ToString()))
            {
                builder.Replace(match.Value, "");
            }
            regex = new Regex(@"<script[\s\S]*?/>", RegexOptions.IgnoreCase);
            foreach (Match match2 in regex.Matches(builder.ToString()))
            {
                builder.Replace(match2.Value, "");
            }
            regex = new Regex(@"<iframe[\s\S]*?/>", RegexOptions.IgnoreCase);
            foreach (Match match3 in regex.Matches(builder.ToString()))
            {
                builder.Replace(match3.Value, "");
            }
            regex = new Regex(@"<iframe[\s\S]*?>[\s\S]*?</iframe>", RegexOptions.IgnoreCase);
            foreach (Match match4 in regex.Matches(builder.ToString()))
            {
                builder.Replace(match4.Value, "");
            }
            return builder.ToString();
        }
    }
}
