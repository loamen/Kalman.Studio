using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Kalman.Studio
{
    public partial class Output : DockExplorer
    {
        delegate void AppendTextCallback(string text);

        public Output()
        {
            InitializeComponent();
        }

        public void AppendText(string text)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                AppendTextCallback d = new AppendTextCallback(AppendText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                if (string.IsNullOrEmpty(text)) return;
                richTextBox1.AppendText(text);
            }
        }

        /// <summary>
        /// 向输出窗口追加一行文本
        /// </summary>
        /// <param name="s"></param>
        public void AppendLine(string text)
        {
            AppendText(text + Environment.NewLine);
        }

        /// <summary>
        /// 清除所有输出文本
        /// </summary>
        public void ClearText()
        {
            richTextBox1.Clear();
        }

        private void menuItemCopy_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void menuItemClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void menuItemSelectAll_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }
    }
}
