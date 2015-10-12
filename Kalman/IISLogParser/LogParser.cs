using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
using Kalman.Utilities;

namespace Kalman.IISLogParser
{
    public class LogParser : IDisposable
    {
        List<string> fileList = new List<string>();
        IList<LogRecord> recordList = new List<LogRecord>();
        Dictionary<string, int> dicUserAgent = new Dictionary<string, int>();
        Dictionary<string, int> dicClientIP = new Dictionary<string, int>();
        Dictionary<string, int> dicClientIPLocation = new Dictionary<string, int>();
        Dictionary<string, int> dicReferer = new Dictionary<string, int>();
        Dictionary<string, int> dicTime = new Dictionary<string, int>();

        //别名
        static Dictionary<string, int> dicUserAgentAlias = new Dictionary<string, int>();
        static Dictionary<string, int> dicRefererAlias = new Dictionary<string, int>();
        static Dictionary<string, int> dicUriStemAlias = new Dictionary<string, int>();

        //别名映射字典
        Dictionary<string, string> dicUserAgentAliasMapping = new Dictionary<string, string>();
        Dictionary<string, string> dicRefererAliasMapping = new Dictionary<string, string>();
        Dictionary<string, string> dicUriStemAliasMapping = new Dictionary<string, string>();

        QQWryLocator qqWry = null;
        LogParseFilter filter = null;

        public LogParser(LogParseFilter logParseFilter)
        {
            filter = logParseFilter;
            LoadMappingData();
        }

        void LoadMappingData()
        {
            string uriSteamAliasPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config\\iislog\\UriStemAlias.config");
            string refererAliasPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config\\iislog\\RefererAlias.config");
            string userAgentAliasPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config\\iislog\\UserAgentAlias.config");

            if (File.Exists(uriSteamAliasPath))
            {
                string[] ss = File.ReadAllLines(uriSteamAliasPath);
                foreach (string s in ss)
                {
                    if (s.Trim().Length == 0) continue;
                    if (s.StartsWith("#")) continue;//注释以#号开头

                    string[] arr = s.Split(' ');
                    if (arr.Length == 2)
                    {
                        if (dicUriStemAliasMapping.ContainsKey(arr[0])) continue;
                        dicUriStemAliasMapping.Add(arr[0].Trim(), arr[1].Trim());
                    }
                }
            }

            if (File.Exists(refererAliasPath))
            {
                string[] ss = File.ReadAllLines(refererAliasPath);
                foreach (string s in ss)
                {
                    if (s.Trim().Length == 0) continue;
                    if (s.StartsWith("#")) continue;//注释以#号开头

                    string[] arr = s.Split(' ');
                    if (arr.Length == 2)
                    {
                        if (dicRefererAliasMapping.ContainsKey(arr[0])) continue;
                        dicRefererAliasMapping.Add(arr[0].Trim(), arr[1].Trim());
                    }
                }
            }

            if (File.Exists(userAgentAliasPath))
            {
                string[] ss = File.ReadAllLines(userAgentAliasPath);
                foreach (string s in ss)
                {
                    if (s.Trim().Length == 0) continue;
                    if (s.StartsWith("#")) continue;//注释以#号开头

                    string[] arr = s.Split(' ');
                    if (arr.Length == 2)
                    {
                        if (dicUserAgentAliasMapping.ContainsKey(arr[0])) continue;
                        dicUserAgentAliasMapping.Add(arr[0].Trim(), arr[1].Trim());
                    }
                }
            }
        }

        public void LoadIPData(string fileName)
        {
            if (File.Exists(fileName) == false) return;
            try
            {
                qqWry = new QQWryLocator(fileName);
            }
            catch
            {
                qqWry = null;
            }
        }

        /// <summary>
        /// 日志记录数
        /// </summary>
        public int LogRecordNum
        {
            get { return recordList.Count; }
        }

        public Dictionary<string, int> UserAgentStat
        {
            get { return dicUserAgent; }
        }

        public Dictionary<string, int> ClientIPStat
        {
            get { return dicClientIP; }
        }

        public Dictionary<string, int> ClientIPLocationStat
        {
            get { return dicClientIPLocation; }
        }

        public Dictionary<string, int> RefererStat
        {
            get { return dicReferer; }
        }

        public Dictionary<string, int> TimeStat
        {
            get { return dicTime; }
        }

        public Dictionary<string, int> UserAgentAliasStat
        {
            get { return dicUserAgentAlias; }
        }

        public Dictionary<string, int> RefererAliasStat
        {
            get { return dicRefererAlias; }
        }

        public Dictionary<string, int> UriStemAliasStat
        {
            get { return dicUriStemAlias; }
        }

        /// <summary>
        /// 获取日志解析结果集
        /// </summary>
        /// <returns></returns>
        public IList<LogRecord> RecordList
        {
            get { return recordList; }
        }

        /// <summary>
        /// 清除解析结果
        /// </summary>
        public void Clear()
        {
            recordList.Clear();
            dicClientIP.Clear();
            dicClientIPLocation.Clear();
            dicReferer.Clear();
            dicUserAgent.Clear();
            dicTime.Clear();

            dicRefererAlias.Clear();
            dicUriStemAlias.Clear();
            dicUserAgentAlias.Clear();
        }

        public string[] Fields { get; set; }
        bool _isParseFinish = false;
        public bool IsParseFinish
        {
            get { return _isParseFinish; }
        }

        public void DoParser()
        {
            Clear();
            _isParseFinish = false;
            fileList = filter.FileList;
            foreach (string fileName in fileList)
            {
                if (File.Exists(fileName) == false) continue;

                FileInfo fi = new FileInfo(fileName);
                using (StreamReader reader = fi.OpenText())
                {
                    while (!reader.EndOfStream)
                    {
                        string s = reader.ReadLine();

                        if (s.StartsWith("#Software"))
                        {
                        }
                        else if (s.StartsWith("#Version"))
                        {
                        }
                        else if (s.StartsWith("#Date"))
                        {
                        }
                        else if (s.StartsWith("#Fields"))
                        {
                            this.Fields = s.Split(':')[1].Trim().Split(' ');
                        }
                        else
                        {
                            try
                            {
                                LogRecord record = ParserLogLine(s);
                                if (DoFilter(record))
                                {
                                    recordList.Add(record);
                                }
                            }
                            catch { }
                        }
                    }
                }
            }

            if (recordList.Count > 0)
            {
                DoStat();
            }
            _isParseFinish = true;
        }

        bool DoFilter(LogRecord record)
        {
            if (filter.Method == 1)
            {
                if (record.Method != "GET") return false;
            }
            if (filter.Method == 2)
            {
                if (record.Method != "POST") return false;
            }

            if (filter.AllowQueryByTime)
            {
                if (record.LogTime < filter.BeginTime) return false;
                if (record.LogTime > filter.EndTime) return false;
            }

            if (filter.AllowQueryByIP)
            {
                if (filter.IPList.Contains(record.ClientIP) == false) return false;
            }

            if (filter.AllowQueryByStatus)
            {
                if (filter.StatusList.Contains(record.Status) == false) return false;
            }

            if (filter.AllowQueryByIPLocation)
            {
                bool flag = false;
                foreach (string s in filter.IPLocationList)
                {
                    if (record.ClientIPLocation.StartsWith(s) == true)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag == false) return false;
            }

            if (filter.AllowQueryByReferer)
            {
                bool flag = false;
                foreach (string s in filter.RefererList)
                {
                    if (record.Referer.ToLower().StartsWith(s) == true)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag == false) return false;
            }

            if (filter.AllowQueryByUri)
            {
                bool flag = false;
                foreach (string s in filter.UriList)
                {
                    //if (r.UriStem.StartsWith(s) == true)
                    if(record.UriStem.ToLower().Contains(s) == true)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag == false) return false;
            }

            if (filter.AllowQueryByUserAgent)
            {
                bool flag = false;
                foreach (string s in filter.UserAgentList)
                {
                    if (record.UserAgent.StartsWith(s) == true)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag == false) return false;
            }

            return true;
        }

        void DoStat()
        {
            foreach (LogRecord record in recordList)
            {
                if (record.ClientIP != null)
                {
                    //if (record.ClientIP == "127.0.0.1") record.ClientIPLocation = "本地机器";
                    if (record.ClientIPLocation == null) record.ClientIPLocation = "未知地区";

                    if (dicClientIP.ContainsKey(record.ClientIP))
                    {
                        int val = dicClientIP[record.ClientIP];
                        dicClientIP[record.ClientIP] = val + 1;
                    }
                    else
                    {
                        dicClientIP.Add(record.ClientIP, 1);
                    }

                    if (dicClientIPLocation.ContainsKey(record.ClientIPLocation))
                    {
                        int val = dicClientIPLocation[record.ClientIPLocation];
                        dicClientIPLocation[record.ClientIPLocation] = val + 1;
                    }
                    else
                    {
                        dicClientIPLocation.Add(record.ClientIPLocation, 1);
                    }
                }

                if (record.UserAgent != null)
                {
                    if (dicUserAgent.ContainsKey(record.UserAgent))
                    {
                        int val = dicUserAgent[record.UserAgent];
                        dicUserAgent[record.UserAgent] = val + 1;
                    }
                    else
                    {
                        dicUserAgent.Add(record.UserAgent, 1);
                    }
                }
                //这里不统计用户代理别名字段
                //if (record.UserAgentAlias != null)
                //{
                //    if (dicUserAgentAlias.ContainsKey(record.UserAgentAlias))
                //    {
                //        int val = dicUserAgentAlias[record.UserAgentAlias];
                //        dicUserAgentAlias[record.UserAgentAlias] = val + 1;
                //    }
                //    else
                //    {
                //        dicUserAgentAlias.Add(record.UserAgentAlias, 1);
                //    }
                //}

                if (record.Referer != null)
                {
                    if (dicReferer.ContainsKey(record.Referer))
                    {
                        int val = dicReferer[record.Referer];
                        dicReferer[record.Referer] = val + 1;
                    }
                    else
                    {
                        dicReferer.Add(record.Referer, 1);
                    }
                }

                if (record.RefererAlias != null)
                {
                    if (dicRefererAlias.ContainsKey(record.RefererAlias))
                    {
                        int val = dicRefererAlias[record.RefererAlias];
                        dicRefererAlias[record.RefererAlias] = val + 1;
                    }
                    else
                    {
                        dicRefererAlias.Add(record.RefererAlias, 1);
                    }
                }

                if (record.UriStemAlias != null)
                {
                    if (dicUriStemAlias.ContainsKey(record.UriStemAlias))
                    {
                        int val = dicUriStemAlias[record.UriStemAlias];
                        dicUriStemAlias[record.UriStemAlias] = val + 1;
                    }
                    else
                    {
                        dicUriStemAlias.Add(record.UriStemAlias, 1);
                    }
                }

                if (record.Date != null)
                {
                    string timeKey = record.LogTime.ToString("yyyy-MM-dd HH");
                    if (dicTime.ContainsKey(timeKey))
                    {
                        int val = dicTime[timeKey];
                        dicTime[timeKey] = val + 1;
                    }
                    else
                    {
                        dicTime.Add(timeKey, 1);
                    }
                }
            }
        }

        //解析扩展字段
        private void ParseExtendField(LogRecord record)
        {
            if (qqWry != null)
            {
                string ipLocation = qqWry.Query(record.ClientIP).Country;
                record.ClientIPLocation = ipLocation;
            }

            record.UriStemAlias = "";
            foreach (KeyValuePair<string,string> kvp in dicUriStemAliasMapping)
            {
                if (record.UriStem.Trim().ToLower() == kvp.Key.Trim().ToLower())
                {
                    record.UriStemAlias = kvp.Value;
                    break;
                }
            }
            record.RefererAlias = "";
            foreach (KeyValuePair<string, string> kvp in dicRefererAliasMapping)
            {
                if (record.Referer.ToLower().StartsWith(kvp.Key.ToLower()))
                {
                    record.RefererAlias = kvp.Value;
                    break;
                }
            }
            record.UserAgentAliasList = new List<string>();
            foreach (KeyValuePair<string, string> kvp in dicUserAgentAliasMapping)
            {
                //多次匹配统计，一条日志记录的用户代理字段可以匹配多个别名
                if (record.UserAgent.ToLower().Contains(kvp.Key.ToLower()))
                {
                    record.UserAgentAliasList.Add(kvp.Value);

                    if (dicUserAgentAlias.ContainsKey(kvp.Value))
                    {
                        int val = dicUserAgentAlias[kvp.Value];
                        dicUserAgentAlias[kvp.Value] = val + 1;
                    }
                    else
                    {
                        dicUserAgentAlias.Add(kvp.Value, 1);
                    }
                }
            }
        }

        LogRecord ParserLogLine(string s)
        {
            string[] ss = s.Split(' ');
            int len = ss.Length;
            LogRecord record = new LogRecord();
            record.ReceiveBytes = 0;
            record.SendBytes = 0;
            record.Referer = "";

            for (int i = 0; i < len; i++)
            {
                switch (this.Fields[i])
                {
                    case "c-ip":
                        record.ClientIP = ss[i];
                        break;
                    case "date":
                        record.Date = ss[i];
                        break;
                    case "cs-method":
                        record.Method = ss[i];
                        break;
                    case "s-port":
                        record.Port = ss[i];
                        break;
                    case "cs-bytes":
                        record.ReceiveBytes = ConvertUtil.ToInt32(ss[i], 0);
                        break;
                    case "cs(Referer)":
                        record.Referer = ss[i];
                        break;
                    case "sc-bytes":
                        record.SendBytes = ConvertUtil.ToInt32(ss[i], 0);
                        break;
                    case "s-ip":
                        record.ServerIP = ss[i];
                        break;
                    case "s-sitename":
                        record.SiteName = ss[i];
                        break;
                    case "sc-status":
                        record.Status = ss[i];
                        break;
                    case "sc-substatus":
                        record.SubStatus = ss[i];
                        break;
                    case "time":
                        record.Time = ss[i];
                        break;
                    case "cs-uri-query":
                        record.UriQuery = ss[i];
                        break;
                    case "cs-uri-stem":
                        record.UriStem = ss[i];
                        break;
                    case "cs(User-Agent)":
                        record.UserAgent = ss[i];
                        break;
                    case "cs-username":
                        record.UserName = ss[i];
                        break;
                    case "sc-win32-status":
                        record.Win32Status = ss[i];
                        break;

                    case "cs-host":
                        break;
                    case "time-taken":
                        break;
                    case "cs-version":
                        break;
                    case "s-computername":
                        break;
                    case "cs(Cookie)":
                        break;
                    default:
                        break;
                }
            }

            ParseExtendField(record);
            return record;
        }

        #region IDisposable 成员

        public void Dispose()
        {
            this.Clear();
        }

        #endregion

        ~LogParser()
        {
            this.Dispose();
        }
    }
}
