namespace Kalman.Studio
{
    partial class BeegoProjectCodeBuilder
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
            this.rbWebProject = new System.Windows.Forms.RadioButton();
            this.rbApiProject = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.gbApiSetting = new System.Windows.Forms.GroupBox();
            this.cbGenerateSwagger = new System.Windows.Forms.CheckBox();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbTableSelect.SuspendLayout();
            this.gbApiSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbWebProject
            // 
            this.rbWebProject.AutoSize = true;
            this.rbWebProject.Location = new System.Drawing.Point(63, 18);
            this.rbWebProject.Name = "rbWebProject";
            this.rbWebProject.Size = new System.Drawing.Size(65, 16);
            this.rbWebProject.TabIndex = 0;
            this.rbWebProject.Text = "Web项目";
            this.rbWebProject.UseVisualStyleBackColor = true;
            this.rbWebProject.CheckedChanged += new System.EventHandler(this.rbWebProject_CheckedChanged);
            // 
            // rbApiProject
            // 
            this.rbApiProject.AutoSize = true;
            this.rbApiProject.Checked = true;
            this.rbApiProject.Location = new System.Drawing.Point(180, 18);
            this.rbApiProject.Name = "rbApiProject";
            this.rbApiProject.Size = new System.Drawing.Size(65, 16);
            this.rbApiProject.TabIndex = 0;
            this.rbApiProject.TabStop = true;
            this.rbApiProject.Text = "Api项目";
            this.rbApiProject.UseVisualStyleBackColor = true;
            this.rbApiProject.CheckedChanged += new System.EventHandler(this.rbApiProject_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbWebProject);
            this.groupBox6.Controls.Add(this.rbApiProject);
            this.groupBox6.Location = new System.Drawing.Point(8, 114);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(428, 44);
            this.groupBox6.TabIndex = 58;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "项目类型";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtProjectName);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(8, 58);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(428, 50);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "基本设置";
            // 
            // txtProjectName
            // 
            this.txtProjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProjectName.Location = new System.Drawing.Point(104, 18);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(304, 21);
            this.txtProjectName.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 44;
            this.label2.Text = "项目名称：";
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
            this.progressBarInfo.Location = new System.Drawing.Point(8, 432);
            this.progressBarInfo.Name = "progressBarInfo";
            this.progressBarInfo.Size = new System.Drawing.Size(429, 18);
            this.progressBarInfo.TabIndex = 52;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(281, 404);
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
            this.btnCancel.Location = new System.Drawing.Point(362, 404);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 60;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // backgroundWorkerGenerate
            // 
            this.backgroundWorkerGenerate.WorkerReportsProgress = true;
            this.backgroundWorkerGenerate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerGenerate_DoWork);
            this.backgroundWorkerGenerate.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerGenerate_ProgressChanged);
            this.backgroundWorkerGenerate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerGenerate_RunWorkerCompleted);
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMsg.AutoSize = true;
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(8, 409);
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
            this.gbTableSelect.Location = new System.Drawing.Point(8, 166);
            this.gbTableSelect.Name = "gbTableSelect";
            this.gbTableSelect.Size = new System.Drawing.Size(428, 230);
            this.gbTableSelect.TabIndex = 62;
            this.gbTableSelect.TabStop = false;
            this.gbTableSelect.Text = "选择表";
            this.gbTableSelect.Visible = false;
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
            // gbApiSetting
            // 
            this.gbApiSetting.Controls.Add(this.cbGenerateSwagger);
            this.gbApiSetting.Location = new System.Drawing.Point(8, 166);
            this.gbApiSetting.Name = "gbApiSetting";
            this.gbApiSetting.Size = new System.Drawing.Size(428, 58);
            this.gbApiSetting.TabIndex = 63;
            this.gbApiSetting.TabStop = false;
            this.gbApiSetting.Text = "设置";
            // 
            // cbGenerateSwagger
            // 
            this.cbGenerateSwagger.AutoSize = true;
            this.cbGenerateSwagger.Location = new System.Drawing.Point(12, 27);
            this.cbGenerateSwagger.Name = "cbGenerateSwagger";
            this.cbGenerateSwagger.Size = new System.Drawing.Size(150, 16);
            this.cbGenerateSwagger.TabIndex = 28;
            this.cbGenerateSwagger.Text = "同时生成Swagger文档库";
            this.cbGenerateSwagger.UseVisualStyleBackColor = true;
            // 
            // BeegoProjectCodeBuilder
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(449, 462);
            this.Controls.Add(this.gbApiSetting);
            this.Controls.Add(this.gbTableSelect);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBarInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BeegoProjectCodeBuilder";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建Beego项目";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BeegoProjectCodeBuilder_FormClosing);
            this.Load += new System.EventHandler(this.BeegoProjectCodeBuilder_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbTableSelect.ResumeLayout(false);
            this.gbApiSetting.ResumeLayout(false);
            this.gbApiSetting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbWebProject;
        private System.Windows.Forms.RadioButton rbApiProject;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.GroupBox gbApiSetting;
        private System.Windows.Forms.CheckBox cbGenerateSwagger;
    }
}