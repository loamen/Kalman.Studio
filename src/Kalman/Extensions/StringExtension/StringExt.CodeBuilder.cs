using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kalman.Utilities;

namespace Kalman.Extensions
{
    public static partial class StringExt
    {
        #region 代码生成器常用的一些字符串处理扩展方法，比如表名前缀的处理

        /// <summary>
        /// 将字符串的首字母转换成大写，比如将user转换成User
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string InitialToUpper(this string s)
        {
            return StringUtil.InitialToUpper(s);
        }

        /// <summary>
        /// 将字符串的首字母转换成小写，比如将User转换成user
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string InitialToLower(this string s)
        {
            return StringUtil.InitialToLower(s);
        }

        /// <summary>
        /// 专用方法，将类似aaa_bbb_ccc_ddd的字符串转换为AaaBbbCccDdd
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string InitialToUpperMulti(this string s)
        {
            return StringUtil.InitialToUpperMulti(s);
        }

        /// <summary>
        /// 移除字符串的前缀，示例："aa_bb_cc_xxx".RemovePrefix("aa_bb_");结果为"cc_xxx";
        /// </summary>
        /// <param name="s"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string RemovePrefix(this string s, string prefix)
        {
            return StringUtil.RemovePrefix(s,prefix);
        }

        /// <summary>
        /// 移除字符串的前缀，默认前缀分隔符是下划线"_"，示例："aa_bb_cc_xxx".RemovePrefix(2);结果为"cc_xxx";
        /// </summary>
        /// <param name="s"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public static string RemovePrefix(this string s, int level)
        {
            return StringUtil.RemovePrefix(s, level);
        }

        /// <summary>
        /// 移除字符串的前缀，示例："aa_bb_cc_xxx".RemovePrefix("_",2);结果为"cc_xxx";
        /// </summary>
        /// <param name="s"></param>
        /// <param name="separator">前缀分隔符，一般为下划线"_"</param>
        /// <param name="level">前缀层次</param>
        /// <returns></returns>
        public static string RemovePrefix(this string s, string separator, int level)
        {
            return StringUtil.RemovePrefix(s, separator, level);
        }

        #endregion
    }
}
