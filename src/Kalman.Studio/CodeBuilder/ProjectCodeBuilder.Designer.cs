namespace Kalman.Studio
{
    partial class ProjectCodeBuilder
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbClassNameRemovePlural = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClassPrefix = new System.Windows.Forms.TextBox();
            this.cbClassNameIsFileName = new System.Windows.Forms.CheckBox();
            this.cbAddSuffix = new System.Windows.Forms.CheckBox();
            this.cbClassNamePascal = new System.Windows.Forms.CheckBox();
            this.cbDeleteTablePrifix = new System.Windows.Forms.CheckBox();
            this.txtClassSuffix = new System.Windows.Forms.TextBox();
            this.txtPrefixLevel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTablePrefix = new System.Windows.Forms.TextBox();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbConnectStringName = new System.Windows.Forms.ComboBox();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBarInfo = new System.Windows.Forms.ProgressBar();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.backgroundWorkerGenerate = new System.ComponentModel.BackgroundWorker();
            this.lblMsg = new System.Windows.Forms.Label();
            this.gbTableSelect = new System.Windows.Forms.GroupBox();
            this.btnRemoveOne = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnSelectOne = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cbTemplateName = new System.Windows.Forms.CheckBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbTableSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbTemplateName);
            this.groupBox3.Controls.Add(this.cbClassNameRemovePlural);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtClassPrefix);
            this.groupBox3.Controls.Add(this.cbClassNameIsFileName);
            this.groupBox3.Controls.Add(this.cbAddSuffix);
            this.groupBox3.Controls.Add(this.cbClassNamePascal);
            this.groupBox3.Controls.Add(this.cbDeleteTablePrifix);
            this.groupBox3.Controls.Add(this.txtClassSuffix);
            this.groupBox3.Controls.Add(this.txtPrefixLevel);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtTablePrefix);
            this.groupBox3.Controls.Add(this.txtNameSpace);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(8, 294);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(429, 155);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "基本设置";
            // 
            // cbClassNameRemovePlural
            // 
            this.cbClassNameRemovePlural.AutoSize = true;
            this.cbClassNameRemovePlural.Location = new System.Drawing.Point(138, 122);
            this.cbClassNameRemovePlural.Name = "cbClassNameRemovePlural";
            this.cbClassNameRemovePlural.Size = new System.Drawing.Size(96, 16);
            this.cbClassNameRemovePlural.TabIndex = 44;
            this.cbClassNameRemovePlural.Text = "去掉类名复数";
            this.cbClassNameRemovePlural.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 43;
            this.label2.Text = "+类名+";
            // 
            // txtClassPrefix
            // 
            this.txtClassPrefix.Location = new System.Drawing.Point(122, 95);
            this.txtClassPrefix.Name = "txtClassPrefix";
            this.txtClassPrefix.Size = new System.Drawing.Size(71, 21);
            this.txtClassPrefix.TabIndex = 42;
            // 
            // cbClassNameIsFileName
            // 
            this.cbClassNameIsFileName.AutoSize = true;
            this.cbClassNameIsFileName.Checked = true;
            this.cbClassNameIsFileName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbClassNameIsFileName.Location = new System.Drawing.Point(13, 122);
            this.cbClassNameIsFileName.Name = "cbClassNameIsFileName";
            this.cbClassNameIsFileName.Size = new System.Drawing.Size(108, 16);
            this.cbClassNameIsFileName.TabIndex = 41;
            this.cbClassNameIsFileName.Text = "类名作为文件名";
            this.cbClassNameIsFileName.UseVisualStyleBackColor = true;
            // 
            // cbAddSuffix
            // 
            this.cbAddSuffix.AutoSize = true;
            this.cbAddSuffix.Location = new System.Drawing.Point(13, 97);
            this.cbAddSuffix.Name = "cbAddSuffix";
            this.cbAddSuffix.Size = new System.Drawing.Size(108, 16);
            this.cbAddSuffix.TabIndex = 40;
            this.cbAddSuffix.Text = "类名添加前后缀";
            this.cbAddSuffix.UseVisualStyleBackColor = true;
            // 
            // cbClassNamePascal
            // 
            this.cbClassNamePascal.AutoSize = true;
            this.cbClassNamePascal.Location = new System.Drawing.Point(13, 72);
            this.cbClassNamePascal.Name = "cbClassNamePascal";
            this.cbClassNamePascal.Size = new System.Drawing.Size(180, 16);
            this.cbClassNamePascal.TabIndex = 39;
            this.cbClassNamePascal.Text = "规范化类名，按Pascal大小写";
            this.cbClassNamePascal.UseVisualStyleBackColor = true;
            // 
            // cbDeleteTablePrifix
            // 
            this.cbDeleteTablePrifix.AutoSize = true;
            this.cbDeleteTablePrifix.Location = new System.Drawing.Point(13, 47);
            this.cbDeleteTablePrifix.Name = "cbDeleteTablePrifix";
            this.cbDeleteTablePrifix.Size = new System.Drawing.Size(96, 16);
            this.cbDeleteTablePrifix.TabIndex = 38;
            this.cbDeleteTablePrifix.Text = "删除表名前缀";
            this.cbDeleteTablePrifix.UseVisualStyleBackColor = true;
            // 
            // txtClassSuffix
            // 
            this.txtClassSuffix.Location = new System.Drawing.Point(246, 95);
            this.txtClassSuffix.Name = "txtClassSuffix";
            this.txtClassSuffix.Size = new System.Drawing.Size(76, 21);
            this.txtClassSuffix.TabIndex = 37;
            // 
            // txtPrefixLevel
            // 
            this.txtPrefixLevel.Location = new System.Drawing.Point(327, 45);
            this.txtPrefixLevel.Name = "txtPrefixLevel";
            this.txtPrefixLevel.Size = new System.Drawing.Size(30, 21);
            this.txtPrefixLevel.TabIndex = 36;
            this.txtPrefixLevel.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(272, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 35;
            this.label8.Text = "前缀层次";
            // 
            // txtTablePrefix
            // 
            this.txtTablePrefix.Location = new System.Drawing.Point(228, 45);
            this.txtTablePrefix.Name = "txtTablePrefix";
            this.txtTablePrefix.Size = new System.Drawing.Size(30, 21);
            this.txtTablePrefix.TabIndex = 33;
            this.txtTablePrefix.Text = "_";
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Location = new System.Drawing.Point(72, 18);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(285, 21);
            this.txtNameSpace.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "命名空间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(157, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 32;
            this.label5.Text = "前缀分隔符";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbConnectStringName);
            this.groupBox1.Controls.Add(this.cmbDatabase);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(8, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 47);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择数据库";
            // 
            // cbConnectStringName
            // 
            this.cbConnectStringName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbConnectStringName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConnectStringName.FormattingEnabled = true;
            this.cbConnectStringName.Location = new System.Drawing.Point(63, 18);
            this.cbConnectStringName.Name = "cbConnectStringName";
            this.cbConnectStringName.Size = new System.Drawing.Size(129, 20);
            this.cbConnectStringName.TabIndex = 3;
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDatabase.Location = new System.Drawing.Point(256, 18);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(152, 20);
            this.cmbDatabase.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "数据库：";
            // 
            // progressBarInfo
            // 
            this.progressBarInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarInfo.Location = new System.Drawing.Point(8, 484);
            this.progressBarInfo.Name = "progressBarInfo";
            this.progressBarInfo.Size = new System.Drawing.Size(427, 18);
            this.progressBarInfo.TabIndex = 52;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(279, 456);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 59;
            this.btnOK.Text = "生成";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(360, 456);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 60;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // backgroundWorkerGenerate
            // 
            this.backgroundWorkerGenerate.WorkerReportsProgress = true;
            this.backgroundWorkerGenerate.WorkerSupportsCancellation = true;
            this.backgroundWorkerGenerate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerGenerate_DoWork);
            this.backgroundWorkerGenerate.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerGenerate_ProgressChanged);
            this.backgroundWorkerGenerate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerGenerate_RunWorkerCompleted);
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMsg.AutoSize = true;
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(8, 461);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(101, 12);
            this.lblMsg.TabIndex = 61;
            this.lblMsg.Text = "代码生成进度显示";
            // 
            // gbTableSelect
            // 
            this.gbTableSelect.Controls.Add(this.btnRemoveOne);
            this.gbTableSelect.Controls.Add(this.btnRemoveAll);
            this.gbTableSelect.Controls.Add(this.btnSelectOne);
            this.gbTableSelect.Controls.Add(this.listBox2);
            this.gbTableSelect.Controls.Add(this.btnSelectAll);
            this.gbTableSelect.Controls.Add(this.listBox1);
            this.gbTableSelect.Location = new System.Drawing.Point(9, 58);
            this.gbTableSelect.Name = "gbTableSelect";
            this.gbTableSelect.Size = new System.Drawing.Size(428, 230);
            this.gbTableSelect.TabIndex = 62;
            this.gbTableSelect.TabStop = false;
            this.gbTableSelect.Text = "选择表";
            // 
            // btnRemoveOne
            // 
            this.btnRemoveOne.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveOne.Location = new System.Drawing.Point(198, 132);
            this.btnRemoveOne.Name = "btnRemoveOne";
            this.btnRemoveOne.Size = new System.Drawing.Size(28, 25);
            this.btnRemoveOne.TabIndex = 9;
            this.btnRemoveOne.Text = "<";
            this.btnRemoveOne.UseVisualStyleBackColor = true;
            this.btnRemoveOne.Click += new System.EventHandler(this.btnRemoveOne_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveAll.Location = new System.Drawing.Point(198, 182);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(28, 25);
            this.btnRemoveAll.TabIndex = 8;
            this.btnRemoveAll.Text = "<<";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnSelectOne
            // 
            this.btnSelectOne.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectOne.Location = new System.Drawing.Point(198, 82);
            this.btnSelectOne.Name = "btnSelectOne";
            this.btnSelectOne.Size = new System.Drawing.Size(28, 25);
            this.btnSelectOne.TabIndex = 7;
            this.btnSelectOne.Text = ">";
            this.btnSelectOne.UseVisualStyleBackColor = true;
            this.btnSelectOne.Click += new System.EventHandler(this.btnSelectOne_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(232, 20);
            this.listBox2.Name = "listBox2";
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox2.Size = new System.Drawing.Size(180, 196);
            this.listBox2.TabIndex = 6;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectAll.Location = new System.Drawing.Point(198, 32);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(28, 25);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = ">>";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 20);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(180, 196);
            this.listBox1.TabIndex = 0;
            // 
            // cbTemplateName
            // 
            this.cbTemplateName.AutoSize = true;
            this.cbTemplateName.Checked = true;
            this.cbTemplateName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTemplateName.Location = new System.Drawing.Point(250, 122);
            this.cbTemplateName.Name = "cbTemplateName";
            this.cbTemplateName.Size = new System.Drawing.Size(120, 16);
            this.cbTemplateName.TabIndex = 45;
            this.cbTemplateName.Text = "模板名作为文件名";
            this.cbTemplateName.UseVisualStyleBackColor = true;
            // 
            // ProjectCodeBuilder
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(447, 514);
            this.Controls.Add(this.gbTableSelect);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBarInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProjectCodeBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建项目";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BeegoProjectCodeBuilder_FormClosing);
            this.Load += new System.EventHandler(this.BeegoProjectCodeBuilder_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbTableSelect.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbDatabase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBarInfo;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbConnectStringName;
        private System.ComponentModel.BackgroundWorker backgroundWorkerGenerate;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.GroupBox gbTableSelect;
        private System.Windows.Forms.Button btnRemoveOne;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnSelectOne;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox cbClassNameRemovePlural;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClassPrefix;
        private System.Windows.Forms.CheckBox cbClassNameIsFileName;
        private System.Windows.Forms.CheckBox cbAddSuffix;
        private System.Windows.Forms.CheckBox cbClassNamePascal;
        private System.Windows.Forms.CheckBox cbDeleteTablePrifix;
        private System.Windows.Forms.TextBox txtClassSuffix;
        private System.Windows.Forms.TextBox txtPrefixLevel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTablePrefix;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbTemplateName;
    }
}