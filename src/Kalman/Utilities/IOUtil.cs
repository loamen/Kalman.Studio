using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalman.Utilities
{
    /// <summary>
    /// 文件操作类 
    /// </summary>
    public sealed class IOUtil
    {
        /// <summary>
        /// 获取目录下文件数量
        /// </summary>
        /// <param name="dirInfo">目录</param>
        /// <param name="extention">扩展名如：*.tt</param>
        /// <returns></returns>
        public static int GetFilesCount(DirectoryInfo dirInfo, string extention = null)
        {

            int totalFile = 0;
            if (string.IsNullOrEmpty(extention))
            {
                totalFile += dirInfo.GetFiles().Length;//获取全部文件
            }
            else
            {
                totalFile += dirInfo.GetFiles(extention).Length;//获取某种格式
            }
            foreach (System.IO.DirectoryInfo subdir in dirInfo.GetDirectories())
            {
                totalFile += GetFilesCount(subdir, extention);
            }
            return totalFile;
        }
    }
}
