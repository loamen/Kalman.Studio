using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;

namespace Kalman.Utilities
{
    /// <summary>
    /// 类型转换工具类
    /// </summary>
    public sealed class ConvertUtil
    {
        #region ToByte
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static byte ToByte(object obj, byte defaultValue)
        {
            if (obj == null) return defaultValue;
            return ToByte(obj.ToString(), defaultValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static byte ToByte(string s, byte defaultValue)
        {
            byte b = 0;
            if (byte.TryParse(s, out b))
                return b;
            else
                return defaultValue;
        }
        #endregion

        #region ToNullableByte
        public static byte? ToNullableByte(object obj)
        {
            if (obj == null) return null;
            return ToNullableByte(obj.ToString());
        }

        public static byte? ToNullableByte(string s)
        {
            byte n = 0;
            if (byte.TryParse(s, out n))
                return n;
            else
                return null;
        }
        #endregion

        #region ToSByte
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static sbyte ToByte(object obj, sbyte defaultValue)
        {
            if (obj == null) return defaultValue;
            return ToByte(obj.ToString(), defaultValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static sbyte ToByte(string s, sbyte defaultValue)
        {
            sbyte b = 0;
            if (sbyte.TryParse(s, out b))
                return b;
            else
                return defaultValue;
        }
        #endregion

        #region ToNullableSByte
        public static sbyte? ToNullableSByte(object obj)
        {
            if (obj == null) return null;
            return ToNullableSByte(obj.ToString());
        }

        public static sbyte? ToNullableSByte(string s)
        {
            sbyte n = 0;
            if (sbyte.TryParse(s, out n))
                return n;
            else
                return null;
        }
        #endregion

        #region ToChar
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static char ToByte(object obj, char defaultValue)
        {
            if (obj == null) return defaultValue;
            return ToByte(obj.ToString(), defaultValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static char ToByte(string s, char defaultValue)
        {
            if (string.IsNullOrEmpty(s)) return defaultValue;

            char c = ' ';
            if (char.TryParse(s.Substring(0, 1), out c))
                return c;
            else
                return defaultValue;
        }
        #endregion

        #region ToString
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string ToString(object obj, string defaultValue)
        {
            if (obj == null) return defaultValue;
            return obj.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToString(object obj)
        {
            return ToString(obj, string.Empty);
        }
        #endregion

        #region ToInt32
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToInt32(object obj, int defaultValue)
        {
            if (obj == null) return defaultValue;

            return ToInt32(obj.ToString(), defaultValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToInt32(string s, int defaultValue)
        {
            if (string.IsNullOrEmpty(s)) return defaultValue;
            if (s.ToLower().Trim() == "true") return 1;
            if (s.ToLower().Trim() == "false") return 0;

            int n = 0;
            if (int.TryParse(s, out n))
                return n;
            else
                return defaultValue;
        }
        #endregion

        #region ToNullableInt32
        public static int? ToNullableInt32(object obj)
        {
            if(obj == null)return null;
            return ToNullableInt32(obj.ToString());
        }

        public static int? ToNullableInt32(string s)
        {
            if (string.IsNullOrEmpty(s)) return null;
            if (s.ToLower().Trim() == "true") return 1;
            if (s.ToLower().Trim() == "false") return 0;

            int n = 0;
            if (int.TryParse(s, out n))
                return n;
            else
                return null;
        }
        #endregion

        #region ToInt16
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Int16 ToInt16(object obj, Int16 defaultValue)
        {
            if (obj == null) return defaultValue;

            return ToInt16(obj.ToString(), defaultValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Int16 ToInt16(string s, Int16 defaultValue)
        {
            if (string.IsNullOrEmpty(s)) return defaultValue;
            if (s.ToLower().Trim() == "true") return 1;
            if (s.ToLower().Trim() == "false") return 0;

            Int16 n = 0;
            if (Int16.TryParse(s, out n))
                return n;
            else
                return defaultValue;
        }
        #endregion

        #region ToNullableInt16
        public static Int16? ToNullableInt16(object obj)
        {
            if (obj == null) return null;
            return ToNullableInt16(obj.ToString());
        }

        public static Int16? ToNullableInt16(string s)
        {
            if (string.IsNullOrEmpty(s)) return null;
            if (s.ToLower().Trim() == "true") return 1;
            if (s.ToLower().Trim() == "false") return 0;

            Int16 n = 0;
            if (Int16.TryParse(s, out n))
                return n;
            else
                return null;
        }
        #endregion

        #region ToInt64
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Int64 ToInt64(object obj, Int64 defaultValue)
        {
            if (obj == null) return defaultValue;

            return ToInt64(obj.ToString(), defaultValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Int64 ToInt64(string s, Int64 defaultValue)
        {
            if (string.IsNullOrEmpty(s)) return defaultValue;
            if (s.ToLower().Trim() == "true") return 1;
            if (s.ToLower().Trim() == "false") return 0;

            Int64 n = 0;
            if (Int64.TryParse(s, out n))
                return n;
            else
                return defaultValue;
        }
        #endregion

        #region ToNullableInt64
        public static Int64? ToNullableInt64(object obj)
        {
            if (obj == null) return null;
            return ToNullableInt64(obj.ToString());
        }

        public static Int64? ToNullableInt64(string s)
        {
            if (string.IsNullOrEmpty(s)) return null;
            if (s.ToLower().Trim() == "true") return 1;
            if (s.ToLower().Trim() == "false") return 0;

            Int64 n = 0;
            if (Int64.TryParse(s, out n))
                return n;
            else
                return null;
        }
        #endregion

        #region ToUInt32
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static UInt32 ToUInt32(object obj, UInt32 defaultValue)
        {
            if (obj == null) return defaultValue;

            return ToUInt32(obj.ToString(), defaultValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static UInt32 ToUInt32(string s, UInt32 defaultValue)
        {
            if (string.IsNullOrEmpty(s)) return defaultValue;
            if (s.ToLower().Trim() == "true") return 1;
            if (s.ToLower().Trim() == "false") return 0;

            UInt32 n = 0;
            if (UInt32.TryParse(s, out n))
                return n;
            else
                return defaultValue;
        }
        #endregion

        #region ToNullableUInt32
        public static UInt32? ToNullableUInt32(object obj)
        {
            if (obj == null) return null;
            return ToNullableUInt32(obj.ToString());
        }

        public static UInt32? ToNullableUInt32(string s)
        {
            if (string.IsNullOrEmpty(s)) return null;
            if (s.ToLower().Trim() == "true") return 1;
            if (s.ToLower().Trim() == "false") return 0;

            UInt32 n = 0;
            if (UInt32.TryParse(s, out n))
                return n;
            else
                return null;
        }
        #endregion

        #region ToUInt16
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static UInt16 ToUInt16(object obj, UInt16 defaultValue)
        {
            if (obj == null) return defaultValue;

            return ToUInt16(obj.ToString(), defaultValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static UInt16 ToUInt16(string s, UInt16 defaultValue)
        {
            if (string.IsNullOrEmpty(s)) return defaultValue;
            if (s.ToLower().Trim() == "true") return 1;
            if (s.ToLower().Trim() == "false") return 0;

            UInt16 n = 0;
            if (UInt16.TryParse(s, out n))
                return n;
            else
                return defaultValue;
        }
        #endregion

        #region ToNullableUInt16
        public static UInt16? ToNullableUInt16(object obj)
        {
            if (obj == null) return null;
            return ToNullableUInt16(obj.ToString());
        }

        public static UInt16? ToNullableUInt16(string s)
        {
            if (string.IsNullOrEmpty(s)) return null;
            if (s.ToLower().Trim() == "true") return 1;
            if (s.ToLower().Trim() == "false") return 0;

            UInt16 n = 0;
            if (UInt16.TryParse(s, out n))
                return n;
            else
                return null;
        }
        #endregion

        #region ToUInt64
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static UInt64 ToUInt64(object obj, UInt64 defaultValue)
        {
            if (obj == null) return defaultValue;

            return ToUInt64(obj.ToString(), defaultValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static UInt64 ToUInt64(string s, UInt64 defaultValue)
        {
            if (string.IsNullOrEmpty(s)) return defaultValue;
            if (s.ToLower().Trim() == "true") return 1;
            if (s.ToLower().Trim() == "false") return 0;

            UInt64 n = 0;
            if (UInt64.TryParse(s, out n))
                return n;
            else
                return defaultValue;
        }
        #endregion

        #region ToNullableUInt64
        public static UInt64? ToNullableUInt64(object obj)
        {
            if (obj == null) return null;
            return ToNullableUInt64(obj.ToString());
        }

        public static UInt64? ToNullableUInt64(string s)
        {
            if (string.IsNullOrEmpty(s)) return null;
            if (s.ToLower().Trim() == "true") return 1;
            if (s.ToLower().Trim() == "false") return 0;

            UInt64 n = 0;
            if (UInt64.TryParse(s, out n))
                return n;
            else
                return null;
        }
        #endregion

        #region ToDecimal
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Decimal ToDecimal(object obj, Decimal defaultValue)
        {
            if (obj == null) return defaultValue;
            return ToDecimal(obj.ToString(), defaultValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Decimal ToDecimal(string s, Decimal defaultValue)
        {
            Decimal n = 0;
            if (Decimal.TryParse(s, out n))
                return n;
            else
                return defaultValue;
        }
        #endregion

        #region ToNullableDecimal
        public static Decimal? ToNullableDecimal(object obj)
        {
            if (obj == null) return null;
            return ToNullableDecimal(obj.ToString());
        }

        public static Decimal? ToNullableDecimal(string s)
        {
            Decimal n = 0;
            if (Decimal.TryParse(s, out n))
                return n;
            else
                return null;
        }
        #endregion

        #region ToDouble
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Double ToDouble(object obj, Double defaultValue)
        {
            if (obj == null) return defaultValue;

            return ToDouble(obj.ToString(), defaultValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Double ToDouble(string s, Double defaultValue)
        {
            Double n = 0;
            if (Double.TryParse(s, out n))
                return n;
            else
                return defaultValue;
        }
        #endregion

        #region ToNullableDouble
        public static Double? ToNullableDouble(object obj)
        {
            if (obj == null) return null;
            return ToNullableDouble(obj.ToString());
        }

        public static Double? ToNullableDouble(string s)
        {
            Double n = 0;
            if (Double.TryParse(s, out n))
                return n;
            else
                return null;
        }
        #endregion

        #region ToSingle
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Single ToSingle(object obj, Single defaultValue)
        {
            if (obj == null) return defaultValue;

            return ToSingle(obj.ToString(), defaultValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Single ToSingle(string s, Single defaultValue)
        {
            Single n = 0;
            if (Single.TryParse(s, out n))
                return n;
            else
                return defaultValue;
        }
        #endregion

        #region ToNullableSingle
        public static Single? ToNullableSingle(object obj)
        {
            if (obj == null) return null;
            return ToNullableSingle(obj.ToString());
        }

        public static Single? ToNullableSingle(string s)
        {
            Single n = 0;
            if (Single.TryParse(s, out n))
                return n;
            else
                return null;
        }
        #endregion

        #region ToDateTime
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(string s, DateTime defaultValue)
        {
            DateTime dt = DateTime.MinValue;
            if (DateTime.TryParse(s, out dt))
                return dt;
            else
                return defaultValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(object obj, DateTime defaultValue)
        {
            if (obj == null) return defaultValue;
            return ToDateTime(obj.ToString(), defaultValue);
        }
        #endregion

        #region ToNullableDateTime
        public static DateTime? ToNullableDateTime(object obj)
        {
            if (obj == null) return null;
            return ToNullableDateTime(obj.ToString());
        }

        public static DateTime? ToNullableDateTime(string s)
        {
            DateTime dt = DateTime.MinValue;
            if (DateTime.TryParse(s, out dt))
                return dt;
            else
                return null;
        }
        #endregion

        #region ToBoolean
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool ToBoolean(string s, bool defaultValue)
        {
            if (string.IsNullOrEmpty(s)) return false;
            if (s == "0") return false;
            if (s == "1") return true;
            if (s.ToLower() == "false") return false;
            if (s.ToLower() == "true") return true;

            bool b = false;
            if (bool.TryParse(s, out b))
                return b;
            else
                return defaultValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool ToBoolean(object obj, bool defaultValue)
        {
            if (obj == null) return defaultValue;
            return ToBoolean(obj.ToString(), defaultValue);
        }
        #endregion

        #region ToNullableBoolean
        public static bool? ToNullableBoolean(object obj)
        {
            if (obj == null) return null;
            return ToNullableBoolean(obj.ToString());
        }

        public static bool? ToNullableBoolean(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            if (s == "0") return false;
            if (s == "1") return true;
            if (s.ToLower() == "false") return false;
            if (s.ToLower() == "true") return true;

            bool b = false;
            if (bool.TryParse(s, out b))
                return b;
            else
                return null;
        }
        #endregion

        #region ToObject<T>

        /// <summary>
        /// 将IDataReader转换成对象实体
        /// </summary>
        /// <typeparam name="T">目标对象类型</typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        [Obsolete("负载测试下性能比较差，改用EmitMapper")]
        public static T ToObject<T>(IDataReader reader) where T : class, new()
        {
            Type entityType = typeof(T);
            Dictionary<string, PropertyInfo> dic = new Dictionary<string, PropertyInfo>();
            foreach (PropertyInfo info in entityType.GetProperties())
            {
                dic.Add(info.Name, info);
            }

            string columnName = string.Empty;
            T t = new T();
            foreach (KeyValuePair<string, PropertyInfo> attribute in dic)
            {
                columnName = attribute.Key;
                int filedIndex = 0;
                while (filedIndex < reader.FieldCount)
                {
                    if (reader.GetName(filedIndex) == columnName)
                    {
                        attribute.Value.SetValue(t, reader[filedIndex], null);
                        break;
                    }
                    filedIndex++;
                }
            }
            return t;
        }

        #endregion

        #region ToList<T>

        /// <summary>
        /// 将IDataReader转换成对象实体列表
        /// </summary>
        /// <typeparam name="T">目标对象类型</typeparam>
        /// <param name="reader"></param>
        [Obsolete("负载测试下性能比较差，改用EmitMapper")]
        public static List<T> ToList<T>(IDataReader reader) where T : class, new()
        {
            List<T> list = new List<T>();
            Type entityType = typeof(T);
            Dictionary<string, PropertyInfo> dic = new Dictionary<string, PropertyInfo>();
            foreach (PropertyInfo info in entityType.GetProperties())
            {
                dic.Add(info.Name, info);
            }

            string columnName = string.Empty;
            while (reader.Read())
            {
                T t = new T();
                foreach (KeyValuePair<string, PropertyInfo> attribute in dic)
                {
                    columnName = attribute.Key;
                    int filedIndex = 0;
                    while (filedIndex < reader.FieldCount)
                    {
                        if (reader.GetName(filedIndex) == columnName)
                        {
                            attribute.Value.SetValue(t, reader[filedIndex], null);
                            break;
                        }
                        filedIndex++;
                    }
                }
                list.Add(t);
            }
            return list;
        }

        #endregion
    }
}