using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading;
using System.ServiceModel.Channels;

namespace Kalman.ServiceModel
{
    /// <summary>
    /// WCF客户端代理类
    /// </summary>
    public static class WcfClientProxy
    {
        /// <summary>
        /// 创建一个客户端代理，不需要配置，默认使用NetTcpBinding
        /// </summary>
        /// <typeparam name="I">服务契约接口类型</typeparam>
        /// <param name="uri">服务地址</param>
        /// <returns></returns>
        public static I Create<I>(string uri)
        {
            NetTcpBinding binding = new NetTcpBinding();
            EndpointAddress ea = new EndpointAddress(new Uri(uri));
            return new ChannelFactory<I>(binding, ea).CreateChannel();
        }

        /// <summary>
        /// 创建一个客户端代理，不需要配置，默认使用NetTcpBinding
        /// </summary>
        /// <typeparam name="I">服务契约接口类型</typeparam>
        /// <param name="ea">端点地址</param>
        /// <returns></returns>
        public static I Create<I>(EndpointAddress ea)
        {
            NetTcpBinding binding = new NetTcpBinding();
            return new ChannelFactory<I>(binding, ea).CreateChannel();
        }

        /// <summary>
        /// 创建一个客户端代理，不需要配置
        /// </summary>
        /// <typeparam name="I">服务契约接口类型</typeparam>
        /// <param name="uri">服务地址</param>
        /// <param name="binding">通道绑定类型（BasicHttpBinding|NetTcpBinding|CustomBinding|NetNamedPipeBinding|NetPeerTcpBinding|WebHttpBinding|WSDualHttpBinding）</param>
        /// <returns></returns>
        public static I Create<I>(Binding binding, string uri)
        {
            EndpointAddress ea = new EndpointAddress(new Uri(uri));
            return new ChannelFactory<I>(binding, ea).CreateChannel();
        }

        /// <summary>
        /// 创建一个客户端代理，不需要配置
        /// </summary>
        /// <typeparam name="I">服务契约接口类型</typeparam>
        /// <param name="binding">通道绑定类型（BasicHttpBinding|NetTcpBinding|CustomBinding|NetNamedPipeBinding|NetPeerTcpBinding|WebHttpBinding|WSDualHttpBinding）</param>
        /// <param name="ea">端点地址</param>
        /// <returns></returns>
        public static I Create<I>(Binding binding, EndpointAddress ea)
        {
            return new ChannelFactory<I>(binding, ea).CreateChannel();
        }

        /// <summary>
        /// 创建一个客户端代理，需配置端点并指定名称
        /// </summary>
        /// <typeparam name="I">服务契约接口类型</typeparam>
        /// <param name="endPointConfigurationName">端点名称</param>
        /// <returns></returns>
        public static I CreateByConfig<I>(string endPointConfigurationName)
        {
            return new ChannelFactory<I>(endPointConfigurationName).CreateChannel();
        }

        /// <summary>
        /// 创建一个客户端代理，需配置端点并指定名称
        /// </summary>
        /// <typeparam name="I">服务契约接口类型</typeparam>
        /// <param name="uri">服务地址</param>
        /// <param name="endPointConfigurationName">端点名称</param>
        /// <returns></returns>
        public static I CreateByConfig<I>(string uri, string endPointConfigurationName)
        {
            EndpointAddress ea = new EndpointAddress(new Uri(uri));
            return new ChannelFactory<I>(endPointConfigurationName, ea).CreateChannel();
        }

        /// <summary>
        /// 创建一个自托管实例，主要用于测试
        /// </summary>
        /// <typeparam name="I">服务契约接口类型</typeparam>
        /// <typeparam name="T">服务契约的实现类型</typeparam>
        /// <returns>返回客户端代理实例</returns>
        public static I CreateSelfHost<T, I>()
        {
            WcfSelfHost<T, I> host = new WcfSelfHost<T, I>();
            return host.Client;
        }

        /// <summary>
        /// 关闭通道连接并释放资源
        /// </summary>
        /// <example>WcfClientProxy.CloseAndDispose((IClientChannel)_IService);</example>
        /// <param name="serviceProxy">代理实例</param>
        public static void CloseAndDispose(IClientChannel serviceProxy)
        {
            if (serviceProxy == null) return;

            try
            {
                if (serviceProxy.State == CommunicationState.Opened)
                {
                    serviceProxy.Close();
                }
                serviceProxy.Dispose();
            }
            catch (CommunicationException) { serviceProxy.Abort(); }
            catch (TimeoutException) { serviceProxy.Abort(); }
            catch (Exception)
            {
                serviceProxy.Abort();
                //throw;
                ///todo:未知异常，暂不抛出，考虑记录日志
            }
            finally
            {
                serviceProxy = null;
            }
        }

    }
}
