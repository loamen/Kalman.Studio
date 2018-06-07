using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using System.Web;

namespace Kalman.Net
{
    /// <summary>
    /// HTTP通信客户端组件修正版（解决了.NET HTTP模块与非IIS服务器通信时，使用POST方式提交数据可能出现471异常的问题；
    /// .NET HTTP模块向服务器POST数据时先验证URL是否有效，然后才提交数据，而非IIS服务器可能被认为是异常）
    /// </summary>
    public class HttpClient
    {
        #region fields
        private bool keepContext;
        private string defaultLanguage = "zh-CN";
        private Encoding defaultEncoding = Encoding.UTF8;
        private Encoding requestEncoding = Encoding.UTF8;
        private string accept = "*/*";
        private string userAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        private HttpVerb verb = HttpVerb.GET;
        private HttpClientContext context;
        private readonly List<HttpUploadingFile> files = new List<HttpUploadingFile>();
        private readonly Dictionary<string, string> postingData = new Dictionary<string, string>();
        private string url;
        private WebHeaderCollection responseHeaders;
        private int startPoint;
        private int endPoint;
        #endregion

        #region events
        public event EventHandler<StatusUpdateEventArgs> StatusUpdate;

        private void OnStatusUpdate(StatusUpdateEventArgs e)
        {
            EventHandler<StatusUpdateEventArgs> temp = StatusUpdate;

            if (temp != null)
                temp(this, e);
        }
        #endregion

        #region properties
        /// <summary>
        /// 是否自动在不同的请求间保留Cookie, Referer
        /// </summary>
        public bool KeepContext
        {
            get { return keepContext; }
            set { keepContext = value; }
        }

        /// <summary>
        /// 期望的回应的语言
        /// </summary>
        public string DefaultLanguage
        {
            get { return defaultLanguage; }
            set { defaultLanguage = value; }
        }

        /// <summary>
        /// GetString()如果不能从HTTP头或Meta标签中获取编码信息,则使用此编码来获取字符串
        /// </summary>
        public Encoding DefaultEncoding
        {
            get { return defaultEncoding; }
            set { defaultEncoding = value; }
        }

        /// <summary>
        /// 发出请求的数据编码
        /// </summary>
        public Encoding RequestEncoding
        {
            get { return requestEncoding; }
            set { requestEncoding = value; }
        }

        /// <summary>
        /// 指示发出Get请求还是Post请求
        /// </summary>
        public HttpVerb Verb
        {
            get { return verb; }
            set { verb = value; }
        }

        /// <summary>
        /// 要上传的文件.如果不为空则自动转为Post请求
        /// </summary>
        public List<HttpUploadingFile> Files
        {
            get { return files; }
        }

        /// <summary>
        /// 要发送的Form表单信息
        /// </summary>
        public Dictionary<string, string> PostingData
        {
            get { return postingData; }
        }

        /// <summary>
        /// 获取或设置请求资源的地址
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        /// <summary>
        /// 用于在获取回应后,暂时记录回应的HTTP头
        /// </summary>
        public WebHeaderCollection ResponseHeaders
        {
            get { return responseHeaders; }
        }

        /// <summary>
        /// 获取或设置期望的资源类型
        /// </summary>
        public string Accept
        {
            get { return accept; }
            set { accept = value; }
        }

        /// <summary>
        /// 获取或设置请求中的Http头User-Agent的值
        /// </summary>
        public string UserAgent
        {
            get { return userAgent; }
            set { userAgent = value; }
        }

        /// <summary>
        /// 获取或设置Cookie及Referer
        /// </summary>
        public HttpClientContext Context
        {
            get { return context; }
            set { context = value; }
        }

        /// <summary>
        /// 获取或设置获取内容的起始点,用于断点续传,多线程下载等
        /// </summary>
        public int StartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }

        /// <summary>
        /// 获取或设置获取内容的结束点,用于断点续传,多下程下载等.
        /// 如果为0,表示获取资源从StartPoint开始的剩余内容
        /// </summary>
        public int EndPoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }

        /// <summary>
        /// 请求超时前等待的毫秒数。默认值为 100,000 毫秒（100 秒）
        /// </summary>
        public int Timeout { get; set; }

        #endregion

        #region constructors
        /// <summary>
        /// 构造新的HttpClient实例
        /// </summary>
        public HttpClient()
            : this(null)
        {
        }

        /// <summary>
        /// 构造新的HttpClient实例
        /// </summary>
        /// <param name="url">要获取的资源的地址</param>
        public HttpClient(string url)
            : this(url, false)
        {
        }

        /// <summary>
        /// 构造新的HttpClient实例
        /// </summary>
        /// <param name="url">要获取的资源的地址</param>
        /// <param name="expect100Continue">是否使用100-continue行为（默认为false，对于非IIS服务器向其POST数据时可能会出现471错误，将该参数设置为false可以避免这个问题）</param>
        public HttpClient(string url, bool expect100Continue)
            : this(url, expect100Continue, null)
        {
        }

        /// <summary>
        /// 构造新的HttpClient实例
        /// </summary>
        /// <param name="url">要获取的资源的地址</param>
        /// <param name="expect100Continue">是否使用100-continue行为（默认为false，对于非IIS服务器向其POST数据时可能会出现471错误，将该参数设置为false可以避免这个问题）</param>
        /// <param name="context">Cookie及Referer</param>
        public HttpClient(string url, bool expect100Continue, HttpClientContext context)
            : this(url, expect100Continue, context, false)
        {
        }

        /// <summary>
        /// 构造新的HttpClient实例
        /// </summary>
        /// <param name="url">要获取的资源的地址</param>
        /// <param name="expect100Continue">是否使用100-continue行为（默认为false，对于非IIS服务器向其POST数据时可能会出现471错误，将该参数设置为false可以避免这个问题）</param>
        /// <param name="context">Cookie及Referer</param>
        /// <param name="keepContext">是否自动在不同的请求间保留Cookie, Referer</param>
        public HttpClient(string url, bool expect100Continue, HttpClientContext context, bool keepContext)
        {
            ServicePointManager.Expect100Continue = expect100Continue;
            this.url = url;
            this.context = context;
            this.keepContext = keepContext;
            if (this.context == null)
                this.context = new HttpClientContext();
        }
        #endregion

        #region AttachFile
        /// <summary>
        /// 在请求中添加要上传的文件
        /// </summary>
        /// <param name="fileName">要上传的文件路径</param>
        /// <param name="fieldName">文件字段的名称(相当于&lt;input type=file name=fieldName&gt;)里的fieldName)</param>
        public void AttachFile(string fileName, string fieldName)
        {
            HttpUploadingFile file = new HttpUploadingFile(fileName, fieldName);
            files.Add(file);
        }

        /// <summary>
        /// 在请求中添加要上传的文件
        /// </summary>
        /// <param name="data">要上传的文件内容</param>
        /// <param name="fileName">文件名</param>
        /// <param name="fieldName">文件字段的名称(相当于&lt;input type=file name=fieldName&gt;)里的fieldName)</param>
        public void AttachFile(byte[] data, string fileName, string fieldName)
        {
            HttpUploadingFile file = new HttpUploadingFile(data, fileName, fieldName);
            files.Add(file);
        }
        #endregion

        /// <summary>
        /// 清空PostingData, Files, StartPoint, EndPoint, ResponseHeaders, 并把Verb设置为Get.
        /// 在发出一个包含上述信息的请求后,必须调用此方法或手工设置相应属性以使下一次请求不会受到影响.
        /// </summary>
        public void Reset()
        {
            verb = HttpVerb.GET;
            files.Clear();
            postingData.Clear();
            responseHeaders = null;
            startPoint = 0;
            endPoint = 0;
        }

        private HttpWebRequest CreateRequest()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.AllowAutoRedirect = false;
            req.CookieContainer = new CookieContainer();
            req.Headers.Add("Accept-Language", defaultLanguage);
            req.Accept = accept;
            req.UserAgent = userAgent;
            req.KeepAlive = false;

            if (Timeout > 0)
            {
                req.Timeout = Timeout;
            }

            if (context.Cookies != null)
                req.CookieContainer.Add(context.Cookies);
            if (!string.IsNullOrEmpty(context.Referer))
                req.Referer = context.Referer;

            if (verb == HttpVerb.HEAD)
            {
                req.Method = "HEAD";
                return req;
            }

            if (postingData.Count > 0 || files.Count > 0)
                verb = HttpVerb.POST;

            if (verb == HttpVerb.POST)
            {
                req.Method = "POST";

                MemoryStream memoryStream = new MemoryStream();
                StreamWriter writer = new StreamWriter(memoryStream);

                if (files.Count > 0)
                {
                    string newLine = "\r\n";
                    string boundary = Guid.NewGuid().ToString().Replace("-", "");
                    req.ContentType = "multipart/form-data; boundary=" + boundary;

                    foreach (string key in postingData.Keys)
                    {
                        writer.Write("--" + boundary + newLine);
                        writer.Write("Content-Disposition: form-data; name=\"{0}\"{1}{1}", key, newLine);
                        writer.Write(postingData[key] + newLine);
                    }

                    foreach (HttpUploadingFile file in files)
                    {
                        writer.Write("--" + boundary + newLine);
                        writer.Write(
                            "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"{2}",
                            file.FieldName,
                            file.FileName,
                            newLine
                            );
                        writer.Write("Content-Type: application/octet-stream" + newLine + newLine);
                        writer.Flush();
                        memoryStream.Write(file.Data, 0, file.Data.Length);
                        writer.Write(newLine);
                        writer.Write("--" + boundary + newLine);
                    }
                }
                else
                {
                    req.ContentType = "application/x-www-form-urlencoded";
                    StringBuilder sb = new StringBuilder();
                    foreach (string key in postingData.Keys)
                    {
                        sb.AppendFormat("{0}={1}&", HttpUtility.UrlEncode(key, requestEncoding), HttpUtility.UrlEncode(postingData[key], requestEncoding));
                    }
                    if (sb.Length > 0)
                        sb.Length--;
                    writer.Write(sb.ToString());
                }

                writer.Flush();

                using (Stream stream = req.GetRequestStream())
                {
                    memoryStream.WriteTo(stream);
                }
            }

            if (startPoint != 0 && endPoint != 0)
                req.AddRange(startPoint, endPoint);
            else if (startPoint != 0 && endPoint == 0)
                req.AddRange(startPoint);

            return req;
        }

        /// <summary>
        /// 发出一次新的请求,并返回获得的回应
        /// 调用此方法永远不会触发StatusUpdate事件.
        /// </summary>
        /// <returns>相应的HttpWebResponse</returns>
        public HttpWebResponse GetResponse()
        {
            HttpWebRequest req = CreateRequest();
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            responseHeaders = res.Headers;
            if (keepContext)
            {
                context.Cookies = res.Cookies;
                context.Referer = url;
            }
            return res;
        }

        /// <summary>
        /// 发出一次新的请求,并返回回应内容的流
        /// 调用此方法永远不会触发StatusUpdate事件.
        /// </summary>
        /// <returns>包含回应主体内容的流</returns>
        public Stream GetStream()
        {
            return GetResponse().GetResponseStream();
        }

        /// <summary>
        /// 发出一次新的请求,并以字节数组形式返回回应的内容
        /// 调用此方法会触发StatusUpdate事件
        /// </summary>
        /// <returns>包含回应主体内容的字节数组</returns>
        public byte[] GetBytes()
        {
            HttpWebResponse res = GetResponse();
            int length = (int)res.ContentLength;

            MemoryStream memoryStream = new MemoryStream();
            byte[] buffer = new byte[0x100];
            Stream rs = res.GetResponseStream();
            for (int i = rs.Read(buffer, 0, buffer.Length); i > 0; i = rs.Read(buffer, 0, buffer.Length))
            {
                memoryStream.Write(buffer, 0, i);
                OnStatusUpdate(new StatusUpdateEventArgs((int)memoryStream.Length, length));
            }
            rs.Close();

            return memoryStream.ToArray();
        }

        /// <summary>
        /// 发出一次新的请求,以Http头,或Html Meta标签,或DefaultEncoding指示的编码信息对回应主体解码
        /// 调用此方法会触发StatusUpdate事件
        /// </summary>
        /// <returns>解码后的字符串</returns>
        public string GetString()
        {
            byte[] data = GetBytes();
            string encodingName = GetEncodingFromHeaders();

            if (encodingName == null)
                encodingName = GetEncodingFromBody(data);

            Encoding encoding;
            if (encodingName == null)
                encoding = defaultEncoding;
            else
            {
                try
                {
                    encoding = Encoding.GetEncoding(encodingName);
                }
                catch (ArgumentException)
                {
                    encoding = defaultEncoding;
                }
            }
            return encoding.GetString(data);
        }

        /// <summary>
        /// 发出一次新的请求,对回应的主体内容以指定的编码进行解码
        /// 调用此方法会触发StatusUpdate事件
        /// </summary>
        /// <param name="encoding">指定的编码</param>
        /// <returns>解码后的字符串</returns>
        public string GetString(Encoding encoding)
        {
            byte[] data = GetBytes();
            return encoding.GetString(data);
        }

        private string GetEncodingFromHeaders()
        {
            string encoding = null;
            string contentType = responseHeaders["Content-Type"];
            if (contentType != null)
            {
                int i = contentType.IndexOf("charset=");
                if (i != -1)
                {
                    encoding = contentType.Substring(i + 8);
                }
            }
            return encoding;
        }

        private string GetEncodingFromBody(byte[] data)
        {
            string encodingName = null;
            string dataAsAscii = Encoding.ASCII.GetString(data);
            if (dataAsAscii != null)
            {
                int i = dataAsAscii.IndexOf("charset=");
                if (i != -1)
                {
                    int j = dataAsAscii.IndexOf("\"", i);
                    if (j != -1)
                    {
                        int k = i + 8;
                        encodingName = dataAsAscii.Substring(k, (j - k) + 1);
                        char[] chArray = new char[2] { '>', '"' };
                        encodingName = encodingName.TrimEnd(chArray);
                    }
                }
            }
            return encodingName;
        }

        /// <summary>
        /// 发出一次新的Head请求,获取资源的长度
        /// 此请求会忽略PostingData, Files, StartPoint, EndPoint, Verb
        /// </summary>
        /// <returns>返回的资源长度</returns>
        public int HeadContentLength()
        {
            Reset();
            HttpVerb lastVerb = verb;
            verb = HttpVerb.HEAD;
            using (HttpWebResponse res = GetResponse())
            {
                verb = lastVerb;
                return (int)res.ContentLength;
            }
        }

        /// <summary>
        /// 发出一次新的请求,把回应的主体内容保存到文件
        /// 调用此方法会触发StatusUpdate事件
        /// 如果指定的文件存在,它会被覆盖
        /// </summary>
        /// <param name="fileName">要保存的文件路径</param>
        public void SaveToFile(string fileName)
        {
            SaveToFile(fileName, FileExistsAction.Overwrite);
        }

        /// <summary>
        /// 发出一次新的请求,把回应的主体内容保存到文件
        /// 调用此方法会触发StatusUpdate事件
        /// </summary>
        /// <param name="fileName">要保存的文件路径</param>
        /// <param name="existsAction">指定的文件存在时的选项</param>
        /// <returns>是否向目标文件写入了数据</returns>
        public bool SaveToFile(string fileName, FileExistsAction existsAction)
        {
            byte[] data = GetBytes();
            switch (existsAction)
            {
                case FileExistsAction.Overwrite:
                    using (BinaryWriter writer = new BinaryWriter(new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write)))
                        writer.Write(data);
                    return true;

                case FileExistsAction.Append:
                    using (BinaryWriter writer = new BinaryWriter(new FileStream(fileName, FileMode.Append, FileAccess.Write)))
                        writer.Write(data);
                    return true;

                default:
                    if (!File.Exists(fileName))
                    {
                        using (
                            BinaryWriter writer =
                                new BinaryWriter(new FileStream(fileName, FileMode.Create, FileAccess.Write)))
                            writer.Write(data);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }
        }
    }

    public class HttpClientContext
    {
        private CookieCollection cookies;
        private string referer;

        public CookieCollection Cookies
        {
            get { return cookies; }
            set { cookies = value; }
        }

        public string Referer
        {
            get { return referer; }
            set { referer = value; }
        }
    }

    public enum HttpVerb
    {
        GET,
        POST,
        HEAD,
    }

    public enum FileExistsAction
    {
        Overwrite,
        Append,
        Cancel,
    }

    public class HttpUploadingFile
    {
        private string fileName;
        private string fieldName;
        private byte[] data;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public string FieldName
        {
            get { return fieldName; }
            set { fieldName = value; }
        }

        public byte[] Data
        {
            get { return data; }
            set { data = value; }
        }

        public HttpUploadingFile(string fileName, string fieldName)
        {
            this.fileName = fileName;
            this.fieldName = fieldName;
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                byte[] inBytes = new byte[stream.Length];
                stream.Read(inBytes, 0, inBytes.Length);
                data = inBytes;
            }
        }

        public HttpUploadingFile(byte[] data, string fileName, string fieldName)
        {
            this.data = data;
            this.fileName = fileName;
            this.fieldName = fieldName;
        }
    }

    public class StatusUpdateEventArgs : EventArgs
    {
        private readonly int bytesGot;
        private readonly int bytesTotal;

        public StatusUpdateEventArgs(int got, int total)
        {
            bytesGot = got;
            bytesTotal = total;
        }

        /// <summary>
        /// 已经下载的字节数
        /// </summary>
        public int BytesGot
        {
            get { return bytesGot; }
        }

        /// <summary>
        /// 资源的总字节数
        /// </summary>
        public int BytesTotal
        {
            get { return bytesTotal; }
        }
    }
}
