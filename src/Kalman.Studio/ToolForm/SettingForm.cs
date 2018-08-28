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
    }
}
