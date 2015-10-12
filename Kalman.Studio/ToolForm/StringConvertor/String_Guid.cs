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
    public partial class String_Guid : StringConvertorBase
    {
        public String_Guid()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string guid = Guid.NewGuid().ToString();

            if (rbtnToLower.Checked) guid = guid.ToLower();
            if (rbtnToUpper.Checked) guid = guid.ToUpper();
            if (cbRemove.Checked) guid = guid.Replace("-", "");

            base.SC.S2 = guid;

        }
    }
}
