using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using WeifenLuo.WinFormsUI.Docking;
using Kalman.Data;

namespace Kalman.Studio
{
    public partial class DbSchemaViewer : DockableForm
    {
        public DbSchemaViewer()
        {
            InitializeComponent();
        }

        private void DbSchemaViewer_Load(object sender, EventArgs e)
        {
            foreach (ConnectionStringSettings css in ConfigurationManager.ConnectionStrings)
            {
                cbConnectionStrings.Items.Add(css.Name);
            }
            
            cbSchemaName.DataSource = new string[]{
                                                    "MetaDataCollections",
                                                    "Databases",
                                                    "Catalogs",
                                                    "Users",
                                                    "Tables",
                                                    "Columns",
                                                    "Views",
                                                    "ViewColumns",
                                                    "Procedures",
                                                    "ProcedureParameters",
                                                    "Indexes",
                                                    "IndexColumns",
                                                    "ForeignKeys",
                                                    "UserDefinedTypes",
                                                    "StructuredTypeMembers",
                                                    "DataSourceInformation",
                                                    "DataTypes",
                                                    "Restrictions",
                                                    "ReservedWords"
                                                    };
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (cbConnectionStrings.SelectedItem == null) return;
            string cnName = cbConnectionStrings.SelectedItem.ToString();

            DbSchema schema = DbSchemaFactory.Create(cnName);
            string schemaName = cbSchemaName.SelectedItem == null ? cbSchemaName.Text : cbSchemaName.SelectedItem.ToString();
            string s = txtRestrictions.Text;

            DataTable dt;
            if (s == string.Empty)
            {
                dt = schema.GetSchema(schemaName);
            }
            else
            {
                string[] restrictions = s.Split(',');
                dt = schema.GetSchema(schemaName,restrictions);
            }

            gridView.DataSource = dt;
        }
    }
}
