using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Kalman.ServiceModel
{
    /// <summary>
    /// 错误信息
    /// </summary>
    [Serializable]
    public class ErrorInfo
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        [DataMember]
        public int Code { get; set; }

        /// <summary>
        /// 错误原因
        /// </summary>
        [DataMember]
        public string Reason { get; set; }

        /// <summary>
        /// 发生异常的类型名称，如FC.xxxService
        /// </summary>
        [DataMember]
        public string TypeName { get; set; }

        /// <summary>
        /// 发生异常的方法名称
        /// </summary>
        [DataMember]
        public string MethodName { get; set; }
    }
}
