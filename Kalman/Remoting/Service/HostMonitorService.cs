using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.Remoting
{
    /// <summary>
    /// Remoting宿主监控服务类，提供Remoting宿主服务器的一些基本信息和操作，比如：获取当前时间、CPU、内存信息及对本机服务控制等
    /// 该对象在Remoting服务端默认发布，客户端可以通过该服务类来获取Remoting宿主服务器的一些基本信息
    /// </summary>
    public class HostMonitorService : MarshalByRefObject
    {
        /// <summary>
        /// 获取Remoting宿主服务器当前时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }
    }
}
