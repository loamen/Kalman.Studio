using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kalman.Logging;
using System.IO;

namespace Kalman.Remoting
{
    /// <summary>
    /// Remoting Logging Service
    /// </summary>
    public class LoggingService : MarshalByRefObject
    {
        #region Write Log

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="appName">应用程序名称（唯一）</param>
        /// <param name="msg">日志消息</param>
        public void WriteLog(string appName, string msg)
        {
            string path = GetLogPath(appName);
            msg = FormatLogMessage(msg,null);
            File.AppendAllText(path, msg, Encoding.UTF8);
        }

        ///// <summary>
        ///// 写日志
        ///// </summary>
        ///// <param name="appName">应用程序名称（唯一）</param>
        ///// <param name="msg">日志消息</param>
        ///// <param name="ex">需要记录的异常</param>
        //public void WriteLog(string appName, string msg, Exception ex)
        //{
        //    string path = GetLogPath(appName);
        //    msg = FormatLogMessage(msg, ex);
        //    File.AppendAllText(path, msg, Encoding.UTF8);
        //}

        /// <summary>
        /// 获取指定名称的应用程序日志写入路径
        /// </summary>
        /// <param name="appName">应用程序名称</param>
        /// <returns></returns>
        private string GetLogPath(string appName)
        {
            string path = string.Format("log\\{0}\\{1}", appName, DateTime.Now.ToString("yyyyMM"));
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);

            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }

            path = Path.Combine(path, DateTime.Now.ToString("yyyy-MM-dd") + ".log");
            return path;
        }

        private string FormatLogMessage(string msg, Exception ex)
        {
            if (ex != null)
            {
                msg = msg + "\r\n" + ex.ToString();
            }
            return string.Format("{0} {1}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), msg);
        }
        #endregion

        #region Log File Manage
        ///todo:Log File Manage

        #endregion
    }
}
