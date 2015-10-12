using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.Remoting
{
    /// <summary>
    /// Remoting宿主实体类
    /// </summary>
    [Serializable]
    public class Host
    {
        /// <summary>
        /// Remoting宿主名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Remoting宿主地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Remoting宿主是否可用
        /// </summary>
        //public bool IsUsable { get; set; }
    }
}
