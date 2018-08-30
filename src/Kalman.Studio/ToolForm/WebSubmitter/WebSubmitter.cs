using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Web;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Kalman.Net;

namespace Kalman.Studio
{
    public partial class WebSubmitter : DockableForm
    {
        static Dictionary<string, string> dicParams = new Dictionary<string, string>(); //用于保存请求参数
        static Dictionary<string, RequestInfo> dic = new Dictionary<string, RequestInfo>();

        public WebSubmitter()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string paramName = txtPName.Text.Trim();
            string paramValue = txtPValue.Text.Trim();

            AddParam(paramName, paramValue);
            BindParams();
        }

        public void SetUrl(string url)
        {
            txtUrl.Text = url;
        }

        public void AddParam(string paramName, string paramValue)
        {
            if (paramName == string.Empty) return;

            if (dicParams.ContainsKey(paramName)) dicParams[paramName] = paramValue;
            else dicParams.Add(paramName, paramValue);
        }

        public void BindParams()
        {
            lbParams.Items.Clear();

            foreach (KeyValuePair<string, string> kvp in dicParams)
            {
                lbParams.Items.Add(string.Format("{0}|{1}", kvp.Key, kvp.Value));
            }

            txtPName.Text = string.Empty;
            txtPValue.Text = string.Empty;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveParam();
        }

        private void RemoveParam()
        {
            object obj = lbParams.SelectedItem;
            if (obj == null) return;

            string paramName = obj.ToString().Split('|')[0];

            dicParams.Remove(paramName);
            BindParams();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUrl.Text.Trim() == string.Empty)
            {
                MsgBox.Show("请求地址不能为空");
                return;
            }

            DialogResult result = MsgBox.ShowQuestionMessage("是否提交当前请求", "确认提交请求");
            if (result != DialogResult.Yes) return;

            DoSubmit();
        }

        void DoSubmit()
        {
            RequestInfo ri = new RequestInfo();
            ri.Url = txtUrl.Text.Trim();
            ri.IsPost = cbIsPost.Checked;
            ri.Params = new Dictionary<string, string>();
            ri.RequestTime = DateTime.Now;

            foreach (KeyValuePair<string,string> kvp in dicParams)
            {
                ri.Params.Add(kvp.Key, kvp.Value);
            }

            rtbResponse.Text = string.Format("正在向{0}提交请求...",ri.FullUrl);

            HttpClient hc;
            string responseText = string.Empty;

            if (ri.IsPost)
            {
                //ServicePointManager.Expect100Continue = false;
                hc = new HttpClient(ri.Url);
                hc.Verb = HttpVerb.POST;
                hc.RequestEncoding = GetRequestEncoding();

                foreach (KeyValuePair<string,string> kvp in ri.Params)
                {
                    hc.PostingData.Add(kvp.Key, kvp.Value);
                }

                responseText = hc.GetString();
            }
            else
            {
                hc = new HttpClient(ri.FullUrl);
                hc.RequestEncoding = GetRequestEncoding();
                responseText = hc.GetString();
            }

            rtbResponse.Text = responseText;
            lbHistory.Items.Add(ri.ToString());
            dic.Add(ri.ToString(), ri);
            webBrowser1.DocumentText = responseText;
            this.Clear();
        }

        void Clear()
        {
            txtUrl.Text = string.Empty;
            txtPName.Text = string.Empty;
            txtPValue.Text = string.Empty;
            cbIsPost.Checked = false;
            dicParams.Clear();
            lbParams.Items.Clear();
        }

        Encoding GetRequestEncoding()
        {
            if (rbtnDefault.Checked) return Encoding.Default;
            if (rbtnGB2312.Checked) return Encoding.GetEncoding("gb2312");
            if (rbtnUTF8.Checked) return Encoding.UTF8;
            if (rbtnUnicode.Checked) return Encoding.Unicode;
            if (rbtnOther.Checked && txtEncode.Text.Trim().Length > 0) return Encoding.GetEncoding(txtEncode.Text);

            return Encoding.UTF8;
        }

        private void lbParams_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            object obj = lbParams.SelectedItem;
            if (obj == null) return;

            txtPName.Text = obj.ToString().Split('|')[0];
            txtPValue.Text = obj.ToString().Split('|')[1];
        }

        private void lbHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RequestInfo ri = dic[lbHistory.SelectedItem.ToString()];
            if (ri == null) return;

            this.txtUrl.Text = ri.Url;
            cbIsPost.Checked = ri.IsPost;
            //dicParams = ri.Params;

            dicParams.Clear();
            foreach (KeyValuePair<string,string> kvp in ri.Params)
            {
                dicParams.Add(kvp.Key, kvp.Value);
            }
            BindParams();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        #region RequestInfo
        /// <summary>
        /// 请求信息
        /// </summary>
        class RequestInfo
        {
            /// <summary>
            /// 请求地址
            /// </summary>
            public string Url { get; set; }

            /// <summary>
            /// 是否已Post方式提交
            /// </summary>
            public bool IsPost { get; set; }

            public DateTime RequestTime { get; set; }

            /// <summary>
            /// 参数集合
            /// </summary>
            public Dictionary<string,string> Params { get; set; }

            public string QueryString
            {
                get
                {
                    if (this.Params == null || this.Params.Count == 0) return string.Empty;
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (KeyValuePair<string,string> kvp in this.Params)
                        {
                            sb.Append(string.Format("{0}={1}&", kvp.Key, HttpUtility.UrlEncode(kvp.Value)));
                        }

                        return sb.ToString().Trim('&');
                    }
                }
            }

            public string FullUrl
            {
                get
                {
                    if (this.IsPost == true || this.Params == null || this.Params.Count == 0) return this.Url;
                    else
                    {
                        if (this.Url.IndexOf("?") == -1)
                        {
                            return string.Format("{0}?{1}", this.Url, this.QueryString);
                        }
                        else
                        {
                            return string.Format("{0}&{1}", this.Url, this.QueryString); 
                        }
                    }
                }
            }

            public override string ToString()
            {
                if (IsPost == false)
                {
                    return string.Format("{0}->{1}", this.RequestTime.ToString("yyyy-MM-dd HH:mm:ss:fff"), this.FullUrl);
                }
                else

                    return string.Format("{0}->{1}[PostData:{2}]", this.RequestTime.ToString("yyyy-MM-dd HH:mm:ss:fff"), this.Url,this.QueryString);
                }
        }
        #endregion

        string path = Path.Combine(Application.StartupPath, "config\\RequestHistory.json");
        private void WebSubmitter_Load(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                dic = JsonConvert.DeserializeObject<Dictionary<string, RequestInfo>>(File.ReadAllText(path));

                foreach (KeyValuePair<string,RequestInfo> kvp in dic)
                {
                    lbHistory.Items.Add(kvp.Key);
                }
            }
        }

        private void WebSubmitter_FormClosing(object sender, FormClosingEventArgs e)
        {
            string s = JsonConvert.SerializeObject(dic);
            File.WriteAllText(path, s, Encoding.UTF8);
        }

        private void lbHistory_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //lbHistory.se
            }
        }

        private void menuItemRemoveHistory_Click(object sender, EventArgs e)
        {
            if (lbHistory.SelectedItem != null)
            {
                string s = lbHistory.SelectedItem.ToString();
                dic.Remove(s);

                lbHistory.Items.Remove(s);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportPostParams import = new ImportPostParams();
            import.ShowDialog(this);
        }


        
    }
}
