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
    public partial class String_Replace : StringConvertorBase
    {
        public String_Replace()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string s1 = txt1.Text;
            string s2 = txt2.Text;

            if (!string.IsNullOrEmpty(s1))
            {
                SC.S2 = SC.S2.Replace(s1, s2);
            }
            this.Close();
        }
    }
}
