using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalman
{
    public class NormalConfig
    {
        /// <summary>
        /// 我的文档
        /// </summary>
        public static string MyDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        /// <summary>
        /// 设置目录
        /// </summary>
        public static string SettingPath
        {
            get
            {
                string path = MyDocumentsPath + @"\Loamen\KalmanStudio";
                var di = new DirectoryInfo(path);
                if (!di.Exists)
                {
                    di.Create();
                }
                return di.FullName;
            }
        }

        /// <summary>
        /// 数据目录
        /// </summary>
        public static string DatabasePath
        {
            get
            {
                string path = SettingPath + @"\Data";
                var di = new DirectoryInfo(path);
                if (!di.Exists)
                {
                    di.Create();
                }
                return di.FullName;
            }
        }

        /// <summary>
        /// 配置数据文件
        /// </summary>
        public static string SettingDataFileName
        {
            get
            {
                return DatabasePath + @"\setting.db";
            }
        }
    }
}
