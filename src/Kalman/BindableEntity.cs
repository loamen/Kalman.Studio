using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;
using System.Collections.Specialized;
using System.Collections;
using Kalman.Resources;
using Kalman.Data;

namespace Kalman
{
    /// <summary>
    /// 获取实体类成员属性值的方法委托
    /// </summary>
    /// <param name="propertyName">成员属性名称</param>
    /// <returns>返回成员属性对应的值</returns>
    public delegate object GetHandler(string propertyName);

    /// <summary>
    /// 可绑定数据的实体
    /// </summary>
    [Serializable]
    public abstract class BindableEntity
    {
        /// <summary>
        /// 获取指定成员属性的值
        /// </summary>
        /// <param name="propertyName">成员属性名称</param>
        /// <returns>返回成员属性对应的值</returns>
        public object GetValue(string propertyName)
        {
            PropertyInfo p = this.GetType().GetProperty(propertyName,
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.IgnoreCase);

            if (p != null)
                return p.GetValue(this, null);
            else
                return null;
        }

        /// <summary>
        /// 设置指定成员属性的值
        /// </summary>
        /// <param name="propertyName">成员属性名称</param>
        /// <param name="value">成员属性值</param>
        public void SetValue(string propertyName, object value)
        {
            PropertyInfo p = this.GetType().GetProperty(propertyName,
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.IgnoreCase);

            if (p != null) p.SetValue(this, value, null);
        }

        /// <summary>
        /// 类型转换
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="obj">待转换对象</param>
        protected T Cast<T>(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                try
                {
                    if (Type.Equals(typeof(T), obj.GetType()))
                        return (T)obj;
                    else
                        return (T)Convert.ChangeType(obj, typeof(T));
                }
                catch
                {
                    //string msg = string.Format("[{0}，类型<{1}>]转换为类型<{2}>失败", obj, obj.GetType().Name, typeof(T).Name);
                    string msg = string.Format(Common.TypeConvertFailed, obj.GetType().Name, typeof(T).Name);
                    throw new InvalidCastException(msg);
                }
            }
            else
                return default(T);
        }

        /// <summary>
        /// 需要在派生类中定义具体的绑定方法
        /// </summary>
        /// <param name="get"></param>
        public abstract void Bind(GetHandler get);

        /// <summary>
        /// 将DataReader对象绑定到实体类
        /// </summary>
        /// <param name="dataReader"></param>
        /// <param name="isClose">绑定操作完成后是否关闭DataReader对象</param>
        /// <returns></returns>
        public virtual bool Bind(IDataReader dataReader, bool isClose)
        {
            DataReaderWrapper wrapper = DataReaderWrapper.New(dataReader);
            if (isClose)
            {
                using (wrapper)
                {
                    if (wrapper.Read())
                    {
                        Bind(delegate(string name)
                        {
                            return wrapper[name];
                        });
                        return true;
                    }
                    else
                        return false;
                }
            }
            else
            {
                Bind(delegate(string name)
                {
                    return wrapper[name];
                });
                return true;
            }
        }

        public virtual void Bind(IDataReader dataReader)
        {
            DataReaderWrapper wrapper = DataReaderWrapper.New(dataReader);
            Bind(delegate(string name)
            {
                return wrapper[name];
            });
        }
        
        /// <summary>
        /// 将DataRow对象绑定到实体类
        /// </summary>
        /// <param name="dataRow"></param>
        public virtual void Bind(DataRow dataRow)
        {
            Bind(delegate(string name)
            {
                int colIndex = dataRow.Table.Columns.IndexOf(name);

                if (colIndex >= 0)
                    return dataRow[colIndex];
                else
                    return null;
            });
        }

        public virtual void Bind(BindableEntity entity)
        {
            Bind(delegate(string name) { return entity.GetValue(name); });
        }

        public virtual void Bind(NameValueCollection nvc)
        {
            Bind(delegate(string name) { return nvc[name]; });
        }
    }
}
