namespace Kalman.Studio
{
    partial class IISLogParser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.gbGrid = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClientIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClientIPLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWin32Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSendBytes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceiveBytes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReferer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUriStemAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRefererAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserAgentAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserAgent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.menuItemExportToDB = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.cms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(5, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbGrid);
            this.splitContainer1.Size = new System.Drawing.Size(823, 483);
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Controls.Add(this.cbCategory);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(193, 483);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "分类统计";
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(3, 37);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(187, 436);
            this.listBox1.TabIndex = 3;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // cbCategory
            // 
            this.cbCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Items.AddRange(new object[] {
            "显示全部数据",
            "按用户代理汇总",
            "按用户代理别名汇总",
            "按时间汇总",
            "按客户端IP汇总",
            "按引用地址汇总",
            "按引用地址别名汇总",
            "按请求地址别名汇总",
            "按客户端IP归属地汇总"});
            this.cbCategory.Location = new System.Drawing.Point(3, 17);
            this.cbCategory.MaxDropDownItems = 15;
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(187, 20);
            this.cbCategory.TabIndex = 2;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // gbGrid
            // 
            this.gbGrid.Controls.Add(this.dataGridView1);
            this.gbGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbGrid.Location = new System.Drawing.Point(0, 0);
            this.gbGrid.Name = "gbGrid";
            this.gbGrid.Size = new System.Drawing.Size(626, 483);
            this.gbGrid.TabIndex = 1;
            this.gbGrid.TabStop = false;
            this.gbGrid.Text = "日志数据";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colTime,
            this.colMethod,
            this.colClientIP,
            this.colClientIPLocation,
            this.colStatus,
            this.colSubStatus,
            this.colWin32Status,
            this.colSendBytes,
            this.colReceiveBytes,
            this.colUri,
            this.colReferer,
            this.colUriStemAlias,
            this.colRefererAlias,
            this.colUserAgentAlias,
            this.colUserAgent});
            this.dataGridView1.ContextMenuStrip = this.cms;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(620, 463);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "Date";
            this.colDate.HeaderText = "日期";
            this.colDate.Name = "colDate";
            this.colDate.Width = 80;
            // 
            // colTime
            // 
            this.colTime.DataPropertyName = "Time";
            this.colTime.HeaderText = "时间";
            this.colTime.Name = "colTime";
            this.colTime.Width = 80;
            // 
            // colMethod
            // 
            this.colMethod.DataPropertyName = "Method";
            this.colMethod.HeaderText = "方法";
            this.colMethod.Name = "colMethod";
            this.colMethod.Width = 55;
            // 
            // colClientIP
            // 
            this.colClientIP.DataPropertyName = "ClientIP";
            this.colClientIP.HeaderText = "客户端IP";
            this.colClientIP.Name = "colClientIP";
            // 
            // colClientIPLocation
            // 
            this.colClientIPLocation.DataPropertyName = "ClientIPLocation";
            this.colClientIPLocation.HeaderText = "客户端IP归属地";
            this.colClientIPLocation.Name = "colClientIPLocation";
            this.colClientIPLocation.Width = 120;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "协议状态";
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 80;
            // 
            // colSubStatus
            // 
            this.colSubStatus.DataPropertyName = "SubStatus";
            this.colSubStatus.HeaderText = "协议子状态";
            this.colSubStatus.Name = "colSubStatus";
            this.colSubStatus.Width = 90;
            // 
            // colWin32Status
            // 
            this.colWin32Status.DataPropertyName = "Win32Status";
            this.colWin32Status.HeaderText = "Win32状态";
            this.colWin32Status.Name = "colWin32Status";
            this.colWin32Status.Width = 85;
            // 
            // colSendBytes
            // 
            this.colSendBytes.DataPropertyName = "SendBytes";
            this.colSendBytes.HeaderText = "发送字节数";
            this.colSendBytes.Name = "colSendBytes";
            // 
            // colReceiveBytes
            // 
            this.colReceiveBytes.DataPropertyName = "ReceiveBytes";
            this.colReceiveBytes.HeaderText = "接收字节数";
            this.colReceiveBytes.Name = "colReceiveBytes";
            // 
            // colUri
            // 
            this.colUri.DataPropertyName = "UriStem";
            this.colUri.HeaderText = "请求地址";
            this.colUri.Name = "colUri";
            this.colUri.Width = 200;
            // 
            // colReferer
            // 
            this.colReferer.DataPropertyName = "Referer";
            this.colReferer.HeaderText = "引用地址";
            this.colReferer.Name = "colReferer";
            this.colReferer.Width = 200;
            // 
            // colUriStemAlias
            // 
            this.colUriStemAlias.DataPropertyName = "UriStemAlias";
            this.colUriStemAlias.HeaderText = "请求地址别名";
            this.colUriStemAlias.Name = "colUriStemAlias";
            this.colUriStemAlias.Width = 120;
            // 
            // colRefererAlias
            // 
            this.colRefererAlias.DataPropertyName = "RefererAlias";
            this.colRefererAlias.HeaderText = "引用地址别名";
            this.colRefererAlias.Name = "colRefererAlias";
            this.colRefererAlias.Width = 120;
            // 
            // colUserAgentAlias
            // 
            this.colUserAgentAlias.DataPropertyName = "UserAgentAlias";
            this.colUserAgentAlias.HeaderText = "用户代理别名";
            this.colUserAgentAlias.Name = "colUserAgentAlias";
            this.colUserAgentAlias.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colUserAgentAlias.Width = 250;
            // 
            // colUserAgent
            // 
            this.colUserAgent.DataPropertyName = "UserAgent";
            this.colUserAgent.HeaderText = "用户代理";
            this.colUserAgent.Name = "colUserAgent";
            this.colUserAgent.Width = 700;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSelectAll,
            this.menuItemCopy,
            this.menuItemExportToExcel,
            this.menuItemExportToDB});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(161, 114);
            // 
            // menuItemSelectAll
            // 
            this.menuItemSelectAll.Name = "menuItemSelectAll";
            this.menuItemSelectAll.Size = new System.Drawing.Size(160, 22);
            this.menuItemSelectAll.Text = "全选";
            this.menuItemSelectAll.Click += new System.EventHandler(this.menuItemSelectAll_Click);
            // 
            // menuItemCopy
            // 
            this.menuItemCopy.Name = "menuItemCopy";
            this.menuItemCopy.Size = new System.Drawing.Size(160, 22);
            this.menuItemCopy.Text = "复制";
            this.menuItemCopy.Click += new System.EventHandler(this.menuItemCopy_Click);
            // 
            // menuItemExportToExcel
            // 
            this.menuItemExportToExcel.Name = "menuItemExportToExcel";
            this.menuItemExportToExcel.Size = new System.Drawing.Size(160, 22);
            this.menuItemExportToExcel.Text = "导出Excel";
            this.menuItemExportToExcel.Click += new System.EventHandler(this.menuItemExport_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "IIS日志文件(*.log)|*.log|所有文件(*.*)|*.*";
            this.openFileDialog1.InitialDirectory = "C:\\WINDOWS\\system32\\LogFiles";
            // 
            // menuItemExportToDB
            // 
            this.menuItemExportToDB.Name = "menuItemExportToDB";
            this.menuItemExportToDB.Size = new System.Drawing.Size(160, 22);
            this.menuItemExportToDB.Text = "导出到SqlServer";
            this.menuItemExportToDB.Click += new System.EventHandler(this.menuItemExportToDB_Click);
            // 
            // IISLogParser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 493);
            this.Controls.Add(this.splitContainer1);
            this.Name = "IISLogParser";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "IIS日志解析器";
            this.Load += new System.EventHandler(this.IISLogParser_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gbGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.cms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.GroupBox gbGrid;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem menuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem menuItemExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem menuItemSelectAll;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClientIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClientIPLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWin32Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSendBytes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceiveBytes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUri;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReferer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUriStemAlias;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRefererAlias;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserAgentAlias;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserAgent;
        private System.Windows.Forms.ToolStripMenuItem menuItemExportToDB;


    }
}