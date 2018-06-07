using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;

namespace Kalman.Remoting
{
    /// <summary>
    /// 客户端访问Remoting对象的代理类
    /// </summary>
    public class RemotingClientProxy
    {
        public static readonly RemotingClientProxy Instance = new RemotingClientProxy();
        private RemotingClientProxy()
        {
            HostManager.Instance.PollingHost();

            //注册通道信息
            //BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();
            //BinaryClientFormatterSinkProvider clientProvider = new BinaryClientFormatterSinkProvider();
            //serverProvider.TypeFilterLevel = TypeFilterLevel.Full;
            //IDictionary props = new Hashtable();
            //props["port"] = 0;
            //props["name"] = AppDomain.CurrentDomain.FriendlyName;
            //props["secure"] = false;
            //TcpChannel channel = new TcpChannel(props, clientProvider, serverProvider);

            //ChannelServices.RegisterChannel(channel, false);
        }

        /// <summary>
        /// 获取远程对象实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectUri"></param>
        /// <returns></returns>
        public T GetObject<T>(string objectUri)
        {
            string hostUrl = HostManager.Instance.GetCurrentHostAddress();
            return GetObject<T>(hostUrl, objectUri);
        }

        /// <summary>
        /// 获取远程对象实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hostUrl"></param>
        /// <param name="objectUri"></param>
        /// <returns></returns>
        public T GetObject<T>(string hostUrl,string objectUri)
        {
            string url = string.Format("{0}/{1}", hostUrl.TrimEnd('/'), objectUri);
            return (T)Activator.GetObject(typeof(T), url);
        }

        /// <summary>
        /// 获取远程对象实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetObject<T>()
        {
            string clientName = string.Empty;
            foreach (ClientConfig cc in RemotingConfig.Instance.ClientInfoCollection.Values)
            {
                clientName = cc.Name;
                break;
            }
            return GetObjectByClient<T>(clientName);
        }

        /// <summary>
        /// 获取指定客户端名称的远程对象实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="clientName"></param>
        /// <returns></returns>
        public T GetObjectByClient<T>(string clientName)
        {
            ClientConfig ci = RemotingConfig.Instance.ClientInfoCollection[clientName];
            string hostUrl = HostManager.Instance.GetCurrentHostAddress(clientName);

            if (string.IsNullOrEmpty(hostUrl))
                hostUrl = RemotingConfig.Instance.ClientInfoCollection[clientName].DefaultHost.Url;

            foreach (WellKnownClientTypeEntry entry in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
            {
                if (entry.TypeName == typeof(T).FullName)
                {
                    return GetObject<T>(hostUrl, entry.ObjectUrl);
                }
            }

            //若没有在配置中映射类型的远程对象地址，那么用类型的全名称代替
            return GetObject<T>(hostUrl, typeof(T).FullName);
        }

        /// <summary>
        /// 获取指定客户端名称的远程对象实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="clientName"></param>
        /// <param name="objectUri"></param>
        /// <returns></returns>
        public T GetObjectByClient<T>(string clientName, string objectUri)
        {
            ClientConfig ci = RemotingConfig.Instance.ClientInfoCollection[clientName];
            string hostUrl = HostManager.Instance.GetCurrentHostAddress(clientName);

            if (string.IsNullOrEmpty(hostUrl))
                hostUrl = RemotingConfig.Instance.ClientInfoCollection[clientName].DefaultHost.Url;

            return GetObject<T>(hostUrl, objectUri);
        }
    }
}
