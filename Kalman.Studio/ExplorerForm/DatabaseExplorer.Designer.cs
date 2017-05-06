namespace Kalman.Studio
{
    partial class DatabaseExplorer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseExplorer));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbConnectionStrings = new System.Windows.Forms.ComboBox();
            this.tvDatabase = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.btnSetConnectString = new System.Windows.Forms.Button();
            this.cmsTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemPreviewTableData = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBuildCodeForTable = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBuildTestDataForTable = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBuildInsertSqlForTable = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSpSql = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsSp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemViewSql = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemRefreshDB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDatabase = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemViewDB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBatchBuildCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBuildDBDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAddDbConnect = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.cmsTable.SuspendLayout();
            this.cmsSp.SuspendLayout();
            this.cmsView.SuspendLayout();
            this.cmsDatabase.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel1.Controls.Add(this.cbConnectionStrings, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tvDatabase, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSetConnectString, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(290, 429);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // cbConnectionStrings
            // 
            this.cbConnectionStrings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbConnectionStrings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConnectionStrings.FormattingEnabled = true;
            this.cbConnectionStrings.Location = new System.Drawing.Point(3, 3);
            this.cbConnectionStrings.Name = "cbConnectionStrings";
            this.cbConnectionStrings.Size = new System.Drawing.Size(200, 20);
            this.cbConnectionStrings.TabIndex = 0;
            this.cbConnectionStrings.SelectedIndexChanged += new System.EventHandler(this.cbConnectionStrings_SelectedIndexChanged);
            // 
            // tvDatabase
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tvDatabase, 2);
            this.tvDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDatabase.HotTracking = true;
            this.tvDatabase.ImageIndex = 0;
            this.tvDatabase.ImageList = this.imgList;
            this.tvDatabase.Location = new System.Drawing.Point(5, 30);
            this.tvDatabase.Margin = new System.Windows.Forms.Padding(5);
            this.tvDatabase.Name = "tvDatabase";
            this.tvDatabase.SelectedImageIndex = 0;
            this.tvDatabase.ShowNodeToolTips = true;
            this.tvDatabase.Size = new System.Drawing.Size(280, 398);
            this.tvDatabase.TabIndex = 1;
            this.tvDatabase.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tvDatabase_MouseClick);
            this.tvDatabase.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tvDatabase_MouseDoubleClick);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "cs2.ICO");
            this.imgList.Images.SetKeyName(1, "db.ico");
            this.imgList.Images.SetKeyName(2, "folder.ICO");
            this.imgList.Images.SetKeyName(3, "table.ICO");
            this.imgList.Images.SetKeyName(4, "view.ICO");
            this.imgList.Images.SetKeyName(5, "sp.ICO");
            this.imgList.Images.SetKeyName(6, "key.ICO");
            this.imgList.Images.SetKeyName(7, "column.ICO");
            this.imgList.Images.SetKeyName(8, "index.ICO");
            this.imgList.Images.SetKeyName(9, "trigger.ICO");
            this.imgList.Images.SetKeyName(10, "check.ICO");
            // 
            // btnSetConnectString
            // 
            this.btnSetConnectString.Location = new System.Drawing.Point(209, 3);
            this.btnSetConnectString.Name = "btnSetConnectString";
            this.btnSetConnectString.Size = new System.Drawing.Size(75, 19);
            this.btnSetConnectString.TabIndex = 2;
            this.btnSetConnectString.Text = "设置服务器";
            this.btnSetConnectString.UseVisualStyleBackColor = true;
            this.btnSetConnectString.Click += new System.EventHandler(this.btnSetConnectString_Click);
            // 
            // cmsTable
            // 
            this.cmsTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemPreviewTableData,
            this.menuItemBuildCodeForTable,
            this.menuItemBuildTestDataForTable,
            this.menuItemBuildInsertSqlForTable});
            this.cmsTable.Name = "cmsTable";
            this.cmsTable.Size = new System.Drawing.Size(173, 92);
            // 
            // menuItemPreviewTableData
            // 
            this.menuItemPreviewTableData.Name = "menuItemPreviewTableData";
            this.menuItemPreviewTableData.Size = new System.Drawing.Size(172, 22);
            this.menuItemPreviewTableData.Text = "预览数据";
            this.menuItemPreviewTableData.Click += new System.EventHandler(this.menuItemPreviewTableData_Click);
            // 
            // menuItemBuildCodeForTable
            // 
            this.menuItemBuildCodeForTable.Name = "menuItemBuildCodeForTable";
            this.menuItemBuildCodeForTable.Size = new System.Drawing.Size(172, 22);
            this.menuItemBuildCodeForTable.Text = "代码生成器";
            this.menuItemBuildCodeForTable.Click += new System.EventHandler(this.menuItemBuildCodeForTable_Click);
            // 
            // menuItemBuildTestDataForTable
            // 
            this.menuItemBuildTestDataForTable.Name = "menuItemBuildTestDataForTable";
            this.menuItemBuildTestDataForTable.Size = new System.Drawing.Size(172, 22);
            this.menuItemBuildTestDataForTable.Text = "测试数据生成器";
            this.menuItemBuildTestDataForTable.Click += new System.EventHandler(this.menuItemBuildTestDataForTable_Click);
            // 
            // menuItemBuildInsertSqlForTable
            // 
            this.menuItemBuildInsertSqlForTable.Name = "menuItemBuildInsertSqlForTable";
            this.menuItemBuildInsertSqlForTable.Size = new System.Drawing.Size(172, 22);
            this.menuItemBuildInsertSqlForTable.Text = "生成数据插入脚本";
            this.menuItemBuildInsertSqlForTable.Click += new System.EventHandler(this.menuItemBuildInsertSqlForTable_Click);
            // 
            // menuItemSpSql
            // 
            this.menuItemSpSql.Name = "menuItemSpSql";
            this.menuItemSpSql.Size = new System.Drawing.Size(172, 22);
            this.menuItemSpSql.Text = "查看存储过程定义";
            this.menuItemSpSql.Click += new System.EventHandler(this.menuItemSpSql_Click);
            // 
            // cmsSp
            // 
            this.cmsSp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSpSql});
            this.cmsSp.Name = "cmsSp";
            this.cmsSp.Size = new System.Drawing.Size(173, 26);
            // 
            // menuItemViewSql
            // 
            this.menuItemViewSql.Name = "menuItemViewSql";
            this.menuItemViewSql.Size = new System.Drawing.Size(148, 22);
            this.menuItemViewSql.Text = "查看视图定义";
            this.menuItemViewSql.Click += new System.EventHandler(this.menuItemViewSql_Click);
            // 
            // cmsView
            // 
            this.cmsView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemViewSql});
            this.cmsView.Name = "cmsView";
            this.cmsView.Size = new System.Drawing.Size(149, 26);
            // 
            // menuItemRefreshDB
            // 
            this.menuItemRefreshDB.Name = "menuItemRefreshDB";
            this.menuItemRefreshDB.Size = new System.Drawing.Size(160, 22);
            this.menuItemRefreshDB.Text = "刷新数据库";
            this.menuItemRefreshDB.Click += new System.EventHandler(this.menuItemRefreshDB_Click);
            // 
            // menuItemNewQuery
            // 
            this.menuItemNewQuery.Name = "menuItemNewQuery";
            this.menuItemNewQuery.Size = new System.Drawing.Size(160, 22);
            this.menuItemNewQuery.Text = "新建查询";
            this.menuItemNewQuery.Click += new System.EventHandler(this.menuItemNewQuery_Click);
            // 
            // cmsDatabase
            // 
            this.cmsDatabase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNewQuery,
            this.menuItemViewDB,
            this.menuItemBatchBuildCode,
            this.menuItemBuildDBDoc,
            this.menuItemRefreshDB});
            this.cmsDatabase.Name = "cmsDatabase";
            this.cmsDatabase.Size = new System.Drawing.Size(161, 114);
            // 
            // menuItemViewDB
            // 
            this.menuItemViewDB.Name = "menuItemViewDB";
            this.menuItemViewDB.Size = new System.Drawing.Size(160, 22);
            this.menuItemViewDB.Text = "查看数据库";
            this.menuItemViewDB.Click += new System.EventHandler(this.menuItemViewDB_Click);
            // 
            // menuItemBatchBuildCode
            // 
            this.menuItemBatchBuildCode.Name = "menuItemBatchBuildCode";
            this.menuItemBatchBuildCode.Size = new System.Drawing.Size(160, 22);
            this.menuItemBatchBuildCode.Text = "批量生成代码";
            this.menuItemBatchBuildCode.Click += new System.EventHandler(this.menuItemBatchBuildCode_Click);
            // 
            // menuItemBuildDBDoc
            // 
            this.menuItemBuildDBDoc.Name = "menuItemBuildDBDoc";
            this.menuItemBuildDBDoc.Size = new System.Drawing.Size(160, 22);
            this.menuItemBuildDBDoc.Text = "生成数据库文档";
            this.menuItemBuildDBDoc.Click += new System.EventHandler(this.menuItemBuildDBDoc_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddDbConnect});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(290, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // tsbAddDbConnect
            // 
            this.tsbAddDbConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddDbConnect.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddDbConnect.Image")));
            this.tsbAddDbConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddDbConnect.Name = "tsbAddDbConnect";
            this.tsbAddDbConnect.Size = new System.Drawing.Size(23, 22);
            this.tsbAddDbConnect.Text = "添加数据库连接";
            this.tsbAddDbConnect.Click += new System.EventHandler(this.tsbAddDbConnect_Click);
            // 
            // DatabaseExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 429);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft;
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DatabaseExplorer";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.Text = "数据库对象浏览器";
            this.Load += new System.EventHandler(this.DatabaseExplorer_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.cmsTable.ResumeLayout(false);
            this.cmsSp.ResumeLayout(false);
            this.cmsView.ResumeLayout(false);
            this.cmsDatabase.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbConnectionStrings;
        private System.Windows.Forms.TreeView tvDatabase;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ContextMenuStrip cmsTable;
        private System.Windows.Forms.ToolStripMenuItem menuItemPreviewTableData;
        private System.Windows.Forms.ToolStripMenuItem menuItemBuildCodeForTable;
        private System.Windows.Forms.ToolStripMenuItem menuItemBuildInsertSqlForTable;
        private System.Windows.Forms.ToolStripMenuItem menuItemSpSql;
        private System.Windows.Forms.ContextMenuStrip cmsSp;
        private System.Windows.Forms.ToolStripMenuItem menuItemViewSql;
        private System.Windows.Forms.ContextMenuStrip cmsView;
        private System.Windows.Forms.ToolStripMenuItem menuItemRefreshDB;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewQuery;
        private System.Windows.Forms.ContextMenuStrip cmsDatabase;
        private System.Windows.Forms.ToolStripMenuItem menuItemViewDB;
        private System.Windows.Forms.ToolStripMenuItem menuItemBatchBuildCode;
        private System.Windows.Forms.ToolStripMenuItem menuItemBuildDBDoc;
        private System.Windows.Forms.ToolStripMenuItem menuItemBuildTestDataForTable;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAddDbConnect;
        private System.Windows.Forms.Button btnSetConnectString;
    }
}