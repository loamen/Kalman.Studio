using System;
using System.Collections.Generic;
using System.Text;

namespace Kalman.Caching
{
    /// <summary>
    ///	使用绝对时间[UTC]来判断一个缓存项是否过期
    /// </summary>
    [Serializable]
    public class AbsoluteTime : ICacheItemExpiration
    {
        private DateTime absoluteExpirationTime;

        /// <summary>
        ///	创建一个实例并将输入的时间转换为UTC时间，转换后的时间值将用来判断该缓存项是否过期
        /// </summary>
        public AbsoluteTime(DateTime absoluteTime)
        {
            if (absoluteTime > DateTime.Now)
            {
                this.absoluteExpirationTime = absoluteTime.ToUniversalTime();
            }
            else
            {
                throw new ArgumentOutOfRangeException("时间超出范围，应该指定一个将来的时间");
            }
        }

        /// <summary>
        /// 获取过期时间
        /// </summary>
        public DateTime AbsoluteExpirationTime
        {
            get { return absoluteExpirationTime; }
        }

        /// <summary>
        /// 创建一个实例并指定从现在开始的时间间隔，在这个时间间隔后缓存项将过期
        /// </summary>
        public AbsoluteTime(TimeSpan timeFromNow)
            : this(DateTime.Now + timeFromNow)
        {
        }

        public bool HasExpired()
        {
            DateTime nowDateTime = DateTime.Now.ToUniversalTime();
            return nowDateTime.Ticks >= this.absoluteExpirationTime.Ticks;
        }

        public void Initialize(CacheItem owningCacheItem)
        {
        }
    }
}
