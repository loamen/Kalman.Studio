using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.Collections.ObjectModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Kalman.ServiceModel
{
    /// <summary>
    /// WCF服务对象基类
    /// </summary>
    public abstract class WcfServiceBase : IServiceBehavior, IWcfServiceBase
    {
        /// <summary>
        /// 校验服务器是否在线
        /// </summary>
        public virtual void CheckIsOnline()
        { }
        
        #region IServiceBehavior 成员

        /// <summary>
        /// 用于向绑定元素传递自定义数据，以支持协定实现。
        /// </summary>
        /// <param name="serviceDescription">服务的服务说明</param>
        /// <param name="serviceHostBase">服务的宿主</param>
        /// <param name="endpoints">服务终结点</param>
        /// <param name="bindingParameters">绑定元素可访问的自定义对象</param>
        public virtual void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        /// <summary>
        /// 用于更改运行时属性值或插入自定义扩展对象（例如错误处理程序、消息或参数拦截器、安全扩展以及其他自定义扩展对象）。
        /// </summary>
        /// <param name="serviceDescription">服务说明</param>
        /// <param name="serviceHostBase">当前正在生成的宿主</param>
        public virtual void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            IErrorHandler handler = new WcfErrorHandler();

            foreach (ChannelDispatcher dispatcher in serviceHostBase.ChannelDispatchers)
            {
                // 增加错误处理器
                dispatcher.ErrorHandlers.Add(handler);
            }
        }

        /// <summary>
        /// 用于检查服务宿主和服务说明，从而确定服务是否可成功运行。
        /// </summary>
        /// <param name="serviceDescription">服务说明</param>
        /// <param name="serviceHostBase">当前正在构建的服务宿主</param>
        public virtual void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        #endregion
    }
}
