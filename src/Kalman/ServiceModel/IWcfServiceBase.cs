using System;
using System.ServiceModel;

namespace Kalman.ServiceModel
{
    /// <summary>
    /// WCF服务基础接口
    /// </summary>
    [ServiceContract]
    public interface IWcfServiceBase
    {
        /// <summary>
        /// 校验服务器是否在线
        /// </summary>
        [Obsolete("改用专门的监控服务来检查服务状态")]
        [OperationContract]
        void CheckIsOnline();
    }
}
