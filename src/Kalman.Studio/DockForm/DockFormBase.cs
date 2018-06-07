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
    public partial class DockFormBase : DockContent
    {
        public DockFormBase()
        {
            InitializeComponent();
        }

        protected Main MainForm
        {
            get { return this.ParentForm as Main; }
        }

        private void DockFromBase_Load(object sender, EventArgs e)
        {

        }
    }
}
