using System;
using System.Collections.Generic;
using System.Text;

namespace Kalman.Caching
{
    /// <summary>
    /// 从不过期
    /// </summary>
    [Serializable]
    public class NeverExpired : ICacheItemExpiration
    {
        public bool HasExpired()
        {
            return false;
        }

        public void Initialize(CacheItem owningCacheItem)
        {
        }
    }
}
