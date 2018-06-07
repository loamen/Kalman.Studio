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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Help.ShowHelp(this, "http://lingyun_k.cnblogs.com");
        }

        private void About_Load(object sender, EventArgs e)
        {
            lblAbout.Text += " " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            lblCopyRight.Text = string.Format("Copyright ©2009-{0} Kalman 版权所有", DateTime.Now.Year);
        }
    }
}
