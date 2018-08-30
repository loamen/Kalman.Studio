using System;
using System.IO;
using System.Windows.Forms;

namespace Kalman.Studio.ToolForm
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            txtGoRoot.Text = Environment.GetEnvironmentVariable("GOROOT");
            txtGoBin.Text = Environment.GetEnvironmentVariable("GOBIN");
            txtGoPath.Text = Environment.GetEnvironmentVariable("GOPATH");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtGoBin.Text.Trim()))
            {
                Environment.SetEnvironmentVariable("GOBIN", txtGoBin.Text.Trim());
            }

            if (Directory.Exists(txtGoRoot.Text.Trim()))
            {
                Environment.SetEnvironmentVariable("GOROOT", txtGoRoot.Text.Trim());
            }

            if (Directory.Exists(txtGoPath.Text.Trim()))
            {
                Environment.SetEnvironmentVariable("GOPATH", txtGoPath.Text.Trim());
            }

            this.Close();
        }

        private void btnBrowserGoRoot_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtGoRoot.Text;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtGoRoot.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnBrowserGoBin_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtGoBin.Text;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtGoBin.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnBrowserGoPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtGoPath.Text;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtGoPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
