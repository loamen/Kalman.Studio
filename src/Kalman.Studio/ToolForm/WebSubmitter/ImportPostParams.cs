using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kalman.Utilities;
using System.Web;

namespace Kalman.Studio
{
    public partial class ImportPostParams : Form
    {
        public ImportPostParams()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            WebSubmitter owner = this.Owner as WebSubmitter;

            string s = richTextBox1.Text;

            if (s.IndexOf("?") != -1)
            {
                string[] arr = s.Split('?');
                owner.SetUrl(arr[0]);
                s = arr[1];
            }

            string separator1 = txtSeparator1.Text; //参数分隔符号
            string separator2 = txtSeparator2.Text; //键值分隔符号
            bool isTrim = cbTrim.Checked;   //是否移除参数及其值的首尾空格
            bool isUrlDecode = cbUrlDecode.Checked; //是否对原始字符串进行Url解码
            bool mutilRow = cbMutilRow.Checked;

            if (isUrlDecode) s = HttpUtility.UrlDecode(s);

            //如果分隔符有转义符的时候，需要处理一下
            separator1 = separator1.Replace("\\\\", "\\");
            separator2 = separator2.Replace("\\\\", "\\");

            string[] paramItems = s.Split(new string[]{separator1}, StringSplitOptions.None);
            if (mutilRow) paramItems = richTextBox1.Lines;

            foreach (string item in paramItems)
            {
                string[] ss = item.Split(separator2.ToCharArray());
                string name = ss[0];
                string value = ss.Length > 1 ? ss[1] : string.Empty;

                if (isTrim)
                {
                    name = name.Trim();
                    value = value.Trim();
                }

                owner.AddParam(name, value);
            }

            owner.BindParams();
            this.Close();
        }
    }
}
