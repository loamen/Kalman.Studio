using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kalman.Utilities;

namespace Kalman.Studio
{
    public partial class String_Convert : StringConvertorBase
    {
        public String_Convert()
        {
            InitializeComponent();
        }

        private void btnToSBC_Click(object sender, EventArgs e)
        {
            if (SC != null && SC.S1.Length > 0)
            {
                SC.S2 = StringUtil.ToSBC(SC.S1);
                this.Close();
            }
        }

        private void btnToDBC_Click(object sender, EventArgs e)
        {
            if (SC != null && SC.S1.Length > 0)
            {
                SC.S2 = StringUtil.ToDBC(SC.S1);
                this.Close();
            }
        }

        private void btnToBase64_Click(object sender, EventArgs e)
        {
            SC.S2 = StringUtil.Base64Encode(SC.S1, SC.GetEncoding());
            this.Close();
        }

        private void btnFromBase64_Click(object sender, EventArgs e)
        {
            SC.S2 = StringUtil.Base64Decode(SC.S1, SC.GetEncoding());
            this.Close();
        }

        private void btnUrlEncode_Click(object sender, EventArgs e)
        {
            SC.S2 = System.Web.HttpUtility.UrlEncode(SC.S1, SC.GetEncoding());
            this.Close();
        }

        private void btnUrlDecode_Click(object sender, EventArgs e)
        {
            SC.S2 = System.Web.HttpUtility.UrlDecode(SC.S1, SC.GetEncoding());
            this.Close();
        }

        private void btnHtmlEncode_Click(object sender, EventArgs e)
        {
            SC.S2 = System.Web.HttpUtility.HtmlEncode(SC.S1);
            this.Close();
        }

        private void btnHtmlDecode_Click(object sender, EventArgs e)
        {
            SC.S2 = System.Web.HttpUtility.HtmlDecode(SC.S1);
            this.Close();
        }

        private void btnGuid_Click(object sender, EventArgs e)
        {
            SC.S2 = Guid.NewGuid().ToString();
            this.Close();
        }

        private void btnToHex_Click(object sender, EventArgs e)
        {
            SC.S2 = StringUtil.ToHexString(SC.S1, SC.GetEncoding());
            this.Close();
        }

        private void btnFromHex_Click(object sender, EventArgs e)
        {
            SC.S2 = StringUtil.FromHexString(SC.S1, SC.GetEncoding());
            this.Close();
        }

       
    }
}
