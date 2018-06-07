using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;

namespace Kalman.Remoting
{
    /// <summary>
    /// 客户端配置，每个Client对应一个目标Host
    /// </summary>
    [Serializable]
    public class ClientConfig
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        
        Host _DefaultHost;
        /// <summary>
        /// 默认Remoting宿主
        /// </summary>
        public Host DefaultHost
        {
            get { return _DefaultHost; }
            set { _DefaultHost = value; }
        }

        bool _LBEnabled = false;
        /// <summary>
        /// 获取或设置是否启用负载均衡
        /// </summary>
        public bool LBEnabled
        {
            get { return _LBEnabled; }
            set { _LBEnabled = value; }
        }

        int _PollingInterval = 1;
        /// <summary>
        /// 获取或设置Remoting宿主轮询时间间隔
        /// </summary>
        public int PollingInterval
        {
            get { return _PollingInterval; }
            set { _PollingInterval = value; }
        }

        Dictionary<string, Host> _HostCollection = new Dictionary<string, Host>();
        //Dictionary<string, WellKnownClientObject> _WellKnownObjectCollection = new Dictionary<string, WellKnownClientObject>();

        /// <summary>
        /// Remoting宿主集合
        /// </summary>
        public Dictionary<string, Host> HostCollection
        {
            get { return _HostCollection; }
        }

        /// <summary>
        /// 加入一个Remoting宿主
        /// </summary>
        /// <param name="host"></param>
        public void AddHost(Host host)
        {
            if (_HostCollection.ContainsKey(host.Name) == false)
            {
                _HostCollection.Add(host.Name, host);
            }
        }

        ///// <summary>
        ///// WellKnown对象集合
        ///// </summary>
        //public Dictionary<string, WellKnownClientObject> WellKnownObjectCollection
        //{
        //    get { return _WellKnownObjectCollection; }
        //}

        ///// <summary>
        ///// 加入一个WellKnown对象
        ///// </summary>
        ///// <param name="entry"></param>
        //public void AddWellKnownObject(WellKnownClientObject entry)
        //{
        //    if (_WellKnownObjectCollection.ContainsKey(entry.ObjectUri) == false)
        //    {
        //        _WellKnownObjectCollection.Add(entry.ObjectUri, entry);
        //    }
        //}
    }
}
