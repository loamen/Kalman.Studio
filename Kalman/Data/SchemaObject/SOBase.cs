using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kalman.Collections;
using System.Runtime.Serialization;

namespace Kalman.Data.SchemaObject
{
    /// <summary>
    /// 架构对象基类
    /// </summary>
    [Serializable]
    public abstract class SOBase
    {
        /// <summary>
        /// 获取所属数据库对象
        /// </summary>
        public abstract SODatabase Database { get; }

        /// <summary>
        /// 用来标识对象的名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 完整名称，比如"[dbo].[user]"
        /// </summary>
        public virtual string FullName { get { return this.Name; } }

        /// <summary>
        /// 对象的注释信息
        /// </summary>
        public virtual string Comment { get; set; }

        [NonSerialized]//避免生成代码出现序列化错误
        SynchronizedDictionary<string, object> extendProperties = new SynchronizedDictionary<string, object>();

        /// <summary>
        /// 设置扩展属性
        /// 若指定属性不存在，则添加该属性，若指定属性已存在，则修改该属性
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public virtual void SetValue(string name, object value)
        {
            if (extendProperties.ContainsKey(name))
            {
                extendProperties[name] = value;
            }
            else
            {
                extendProperties.Add(name, value);
            }
        }

        /// <summary>
        /// 获取扩展属性
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual object GetValue(string name)
        {
            if (extendProperties.ContainsKey(name))
            {
                return extendProperties[name];
            }
            else
            {
                return null;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
