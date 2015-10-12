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
    public partial class DbTableViewer : Form
    {
        SOTable currentTable;
        public DbTableViewer(SOTable table)
        {
            InitializeComponent();
            currentTable = table;
        }

        private void DbTableViewer_Load(object sender, EventArgs e)
        {
            dgv.AutoGenerateColumns = false;
            this.Text = string.Format("查看表信息[{0}->{1}]", currentTable.Database.Name, currentTable.Name);
            dgv.DataSource = DbSchemaHelper.Instance.CurrentSchema.GetTableColumnList(currentTable);
        }
    }
}
