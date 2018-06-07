using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
namespace Kalman.ServiceModel
{
    /// <summary>
    /// 一个简单的WCF自托管组件，可以方便的在单元测试和控制台程序中使用，不需要配置也不需要代理类
    /// </summary>
    /// <typeparam name="T">契约对应的实现类型</typeparam>
    /// <typeparam name="I">契约接口类型</typeparam>
    public class WcfSelfHost<T, I> : IDisposable
    {
        /// <summary>
        /// {protocol}//{host}:{port}
        /// </summary>
        private const string _ENDPOINTURL = "{protocol}//{host}:{port}";
        ReaderWriterLockSlim _portLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        private const ushort _BASEPORT = 30000;
        /// <summary>
        /// string == address
        /// </summary>
        private static Dictionary<string, ushort> _portMap = new Dictionary<string, ushort>();
        ServiceEndpoint _ep;
        ServiceHost _host = null;

        /// <summary>
        /// 
        /// </summary>
        public WcfSelfHost()
        {
            EndpointAddress ea = buildEndPoint();

            _host = new ServiceHost(typeof(T), new Uri[] { ea.Uri });
            _ep = _host.AddServiceEndpoint(typeof(I), new NetTcpBinding(), ea.Uri);
            CommunicationState state = _host.State;
            _host.Open();
        }


        private EndpointAddress buildEndPoint()
        {
            string subAddress = typeof(T).Name;
            string addressKey = typeof(T).FullName;
            ushort hostPort = 0;
            try
            {
                _portLock.EnterUpgradeableReadLock();

                if (_portMap.ContainsKey(addressKey) == true)
                {
                    hostPort = (ushort)((ushort)_portMap[addressKey] + (ushort)_BASEPORT);
                }
                else
                {
                    try
                    {
                        _portLock.EnterWriteLock();
                        _portMap[addressKey] = (ushort)(_BASEPORT + _portMap.Count);
                        hostPort = _portMap[addressKey];
                    }
                    finally
                    {
                        _portLock.ExitWriteLock();
                    }
                }
            }
            finally
            {
                _portLock.ExitUpgradeableReadLock();
            }

            string endPoint = _ENDPOINTURL;
            string protocol = "net.tcp:";
            string host = "localhost/"+subAddress;
            string port = hostPort.ToString();

            endPoint = endPoint.Replace("{protocol}", protocol).Replace("{host}", host).Replace("{port}", port);
            return new EndpointAddress(endPoint);

        }

        #region IDisposable Members

        /// <summary>
        /// 释放服务宿主资源
        /// </summary>
        /// <param name="isDisposing">如果为True则调用Dispose</param>
        public void Dispose(bool isDisposing)
        {
            if (isDisposing == true)
            {
                if (_host != null)
                {
                    try
                    {
                        switch (_host.State)
                        {
                            case CommunicationState.Created:
                                break;
                            case CommunicationState.Opening:
                                _host.Close(new TimeSpan(0, 0, 0, 0, 500));
                                break;
                            case CommunicationState.Opened:
                                _host.Close(new TimeSpan(0,0,0,0,500));
                                break;
                            case CommunicationState.Faulted:
                                break;

                        }
                    }
                    catch
                    {
                        _host.Abort();
                    }

                    _host = null;
                }
            }
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~WcfSelfHost()
        {
            Dispose(false);
        }
        private I _client;
        private bool _isClientSet = false;

        /// <summary>
        /// 获取服务的客户端代理实例
        /// </summary>
        public I Client
        {
            get
            {
                if (_isClientSet == false)
                {                    
                    ChannelFactory<I> factory = new ChannelFactory<I>(_ep.Binding, _ep.Address);
                    _client = factory.CreateChannel();
                    _isClientSet = true;                    
                }
                
                return _client;
            }
        }
        
        #endregion
    }
}
