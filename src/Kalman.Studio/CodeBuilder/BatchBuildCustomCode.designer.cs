namespace Kalman.Studio
{
    partial class BatchBuildCustomCode
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.gbTableSelect = new System.Windows.Forms.GroupBox();
            this.cbSchema = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemoveOne = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnSelectOne = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectTemplate = new System.Windows.Forms.Button();
            this.txtTemplateFile = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFileNamePrefix = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRemoveProperty = new System.Windows.Forms.Button();
            this.btnAddProperty = new System.Windows.Forms.Button();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.txtPValue = new System.Windows.Forms.TextBox();
            this.txtPName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnBuildCode = new System.Windows.Forms.Button();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gbTableSelect.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(11, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(240, 172);
            this.listBox1.TabIndex = 0;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // gbTableSelect
            // 
            this.gbTableSelect.Controls.Add(this.cbSchema);
            this.gbTableSelect.Controls.Add(this.label1);
            this.gbTableSelect.Controls.Add(this.btnRemoveOne);
            this.gbTableSelect.Controls.Add(this.btnRemoveAll);
            this.gbTableSelect.Controls.Add(this.btnSelectOne);
            this.gbTableSelect.Controls.Add(this.listBox2);
            this.gbTableSelect.Controls.Add(this.btnSelectAll);
            this.gbTableSelect.Controls.Add(this.listBox1);
            this.gbTableSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTableSelect.Location = new System.Drawing.Point(0, 0);
            this.gbTableSelect.Margin = new System.Windows.Forms.Padding(10);
            this.gbTableSelect.Name = "gbTableSelect";
            this.gbTableSelect.Padding = new System.Windows.Forms.Padding(10);
            this.gbTableSelect.Size = new System.Drawing.Size(592, 221);
            this.gbTableSelect.TabIndex = 1;
            this.gbTableSelect.TabStop = false;
            this.gbTableSelect.Text = "选择架构和模板";
            // 
            // cbSchema
            // 
            this.cbSchema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSchema.FormattingEnabled = true;
            this.cbSchema.Items.AddRange(new object[] {
            "基于表架构代码生成",
            "基于视图架构代码生成",
            "基于存储过程架构代码生成"});
            this.cbSchema.Location = new System.Drawing.Point(68, 16);
            this.cbSchema.Name = "cbSchema";
            this.cbSchema.Size = new System.Drawing.Size(183, 20);
            this.cbSchema.TabIndex = 11;
            this.cbSchema.SelectedIndexChanged += new System.EventHandler(this.cbSchema_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "选择架构";
            // 
            // btnRemoveOne
            // 
            this.btnRemoveOne.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveOne.Location = new System.Drawing.Point(270, 134);
            this.btnRemoveOne.Name = "btnRemoveOne";
            this.btnRemoveOne.Size = new System.Drawing.Size(50, 25);
            this.btnRemoveOne.TabIndex = 9;
            this.btnRemoveOne.Text = "<";
            this.btnRemoveOne.UseVisualStyleBackColor = true;
            this.btnRemoveOne.Click += new System.EventHandler(this.btnRemoveOne_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveAll.Location = new System.Drawing.Point(270, 176);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(50, 25);
            this.btnRemoveAll.TabIndex = 8;
            this.btnRemoveAll.Text = "<<";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnSelectOne
            // 
            this.btnSelectOne.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectOne.Location = new System.Drawing.Point(270, 92);
            this.btnSelectOne.Name = "btnSelectOne";
            this.btnSelectOne.Size = new System.Drawing.Size(50, 25);
            this.btnSelectOne.TabIndex = 7;
            this.btnSelectOne.Text = ">";
            this.btnSelectOne.UseVisualStyleBackColor = true;
            this.btnSelectOne.Click += new System.EventHandler(this.btnSelectOne_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(339, 41);
            this.listBox2.Name = "listBox2";
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox2.Size = new System.Drawing.Size(240, 172);
            this.listBox2.TabIndex = 6;
            this.listBox2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox2_MouseDoubleClick);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectAll.Location = new System.Drawing.Point(270, 50);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(50, 25);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = ">>";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(519, 16);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(62, 23);
            this.btnPreview.TabIndex = 22;
            this.btnPreview.Text = "预览";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelectTemplate);
            this.groupBox1.Controls.Add(this.btnPreview);
            this.groupBox1.Controls.Add(this.txtTemplateFile);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtFileNamePrefix);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnRemoveProperty);
            this.groupBox1.Controls.Add(this.btnAddProperty);
            this.groupBox1.Controls.Add(this.listBox3);
            this.groupBox1.Controls.Add(this.txtPValue);
            this.groupBox1.Controls.Add(this.txtPName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblMsg);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.btnReturn);
            this.groupBox1.Controls.Add(this.btnBuildCode);
            this.groupBox1.Controls.Add(this.btnBrowser);
            this.groupBox1.Controls.Add(this.txtOutputPath);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 221);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 316);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数设置";
            // 
            // btnSelectTemplate
            // 
            this.btnSelectTemplate.Location = new System.Drawing.Point(450, 16);
            this.btnSelectTemplate.Name = "btnSelectTemplate";
            this.btnSelectTemplate.Size = new System.Drawing.Size(62, 23);
            this.btnSelectTemplate.TabIndex = 34;
            this.btnSelectTemplate.Text = "浏览...";
            this.btnSelectTemplate.UseVisualStyleBackColor = true;
            this.btnSelectTemplate.Click += new System.EventHandler(this.btnSelectTemplate_Click);
            // 
            // txtTemplateFile
            // 
            this.txtTemplateFile.Location = new System.Drawing.Point(92, 17);
            this.txtTemplateFile.Name = "txtTemplateFile";
            this.txtTemplateFile.Size = new System.Drawing.Size(352, 21);
            this.txtTemplateFile.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 32;
            this.label8.Text = "选择模板";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(134, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(311, 12);
            this.label7.TabIndex = 31;
            this.label7.Text = "输入要移除的文件名前缀分隔符，如\"_\"，若为空则不处理";
            // 
            // txtFileNamePrefix
            // 
            this.txtFileNamePrefix.Location = new System.Drawing.Point(92, 197);
            this.txtFileNamePrefix.Name = "txtFileNamePrefix";
            this.txtFileNamePrefix.Size = new System.Drawing.Size(36, 21);
            this.txtFileNamePrefix.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 29;
            this.label6.Text = "文件名前缀";
            // 
            // btnRemoveProperty
            // 
            this.btnRemoveProperty.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveProperty.Location = new System.Drawing.Point(270, 126);
            this.btnRemoveProperty.Name = "btnRemoveProperty";
            this.btnRemoveProperty.Size = new System.Drawing.Size(50, 25);
            this.btnRemoveProperty.TabIndex = 28;
            this.btnRemoveProperty.Text = "<";
            this.btnRemoveProperty.UseVisualStyleBackColor = true;
            this.btnRemoveProperty.Click += new System.EventHandler(this.btnRemoveProperty_Click);
            // 
            // btnAddProperty
            // 
            this.btnAddProperty.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddProperty.Location = new System.Drawing.Point(270, 70);
            this.btnAddProperty.Name = "btnAddProperty";
            this.btnAddProperty.Size = new System.Drawing.Size(50, 25);
            this.btnAddProperty.TabIndex = 27;
            this.btnAddProperty.Text = ">";
            this.btnAddProperty.UseVisualStyleBackColor = true;
            this.btnAddProperty.Click += new System.EventHandler(this.btnAddProperty_Click);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 12;
            this.listBox3.Location = new System.Drawing.Point(341, 45);
            this.listBox3.Name = "listBox3";
            this.listBox3.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox3.Size = new System.Drawing.Size(240, 136);
            this.listBox3.TabIndex = 26;
            this.listBox3.DoubleClick += new System.EventHandler(this.listBox3_DoubleClick);
            // 
            // txtPValue
            // 
            this.txtPValue.Location = new System.Drawing.Point(92, 73);
            this.txtPValue.Multiline = true;
            this.txtPValue.Name = "txtPValue";
            this.txtPValue.Size = new System.Drawing.Size(159, 114);
            this.txtPValue.TabIndex = 25;
            // 
            // txtPName
            // 
            this.txtPName.Location = new System.Drawing.Point(92, 45);
            this.txtPName.Name = "txtPName";
            this.txtPName.Size = new System.Drawing.Size(159, 21);
            this.txtPName.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "扩展属性值";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "扩展属性名";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(13, 272);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(101, 12);
            this.lblMsg.TabIndex = 21;
            this.lblMsg.Text = "代码生成进度显示";
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.ForestGreen;
            this.progressBar1.Location = new System.Drawing.Point(11, 292);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(570, 18);
            this.progressBar1.Step = 2;
            this.progressBar1.TabIndex = 20;
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(506, 261);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 19;
            this.btnReturn.Text = "返回";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnBuildCode
            // 
            this.btnBuildCode.Location = new System.Drawing.Point(394, 261);
            this.btnBuildCode.Name = "btnBuildCode";
            this.btnBuildCode.Size = new System.Drawing.Size(75, 23);
            this.btnBuildCode.TabIndex = 18;
            this.btnBuildCode.Text = "生成代码";
            this.btnBuildCode.UseVisualStyleBackColor = true;
            this.btnBuildCode.Click += new System.EventHandler(this.btnBuildCode_Click);
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(518, 226);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(62, 23);
            this.btnBrowser.TabIndex = 12;
            this.btnBrowser.Text = "浏览...";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(92, 227);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(420, 21);
            this.txtOutputPath.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "代码输出目录";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "T4模板|*.tt|所有文件|*.*";
            // 
            // BatchBuildCustomCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 537);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbTableSelect);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 564);
            this.MinimumSize = new System.Drawing.Size(600, 564);
            this.Name = "BatchBuildCustomCode";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量生成代码";
            this.Load += new System.EventHandler(this.BatchBuildCustomCode_Load);
            this.gbTableSelect.ResumeLayout(false);
            this.gbTableSelect.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnBuildCode;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnRemoveOne;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnSelectOne;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.GroupBox gbTableSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.ListBox listBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox cbSchema;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPValue;
        private System.Windows.Forms.TextBox txtPName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddProperty;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Button btnRemoveProperty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFileNamePrefix;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTemplateFile;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSelectTemplate;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}