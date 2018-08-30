using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kalman.Security;
using System.IO;

namespace Kalman.Studio
{
    public partial class String_Hash : StringConvertorBase
    {
        public String_Hash()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            HashAlgorithmType hashAlgorithmType = HashAlgorithmType.MD5;

            if (rbMD5.Checked) hashAlgorithmType = HashAlgorithmType.MD5;
            if (rbSHA1.Checked) hashAlgorithmType = HashAlgorithmType.SHA1;
            if (rbSHA256.Checked) hashAlgorithmType = HashAlgorithmType.SHA256;
            if (rbSHA384.Checked) hashAlgorithmType = HashAlgorithmType.SHA384;
            if (rbSHA512.Checked) hashAlgorithmType = HashAlgorithmType.SHA512;

            if (SC != null && SC.S1.Length > 0)
            {
                if (cbFileHash.Checked)
                {
                    if (File.Exists(SC.S1))
                    {
                        this.Cursor = Cursors.WaitCursor;
                        FileStream fs = new FileStream(SC.S1, FileMode.Open, FileAccess.Read, FileShare.Read, 1024 * 1024);
                        SC.S2 = HashCryto.GetHash2String(fs, hashAlgorithmType);
                        this.Cursor = Cursors.Default;
                    }
                    else
                    {
                        MsgBox.Show(string.Format("文件{0}不存在", SC.S1));
                    }
                    return;
                }

                if (cbBase64.Checked)
                {
                    SC.S2 = HashCryto.GetHash2Base64(SC.S1, hashAlgorithmType, SC.GetEncoding());
                }
                else
                {
                    SC.S2 = HashCryto.GetHash2String(SC.S1, hashAlgorithmType, SC.GetEncoding());
                }
            }
            this.Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFileHash_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFileHash.Checked)
            {
                cbBase64.Checked = false;
                cbBase64.Enabled = false;
            }
            else
            {
                cbBase64.Enabled = true;
            }
        }
    }
}
