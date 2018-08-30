using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kalman.Security;

namespace Kalman.Studio
{
    public partial class String_SymmetricAlgorithm : StringConvertorBase
    {
        public String_SymmetricAlgorithm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SymmetricAlgorithmType algorithmType = SymmetricAlgorithmType.DES;
            if (rbtnDES.Checked) algorithmType = SymmetricAlgorithmType.DES;

            if (rbtnRC2_128.Checked) algorithmType = SymmetricAlgorithmType.RC2_128;
            if (rbtnRC2_40.Checked) algorithmType = SymmetricAlgorithmType.RC2_40;
            if (rbtnRC2_64.Checked) algorithmType = SymmetricAlgorithmType.RC2_64;
            if (rbtnRC2_96.Checked) algorithmType = SymmetricAlgorithmType.RC2_96;
            
            if (rbtnRijndael_128.Checked) algorithmType = SymmetricAlgorithmType.Rijndael_128;
            if (rbtnRijndael_192.Checked) algorithmType = SymmetricAlgorithmType.Rijndael_192;
            if (rbtnRijndael_256.Checked) algorithmType = SymmetricAlgorithmType.Rijndael_256;
            
            if (rbtnTripleDES_128.Checked) algorithmType = SymmetricAlgorithmType.TripleDES_128;
            if (rbtnTripleDES_192.Checked) algorithmType = SymmetricAlgorithmType.TripleDES_192;

            string key = txtKey.Text;
            string iv = txtIV.Text;

            SymmetricCryto sc = null;
            if (string.IsNullOrEmpty(key))
            {
                sc = new SymmetricCryto(algorithmType);
            }
            else
            {
                if (string.IsNullOrEmpty(iv))
                {
                    sc = new SymmetricCryto(key, algorithmType);
                }
                else
                {
                    sc = new SymmetricCryto(key, iv, algorithmType);
                }
            }

            try
            {
                if (rbtnEN.Checked)
                {
                    SC.S2 = sc.EncryptString(SC.S1);
                }
                else
                {
                    SC.S2 = sc.DecryptString(SC.S1);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowExceptionMessage(ex);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
