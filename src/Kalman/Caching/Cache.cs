using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Security.Permissions;

namespace Kalman.Caching
{
    public class Cache
    {
        private Hashtable inMemoryCache = Hashtable.Synchronized(new Hashtable());

        public int Count
        {
            get { return inMemoryCache.Count; }
        }

        public void Add(string key, object value)
        {
            Add(key, value, null);
        }

        public void Add(string key, object value, params ICacheItemExpiration[] expirations)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("参数[key]不能为空或空字符串");
            }

            CacheItem cacheItemBeforeLock = null;

            lock (inMemoryCache.SyncRoot)
            {
                if (!inMemoryCache.Contains(key))
                {
                    cacheItemBeforeLock = new CacheItem(key, value, expirations);
                    inMemoryCache[key] = cacheItemBeforeLock;
                }
                else
                {
                    cacheItemBeforeLock = (CacheItem)inMemoryCache[key];
                    try
                    {
                        cacheItemBeforeLock.Replace(value, expirations);
                        inMemoryCache[key] = cacheItemBeforeLock;
                    }
                    catch
                    {
                        inMemoryCache.Remove(key);
                        throw;
                    }
                }
            }
        }

        public void Remove(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("参数[key]不能为空或空字符串");
            }

            lock (inMemoryCache.SyncRoot)
            {
                if (inMemoryCache.ContainsKey(key))
                {
                    inMemoryCache.Remove(key);
                }
            }
        }

        public void RemoveByKeyPrefix(string keyPrefix)
        {
            List<string> toRemoveKeys = new List<string>();
            foreach (string key in inMemoryCache.Keys)
            {
                if (key.StartsWith(keyPrefix))
                {
                    toRemoveKeys.Add(key);
                }
            }

            lock (inMemoryCache)
            {
                foreach (string key in toRemoveKeys)
                {
                    inMemoryCache.Remove(key);
                }
            }
        }

        public object Get(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("参数[key]不能为空或空字符串");
            }

            CacheItem cacheItem = (CacheItem)inMemoryCache[key];

            if (cacheItem == null)
            {
                return null;
            }

            lock (inMemoryCache.SyncRoot)
            {
                if (cacheItem.HasExpired())
                {
                    cacheItem.TouchedByUserAction(true);

                    inMemoryCache.Remove(key);

                    return null;
                }
            }

            cacheItem.TouchedByUserAction(false);
            return cacheItem.Value;
        }

        public void Clear()
        {
            RestartFlushAlgorithm:
            lock (inMemoryCache.SyncRoot)
            {
                foreach (string key in inMemoryCache.Keys)
                {
                    bool lockWasSuccessful = false;
                    CacheItem itemToRemove = (CacheItem)inMemoryCache[key];
                    try
                    {
                        if (lockWasSuccessful = Monitor.TryEnter(itemToRemove))
                        {
                            itemToRemove.TouchedByUserAction(true);
                        }
                        else
                        {
                            goto RestartFlushAlgorithm;
                        }
                    }
                    finally
                    {
                        if (lockWasSuccessful) Monitor.Exit(itemToRemove);
                    }
                }

                inMemoryCache.Clear();
            }
        }
    } 
}