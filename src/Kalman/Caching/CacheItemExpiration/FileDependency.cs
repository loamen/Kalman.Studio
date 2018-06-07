using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Permissions;

namespace Kalman.Caching
{
    /// <summary>
    ///	基于文件依赖的缓存项过期对象
    /// </summary>
    [Serializable]
    [System.Runtime.InteropServices.ComVisible(false)]
    public class FileDependency : ICacheItemExpiration
    {
        private readonly string dependencyFileName;

        private DateTime lastModifiedTime;

        public FileDependency(string fullFileName)
        {
            if (string.IsNullOrEmpty(fullFileName))
            {
                throw new ArgumentException("文件名不能为空");
            }

            dependencyFileName = Path.GetFullPath(fullFileName);
            EnsureTargetFileAccessible();

            if (!File.Exists(dependencyFileName))
            {
                throw new ArgumentException("指定的文件不存在");
            }

            this.lastModifiedTime = File.GetLastWriteTime(fullFileName);
        }

        /// <summary>
        /// 获取缓存项依赖的文件名
        /// </summary>
        public string FileName
        {
            get { return dependencyFileName; }
        }

        /// <summary>
        /// 获取缓存项依赖文件的最后修改时间
        /// </summary>
        public DateTime LastModifiedTime
        {
            get { return lastModifiedTime; }
        }

        /// <summary>
        ///	判断缓存项是否过期
        /// </summary>
        public bool HasExpired()
        {
            EnsureTargetFileAccessible();

            if (File.Exists(this.dependencyFileName) == false)
            {
                return true;
            }

            DateTime currentModifiedTime = File.GetLastWriteTime(dependencyFileName);
            if (DateTime.Compare(lastModifiedTime, currentModifiedTime) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Initialize(CacheItem owningCacheItem)
        {
        }

        /// <summary>
        /// 确认目标文件可被访问
        /// </summary>
        private void EnsureTargetFileAccessible()
        {
            string file = dependencyFileName;
            FileIOPermission permission = new FileIOPermission(FileIOPermissionAccess.Read, file);
            permission.Demand();
        }
    }
}
