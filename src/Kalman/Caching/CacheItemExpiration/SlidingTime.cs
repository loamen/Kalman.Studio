using System;
using System.Collections.Generic;
using System.Text;

namespace Kalman.Caching
{
    /// <summary>
    /// 使用时间片来判断一个缓存项是否过期
    /// </summary>
    [Serializable]
    public class SlidingTime : ICacheItemExpiration
    {
        private DateTime timeLastUsed;
        private TimeSpan itemSlidingExpiration;

        public SlidingTime(TimeSpan slidingExpiration)
        {
            if (!(slidingExpiration.TotalSeconds >= 1))
            {
                throw new ArgumentOutOfRangeException("参数值超出范围");
            }

            this.itemSlidingExpiration = slidingExpiration;
        }

        internal SlidingTime(TimeSpan slidingExpiration, DateTime originalTimeStamp)
            : this(slidingExpiration)
        {
            timeLastUsed = originalTimeStamp;
        }

        public TimeSpan ItemSlidingExpiration
        {
            get { return itemSlidingExpiration; }
        }

        /// <summary>
        /// 获取缓存项最近使用时间
        /// </summary>
        public DateTime TimeLastUsed
        {
            get { return timeLastUsed; }
        }

        /// <summary>
        /// 判断缓存项是否过期
        /// </summary>
        public bool HasExpired()
        {
            bool expired = CheckSlidingExpiration(DateTime.Now,
                                                  this.timeLastUsed,
                                                  this.itemSlidingExpiration);
            return expired;
        }

        /// <summary>
        ///	通知该缓存项最近被使用过
        /// </summary>
        public void Notify()
        {
            this.timeLastUsed = DateTime.Now;
        }

        public void Initialize(CacheItem owningCacheItem)
        {
        }

        /// <summary>
        ///	检查是否过期
        /// </summary>
        /// <param name="nowDateTime">当前时间</param>
        /// <param name="lastUsed">缓存项最后使用时间</param>
        /// <param name="slidingExpiration">过期时间片</param>
        private static bool CheckSlidingExpiration(DateTime nowDateTime,
                                                   DateTime lastUsed,
                                                   TimeSpan slidingExpiration)
        {
            DateTime tmpNowDateTime = nowDateTime.ToUniversalTime();
            DateTime tmpLastUsed = lastUsed.ToUniversalTime();

            long expirationTicks = tmpLastUsed.Ticks + slidingExpiration.Ticks;

            bool expired = (tmpNowDateTime.Ticks >= expirationTicks) ? true : false;

            return expired;
        }
    }
}
