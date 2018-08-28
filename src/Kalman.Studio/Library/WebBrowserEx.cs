using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Loamen.WinControls.UI
{
    /// <summary>
    ///     错误编码
    /// </summary>
    public enum ErrorCodes : long
    {
        HTTP_STATUS_BAD_REQUEST = 400,
        HTTP_STATUS_DENIED = 401,
        HTTP_STATUS_PAYMENT_REQ = 402,
        HTTP_STATUS_FORBIDDEN = 403,
        HTTP_STATUS_NOT_FOUND = 404,
        HTTP_STATUS_BAD_METHOD = 405,
        HTTP_STATUS_NONE_ACCEPTABLE = 406,
        HTTP_STATUS_PROXY_AUTH_REQ = 407,
        HTTP_STATUS_REQUEST_TIMEOUT = 408,
        HTTP_STATUS_CONFLICT = 409,
        HTTP_STATUS_GONE = 410,
        HTTP_STATUS_LENGTH_REQUIRED = 411,
        HTTP_STATUS_PRECOND_FAILED = 412,
        HTTP_STATUS_REQUEST_TOO_LARGE = 413,
        HTTP_STATUS_URI_TOO_LONG = 414,
        HTTP_STATUS_UNSUPPORTED_MEDIA = 415,
        HTTP_STATUS_RETRY_WITH = 449,
        HTTP_STATUS_SERVER_ERROR = 500,
        HTTP_STATUS_NOT_SUPPORTED = 501,
        HTTP_STATUS_BAD_GATEWAY = 502,
        HTTP_STATUS_SERVICE_UNAVAIL = 503,
        HTTP_STATUS_GATEWAY_TIMEOUT = 504,
        HTTP_STATUS_VERSION_NOT_SUP = 505,

        INET_E_INVALID_URL = 0x800C0002L,
        INET_E_NO_SESSION = 0x800C0003L,
        INET_E_CANNOT_CONNECT = 0x800C0004L,
        INET_E_RESOURCE_NOT_FOUND = 0x800C0005L,
        INET_E_OBJECT_NOT_FOUND = 0x800C0006L,
        INET_E_DATA_NOT_AVAILABLE = 0x800C0007L,
        INET_E_DOWNLOAD_FAILURE = 0x800C0008L,
        INET_E_AUTHENTICATION_REQUIRED = 0x800C0009L,
        INET_E_NO_VALID_MEDIA = 0x800C000AL,
        INET_E_CONNECTION_TIMEOUT = 0x800C000BL,
        INET_E_INVALID_REQUEST = 0x800C000CL,
        INET_E_UNKNOWN_PROTOCOL = 0x800C000DL,
        INET_E_SECURITY_PROBLEM = 0x800C000EL,
        INET_E_CANNOT_LOAD_DATA = 0x800C000FL,
        INET_E_CANNOT_INSTANTIATE_OBJECT = 0x800C0010L,
        INET_E_REDIRECT_FAILED = 0x800C0014L,
        INET_E_REDIRECT_TO_DIR = 0x800C0015L,
        INET_E_CANNOT_LOCK_REQUEST = 0x800C0016L,
        INET_E_USE_EXTEND_BINDING = 0x800C0017L,
        INET_E_TERMINATED_BIND = 0x800C0018L,
        INET_E_INVALID_CERTIFICATE = 0x800C0019L,
        INET_E_CODE_DOWNLOAD_DECLINED = 0x800C0100L,
        INET_E_RESULT_DISPATCHED = 0x800C0200L,
        INET_E_CANNOT_REPLACE_SFP_FILE = 0x800C0300L,
        INET_E_CODE_INSTALL_BLOCKED_BY_HASH_POLICY = 0x800C0500L,
        INET_E_CODE_INSTALL_SUPPRESSED = 0x800C0400L
    }

    public class WebBrowserExtendedNavigatingEventArgs : CancelEventArgs
    {
        private readonly string _Frame;
        private readonly string _Url;

        public WebBrowserExtendedNavigatingEventArgs(string url, string frame)
        {
            _Url = url;
            _Frame = frame;
        }

        public string Url
        {
            get { return _Url; }
        }

        public string Frame
        {
            get { return _Frame; }
        }
    }

    public class WebBrowserNavigateErrorEventArgs : EventArgs
    {
        public WebBrowserNavigateErrorEventArgs(
            string url, string frame, Int32 statusCode, Boolean cancel)
        {
            Url = url;
            Frame = frame;
            StatusCode = statusCode;
            Cancel = cancel;
        }

        public string Url { get; set; }

        public string Frame { get; set; }

        public Int32 StatusCode { get; set; }

        public Boolean Cancel { get; set; }
    }


    internal struct Struct_INTERNET_PROXY_INFO
    {
        public int dwAccessType;
        public IntPtr proxy;
        public IntPtr proxyBypass;
    }

    public class WebBrowserEx : WebBrowser
    {
        #region valiable

        private const int INTERNET_OPTION_PROXY = 38;
        private const int INTERNET_OPEN_TYPE_PROXY = 3;
        private const int URLMON_OPTION_USERAGENT = 0x10000001;
        private const int INTERNET_OPEN_TYPE_DIRECT = 1;
        public Label ProxyLabel = new Label();

        /// <summary>
        ///     显示当前代理信息
        /// </summary>
        public Label StatusLabel = new Label();

        private AxHost.ConnectionPointCookie cookie;
        private WebBrowserExtendedEvents events;

        [DllImport("urlmon.dll", CharSet = CharSet.Ansi)]
        private static extern int UrlMkSetSessionOption(int dwOption, string pBuffer, int dwBufferLength, int dwReserved);

        [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer,
                                                     int lpdwBufferLength);

        #endregion

        public WebBrowserEx()
        {
            AddStatusLabel("");
            AddProxyLabel("");
            AfterProxyChanged += WebBrowserEx_ProxyChanged;
        }

        protected void AddStatusLabel(string text)
        {
            if (StatusLabel == null || StatusLabel.Name != "StatusLabel")
            {
                StatusLabel.AutoSize = true;
                StatusLabel.Name = "StatusLabel";
                StatusLabel.Size = new Size(77, 12);
                StatusLabel.Left = 0;
                StatusLabel.Visible = false;
                Controls.Add(StatusLabel);
            }
            StatusLabel.Top = Height - StatusLabel.Height;
            StatusLabel.Text = text;
        }

        protected void AddProxyLabel(string text)
        {
            if (ProxyLabel == null || ProxyLabel.Name != "ProxyLable")
            {
                ProxyLabel.AutoSize = true;
                ProxyLabel.Name = "StatusLabel";
                ProxyLabel.Size = new Size(77, 12);
                ProxyLabel.Left = 0;
                ProxyLabel.Visible = false;
                Controls.Add(ProxyLabel);
            }
            ProxyLabel.Top = 0;
            ProxyLabel.Text = text;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            StatusLabel.Top = Height - StatusLabel.Height;
            StatusLabel.Left = 0;

            ProxyLabel.Top = 0;
            ProxyLabel.Left = 0;
        }

        #region Set User-Agent

        private string defaultUserAgent;

        /// <summary>
        ///     User-Agent
        /// </summary>
        public string UserAgent
        {
            get
            {
                if (string.IsNullOrEmpty(defaultUserAgent))
                    defaultUserAgent = GetDefaultUserAgent();
                return defaultUserAgent;
            }
            set
            {
                defaultUserAgent = value;
                SetUserAgent(defaultUserAgent);
            }
        }

        /// <summary>
        ///     在默认的UserAgent后面加一部分
        /// </summary>
        public void AppendUserAgent(string appendUserAgent)
        {
            if (string.IsNullOrEmpty(defaultUserAgent))
                defaultUserAgent = GetDefaultUserAgent();

            string ua = defaultUserAgent + ";" + appendUserAgent;
            SetUserAgent(ua);
        }

        /// <summary>
        ///     修改UserAgent
        /// </summary>
        public void SetUserAgent(string userAgent)
        {
            UrlMkSetSessionOption(URLMON_OPTION_USERAGENT, userAgent, userAgent.Length, 0);
            defaultUserAgent = userAgent;
        }

        /// <summary>
        ///     一个很BT的获取IE默认UserAgent的方法
        /// </summary>
        private static string GetDefaultUserAgent()
        {
            var wb = new WebBrowser();
            wb.Navigate("about:blank");
            while (wb.IsBusy) Application.DoEvents();
            object window = wb.Document.Window.DomWindow;
            Type wt = window.GetType();
            object navigator = wt.InvokeMember("navigator", BindingFlags.GetProperty,
                                               null, window, new object[] {});
            Type nt = navigator.GetType();
            object userAgent = nt.InvokeMember("userAgent", BindingFlags.GetProperty,
                                               null, navigator, new object[] {});
            return userAgent.ToString();
        }

        #endregion

        #region SetProxy

        //定义的委托
        public delegate void OnProxyChanged(object sender, EventArgs e);

        private string _proxyServer;

        /// <summary>
        ///     Get or set proxy of WebBrowser.
        /// </summary>
        public string ProxyServer
        {
            get { return _proxyServer; }
            set
            {
                _proxyServer = value;
                SetProxy(value);

                //如果变量改变则调用事件触发函数
                WhenProxyChanged();
            }
        }

        /// <summary>
        ///     当代理改变时
        /// </summary>
        [Description("当代理改变时触发。")]
        public event OnProxyChanged AfterProxyChanged;

        private void WebBrowserEx_ProxyChanged(object sender, EventArgs e)
        {
            //do something
        }

        private void WhenProxyChanged()
        {
            if (AfterProxyChanged != null)
            {
                AfterProxyChanged(this, new EventArgs());
            }
        }

        /// <summary>
        ///     Set proxy for WebBrowser.
        /// </summary>
        /// <param name="Proxy"></param>
        private void SetProxy(string proxyServer)
        {
            Struct_INTERNET_PROXY_INFO struct_IPI;
            if (!string.IsNullOrEmpty(proxyServer))
            {
                // Filling in structure 
                struct_IPI.dwAccessType = INTERNET_OPEN_TYPE_PROXY;
                struct_IPI.proxy = Marshal.StringToHGlobalAnsi(proxyServer);
                struct_IPI.proxyBypass = Marshal.StringToHGlobalAnsi("local");
                // Allocating memory 
                IntPtr intptrStruct = Marshal.AllocCoTaskMem(Marshal.SizeOf(struct_IPI));
                // Converting structure to IntPtr 
                Marshal.StructureToPtr(struct_IPI, intptrStruct, true);
                bool iReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_PROXY, intptrStruct,
                                                 Marshal.SizeOf(struct_IPI));
                _proxyServer = proxyServer;
                ProxyLabel.Text = "Current Proxy:" + _proxyServer;
                ProxyLabel.Visible = true;
            }
            else
            {
                struct_IPI.dwAccessType = INTERNET_OPEN_TYPE_DIRECT;
                struct_IPI.proxy = Marshal.StringToHGlobalAnsi("");
                struct_IPI.proxyBypass = Marshal.StringToHGlobalAnsi("");
                // Allocating memory 
                IntPtr intptrStruct = Marshal.AllocCoTaskMem(Marshal.SizeOf(struct_IPI));
                // Converting structure to IntPtr 
                Marshal.StructureToPtr(struct_IPI, intptrStruct, true);
                bool iReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_PROXY, intptrStruct,
                                                 Marshal.SizeOf(struct_IPI));
                _proxyServer = proxyServer;
                ProxyLabel.Text = _proxyServer;
                ProxyLabel.Visible = false;
            }
        }

        #endregion

        #region

        public delegate void WebBrowserNavigateErrorEventHandler(object sender,
                                                                 WebBrowserNavigateErrorEventArgs e);

        public event WebBrowserNavigateErrorEventHandler NavigateError;

        // Raises the NavigateError event.
        protected virtual void OnNavigateError(
            WebBrowserNavigateErrorEventArgs e)
        {
            if (NavigateError != null)
            {
                NavigateError(this, e);
            }
        }

        #endregion

        #region

        protected override void OnStatusTextChanged(EventArgs e)
        {
            base.OnStatusTextChanged(e);
        }

        //This method will be called to give you a chance to create your own event sink
        protected override void CreateSink()
        {
            //MAKE SURE TO CALL THE BASE or the normal events won't fire
            base.CreateSink();
            events = new WebBrowserExtendedEvents(this);
            cookie = new AxHost.ConnectionPointCookie(ActiveXInstance, events, typeof (DWebBrowserEvents2));
        }

        protected override void DetachSink()
        {
            if (null != cookie)
            {
                cookie.Disconnect();
                cookie = null;
            }
            base.DetachSink();
        }

        //This new event will fire when the page is navigating
        public event EventHandler BeforeNavigate;
        public event EventHandler BeforeNewWindow;

        protected void OnBeforeNewWindow(string url, out bool cancel)
        {
            EventHandler h = BeforeNewWindow;
            var args = new WebBrowserExtendedNavigatingEventArgs(url, null);
            if (null != h)
            {
                h(this, args);
            }
            cancel = args.Cancel;
        }

        protected void OnBeforeNavigate(string url, string frame, out bool cancel)
        {
            EventHandler h = BeforeNavigate;
            var args = new WebBrowserExtendedNavigatingEventArgs(url, frame);
            if (null != h)
            {
                h(this, args);
            }
            //Pass the cancellation chosen back out to the events
            cancel = args.Cancel;
        }

        #endregion

        #region //This class will capture events from the WebBrowser

        private class WebBrowserExtendedEvents : StandardOleMarshalObject, DWebBrowserEvents2
        {
            private readonly WebBrowserEx _Browser;

            public WebBrowserExtendedEvents(WebBrowserEx browser)
            {
                _Browser = browser;
            }

            //Implement whichever events you wish
            public void BeforeNavigate2(object pDisp, ref object URL, ref object flags, ref object targetFrameName,
                                        ref object postData, ref object headers, ref bool cancel)
            {
                _Browser.OnBeforeNavigate((string) URL, (string) targetFrameName, out cancel);
            }

            public void NewWindow3(object pDisp, ref bool cancel, ref object flags, ref object URLContext,
                                   ref object URL)
            {
                _Browser.OnBeforeNewWindow((string) URL, out cancel);
            }

            public void NavigateError(object pDisp, ref object url,
                                      ref object frame, ref object statusCode, ref bool cancel)
            {
                //Raise the NavigateError event.
                _Browser.OnNavigateError(
                    new WebBrowserNavigateErrorEventArgs(
                        (string) url, (string) frame, (Int32) statusCode, cancel));
            }
        }

        #endregion

        #region

        [ComImport, Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D"),
         InterfaceType(ComInterfaceType.InterfaceIsIDispatch),
         TypeLibType(TypeLibTypeFlags.FHidden)]
        public interface DWebBrowserEvents2
        {
            [DispId(250)]
            void BeforeNavigate2(
                [In,
                 MarshalAs(UnmanagedType.IDispatch)] object pDisp,
                [In] ref object URL,
                [In] ref object flags,
                [In] ref object targetFrameName, [In] ref object postData,
                [In] ref object headers,
                [In,
                 Out] ref bool cancel);

            [DispId(273)]
            void NewWindow3(
                [In,
                 MarshalAs(UnmanagedType.IDispatch)] object pDisp,
                [In, Out] ref bool cancel,
                [In] ref object flags,
                [In] ref object URLContext,
                [In] ref object URL);

            [DispId(271)]
            void NavigateError(
                [In, MarshalAs(UnmanagedType.IDispatch)] object pDisp,
                [In] ref object URL, [In] ref object frame,
                [In] ref object statusCode, [In, Out] ref bool cancel);
        }

        #endregion

        #region

        /// <summary>
        ///     设置INTERNET选项
        /// </summary>
        public void SetInternetOption()
        {
            var p = new Process();
            p.StartInfo = new ProcessStartInfo("rundll32.exe", "shell32.dll,Control_RunDLL inetcpl.cpl");
            p.Start();
        }

        #endregion
    }
}