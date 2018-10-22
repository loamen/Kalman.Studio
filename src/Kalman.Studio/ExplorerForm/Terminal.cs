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
            rtbCommand.Clear();
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

        private void rtbCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Before the process starts, create a new stringbuilder
                var m_output = new StringBuilder();

                e.Handled = true;
                e.SuppressKeyPress = true;
                ProcessStartInfo cmdStartInfo = new ProcessStartInfo();
                cmdStartInfo.FileName = @"C:\Windows\System32\cmd.exe";
                cmdStartInfo.RedirectStandardOutput = true;
                cmdStartInfo.RedirectStandardError = true;
                cmdStartInfo.RedirectStandardInput = true;
                cmdStartInfo.UseShellExecute = false;
                cmdStartInfo.CreateNoWindow = true;

                Process cmdProcess = new Process();
                cmdProcess.StartInfo = cmdStartInfo;
                //cmdProcess.OutputDataReceived += cmd_DataReceived;
                cmdProcess.EnableRaisingEvents = true;
                cmdProcess.Start();
                cmdProcess.BeginOutputReadLine();
                cmdProcess.BeginErrorReadLine();

                cmdProcess.StandardInput.WriteLine(rtbCommand.Text);
                cmdProcess.StandardInput.WriteLine("exit");

                cmdProcess.WaitForExit();

                // And now that everything's done, just set the text
                // to whatever's in the stringbuilder
                //rtbCommand.Text = m_output.ToString();

                // We're done with the stringbuilder, let the garbage
                // collector free it
                m_output = null;
            }
        }

        // Note: This is no longer a static method so it has
        // access to the member variables, including m_output
        void cmd_DataReceived(object sender, DataReceivedEventArgs e)
        {
            Debug.WriteLine("Output from other process");
            Debug.WriteLine(e.Data);

            // Add the data, one line at a time, to the string builder
            AppendText(e.Data);
        }
    }
}
