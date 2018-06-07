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
    public partial class PdmModelViewer : DockableForm
    {
        public PdmModelViewer()
        {
            InitializeComponent();
        }

        public void LoadModel(PDModel m)
        {
            this.Text = m.Name;

            dgvTable.AutoGenerateColumns = false;
            dgvView.AutoGenerateColumns = false;
            dgvSP.AutoGenerateColumns = false;

            dgvTable.DataSource = m.AllTableList;
            dgvView.DataSource = m.AllViewList;
            dgvSP.DataSource = m.AllProcedureList;

            tpTable.Text = string.Format("表[{0}]", dgvTable.Rows.Count);
            tpView.Text = string.Format("视图[{0}]", dgvView.Rows.Count);
            tpSP.Text = string.Format("存储过程[{0}]", dgvSP.Rows.Count);
        }

        public void LoadPackage(PDPackage p)
        {
            this.Text = p.Name;

            dgvTable.AutoGenerateColumns = false;
            dgvView.AutoGenerateColumns = false;
            dgvSP.AutoGenerateColumns = false;

            dgvTable.DataSource = p.TableList;
            dgvView.DataSource = p.ViewList;
            dgvSP.DataSource = p.ProcedureList;

            tpTable.Text = string.Format("表[{0}]", dgvTable.Rows.Count);
            tpView.Text = string.Format("视图[{0}]", dgvView.Rows.Count);
            tpSP.Text = string.Format("存储过程[{0}]", dgvSP.Rows.Count);
        }

        private void dgvTable_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dgvTable.CurrentRow.Selected = false;
                dgvTable.Rows[e.RowIndex].Selected = true;
            }
        }
        private void dgvView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dgvView.CurrentRow.Selected = false;
                dgvView.Rows[e.RowIndex].Selected = true;
            }
        }
        private void dgvSP_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dgvSP.CurrentRow.Selected = false;
                dgvSP.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                PdmTableViewer v = new PdmTableViewer(dgvTable.Rows[e.RowIndex].DataBoundItem as PDTable);
                v.ShowDialog();
            }
        }
    }
}
