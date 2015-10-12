using System;
using System.Collections.Generic;
using System.Text;

namespace Kalman.Caching
{
    /// <summary>
    ///	缓存项过期接口，可以基于该接口实现需要的缓存项过期对象
    /// </summary>
    public interface ICacheItemExpiration
    {
        /// <summary>
        /// 判断缓存项是否过期
        /// </summary>
        bool HasExpired();

        /// <summary>
        /// 初始化
        /// </summary>
        void Initialize(CacheItem owningCacheItem);
    }
}
