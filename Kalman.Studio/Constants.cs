using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kalman.Studio
{
    /// <summary>
    /// 配置
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// 我的文档
        /// </summary>
        public static string MyDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        /// <summary>
        /// 配置存储路径
        /// </summary>
        public static string SettingPath
        {
            get
            {
                string path = MyDocumentsPath + @"\Loamen\Kalman Studio";
                var di = new DirectoryInfo(path);
                if (!di.Exists)
                {
                    di.Create();
                }
                return di.FullName;
            }
        }

        /// <summary>
        /// 配置数据库路径
        /// </summary>
        public static string SettingDbFileName = SettingPath + @"\Data\Setting.db";

        /// <summary>
        /// 配置数据库字符串
        /// </summary>
        public static string SettingConnectString = string.Format(@"Data Source={0};Version=3;", SettingDbFileName);
    }
}
