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
    /// <summary>
    /// 可停靠在文档区域的窗体基类
    /// </summary>
    public partial class DockableForm : DockFormBase
    {
        public DockableForm()
        {
            InitializeComponent();
        }

        private void menuItemClose_Click(object sender, EventArgs e)
        {
            this.CloseDockableFrom();
        }

        protected virtual void CloseDockableFrom()
        {
            this.Hide();
        }

        private void menuItemCloseOther_Click(object sender, EventArgs e)
        {
            MainForm.CloseOtherDockDocument();
        }

        private void menuItemCloseAll_Click(object sender, EventArgs e)
        {
            MainForm.CloseAllDockDocument();
        }
    }
}
