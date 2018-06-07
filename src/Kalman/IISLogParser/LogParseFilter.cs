using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.IISLogParser
{
    public class LogParseFilter
    {
        int _Method = 0;
        /// <summary>
        /// 方法[0:All,1:Get,2:Post]
        /// </summary>
        public int Method
        {
            get { return _Method; }
            set { _Method = value; }
        }

        List<string> _FileList = new List<string>();
        public List<string> FileList
        {
            get
            {
                return _FileList;
            }
        }

        public void AddFile(string fileName)
        {
            if (_FileList.Contains(fileName)) return;
            _FileList.Add(fileName);
        }

        public void AddFiles(string[] fileNames)
        {
            foreach (string item in fileNames)
            {
                AddFile(item);
            }
        }

        public bool AllowQueryByTime = false;
        public bool AllowQueryByIP = false;
        public bool AllowQueryByIPLocation = false;
        public bool AllowQueryByUserAgent = false;
        public bool AllowQueryByUri = false;
        public bool AllowQueryByReferer = false;
        public bool AllowQueryByStatus = false;

        public DateTime BeginTime = DateTime.Now;
        public DateTime EndTime = DateTime.Now;

        IList<string> _IPList = new List<string>();
        public IList<string> IPList { get { return _IPList; } }
        public void AddIP(string ip)
        {
            if (_IPList.Contains(ip)) return;
            _IPList.Add(ip);
        }

        IList<string> _IPLocationList = new List<string>();
        public IList<string> IPLocationList { get { return _IPLocationList; } }
        public void AddIPLocation(string location)
        {
            if (_IPLocationList.Contains(location)) return;
            _IPLocationList.Add(location);
        }

        IList<string> _UserAgentList = new List<string>();
        public IList<string> UserAgentList { get { return _UserAgentList; } }
        public void AddUserAgent(string userAgent)
        {
            if (_UserAgentList.Contains(userAgent)) return;
            _UserAgentList.Add(userAgent);
        }

        IList<string> _UriList = new List<string>();
        public IList<string> UriList { get { return _UriList; } }
        public void AddUri(string uri)
        {
            if (_UriList.Contains(uri)) return;
            _UriList.Add(uri);
        }

        IList<string> _RefererList = new List<string>();
        public IList<string> RefererList { get { return _RefererList; } }
        public void AddReferer(string referer)
        {
            if (_RefererList.Contains(referer)) return;
            _RefererList.Add(referer);
        }

        IList<string> _StatusList = new List<string>();
        public IList<string> StatusList { get { return _StatusList; } }
        public void AddStatus(string status)
        {
            if (_StatusList.Contains(status)) return;
            _StatusList.Add(status);
        }
    }
}
