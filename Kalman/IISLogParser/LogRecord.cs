using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kalman.Utilities;

namespace Kalman.IISLogParser
{
    /// <summary>
    /// IIS日志记录对象，对应一条IIS日志记录
    /// </summary>
    [Serializable]
    public class LogRecord
    {
        /// <summary>
        /// 客户端IP地址[c-ip]
        /// </summary>
        public string ClientIP { get; set; }

        /// <summary>
        /// IP归属地
        /// </summary>
        public string ClientIPLocation { get; set; }

        /// <summary>
        /// 方法[cs-method]
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// URI查询[cs-uri-query]
        /// </summary>
        public string UriQuery { get; set; }

        /// <summary>
        /// URI资源[cs-uri-stem]
        /// </summary>
        public string UriStem { get; set; }

        /// <summary>
        /// URI资源别名，需要配置与URI资源的对照表
        /// </summary>
        public string UriStemAlias { get; set; }

        /// <summary>
        /// 完整的请求Url，包括参数部分
        /// </summary>
        public string Url
        {
            get
            {
                if (string.IsNullOrEmpty(UriStem)) return string.Empty;
                string url = UriStem;
                if (string.IsNullOrEmpty(UriQuery))
                {
                    return url;
                }
                else
                {
                    return string.Format("{0}?{1}", url, UriQuery);
                }
            }
        }

        /// <summary>
        /// 用户代理，客户端所用浏览器[cs(User-Agent)]
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// 用户代理别名，需要配置与用户代理的对照表
        /// </summary>
        public List<string> UserAgentAliasList { get; set; }

        public string UserAgentAlias
        {
            get
            {
                if (UserAgentAliasList == null || UserAgentAliasList.Count == 0) return "";
                StringBuilder sb = new StringBuilder();
                foreach (string s in UserAgentAliasList)
                {
                    sb.AppendFormat("{0},", s);
                }
                return sb.ToString().TrimEnd(',');
            }
        }

        /// <summary>
        /// 用户名[cs-username]
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 记录日期[date]
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 记录时间[time]
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 日志记录时间
        /// </summary>
        public DateTime LogTime
        {
            get
            {
                return ConvertUtil.ToDateTime(string.Format("{0} {1}", Date, Time), DateTime.MinValue);
            }
        }

        /// <summary>
        /// 服务器IP地址[s-ip]
        /// </summary>
        public string ServerIP { get; set; }

        /// <summary>
        /// 服务器端口[s-port]
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// 服务名[s-sitename]
        /// </summary>
        public string SiteName { get; set; }

        /// <summary>
        /// 引用站点，统计访问来源[cs(Referer)]
        /// </summary>
        public string Referer { get; set; }

        /// <summary>
        /// 引用站点别名，需要配置与引用站点的对照表，比如："http://www.baidu.com"别名为"百度"
        /// </summary>
        public string RefererAlias { get; set; }

        /// <summary>
        /// 协议状态[sc-status]
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 协议子状态[sc-substatus]
        /// </summary>
        public string SubStatus { get; set; }

        /// <summary>
        /// Win32状态[sc-win32-status]
        /// </summary>
        public string Win32Status { get; set; }

        /// <summary>
        /// 接收的字节数[cs-bytes]
        /// </summary>
        public int ReceiveBytes { get; set; }

        /// <summary>
        /// 发送的字节数[sc-bytes]
        /// </summary>
        public int SendBytes { get; set; }

        ///// <summary>
        ///// Cookie[cs(Cookie)]
        ///// </summary>
        //public string Cookie { get; set; }

        ///// <summary>
        ///// 服务器名[s-computername]
        ///// </summary>
        //public string ComputerName { get; set; }

        ///// <summary>
        ///// 协议版本[cs-version]
        ///// </summary>
        //public string Version { get; set; }

        ///// <summary>
        ///// 主机[cs-host]
        ///// </summary>
        //public string Host { get; set; }

        ///// <summary>
        ///// 所用时间[time-taken]，分析耗时访问动作
        ///// </summary>
        //public string TimeTaken { get; set; }
        
    }
}
