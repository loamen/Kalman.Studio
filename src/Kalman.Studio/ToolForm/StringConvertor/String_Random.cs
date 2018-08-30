using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kalman.Utilities;
using System.Collections.Specialized;
using System.IO;

namespace Kalman.Studio
{
    public partial class String_Random : StringConvertorBase
    {
        public String_Random()
        {
            InitializeComponent();
        }
        
        private void String_Random_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 33; i < 127; i++)
            {
                string s = ((char)i).ToString();
                sb.Append(s);
            }

            txtCharList.Text = sb.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int len = (int)numLength.Value;
            string dic = "0123456789";

            if (cbCustomBuild.Checked)
            {
                dic = txtCharList.Text.Trim();
                if (dic.Length == 0)
                {
                    MsgBox.Show("使用自定义生成时，字典内容不能为空");
                    return;
                }
            }
            else
            {
                if (cbLower.Checked) dic = string.Concat(dic, "abcdefghijklmnopqrstuvwxyz");
                if (cbCapital.Checked) dic = string.Concat(dic, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                if (cbSymbol.Checked) dic = string.Concat(dic, "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~");
            }

            int count = (int)numCount.Value;
            string split = txtSplit.Text.Trim();
            int capacity = (int)(count * (numLength.Value + split.Length));
            StringCollection sc = new StringCollection();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                string s = RandomUtil.BuildRandomString(len, dic);

                if (sc.Contains(s)) 
                {
                    continue;
                }
                sc.Add(s);
                
            }

            foreach (var item in sc)
            {
                sb.Append(item);
                sb.Append(split);
            }

            if (cbSaveToFile.Checked)
            {
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileName = saveFileDialog1.FileName;
                    File.AppendAllText(fileName, sb.ToString());
                    SC.S2 = "数据已保存到文件：" + fileName;
                }
                else
                {
                    return;
                }
            }
            else
            {
                SC.S2 = sb.ToString();
            }
            this.Close();
        }

        

    }
}
