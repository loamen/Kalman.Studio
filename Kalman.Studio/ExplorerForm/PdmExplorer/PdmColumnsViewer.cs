using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kalman.PdmParser;

namespace Kalman.Studio
{
    public partial class PdmColumnsViewer : Form
    {
        IList<PDColumn> list = null;
        public PdmColumnsViewer(IList<PDColumn> columnList)
        {
            InitializeComponent();
            list = columnList;
        }

        private void PdmColumnsViewer_Load(object sender, EventArgs e)
        {
            dgvColumn.AutoGenerateColumns = false;
            dgvColumn.DataSource = list;
        }
    }
}
