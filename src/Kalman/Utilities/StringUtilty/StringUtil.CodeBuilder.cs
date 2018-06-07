using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class StringUtil
    {
        #region 代码生成器常用的一些字符串处理方法，比如表名前缀的处理

        /*****************************************************************************************************
         * 在数据库设计中，常见的数据库对象的命名形式有一下几种
         * 1、Pascal大小写方式，如：User,UserName
         * 2、加子系统或模块前缀，前缀后面遵循Pascal大小写方式，如：sys_User、sys_base_User
         * 3、全部小写，单词之间用符合隔开，一般用下划线，如：user_name
         * 4、加子系统或模块前缀，前缀后面全部小写，单词之间用符合隔开，一般用下划线，如：sys_user
         * 
         * 在代码生成器中处理数据库对象的代码生成时，为了让生成的对象名称符合编程语言的设计规范，
         * 因此要对数据库对象的名称进行处理，主要是处理前缀和大小写转换
         * 对于第一种命名方式，符合C#命名规范，一般不用处理，如果是其他语言，可能需要将其转换为驼峰命名方式
         * 对于其他三种命名方式，一般是先移除前缀，再对后面的名称做规范化处理
         *****************************************************************************************************/

        /// <summary>
        /// 将字符串的首字母转换成大写，比如将user转换成User
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string InitialToUpper(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            return string.Concat(s.Substring(0, 1).ToUpper(), s.Substring(1));
        }

        /// <summary>
        /// 将字符串的首字母转换成小写，比如将User转换成user
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string InitialToLower(string s)
        {
            return string.Concat(s.Substring(0, 1).ToLower(), s.Substring(1));
        }

        /// <summary>
        /// 专用方法，将类似aaa_bbb_ccc_ddd的字符串转换为AaaBbbCccDdd
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string InitialToUpperMulti(string s)
        {
            string[] ss = s.Split('_');
            StringBuilder sb = new StringBuilder();

            foreach (string item in ss)
            {
                sb.Append(InitialToUpper(item));
            }

            return sb.ToString();
        }

        /// <summary>
        /// 移除字符串的前缀，示例：RemovePrefix("aa_bb_cc_xxx","aa_bb_");结果为"cc_xxx";
        /// </summary>
        /// <param name="s"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string RemovePrefix(string s, string prefix)
        {
            return s.TrimStart(prefix.ToCharArray());
        }

        /// <summary>
        /// 移除字符串的前缀，默认前缀分隔符是下划线"_"，示例：RemovePrefix("aa_bb_cc_xxx",2);结果为"cc_xxx";
        /// </summary>
        /// <param name="s"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public static string RemovePrefix(string s, int level)
        {
            return RemovePrefix(s, "_", level);
        }

        /// <summary>
        /// 移除字符串的前缀，示例：RemovePrefix("aa_bb_cc_xxx","_",2);结果为"cc_xxx";
        /// </summary>
        /// <param name="s"></param>
        /// <param name="separator">前缀分隔符，一般为下划线"_"</param>
        /// <param name="level">前缀层次</param>
        /// <returns></returns>
        public static string RemovePrefix(string s, string separator, int level)
        {
            if (string.IsNullOrEmpty(separator) == false)
            {
                for (int i = 0; i < level; i++)
                {
                    int idx = s.IndexOf(separator) + 1;
                    if (idx == 0) break;
                    s = s.Remove(0, idx);
                }
            }
            return s;
        }

        public static string ToPascalName(string s, string separator)
        {
            string[] ss = s.Split(separator.ToCharArray());
            StringBuilder sb = new StringBuilder();
            foreach (string item in ss)
            {
                if (item.Length > 2)
                {
                    sb.Append(item.Substring(0, 1).ToUpper() + item.Substring(1).ToLower());
                }
                else
                {
                    sb.Append(item.ToUpper());
                }
            }
            return sb.ToString();
        }



        #endregion
    }
}
