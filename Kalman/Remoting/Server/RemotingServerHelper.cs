using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using System.Collections;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Ipc;

namespace Kalman.Remoting
{
    /// <summary>
    /// Remoting服务端帮助类
    /// </summary>
    [Obsolete("暂停使用该对象发布Remoting业务组件，改用配置文件")]
    public class RSHelper : ILogable
    {
        IChannel serviceChannel;
        ServerConfig sc;

        public RSHelper(ServerConfig cfg)
        {
            sc = cfg;

            if (string.IsNullOrEmpty(sc.Address))
            {
                //取本机IP
            }

            //使用二进制格式化
            BinaryServerFormatterSinkProvider serverProvider = new
                BinaryServerFormatterSinkProvider();
            BinaryClientFormatterSinkProvider clientProvider = new
                BinaryClientFormatterSinkProvider();

            //设置反序列化级别为Full，支持远程处理在所有情况下支持的所有类型
            serverProvider.TypeFilterLevel = TypeFilterLevel.Full;

            IDictionary props = new Hashtable();
            props["name"] = AppDomain.CurrentDomain.FriendlyName;
            props["port"] = sc.Port;

            switch (sc.ChannelType)
            {
                case ChannelType.TCP:
                    serviceChannel = new TcpChannel(props, clientProvider, serverProvider);
                    break;
                case ChannelType.HTTP:
                    serviceChannel = new HttpChannel(props, clientProvider, serverProvider);
                    break;
                case ChannelType.IPC:
                    serviceChannel = new IpcChannel(props, clientProvider, serverProvider);
                    break;
                default:
                    break;
            }

            ChannelServices.RegisterChannel(serviceChannel, false);
        }

        public void RegisterWellKnownObject()
        {
            Log("开始注册Remoting对象");
            foreach (WellKnownServiceTypeEntry entry in sc.WellKnownObjectCollection.Values)
            {
                RemotingConfiguration.RegisterWellKnownServiceType(entry);
                Log(string.Format("已注册[{0}]，对象地址[{1}]，激活类型[{2}]", entry.TypeName, entry.ObjectUri, entry.Mode));
            }

            RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
            RemotingConfiguration.CustomErrorsEnabled(false);

            //注册Remoting宿主监控服务模块
            Log("已注册Remoting宿主监控服务模块，对象地址[HostMonitorService]，激活类型[Singleton]");
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(HostMonitorService), "Kalman.Remoting.HostMonitorService", WellKnownObjectMode.Singleton);

            Log("Remoting对象已全部注册完成");
        }

        /// <summary>
        /// 对象销毁时注销已注册的Remoting信道
        /// </summary>
        ~RSHelper()
        {
            ChannelServices.UnregisterChannel(serviceChannel);
        }

        #region ILogable 成员

        public event LogHandler OnLog;

        #endregion

        void Log(string msg)
        {
            if (OnLog != null)
            {
                OnLog(msg);
            }
        }
    }
}
