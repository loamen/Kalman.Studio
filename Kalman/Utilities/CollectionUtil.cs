using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

namespace Kalman.Utilities
{
    /// <summary>
    /// 集合工具类
    /// </summary>
    public static class CollectionUtil
    {
        /// <summary>
        /// 将集合对象转换为指定字符分隔的字符串
        /// </summary>
        /// <param name="collection">集合对象</param>
        /// <param name="separator">分隔字符</param>
        /// <returns></returns>
        public static string Implode(ICollection collection, string separator)
        {
            if (collection == null || collection.Count == 0) return string.Empty;
            if (separator == null) separator = string.Empty;
            
            StringBuilder sb = new StringBuilder();
            foreach (object item in collection)
            {
                sb.Append(item.ToString() + separator);
            }

            string result = sb.ToString().TrimEnd(separator.ToCharArray());
            return result;
        }

        /// <summary>
        /// 将NameValueCollection集合转换成字符串
        /// </summary>
        /// <param name="nvc">NameValueCollection集合对象</param>
        /// <returns></returns>
        public static string FormatToString(NameValueCollection nvc)
        {
            return FormatToString(nvc, "{0}={1}", "&");
        }

        /// <summary>
        /// 将NameValueCollection集合转换成字符串
        /// </summary>
        /// <param name="nvc">集合对象</param>
        /// <param name="format">转换格式，如："{0}={1}"，{0}表示Name，{1}表示Value</param>
        /// <param name="separator">分隔符，如：&</param>
        /// <returns></returns>
        public static string FormatToString(NameValueCollection nvc, string format, string separator)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string key in nvc.Keys)
            {
                sb.AppendFormat(format, key, nvc[key]);
                sb.Append(separator);
            }

            string s = sb.ToString().TrimEnd(separator.ToCharArray());
            return s;
        }

        /// <summary>
        /// 将IDictionary集合转换成字符串
        /// </summary>
        /// <param name="dic">集合对象</param>
        /// <param name="format">转换格式，如："{0}={1}"，{0}表示Key，{1}表示Value</param>
        /// <param name="separator">分隔符，如：&</param>
        /// <returns></returns>
        public static string FormatToString(IDictionary dic, string format, string separator)
        {
            StringBuilder sb = new StringBuilder();

            foreach (DictionaryEntry item in dic)
            {
                sb.AppendFormat(format, item.Key, item.Value);
                sb.Append(separator);
            }

            string s = sb.ToString().TrimEnd(separator.ToCharArray());
            return s;
        }

        /// <summary>
        /// 将IDictionary泛型集合转换成字符串
        /// </summary>
        /// <param name="dic">泛型集合对象</param>
        /// <param name="format">转换格式，如："{0}={1}"，{0}表示Key，{1}表示Value</param>
        /// <param name="separator">分隔符，如：&</param>
        /// <returns></returns>
        public static string FormatToString<TKey, TValue>(IDictionary<TKey, TValue> dic, string format, string separator)
        {
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<TKey,TValue> item in dic)
            {
                sb.AppendFormat(format, item.Key, item.Value);
                sb.Append(separator);
            }

            string s = sb.ToString().TrimEnd(separator.ToCharArray());
            return s;
        }
    }
}
