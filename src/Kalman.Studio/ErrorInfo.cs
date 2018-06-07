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
    public partial class ErrorInfo : Form
    {
        string errorInfo = "";
        string errorData = "";

        public ErrorInfo(Exception ex,string data)
        {
            InitializeComponent();
            errorInfo = ex.ToString();
            errorData = data;
        }

        private void ErrorInfo_Load(object sender, EventArgs e)
        {
            rtbErrorInfo.Text = errorInfo;
            rtbErrorData.Text = errorData;
        }
    }
}
