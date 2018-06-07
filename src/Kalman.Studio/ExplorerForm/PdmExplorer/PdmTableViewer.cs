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
    public partial class PdmTableViewer : Form
    {
        PDTable _Table = null;

        public PdmTableViewer(PDTable table)
        {
            InitializeComponent();
            _Table = table;
        }

        private void PdmTableViewer_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("查看表[{0}]信息", _Table.Name);
            if (_Table.Package != null) this.Text += string.Format("，所属包[{0}]", _Table.Package.Name);

            dgvColumn.AutoGenerateColumns = false;
            dgvKey.AutoGenerateColumns = false;
            dgvIndex.AutoGenerateColumns = false;

            dgvColumn.DataSource = _Table.ColumnList;
            dgvKey.DataSource = _Table.KeyList;
            dgvIndex.DataSource = _Table.IndexList;
        }

        private void dgvKey_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                PDKey key = dgvKey.Rows[e.RowIndex].DataBoundItem as PDKey;
                if (key == null) return;

                PdmColumnsViewer v = new PdmColumnsViewer(key.ColumnList);
                v.ShowDialog();
            }
        }

        private void dgvIndex_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                PDIndex index = dgvIndex.Rows[e.RowIndex].DataBoundItem as PDIndex;
                if (index == null) return;

                PdmColumnsViewer v = new PdmColumnsViewer(index.ColumnList);
                v.ShowDialog();
            }
        }
    }
}
