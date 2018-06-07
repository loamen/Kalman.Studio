using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kalman.IISLogParser;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;

namespace Kalman.Studio
{
    public partial class IISLogParseCondition : Form
    {
        LogParseFilter filter = new LogParseFilter();
        DockPanel dockPanel;
        IISLogParser parser = null;

        public IISLogParseCondition(DockPanel panel)
        {
            InitializeComponent();
            dockPanel = panel;
        }

        private void IISLogParseCondition_Load(object sender, EventArgs e)
        {
        }

        void BindFileList()
        {
            listBoxLogFiles.Items.Clear();
            foreach (string item in filter.FileList)
            {
                listBoxLogFiles.Items.Add(item);
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string item in openFileDialog1.FileNames)
                {
                    filter.AddFile(item);
                }
                BindFileList();
            }
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                filter.AddFiles(files);
                BindFileList();
            }
        }

        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            if (listBoxLogFiles.SelectedIndex == -1) return;
            listBoxLogFiles.Items.Remove(listBoxLogFiles.SelectedItem);
            filter.FileList.Remove(listBoxLogFiles.SelectedItem.ToString());
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            listBoxLogFiles.Items.Clear();
            filter.FileList.Clear();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rbtnAll.Checked) filter.Method = 0;
            if (rbtnGet.Checked) filter.Method = 1;
            if (rbtnPost.Checked) filter.Method = 2;

            if (cbAllowQueryByIP.Checked)
            {
                filter.IPList.Clear();
                filter.AllowQueryByIP = true;
                string[] ss = txtIPList.Text.Trim().Split(',');
                foreach (string s in ss)
                {
                    filter.AddIP(s.Trim());
                }
            }
            else
            {
                filter.AllowQueryByIP = false;
            }

            if (cbAllowQueryByIPLocation.Checked)
            {
                filter.IPLocationList.Clear();
                filter.AllowQueryByIPLocation = true;
                string[] ss = txtIPLocationList.Text.Trim().Split(',');
                foreach (string s in ss)
                {
                    filter.AddIPLocation(s.Trim());
                }
            }
            else
            {
                filter.AllowQueryByIPLocation = false;
            }

            if (cbAllowQueryByReferer.Checked)
            {
                filter.RefererList.Clear();
                filter.AllowQueryByReferer = true;
                string[] ss = txtRefererList.Text.Trim().ToLower().Split(',');
                foreach (string s in ss)
                {
                    filter.AddReferer(s.Trim());
                }
            }
            else
            {
                filter.AllowQueryByReferer = false;
            }

            if (cbAllowQueryByStatus.Checked)
            {
                filter.StatusList.Clear();
                filter.AllowQueryByStatus = true;
                string[] ss = txtStatusList.Text.Trim().Split(',');
                foreach (string s in ss)
                {
                    filter.AddStatus(s.Trim());
                }
            }
            else
            {
                filter.AllowQueryByStatus = false;
            }

            if (cbAllowQueryByUri.Checked)
            {
                filter.UriList.Clear();
                filter.AllowQueryByUri = true;
                string[] ss = txtUriList.Text.Trim().ToLower().Split(',');
                foreach (string s in ss)
                {
                    filter.AddUri(s.Trim());
                }
            }
            else
            {
                filter.AllowQueryByUri = false;
            }

            if (cbAllowQueryByUserAgent.Checked)
            {
                filter.UserAgentList.Clear();
                filter.AllowQueryByUserAgent = true;
                string[] ss = txtUserAgentList.Text.Trim().Split(',');
                foreach (string s in ss)
                {
                    filter.AddUserAgent(s.Trim());
                }
            }
            else
            {
                filter.AllowQueryByUserAgent = false;
            }

            if (cbAllowQueryByTime.Checked)
            {
                filter.AllowQueryByTime = true;
                filter.BeginTime = dtpBeginTime.Value;
                filter.EndTime = dtpEndTime.Value;
            }
            else
            {
                filter.AllowQueryByTime = false;
            }

            if (parser == null)
            {
                parser = new IISLogParser();
                parser.Show(dockPanel);
            }
            parser.Activate();
            parser.ParseLog(filter);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (parser != null)
            {
                parser.Close();
            }
            base.OnClosing(e);
        }
    }
}
