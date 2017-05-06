using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Kalman.Data;
using Kalman.Data.SchemaObject;
using System.Diagnostics;

namespace Kalman.Studio
{
    public partial class DatabaseExplorer : DockExplorer
    {
        public DatabaseExplorer()
        {
            InitializeComponent();
        }

        private void DatabaseExplorer_Load(object sender, EventArgs e)
        {
            RefreshDatabase();
            //menuItemBuildSqlForTable.Visible = false;
            this.DockPanel.DockLeftPortion = 300;
        }

        DbSchema dbSchema;
        private void cbConnectionStrings_SelectedIndexChanged(object sender, EventArgs e)
        {
            tvDatabase.Nodes.Clear();

            ConnectionStringSettings css = ConfigurationManager.ConnectionStrings[cbConnectionStrings.SelectedItem.ToString()];
            dbSchema = DbSchemaFactory.Create(css.Name);
            DbSchemaHelper.Instance.CurrentSchema = dbSchema;

            TreeNode root = new TreeNode(css.Name, 0, 0);
            root.ToolTipText = css.ConnectionString;
            tvDatabase.Nodes.Add(root);

            Main m = this.ParentForm as Main;
            m.ClearDbList();

            this.Cursor = Cursors.WaitCursor;
            IList<SODatabase> dbList = dbSchema.GetDatabaseList();
            this.Cursor = Cursors.Default;

            foreach (SODatabase db in dbList)
            {
                TreeNode dbNode = new TreeNode(db.Name, 1, 1);
                dbNode.Tag = db;
                dbNode.ToolTipText = string.IsNullOrEmpty(db.Comment) ? db.Name : db.Comment;
                dbNode.ContextMenuStrip = cmsDatabase;
                root.Nodes.Add(dbNode);

                MainForm.AddDbListItem(db);
            }

            root.Expand();
        }

        //加载数据库元数据架构信息
        void LoadDbSchema(TreeNode dbNode)
        {
            this.Cursor = Cursors.WaitCursor;
            dbNode.Nodes.Clear();
            SODatabase db = dbNode.Tag as SODatabase;
            TreeNode tableNode = new TreeNode("表", 2, 2);
            TreeNode viewNode = new TreeNode("视图", 2, 2);
            TreeNode spNode = new TreeNode("存储过程", 2, 2);

            //加载表列表
            IList<SOTable> tableList = dbSchema.GetTableList(db);
            foreach (SOTable t in tableList)
            {
                //TreeNode tn = new TreeNode(t.FullName, 3, 3);
                TreeNode tn = new TreeNode(t.Name, 3, 3);
                tn.Tag = t;
                tn.ToolTipText = string.IsNullOrEmpty(t.Comment) ? t.Name : t.Comment;
                tn.ContextMenuStrip = cmsTable;
                tableNode.Nodes.Add(tn);
            }

            //加载视图列表
            IList<SOView> viewList = dbSchema.GetViewList(db);
            foreach (SOView v in viewList)
            {
                //TreeNode tn = new TreeNode(v.FullName, 4, 4);
                TreeNode tn = new TreeNode(v.Name, 4, 4);
                tn.Tag = v;
                tn.ToolTipText = string.IsNullOrEmpty(v.Comment) ? v.Name : v.Comment;
                tn.ContextMenuStrip = cmsView;
                viewNode.Nodes.Add(tn);
            }

            //加载存储过程列表
            IList<SOCommand> spList = dbSchema.GetCommandList(db);

            if (spList != null && spList.Count > 0)
            {
                foreach (SOCommand p in spList)
                {
                    //TreeNode tn = new TreeNode(p.FullName, 5, 5);
                    TreeNode tn = new TreeNode(p.Name, 5, 5);
                    tn.Tag = p;
                    tn.ToolTipText = string.IsNullOrEmpty(p.Comment) ? p.Name : p.Comment;
                    tn.ContextMenuStrip = cmsSp;
                    spNode.Nodes.Add(tn);
                }
            }

            dbNode.Nodes.Add(tableNode);
            dbNode.Nodes.Add(viewNode);
            dbNode.Nodes.Add(spNode);
            this.Cursor = Cursors.Default;
        }


        #region 树形菜单事件处理

        //解决右键点击节点定位的问题
        private void tvDatabase_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeView tv = sender as TreeView;
                TreeNode tn = tv.GetNodeAt(e.X, e.Y);
                tv.SelectedNode = tn;
            }
        }

        private void tvDatabase_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeView tv = sender as TreeView;
            TreeNode tn = tv.GetNodeAt(e.X, e.Y);

            if (tn != null && tn.Level == 1 && tn.Nodes.Count == 0)
            {
                LoadDbSchema(tn);
                tn.Expand();
            }
            if (tn != null && tn.Parent != null && tn.Level == 3)
            {
                if (tn.Parent.Text == "表")
                {
                    if (this.DockPanel.ActiveDocument is CodeBuilder)
                    {
                        SOTable t = tvDatabase.SelectedNode.Tag as SOTable;
                        if (t == null) return;

                        CodeBuilder builder = this.DockPanel.ActiveDocument as CodeBuilder;
                        builder.Table = t;
                        builder.ColumnList = dbSchema.GetTableColumnList(t);
                        builder.LoadColumnList();
                    }
                }
            }
        }

        #endregion

        #region 数据库右键菜单事件处理

        //查看数据库
        private void menuItemViewDB_Click(object sender, EventArgs e)
        {
            DbObjectViewer ov = new DbObjectViewer();
            ov.CurrentDatabase = tvDatabase.SelectedNode.Tag as SODatabase;
            ov.Show(DockPanel);
        }

        ////使用实体层模板批量生成代码
        //private void menuItemBatchBuildEnityCode_Click(object sender, EventArgs e)
        //{
        //    SODatabase db = tvDatabase.SelectedNode.Tag as SODatabase;

        //    BatchBuildEntityCode dialog = new BatchBuildEntityCode(db);
        //    dialog.ShowDialog();
        //}

        ////使用数据层模板批量生成代码
        //private void menuItemBatchBuildDALCode_Click(object sender, EventArgs e)
        //{
        //    SODatabase db = tvDatabase.SelectedNode.Tag as SODatabase;

        //    BatchBuildDALCode dialog = new BatchBuildDALCode(db);
        //    dialog.ShowDialog();
        //}

        //批量生成代码
        private void menuItemBatchBuildCode_Click(object sender, EventArgs e)
        {
            SODatabase db = tvDatabase.SelectedNode.Tag as SODatabase;

            BatchBuildCode dialog = new BatchBuildCode(db);
            dialog.Show(this.DockPanel);
        }

        ////使用自定义模板批量生成代码
        //private void menuItemBatchBuildCustomCode_Click(object sender, EventArgs e)
        //{
        //    SODatabase db = tvDatabase.SelectedNode.Tag as SODatabase;

        //    BatchBuildCustomCode dialog = new BatchBuildCustomCode(db);
        //    dialog.ShowDialog();
        //}

        //新建查询
        private void menuItemNewQuery_Click(object sender, EventArgs e)
        {
            SODatabase db = tvDatabase.SelectedNode.Tag as SODatabase;
            NewQuery(db, "");
        }

        private void NewQuery(SODatabase db, string sqlText)
        {
            QueryAnalyzer qa = new QueryAnalyzer();
            qa.CurrentDatabase = db;
            base.MainForm.SetCurrentDB(db);

            int count = 1;
            string fileName = string.Format("SqlQuery{0}.sql", count.ToString());
            while (base.MainForm.FindDockDocument(fileName) != null)
            {
                count++;
                fileName = string.Format("SqlQuery{0}.sql", count.ToString());
            }

            qa.FileName = fileName;
            qa.SqlText = sqlText;
            qa.Show(DockPanel);
        }

        //生成数据库文档
        private void menuItemBuildDBDoc_Click(object sender, EventArgs e)
        {
            DbDocBuilder builder = new DbDocBuilder();
            builder.CSName = cbConnectionStrings.SelectedItem.ToString();
            builder.CurrentDatabase = tvDatabase.SelectedNode.Tag as SODatabase;
            builder.ShowDialog();
        }

        //刷新数据库
        private void menuItemRefreshDB_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvDatabase.SelectedNode;
            LoadDbSchema(tn);
        }

        #endregion

        #region 表右键菜单事件处理

        private void menuItemPreviewTableData_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvDatabase.SelectedNode;
            SOTable table = tn.Tag as SOTable;
            List<SOColumn> list = dbSchema.GetTableColumnList(table);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT ");
            for (int i = 0; i < list.Count; i++)
            {
                if (i != list.Count - 1)
                    sb.AppendLine(string.Format("   {0},", dbSchema.QuoteIdentifier(list[i].Name)));
                else
                    sb.AppendLine(string.Format("   {0}", dbSchema.QuoteIdentifier(list[i].Name)));
            }
            sb.AppendLine("FROM ");
            sb.AppendLine(string.Format("   {1}", sb.ToString().TrimEnd(','), table.FullName));

            NewQuery(table.Database, sb.ToString());
        }

        //代码生成器
        private void menuItemBuildCodeForTable_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvDatabase.SelectedNode;
            SOTable table = tn.Tag as SOTable;
            CodeBuilder builder = null;

            //保证代码生成器使用一个实例
            if (this.DockPanel.ActiveDocument != null && this.DockPanel.ActiveDocument is CodeBuilder)
            {
                builder = this.DockPanel.ActiveDocument as CodeBuilder;
                builder.Table = table;
                builder.ColumnList = dbSchema.GetTableColumnList(table);
                builder.LoadColumnList();
            }
            else
            {
                builder = new CodeBuilder();
                builder.Table = table;
                builder.ColumnList = dbSchema.GetTableColumnList(table);
                builder.LoadColumnList();//???:初始化列表CheckBox状态时，数据需要Load两次才能将CheckBox列全部初始化为选中状态
                builder.Show(this.DockPanel);
            }
        }

        //生成测试数据
        private void menuItemBuildTestDataForTable_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvDatabase.SelectedNode;
            SOTable table = tn.Tag as SOTable;
            TestDataGenerator generator = null;

            //保证代码生成器使用一个实例
            if (this.DockPanel.ActiveDocument != null && this.DockPanel.ActiveDocument is TestDataGenerator)
            {
                generator = this.DockPanel.ActiveDocument as TestDataGenerator;
                generator.Table = table;
                generator.LoadColumnList();
            }
            else
            {
                generator = new TestDataGenerator();
                generator.Table = table;
                generator.LoadColumnList();
                generator.Show(this.DockPanel);
            }
        }

        //生成数据插入脚本
        private void menuItemBuildInsertSqlForTable_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvDatabase.SelectedNode;
            SOTable table = tn.Tag as SOTable;
            List<SOColumn> list = dbSchema.GetTableColumnList(table);
            string cmdText = string.Format("select * from {0}", table.FullName);
            DataTable dt = DbSchemaHelper.Instance.CurrentSchema.ExecuteQuery(table.Database, cmdText).Tables[0];

            StringBuilder sbDocText = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO ");
                sb.Append(table.FullName + " (");
                for (int i = 0; i < list.Count; i++)
                {
                    SOColumn c = list[i];
                    if (c.Identify) continue;//忽略标识列

                    if (i != list.Count - 1)
                        sb.Append(string.Format("{0},", dbSchema.QuoteIdentifier(c.Name)));
                    else
                        sb.Append(string.Format("{0}) VALUES (", dbSchema.QuoteIdentifier(c.Name)));
                }
                for (int i = 0; i < list.Count; i++)
                {
                    SOColumn c = list[i];
                    if (c.Identify) continue;//忽略标识列

                    string value = "";
                    if (c.DataType == DbType.Boolean)
                    {
                        value = string.Format("'{0}'", Utils.DbBooleanValueToStirng(dr[c.Name]));
                    }
                    else if (c.DataType == DbType.Byte || c.DataType == DbType.Currency || c.DataType == DbType.Decimal ||
                        c.DataType == DbType.Double || c.DataType == DbType.Int16 || c.DataType == DbType.Int32 ||
                        c.DataType == DbType.Int64 || c.DataType == DbType.SByte || c.DataType == DbType.Single ||
                        c.DataType == DbType.UInt16 || c.DataType == DbType.UInt32 || c.DataType == DbType.UInt64)
                    {
                        value = Utils.DbNumericValueToString(dr[c.Name]);
                    }
                    else
                    {
                        value = string.Format("'{0}'", Utils.DbStringValueToString(dr[c.Name]));
                    }

                    if (i != list.Count - 1)
                        sb.Append(string.Format("{0},", value));
                    else
                        sb.Append(string.Format("{0});", value));
                }

                sbDocText.AppendLine(sb.ToString());
            }

            base.MainForm.NewDockDocument(string.Format("{0}_InsertData", table.Name), CodeType.TSQL, sbDocText.ToString());
        }

        #endregion

        #region 视图右键菜单事件处理

        //查看视图定义
        private void menuItemViewSql_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvDatabase.SelectedNode;
            SOView v = tn.Tag as SOView;

            base.MainForm.NewDockDocument(v.Name, CodeType.TSQL, v.SqlText);
        }

        #endregion

        #region 存储过程右键菜单事件处理

        //查看存储过程定义
        private void menuItemSpSql_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvDatabase.SelectedNode;
            SOCommand p = tn.Tag as SOCommand;

            base.MainForm.NewDockDocument(p.Name, CodeType.TSQL, p.SqlText);
        }

        #endregion

        /// <summary>
        /// 添加数据库连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbAddDbConnect_Click(object sender, EventArgs e)
        {

        }

        private void btnSetConnectString_Click(object sender, EventArgs e)
        {
            var dbSettingForm = new DatabaseSettingForm();
            if(dbSettingForm.ShowDialog() == DialogResult.Yes)
            {
                RefreshDatabase();
            }
        }

        private void RefreshDatabase()
        {
            cbConnectionStrings.Items.Clear();
            tvDatabase.Nodes.Clear();

            foreach (ConnectionStringSettings css in ConfigurationManager.ConnectionStrings)
            {
                cbConnectionStrings.Items.Add(css.Name);
            }
        }
    }
}
