using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kalman.Studio
{
    public partial class StringConnector : DockableForm
    {
        static readonly string paramFormat = "$(RowText)";

        public StringConnector()
        {
            InitializeComponent();
        }

        private void StringConnector_Load(object sender, EventArgs e)
        {
            rtb.AppendText("StringBuilder sb = new StringBuilder();\r\n");
            rtb.AppendText(string.Format("sb.AppendLine(\"{0}\");", paramFormat));

            rtb1.AppendText("这是一个字符串拼接工具" + Environment.NewLine);
            rtb1.AppendText("请在左边文本框编辑模板" + Environment.NewLine);
            rtb1.AppendText("模板文本中参数\"$(RowText)\"将会被原始文本中的每行文本所替换" + Environment.NewLine);
            rtb1.AppendText("请在右下方文本框中输入要替换的字符" + Environment.NewLine);
            rtb1.AppendText("格式：字符1,替换字符1|字符2,替换字符2|..." + Environment.NewLine);
            rtb1.AppendText("如果要替换转义符号，请将转义符号放在最前面" + Environment.NewLine);
            rtb1.AppendText("如：右下方文本框中的示例中就把\"\\,\\\\\"放在最前面" + Environment.NewLine);
            rtb1.AppendText("点击生成按钮，左下方文本框中会输出根据模板格式化后的代码");
            //rtb.AppendText("" + Environment.NewLine);
            //rtb.AppendText("" + Environment.NewLine);
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            rtb2.Clear();
            if (rtb.Text.Trim().Length == 0) return;

            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (txtChars.Text.Contains(","))//保证至少有一个替换项
            {
                string[] chars = txtChars.Text.Split('|');
                foreach (string s in chars)
                {
                    dic.Add(s.Split(',')[0], s.Split(',')[1]);
                }
            }

            string[] ss1 = rtb1.Lines;  //原始文本
            string[] ss = rtb.Lines;    //模板

            foreach (string s in ss)
            {
                if (s.Contains(paramFormat))
                {
                    foreach (string s1 in ss1)
                    {
                        string str = s1;
                        foreach (KeyValuePair<string, string> kvp in dic)
                        {
                            str = str.Replace(kvp.Key, kvp.Value);
                        }

                        str = s.Replace(paramFormat, str);

                        rtb2.AppendText(str);
                        rtb2.AppendText(Environment.NewLine);
                    }
                }
                else
                {
                    rtb2.AppendText(s);
                    rtb2.AppendText(Environment.NewLine);
                }
            }



        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
