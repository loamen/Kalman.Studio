using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalman.Studio
{
    public partial class Terminal : DockExplorer
    {
        delegate void AppendTextCallback(string text);
        delegate void RunAppCallback(string appName, string workingDirectory = null);

        public Terminal()
        {
            InitializeComponent();
        }

        public void AppendText(string text)
        {
            if (this.rtbCommand.InvokeRequired)
            {
                AppendTextCallback d = new AppendTextCallback(AppendText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                if (string.IsNullOrEmpty(text)) return;
                rtbCommand.AppendText(text);
            }
        }

        public void RunApp(string appName, string workingDirectory = null)
        {
            if (this.rtbCommand.InvokeRequired)
            {
                RunAppCallback d = new RunAppCallback(RunApp);
                this.Invoke(d, new object[] { appName,workingDirectory });
            }
            else
            {
                if (string.IsNullOrEmpty(appName)) return;
                rtbCommand.RunApp(appName,workingDirectory);
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

        private void Terminal_Load(object sender, EventArgs e)
        {
            rtbCommand.Exit += new Command.RichConsoleBox.ExitEventHandler(rtbCommand_Exit);
        }

        private void rtbCommand_Exit(object sender, System.EventArgs e)
        {
            Config.MainForm.ShowTerminal(true);
        }

        private void menuItemPaste_Click(object sender, EventArgs e)
        {
            rtbCommand.Paste();
        }

        private void menuItemCopy_Click(object sender, EventArgs e)
        {
            rtbCommand.Copy();
        }

        private void menuItemClear_Click(object sender, EventArgs e)
        {
            rtbCommand.Clear();
        }

        private void menuItemSelectAll_Click(object sender, EventArgs e)
        {
            rtbCommand.SelectAll();
        }
    }
}
