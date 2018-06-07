using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kalman.Data.SchemaObject;

namespace Kalman.Studio
{
    public partial class TestDataGenerator : DockableForm
    {
        public TestDataGenerator()
        {
            InitializeComponent();
        }

        public SOTable Table { get; set; }

        private void TestDataGenerator_Load(object sender, EventArgs e)
        {
            LoadColumnList();
            ShowTitle();
        }

        public void LoadColumnList()
        {
            dataGridView1.AutoGenerateColumns = false;
            if (Table.ColumnList != null)
            {
                this.dataGridView1.DataSource = Table.ColumnList;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                    cell.ValueType = typeof(bool);
                    cell.Value = true;
                }
                ShowTitle();
            }
        }

        private void ShowTitle()
        {
            if (this.Table != null)
            {
                if (Table.Database != null)
                {
                    gbObjName.Text = string.Format("当前对象：{0} -> {1}", Table.Database, Table.Name);
                }
                else
                {
                    gbObjName.Text = string.Format("当前对象：{0}", Table.Name);
                }
            }
            else
            {
                gbObjName.Text = "没有选择表";
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerator_Click(object sender, EventArgs e)
        {

        }
    }
}
