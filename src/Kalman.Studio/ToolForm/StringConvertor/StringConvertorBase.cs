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
    public partial class StringConvertorBase : Form
    {
        public StringConvertorBase()
        {
            InitializeComponent();
        }

        public StringConvertor SC { get; set; }
        private void StringConverterBase_Load(object sender, EventArgs e)
        {
            SC = this.Owner as StringConvertor;
        }
    }
}
