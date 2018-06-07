using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.Utilities
{
    /// <summary>
    /// 跟随机数有关的工具类
    /// </summary>
    public sealed class RandomUtil
    {
        /// <summary>
        /// 生成指定长度的随机字符串
        /// </summary>
        /// <param name="len">生成的随机字符串的长度</param>
        /// <param name="dic">产生随机字符串的字典内容，如："0123456789"</param>
        /// <returns></returns>
        public static string BuildRandomString(int len, string dic)
        {
            CheckUtil.ArgumentNotNullOrEmpty(dic, "产生随机字符串的字典内容");
            int count = dic.Length;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < len; i++)
            {
                
                int idx = GetInteger(0, count);
                sb.Append(dic[idx].ToString());
            }

            return sb.ToString();
        }

        #region 从一组对象里面随机获取一个

        /// <summary>
        /// 从一组字符串中随机获取一个
        /// </summary>
        /// <param name="dic">字典</param>
        /// <returns></returns>
        public static string GetRandomString(string[] dic)
        {
            int idx = GetInteger(0, dic.Length);
            return dic[idx];
        }

        /// <summary>
        /// 从一组字符串中随机获取一个
        /// </summary>
        /// <param name="dic">字典</param>
        /// <returns></returns>
        public static string GetRandomString(IList<string> dic)
        {
            int idx = GetInteger(0, dic.Count);
            return dic[idx];
        }

        /// <summary>
        /// 从一组对象里面随机获取一个
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static object GetRandomObject(object[] dic)
        {
            int idx = GetInteger(0, dic.Length);
            return dic[idx];
        }

        /// <summary>
        /// 从一组对象里面随机获取一个
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static object GetRandomObject(IList<object> dic)
        {
            int idx = GetInteger(0, dic.Count);
            return dic[idx];
        }

        /// <summary>
        /// 从一组对象里面随机获取一个
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static T GetRandomObject<T>(IList<T> dic)
        {
            int idx = GetInteger(0, dic.Count);
            return dic[idx];
        }

        #endregion

        /// <summary>
        /// 获取一个随机整数
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int GetInteger(int min, int max)
        {
            //long tick = DateTime.Now.Ticks;
            //Random rnd = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int val = rnd.Next(min, max);
            return val;
        }

        /// <summary>
        /// 获取一个随机小数
        /// </summary>
        /// <returns></returns>
        public static double GetDouble()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            double val = rnd.NextDouble();
            return val;
        }
    }
}
