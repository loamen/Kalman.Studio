using System;
using System.Collections.Generic;
using System.Text;

namespace Kalman.Caching
{
    /// <summary>
    /// This class contains all data important to define an item stored in the cache. It holds both the DEFAULT_KEY and 
    /// value specified by the user, as well as housekeeping information used internally by this block. It is public, 
    /// rather than internal, to allow block extenders access to it inside their own implementations of IBackingStore.
    /// </summary>
    public class CacheItem
    {
        // User-provided data
        private string key;
        private object data;

        private ICacheItemExpiration[] expirations;
        private bool willBeExpired;

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheItem"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expirations">The expirations.</param>
        public CacheItem(string key, object value, params ICacheItemExpiration[] expirations)
        {
            Initialize(key, value, expirations);

            TouchedByUserAction(false);
        }

        /// <summary>
        /// Replaces the internals of the current cache item with the given new values. This is strictly used in the Cache
        /// class when adding a new item into the cache. By replacing the item's contents, rather than replacing the item
        /// itself, it allows us to keep a single reference in the cache, simplifying locking.
        /// </summary>
        /// <param name="cacheItemData">Value to be stored. May be null.</param>
        /// <param name="cacheItemExpirations">Param array of ICacheItemExpiration objects. May provide 0 or more of these.</param>
        internal void Replace(object cacheItemData, params ICacheItemExpiration[] cacheItemExpirations)
        {
            Initialize(this.key, cacheItemData, cacheItemExpirations);
            TouchedByUserAction(false);
        }

        /// <summary>
        /// Intended to be used internally only. The value should be true when an item is eligible to be expired.
        /// </summary>
        public bool WillBeExpired
        {
            get { return willBeExpired; }
            set { willBeExpired = value; }
        }

        /// <summary>
        /// Returns the cached value of this CacheItem
        /// </summary>
        public object Value
        {
            get { return data; }
        }

        /// <summary>
        /// Returns the DEFAULT_KEY associated with this CacheItem
        /// </summary>
        public string Key
        {
            get { return key; }
        }

        /// <summary>
        /// Returns array of <see cref="ICacheItemExpiration"/> objects for this instance.
        /// </summary>
        /// <returns>
        /// An array of <see cref="ICacheItemExpiration"/> objects.
        /// </returns>
        public ICacheItemExpiration[] GetExpirations()
        {
            return (ICacheItemExpiration[])expirations.Clone();
        }

        /// <summary>
        /// Evaluates all cacheItemExpirations associated with this cache item to determine if it 
        /// should be considered expired. Evaluation stops as soon as any expiration returns true. 
        /// </summary>
        /// <returns>True if item should be considered expired, according to policies
        /// defined in this item's cacheItemExpirations.</returns>
        public bool HasExpired()
        {
            foreach (ICacheItemExpiration expiration in expirations)
            {
                if (expiration.HasExpired())
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Intended to be used internally only. This method is called whenever a CacheItem is touched through the action of a user. It
        /// prevents this CacheItem from being expired or scavenged during an in-progress expiration or scavenging process. It has no effect
        /// on subsequent expiration or scavenging processes.
        /// </summary>
        public void TouchedByUserAction(bool objectRemovedFromCache)
        {
            TouchedByUserAction(objectRemovedFromCache, DateTime.Now);
        }

        /// <summary>
        /// Intended to be used internally only. This method is called whenever a CacheItem is touched through the action of a user. It
        /// prevents this CacheItem from being expired or scavenged during an in-progress expiration or scavenging process. It has no effect
        /// on subsequent expiration or scavenging processes.
        /// </summary>
        internal void TouchedByUserAction(bool objectRemovedFromCache, DateTime timestamp)
        {
            willBeExpired = objectRemovedFromCache ? false : HasExpired();
        }

        private void InitializeExpirations()
        {
            foreach (ICacheItemExpiration expiration in expirations)
            {
                expiration.Initialize(this);
            }
        }

        private void Initialize(string cacheItemKey, object cacheItemData, ICacheItemExpiration[] cacheItemExpirations)
        {
            key = cacheItemKey;
            data = cacheItemData;
            if (cacheItemExpirations == null)
            {
                expirations = new ICacheItemExpiration[1] { new NeverExpired() };
            }
            else
            {
                expirations = cacheItemExpirations;
            }
        }
    }
}
