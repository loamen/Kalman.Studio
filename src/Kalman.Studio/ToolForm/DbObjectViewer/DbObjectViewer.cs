using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Kalman.Data.SchemaObject;

namespace Kalman.Studio
{
    public partial class DbObjectViewer : DockableForm
    {
        public DbObjectViewer()
        {
            InitializeComponent();
        }

        public SODatabase CurrentDatabase { get; set; }

        private void DbObjectViewer_Load(object sender, EventArgs e)
        {
            dgvTable.AutoGenerateColumns = false;
            dgvView.AutoGenerateColumns = false;
            dgvSP.AutoGenerateColumns = false;
            cbDatabase.DataSource = DbSchemaHelper.Instance.CurrentSchema.GetDatabaseList();

            if (CurrentDatabase != null)
            {
                for (int i = 0; i < cbDatabase.Items.Count; i++)
                {
                    if (cbDatabase.Items[i].ToString() == CurrentDatabase.Name)
                    {
                        cbDatabase.SelectedItem = cbDatabase.Items[i];
                        break;
                    }
                }
            }
            BindData();
            cbDatabase.SelectedIndexChanged += new EventHandler(cbDatabase_SelectedIndexChanged);
        }

        private void cbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentDatabase = cbDatabase.SelectedItem as SODatabase;
            BindData();
        }

        void BindData()
        {
            if (CurrentDatabase == null) return;
            dgvTable.DataSource = DbSchemaHelper.Instance.CurrentSchema.GetTableList(CurrentDatabase);
            dgvView.DataSource = DbSchemaHelper.Instance.CurrentSchema.GetViewList(CurrentDatabase);
            dgvSP.DataSource = DbSchemaHelper.Instance.CurrentSchema.GetCommandList(CurrentDatabase);
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
                DbTableViewer v = new DbTableViewer(dgvTable.Rows[e.RowIndex].DataBoundItem as SOTable);
                v.ShowDialog();
            }
        }

        private void dgvView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DbViewViewer v = new DbViewViewer(dgvView.Rows[e.RowIndex].DataBoundItem as SOView);
                v.ShowDialog();
            }
        }

        private void dgvSP_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DbSPViewer v = new DbSPViewer(dgvSP.Rows[e.RowIndex].DataBoundItem as SOCommand);
                v.ShowDialog();
            }
        }
    }
}
