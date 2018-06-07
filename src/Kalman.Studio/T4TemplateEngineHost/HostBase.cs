using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kalman.Utilities;

namespace Kalman.Studio.T4TemplateEngineHost
{
    /// <summary>
    /// T4模板引擎基类
    /// </summary>
    [Serializable]
    public abstract class HostBase
    {
        IList<string> assemblyLocationList = new List<string>(); //程序集的引用路径列表
        IList<string> namespaceList = new List<string>();        //命名空间列表

        public HostBase()
        {
            AddAssemblyLocation(typeof(Kalman.Data.DbSchema).Assembly.Location);    //Kalman.dll
            AddAssemblyLocation(typeof(HostBase).Assembly.Location);    //Kalman.Studio.exe

            AddAssemblyLocation(typeof(System.AppDomain).Assembly.Location);    //mscorlib.dll
            AddAssemblyLocation(typeof(System.Uri).Assembly.Location);  //System.dll
            AddAssemblyLocation(typeof(System.Data.DbType).Assembly.Location);  //System.Data.dll
            AddAssemblyLocation(typeof(System.Linq.Queryable).Assembly.Location);   //System.Core.dll

            AddNamespace("Kalman");
            AddNamespace("Kalman.Extensions");
            AddNamespace("Kalman.Data");
            AddNamespace("Kalman.Data.SchemaObject");
            AddNamespace("Kalman.Data.DbSchemaProvider");
            AddNamespace("Kalman.Data.DbProvider");
            AddNamespace("Kalman.Utilities");

            AddNamespace("Kalman.Studio.T4TemplateEngineHost");

            AddNamespace("System");
            AddNamespace("System.IO");
            AddNamespace("System.Xml");
            AddNamespace("System.Linq");
            AddNamespace("System.Text");
            AddNamespace("System.Data");
            AddNamespace("System.Data.Common");
            AddNamespace("System.Collections");
            AddNamespace("System.Collections.Generic");
            AddNamespace("System.Collections.Specialized");
        }

        /// <summary>
        /// 获取程序集的引用路径列表
        /// </summary>
        public IList<string> AssemblyLocationList
        {
            get { return assemblyLocationList;}
        }

        /// <summary>
        /// 添加一个程序集的引用路径，也可以在tt模板中通过assembly指令声明，如：&lt;#@ assembly name="System.dll" #&gt;
        /// </summary>
        /// <param name="assemblyLocation"></param>
        public void AddAssemblyLocation(string assemblyLocation)
        {
            if (assemblyLocationList.Contains(assemblyLocation)) return;
            assemblyLocationList.Add(assemblyLocation);
        }

        /// <summary>
        /// 获取导入的命名空间列表
        /// </summary>
        public IList<string> NamespaceList
        {
            get { return namespaceList; }
        }

        /// <summary>
        /// 添加一个导入的命名空间名称，也可以在tt模板中通过namespace指令声明，如&lt;#@ import namespace="System" #&gt;
        /// </summary>
        /// <param name="namespaceName"></param>
        public void AddNamespace(string namespaceName)
        {
            if (namespaceList.Contains(namespaceName)) return;
            namespaceList.Add(namespaceName);
        }

        #region ExtendProperties

        Dictionary<string, object> _ExtendProperties = new Dictionary<string, object>();

        /// <summary>
        /// 设置扩展属性值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetValue(string key, object value)
        {
            if (_ExtendProperties.ContainsKey(key))
            {
                _ExtendProperties[key] = value;
            }
            else
            {
                _ExtendProperties.Add(key, value);
            }
        }

        /// <summary>
        /// 获取扩展属性值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object GetValue(string key)
        {
            if (_ExtendProperties.ContainsKey(key))
            {
                return _ExtendProperties[key];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取扩展属性值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetString(string key)
        {
            object obj = GetValue(key);
            if (obj == null) return string.Empty;
            else return obj.ToString();
        }

        /// <summary>
        /// 获取扩展属性值
        /// </summary>
        public int GetInt32(string key)
        {
            return ConvertUtil.ToInt32(GetValue(key), 0);
        }

        /// <summary>
        /// 获取扩展属性值
        /// </summary>
        public bool GetBoolean(string key)
        {
            return ConvertUtil.ToBoolean(GetValue(key), false);
        }

        /// <summary>
        /// 获取扩展属性值
        /// </summary>
        public DateTime GetDateTime(string key)
        {
            return ConvertUtil.ToDateTime(GetValue(key), DateTime.MinValue);
        }

        /// <summary>
        /// 获取扩展属性值
        /// </summary>
        public decimal GetDecimal(string key)
        {
            return ConvertUtil.ToDecimal(GetValue(key), decimal.Zero);
        }

        #endregion
    }
}
