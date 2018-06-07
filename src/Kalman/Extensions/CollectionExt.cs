using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kalman.Utilities;
using System.Collections;
using System.Collections.Specialized;

namespace Kalman.Extensions
{
    public static class CollectionExt
    {
        /// <summary>
        /// 将集合对象转换为指定字符分隔的字符串
        /// </summary>
        /// <param name="collection">集合对象</param>
        /// <param name="separator">分隔字符</param>
        /// <returns></returns>
        public static string Implode(this ICollection collection, string separator)
        {
            return CollectionUtil.Implode(collection, separator);
        }

        /// <summary>
        /// 将NameValueCollection集合转换成字符串
        /// </summary>
        /// <param name="nvc">NameValueCollection集合对象</param>
        /// <returns></returns>
        public static string FormatToString(this NameValueCollection nvc)
        {
            return CollectionUtil.FormatToString(nvc);
        }

        /// <summary>
        /// 将NameValueCollection集合转换成字符串
        /// </summary>
        /// <param name="nvc">集合对象</param>
        /// <param name="format">转换格式，如："{0}={1}"，{0}表示Name，{1}表示Value</param>
        /// <param name="separator">分隔符，如：&</param>
        /// <returns></returns>
        public static string FormatToString(this NameValueCollection nvc, string format, string separator)
        {
            return CollectionUtil.FormatToString(nvc, format, separator);
        }

        /// <summary>
        /// 将IDictionary集合转换成字符串
        /// </summary>
        /// <param name="dic">集合对象</param>
        /// <param name="format">转换格式，如："{0}={1}"，{0}表示Key，{1}表示Value</param>
        /// <param name="separator">分隔符，如：&</param>
        /// <returns></returns>
        public static string FormatToString(this IDictionary dic, string format, string separator)
        {
            return CollectionUtil.FormatToString(dic, format, separator);
        }

        /// <summary>
        /// 将IDictionary泛型集合转换成字符串
        /// </summary>
        /// <param name="dic">泛型集合对象</param>
        /// <param name="format">转换格式，如："{0}={1}"，{0}表示Key，{1}表示Value</param>
        /// <param name="separator">分隔符，如：&</param>
        /// <returns></returns>
        public static string FormatToString<TKey, TValue>(this IDictionary<TKey, TValue> dic, string format, string separator)
        {
            return CollectionUtil.FormatToString<TKey, TValue>(dic, format, separator);
        }
    }
}
