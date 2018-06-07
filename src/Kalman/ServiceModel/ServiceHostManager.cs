using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Xml.Serialization;

namespace Kalman.ServiceModel
{
    /// <summary>
    /// WCF服务宿主管理类
    /// </summary>
    public sealed class ServiceHostManager
    {
        public static readonly ServiceHostManager Instance = new ServiceHostManager();

        List<ServiceHost> _HostList;

        private ServiceHostManager()
        {
            _HostList = new List<ServiceHost>();
        }

        /// <summary>
        /// 发布WCF服务组件
        /// </summary>
        /// <param name="type"></param>
        public void Open(Type type)
        {
            ServiceHost host = new ServiceHost(type);
            host.Open();
            _HostList.Add(host);
        }

        public void Dispose()
        {
            foreach (ServiceHost  host in _HostList)
            {
                try
                {
                    if (host.State == CommunicationState.Opened)
                        host.Close();
                }
                catch
                {
                    host.Abort();
                }
            }
        }
    }
}
