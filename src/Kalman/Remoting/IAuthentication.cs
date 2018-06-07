using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.Remoting
{
    /// <summary>
    /// 认证接口，对于需要进行认证才能调用的远程对象必须实现该接口
    /// </summary>
    public interface IAuthentication
    {
        bool IsValidate { get; }
        bool Validate();
    }
}
