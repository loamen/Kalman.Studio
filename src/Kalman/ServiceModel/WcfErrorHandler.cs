using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Kalman.ServiceModel
{
    /// <summary>
    /// 自定义错误处理器
    /// </summary>
    public class WcfErrorHandler : IErrorHandler
    {
        #region IErrorHandler 成员

        /// <summary>
        /// 启用错误相关处理并返回一个值，该值指示调度程序在某些情况下是否中止会话和实例上下文
        /// </summary>
        /// <param name="error">处理过程中引发的异常</param>
        /// <returns>
        /// 如果WCF不应中止会话（如果有一个）和实例上下文（如果实例上下文不是 System.ServiceModel.InstanceContextMode.Single），则为true；否则为 false。默认值为 false。
        /// </returns>
        public bool HandleError(Exception error)
        {
           ///todo:  if(error is FaultException<ErrorInfo>)
            //在异常返回给客户端之后被调用，在这里记录异常日志
           // System.IO.File.AppendAllText(@"C:\WCF_Log.txt",error.ToString() + "\r\n");
            Console.WriteLine(error.ToString());

            //异常已处理，不终止会话或实例上下文
            return true;
        }

        /// <summary>
        /// 启用创建从服务方法过程中的异常返回的自定义 System.ServiceModel.FaultException<TDetail>。
        /// </summary>
        /// <param name="error">服务操作过程中引发的 System.Exception 对象。</param>
        /// <param name="version">消息的 SOAP 版本</param>
        /// <param name="fault">双工情况下，返回到客户端或服务的 System.ServiceModel.Channels.Message 对象。</param>
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            //在异常发生后，异常信息返回前被调用，这里一般不做处理
            //将托管异常System.Exception转换为System.ServiceModel.FaultException
            //FaultException ex = new FaultException("这条消息将返回至调用方");
            //MessageFault mf = ex.CreateMessageFault();
            //fault = System.ServiceModel.Channels.Message.CreateMessage(version, mf, ex.Action);

            //WCF服务层统一抛出FaultException类型的异常，对于未处理异常则将其包装成FaultException类型的异常，以免造成信道异常
            if (error is FaultException) return;
            FaultException ex = new FaultException(error.Message);
            MessageFault mf = ex.CreateMessageFault();
            fault = System.ServiceModel.Channels.Message.CreateMessage(version, mf, ex.Action);
        }

        #endregion
    }
}
