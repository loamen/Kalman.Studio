namespace Kalman.Studio
{
    partial class DbObjectViewer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbDatabase = new System.Windows.Forms.ComboBox();
            this.lblDbName = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpTable = new System.Windows.Forms.TabPage();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.tpView = new System.Windows.Forms.TabPage();
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.tpSP = new System.Windows.Forms.TabPage();
            this.dgvSP = new System.Windows.Forms.DataGridView();
            this.colSPOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSPName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSPFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSPComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colViewOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colViewName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colViewFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colViewComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTableOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTableComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.tpView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.tpSP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbDatabase);
            this.panel1.Controls.Add(this.lblDbName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 33);
            this.panel1.TabIndex = 0;
            // 
            // cbDatabase
            // 
            this.cbDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDatabase.FormattingEnabled = true;
            this.cbDatabase.Location = new System.Drawing.Point(74, 8);
            this.cbDatabase.Name = "cbDatabase";
            this.cbDatabase.Size = new System.Drawing.Size(178, 20);
            this.cbDatabase.TabIndex = 1;
            // 
            // lblDbName
            // 
            this.lblDbName.AutoSize = true;
            this.lblDbName.Location = new System.Drawing.Point(3, 12);
            this.lblDbName.Name = "lblDbName";
            this.lblDbName.Size = new System.Drawing.Size(65, 12);
            this.lblDbName.TabIndex = 0;
            this.lblDbName.Text = "当前数据库";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpTable);
            this.tabControl1.Controls.Add(this.tpView);
            this.tabControl1.Controls.Add(this.tpSP);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(739, 420);
            this.tabControl1.TabIndex = 1;
            // 
            // tpTable
            // 
            this.tpTable.Controls.Add(this.dgvTable);
            this.tpTable.Location = new System.Drawing.Point(4, 21);
            this.tpTable.Name = "tpTable";
            this.tpTable.Padding = new System.Windows.Forms.Padding(3);
            this.tpTable.Size = new System.Drawing.Size(731, 395);
            this.tpTable.TabIndex = 0;
            this.tpTable.Text = "表";
            this.tpTable.UseVisualStyleBackColor = true;
            // 
            // dgvTable
            // 
            this.dgvTable.AllowUserToAddRows = false;
            this.dgvTable.AllowUserToDeleteRows = false;
            this.dgvTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTableOwner,
            this.colTableName,
            this.colFullName,
            this.colTableComment});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTable.Location = new System.Drawing.Point(3, 3);
            this.dgvTable.MultiSelect = false;
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.RowHeadersVisible = false;
            this.dgvTable.RowTemplate.Height = 23;
            this.dgvTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTable.Size = new System.Drawing.Size(725, 389);
            this.dgvTable.TabIndex = 0;
            this.dgvTable.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTable_CellMouseDown);
            this.dgvTable.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTable_CellMouseDoubleClick);
            // 
            // tpView
            // 
            this.tpView.Controls.Add(this.dgvView);
            this.tpView.Location = new System.Drawing.Point(4, 21);
            this.tpView.Name = "tpView";
            this.tpView.Padding = new System.Windows.Forms.Padding(3);
            this.tpView.Size = new System.Drawing.Size(731, 395);
            this.tpView.TabIndex = 1;
            this.tpView.Text = "视图";
            this.tpView.UseVisualStyleBackColor = true;
            // 
            // dgvView
            // 
            this.dgvView.AllowUserToAddRows = false;
            this.dgvView.AllowUserToDeleteRows = false;
            this.dgvView.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colViewOwner,
            this.colViewName,
            this.colViewFullName,
            this.colViewComment});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvView.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvView.Location = new System.Drawing.Point(3, 3);
            this.dgvView.MultiSelect = false;
            this.dgvView.Name = "dgvView";
            this.dgvView.ReadOnly = true;
            this.dgvView.RowHeadersVisible = false;
            this.dgvView.RowTemplate.Height = 23;
            this.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvView.Size = new System.Drawing.Size(725, 389);
            this.dgvView.TabIndex = 1;
            this.dgvView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvView_CellMouseDoubleClick);
            // 
            // tpSP
            // 
            this.tpSP.Controls.Add(this.dgvSP);
            this.tpSP.Location = new System.Drawing.Point(4, 21);
            this.tpSP.Name = "tpSP";
            this.tpSP.Padding = new System.Windows.Forms.Padding(3);
            this.tpSP.Size = new System.Drawing.Size(731, 395);
            this.tpSP.TabIndex = 2;
            this.tpSP.Text = "存储过程";
            this.tpSP.UseVisualStyleBackColor = true;
            // 
            // dgvSP
            // 
            this.dgvSP.AllowUserToAddRows = false;
            this.dgvSP.AllowUserToDeleteRows = false;
            this.dgvSP.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSPOwner,
            this.colSPName,
            this.colSPFullName,
            this.colSPComment});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSP.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSP.Location = new System.Drawing.Point(3, 3);
            this.dgvSP.MultiSelect = false;
            this.dgvSP.Name = "dgvSP";
            this.dgvSP.ReadOnly = true;
            this.dgvSP.RowHeadersVisible = false;
            this.dgvSP.RowTemplate.Height = 23;
            this.dgvSP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSP.Size = new System.Drawing.Size(725, 389);
            this.dgvSP.TabIndex = 1;
            this.dgvSP.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSP_CellMouseDoubleClick);
            // 
            // colSPOwner
            // 
            this.colSPOwner.DataPropertyName = "Owner";
            this.colSPOwner.FillWeight = 60F;
            this.colSPOwner.HeaderText = "所有者";
            this.colSPOwner.Name = "colSPOwner";
            this.colSPOwner.ReadOnly = true;
            this.colSPOwner.Width = 120;
            // 
            // colSPName
            // 
            this.colSPName.DataPropertyName = "Name";
            this.colSPName.FillWeight = 60F;
            this.colSPName.HeaderText = "存储过程名";
            this.colSPName.Name = "colSPName";
            this.colSPName.ReadOnly = true;
            this.colSPName.Width = 150;
            // 
            // colSPFullName
            // 
            this.colSPFullName.DataPropertyName = "FullName";
            this.colSPFullName.HeaderText = "全名";
            this.colSPFullName.Name = "colSPFullName";
            this.colSPFullName.ReadOnly = true;
            this.colSPFullName.Width = 280;
            // 
            // colSPComment
            // 
            this.colSPComment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSPComment.DataPropertyName = "Comment";
            this.colSPComment.FillWeight = 200F;
            this.colSPComment.HeaderText = "说明";
            this.colSPComment.Name = "colSPComment";
            this.colSPComment.ReadOnly = true;
            // 
            // colViewOwner
            // 
            this.colViewOwner.DataPropertyName = "Owner";
            this.colViewOwner.FillWeight = 60F;
            this.colViewOwner.HeaderText = "所有者";
            this.colViewOwner.Name = "colViewOwner";
            this.colViewOwner.ReadOnly = true;
            this.colViewOwner.Width = 120;
            // 
            // colViewName
            // 
            this.colViewName.DataPropertyName = "Name";
            this.colViewName.FillWeight = 60F;
            this.colViewName.HeaderText = "视图名";
            this.colViewName.Name = "colViewName";
            this.colViewName.ReadOnly = true;
            this.colViewName.Width = 150;
            // 
            // colViewFullName
            // 
            this.colViewFullName.DataPropertyName = "FullName";
            this.colViewFullName.HeaderText = "全名";
            this.colViewFullName.Name = "colViewFullName";
            this.colViewFullName.ReadOnly = true;
            this.colViewFullName.Width = 280;
            // 
            // colViewComment
            // 
            this.colViewComment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colViewComment.DataPropertyName = "Comment";
            this.colViewComment.FillWeight = 200F;
            this.colViewComment.HeaderText = "说明";
            this.colViewComment.Name = "colViewComment";
            this.colViewComment.ReadOnly = true;
            // 
            // colTableOwner
            // 
            this.colTableOwner.DataPropertyName = "Owner";
            this.colTableOwner.FillWeight = 60F;
            this.colTableOwner.HeaderText = "所有者";
            this.colTableOwner.Name = "colTableOwner";
            this.colTableOwner.Width = 120;
            // 
            // colTableName
            // 
            this.colTableName.DataPropertyName = "Name";
            this.colTableName.FillWeight = 60F;
            this.colTableName.HeaderText = "表名";
            this.colTableName.Name = "colTableName";
            this.colTableName.Width = 150;
            // 
            // colFullName
            // 
            this.colFullName.DataPropertyName = "FullName";
            this.colFullName.HeaderText = "全名";
            this.colFullName.Name = "colFullName";
            this.colFullName.Width = 280;
            // 
            // colTableComment
            // 
            this.colTableComment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTableComment.DataPropertyName = "Comment";
            this.colTableComment.FillWeight = 200F;
            this.colTableComment.HeaderText = "说明";
            this.colTableComment.Name = "colTableComment";
            // 
            // DbObjectViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 453);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "DbObjectViewer";
            this.Text = "数据库对象查看器";
            this.Load += new System.EventHandler(this.DbObjectViewer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.tpView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.tpSP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDbName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpTable;
        private System.Windows.Forms.TabPage tpView;
        private System.Windows.Forms.TabPage tpSP;
        private System.Windows.Forms.ComboBox cbDatabase;
        private System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.DataGridView dgvSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTableFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTableOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTableComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colViewOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn colViewName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colViewFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colViewComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSPOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSPName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSPFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSPComment;
    }
}