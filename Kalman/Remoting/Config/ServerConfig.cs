using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;

namespace Kalman.Remoting
{
    /// <summary>
    /// 服务端配置，每个Remoting宿主目前只允许配置一项
    /// </summary>
    [Serializable]
    public class ServerConfig
    {
        ChannelType _ChannelType = ChannelType.TCP;
        
        /// <summary>
        /// 通道类型，默认为TCP通道
        /// </summary>
        public ChannelType ChannelType
        {
            get { return _ChannelType; }
            set { _ChannelType = value; }
        }

        /// <summary>
        /// 服务器地址（IP、机器名或域名）
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 服务端口
        /// </summary>
        public int Port { get; set; }

        Dictionary<string, WellKnownServiceTypeEntry> _WellKnownObjectCollection = new Dictionary<string, WellKnownServiceTypeEntry>();

        public Dictionary<string, WellKnownServiceTypeEntry> WellKnownObjectCollection
        {
            get { return _WellKnownObjectCollection; }
        }

        /// <summary>
        /// 加入一个WellKnown对象实体
        /// </summary>
        /// <param name="entry"></param>
        public void AddWellKnownObject(WellKnownServiceTypeEntry entry)
        {
            if (_WellKnownObjectCollection.ContainsKey(entry.ObjectUri)) return;
            _WellKnownObjectCollection.Add(entry.ObjectUri, entry);
        }
    }
}
