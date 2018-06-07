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
        public Output()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 向输出窗口追加一行文本
        /// </summary>
        /// <param name="s"></param>
        public void AppendLine(string s)
        {
            if (string.IsNullOrEmpty(s)) return;
            richTextBox1.AppendText(s + Environment.NewLine);
        }

        public void AppendText(string s)
        {
            if (string.IsNullOrEmpty(s)) return;
            richTextBox1.AppendText(s);
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
