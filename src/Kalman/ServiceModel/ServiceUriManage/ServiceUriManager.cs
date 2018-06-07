using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Kalman.ServiceModel
{
    public sealed class ServiceUriManager
    {
        public static readonly ServiceUriManager Instance = new ServiceUriManager();
        private ServiceUriManager()
        {
        }

        Dictionary<string, string> dic = new Dictionary<string, string>();
        object syncLock = new object();

        /// <summary>
        /// 获取服务URL
        /// </summary>
        /// <param name="clientName">客户端名称，每种WCF数据服务都需要在调用方配置对应的客户端（命名规范：服务顶层命名空间加Client后缀，如：xxx.Client）</param>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public string GetServiceUrl(string clientName, string serviceName)
        {
            ///todo:容灾及负载均衡的具体实现
            return "net.tcp://127.0.0.1:6666/" + serviceName; 
        }


        public void AddUriMapping(string serviceName, string uri)
        {
            lock (syncLock)
            {
                dic.Add(serviceName, uri);
            }
        }

        public void AddUriMapping(string[] serviceNames, string uri)
        {
            foreach (string serviceName in serviceNames)
            {
                AddUriMapping(serviceName, uri);
            }
        }
    }
}
