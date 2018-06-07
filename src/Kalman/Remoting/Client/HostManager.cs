using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using System.Runtime.Remoting;

namespace Kalman.Remoting
{
    /// <summary>
    /// Remoting宿主管理类
    /// 宿主监控（监控宿主的状态，并标志不可用的宿主）
    /// 负载均衡（将客户端的远程调用请求均匀的分配到各个宿主）
    /// </summary>
    public class HostManager : IDisposable
    {
        public static readonly HostManager Instance = new HostManager();
        RemotingConfig cfg = RemotingConfig.Instance;
        StringDictionary hostStateInfo = new StringDictionary();    //主机状态信息
        Hashtable ht = Hashtable.Synchronized(new Hashtable());     //用来保存每个Client的可用Host列表
        List<Thread> threads = new List<Thread>();

        private HostManager()
        {
        }

        /// <summary>
        /// 轮询Remoting宿主，检测其是否可用
        /// </summary>
        public void PollingHost()
        {
            foreach (ClientConfig ci in cfg.ClientInfoCollection.Values)
            {
                if (ci.LBEnabled)
                {
                    Thread t = new Thread(new ParameterizedThreadStart(DoCheck));
                    t.IsBackground = true;
                    threads.Add(t);
                    t.Start(ci);
                }
            }
        }

        void DoCheck(object obj)
        {
            ClientConfig ci = obj as ClientConfig;
            Host[] hosts = new Host[ci.HostCollection.Count];
            ci.HostCollection.Values.CopyTo(hosts, 0);
            int interval = ci.PollingInterval * 1000;

            while (true)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Host host in hosts)
                {
                    #region Remoting调用方式检测Host
                    try
                    {
                        //若服务不可用，耗时比较长，需改用其他方式检测
                        string objectUri = "Kalman.Remoting.HostMonitorService";
                        HostMonitorService srv = RCHelper.Instance.GetWellKnownObject<HostMonitorService>(host.Url, objectUri);
                        //Trace.WriteLine(srv.GetCurrentDate());

                        //HostMonitorService srv = (HostMonitorService)RemotingServices.Connect(typeof(HostMonitorService), string.Format("{0}/{1}", host.Url, objectUri));
                        //srv.GetCurrentDate();
                        sb.Append(host.Url);
                        sb.Append("|");
                    }
                    catch (Exception ex)
                    {
                        string key = string.Format("{0}|{1}", ci.Name, host.Name);
                        lock (hostStateInfo.SyncRoot)
                        {
                            if (hostStateInfo.ContainsKey(key))
                                hostStateInfo[key] = ex.Message;
                            else
                                hostStateInfo.Add(key, ex.Message);
                        }
                        //Trace.WriteLine(key+"."+ex.Message);
                    }
                    #endregion

                    #region
                    //string[] ss = host.Url.TrimStart("tcp://".ToCharArray()).Split(':');
                    //string ip = ss[0];
                    //int port = int.Parse(ss[1]);
                    //string errMsg = string.Empty;
                    //bool flag = NetUtil.TestIpAndPort(ip, port, out errMsg);

                    //if (flag)
                    //{
                    //    sb.Append(host.Url);
                    //    sb.Append("|");
                    //}
                    //else
                    //{
                    //    string key = string.Format("{0}|{1}", ci.Name, host.Name);
                    //    lock (hostStateInfo.SyncRoot)
                    //    {
                    //        if (hostStateInfo.ContainsKey(key))
                    //            hostStateInfo[key] = errMsg;
                    //        else
                    //            hostStateInfo.Add(key, errMsg);
                    //    }
                    //}
                    #endregion
                }//foreach

                string s = sb.ToString().TrimEnd('|');

                //更新可用Host列表
                lock (ht.SyncRoot)
                {
                    if (ht.ContainsKey(ci.Name))
                    {
                        ht[ci.Name] = s;
                    }
                    else
                    {
                        ht.Add(ci.Name, s);
                    }
                }
                Thread.Sleep(interval);
            }
        }

        /// <summary>
        /// 获取当前Host地址
        /// </summary>
        /// <returns></returns>
        public string GetCurrentHostAddress()
        {
            //取配置的第一个clientName
            string clientName = string.Empty;
            foreach (ClientConfig cc in RemotingConfig.Instance.ClientInfoCollection.Values)
            {
                clientName = cc.Name;
                break;
            }
            return GetCurrentHostAddress(clientName);
        }

        /// <summary>
        /// 获取当前Host地址
        /// </summary>
        /// <param name="clientName"></param>
        /// <returns></returns>
        public string GetCurrentHostAddress(string clientName)
        {
            if (string.IsNullOrEmpty(clientName)) return string.Empty;

            ClientConfig ci = cfg.ClientInfoCollection[clientName];

            if (ci.LBEnabled == false)
                return ci.DefaultHost.Url;
            else
                return GetUsableHostAddress(clientName);
        }

        /// <summary>
        /// 从Client可用Host列表中随机获取一个可用的Host
        /// </summary>
        /// <returns></returns>
        string GetUsableHostAddress(string clientName)
        {
            //改进负载均衡算法，可以根据各Host的调用计数和Host的权重（给性能好的机器更多的调用请求）来设计
            if (!ht.ContainsKey(clientName)) return null;

            string s = ht[clientName].ToString().Trim();
            if (s == string.Empty) return null;

            string[] ss = s.Split('|');
            int len = ss.Length;
            int second = DateTime.Now.Second;
            int idx = second % len;

            return ss[idx];
        }

        /// <summary>
        /// 返回Host状态信息，只记录异常信息
        /// </summary>
        /// <param name="clientName"></param>
        /// <param name="hostName"></param>
        /// <returns></returns>
        public string GetHostStateInfo(string clientName,string hostName)
        {
            string key = string.Format("{0}|{1}", clientName, hostName);

            if (hostStateInfo.ContainsKey(key)) return hostStateInfo[key];
            else return string.Empty;
        }

        #region IDisposable 成员

        public void Dispose()
        {
            foreach (Thread t in threads)
            {
                if (t.ThreadState != System.Threading.ThreadState.Stopped)
                {
                    try
                    {
                        t.Abort();
                    }
                    catch { }
                }
            }
        }

        #endregion

        ~HostManager()
        {
            this.Dispose();
        }
    }
}
