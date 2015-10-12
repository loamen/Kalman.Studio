using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Kalman.Extensions
{
    public static class ObjectExt
    {
        public static string ToString(this object obj, string defaultValue)
        {
            if (obj == null) return defaultValue;
            else return obj.ToString();
        }

        /// <summary>
        /// 将对象属性数据保存到字典
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Dictionary<string, object> ToDictionary(this object value)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            PropertyInfo[] props = value.GetType().GetProperties();
            foreach (PropertyInfo pi in props)
            {
                try
                {
                    result.Add(pi.Name, pi.GetValue(value, null));
                }
                catch { }
            }
            return result;
        }

        /// <summary>
        /// 从字典中还原对象属性数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="settings"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static T FromDictionary<T>(this Dictionary<string, object> settings, T item) where T : class
        {
            PropertyInfo[] props = item.GetType().GetProperties();
            FieldInfo[] fields = item.GetType().GetFields();
            foreach (PropertyInfo pi in props)
            {
                if (settings.ContainsKey(pi.Name))
                {
                    if (pi.CanWrite)
                        pi.SetValue(item, settings[pi.Name], null);
                }
            }
            return item;
        }

        /// <summary>
        /// 将对象属性数据拷贝到另一个同类型对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="From"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static T CopyTo<T>(this object From, T to) where T : class
        {
            Type t = From.GetType();
            var settings = From.ToDictionary();

            to = settings.FromDictionary(to);
            return to;
        }

        /// <summary>
        /// 类型转换
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T ConvertType<T>(this object obj)
        {
            if (typeof(T) == typeof(Guid))
            {
                if (obj == null)
                {
                    return (T)((object)Guid.Empty);
                }
                return (T)((object)new Guid(obj.ToString()));
            }
            if (obj is DBNull || obj == null)
            {
                return default(T);
            }
            return (T)Convert.ChangeType(obj, typeof(T));
        }

        /// <summary>
        /// 实现对象的深拷贝
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T DeepClone<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, obj);

                ms.Position = 0;
                return (T)bf.Deserialize(ms);
            }
        }
    }
}
