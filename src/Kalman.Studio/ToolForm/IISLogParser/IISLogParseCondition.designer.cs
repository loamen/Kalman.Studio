namespace Kalman.Studio
{
    partial class IISLogParseCondition
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnRemoveFile = new System.Windows.Forms.Button();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.listBoxLogFiles = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbAllowQueryByTime = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpBeginTime = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbAllowQueryByIP = new System.Windows.Forms.CheckBox();
            this.txtIPList = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbAllowQueryByIPLocation = new System.Windows.Forms.CheckBox();
            this.txtIPLocationList = new System.Windows.Forms.TextBox();
            this.cbAllowQueryByUserAgent = new System.Windows.Forms.CheckBox();
            this.txtUserAgentList = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbAllowQueryByUri = new System.Windows.Forms.CheckBox();
            this.txtUriList = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cbAllowQueryByReferer = new System.Windows.Forms.CheckBox();
            this.txtRefererList = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cbAllowQueryByStatus = new System.Windows.Forms.CheckBox();
            this.txtStatusList = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.rbtnGet = new System.Windows.Forms.RadioButton();
            this.rbtnPost = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemoveAll);
            this.groupBox1.Controls.Add(this.btnRemoveFile);
            this.groupBox1.Controls.Add(this.btnAddFolder);
            this.groupBox1.Controls.Add(this.btnAddFile);
            this.groupBox1.Controls.Add(this.listBoxLogFiles);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(781, 132);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择日志文件";
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(700, 100);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAll.TabIndex = 4;
            this.btnRemoveAll.Text = "全部移除";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.Location = new System.Drawing.Point(700, 71);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveFile.TabIndex = 3;
            this.btnRemoveFile.Text = "移除文件";
            this.btnRemoveFile.UseVisualStyleBackColor = true;
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Location = new System.Drawing.Point(700, 42);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(75, 23);
            this.btnAddFolder.TabIndex = 2;
            this.btnAddFolder.Text = "添加目录";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Location = new System.Drawing.Point(700, 13);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(75, 23);
            this.btnAddFile.TabIndex = 1;
            this.btnAddFile.Text = "添加文件";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // listBoxLogFiles
            // 
            this.listBoxLogFiles.FormattingEnabled = true;
            this.listBoxLogFiles.ItemHeight = 12;
            this.listBoxLogFiles.Location = new System.Drawing.Point(6, 13);
            this.listBoxLogFiles.Name = "listBoxLogFiles";
            this.listBoxLogFiles.Size = new System.Drawing.Size(688, 112);
            this.listBoxLogFiles.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbAllowQueryByTime);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtpEndTime);
            this.groupBox2.Controls.Add(this.dtpBeginTime);
            this.groupBox2.Location = new System.Drawing.Point(5, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(781, 52);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择时间范围";
            // 
            // cbAllowQueryByTime
            // 
            this.cbAllowQueryByTime.AutoSize = true;
            this.cbAllowQueryByTime.Location = new System.Drawing.Point(691, 23);
            this.cbAllowQueryByTime.Name = "cbAllowQueryByTime";
            this.cbAllowQueryByTime.Size = new System.Drawing.Size(84, 16);
            this.cbAllowQueryByTime.TabIndex = 4;
            this.cbAllowQueryByTime.Text = "启用该条件";
            this.cbAllowQueryByTime.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "结束时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "开始时间";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(391, 21);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(155, 21);
            this.dtpEndTime.TabIndex = 1;
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBeginTime.Location = new System.Drawing.Point(101, 21);
            this.dtpBeginTime.Name = "dtpBeginTime";
            this.dtpBeginTime.Size = new System.Drawing.Size(155, 21);
            this.dtpBeginTime.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbAllowQueryByIP);
            this.groupBox3.Controls.Add(this.txtIPList);
            this.groupBox3.Location = new System.Drawing.Point(5, 201);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(781, 45);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "客户端IP[多个IP之间用\",\"隔开]";
            // 
            // cbAllowQueryByIP
            // 
            this.cbAllowQueryByIP.AutoSize = true;
            this.cbAllowQueryByIP.Location = new System.Drawing.Point(691, 20);
            this.cbAllowQueryByIP.Name = "cbAllowQueryByIP";
            this.cbAllowQueryByIP.Size = new System.Drawing.Size(84, 16);
            this.cbAllowQueryByIP.TabIndex = 4;
            this.cbAllowQueryByIP.Text = "启用该条件";
            this.cbAllowQueryByIP.UseVisualStyleBackColor = true;
            // 
            // txtIPList
            // 
            this.txtIPList.Location = new System.Drawing.Point(8, 17);
            this.txtIPList.Multiline = true;
            this.txtIPList.Name = "txtIPList";
            this.txtIPList.Size = new System.Drawing.Size(672, 23);
            this.txtIPList.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbAllowQueryByIPLocation);
            this.groupBox4.Controls.Add(this.txtIPLocationList);
            this.groupBox4.Location = new System.Drawing.Point(5, 252);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(781, 45);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "客户端IP归属地[多个地址之间用\",\"隔开]，部分匹配";
            // 
            // cbAllowQueryByIPLocation
            // 
            this.cbAllowQueryByIPLocation.AutoSize = true;
            this.cbAllowQueryByIPLocation.Location = new System.Drawing.Point(691, 20);
            this.cbAllowQueryByIPLocation.Name = "cbAllowQueryByIPLocation";
            this.cbAllowQueryByIPLocation.Size = new System.Drawing.Size(84, 16);
            this.cbAllowQueryByIPLocation.TabIndex = 4;
            this.cbAllowQueryByIPLocation.Text = "启用该条件";
            this.cbAllowQueryByIPLocation.UseVisualStyleBackColor = true;
            // 
            // txtIPLocationList
            // 
            this.txtIPLocationList.Location = new System.Drawing.Point(8, 17);
            this.txtIPLocationList.Multiline = true;
            this.txtIPLocationList.Name = "txtIPLocationList";
            this.txtIPLocationList.Size = new System.Drawing.Size(672, 23);
            this.txtIPLocationList.TabIndex = 0;
            // 
            // cbAllowQueryByUserAgent
            // 
            this.cbAllowQueryByUserAgent.AutoSize = true;
            this.cbAllowQueryByUserAgent.Location = new System.Drawing.Point(691, 20);
            this.cbAllowQueryByUserAgent.Name = "cbAllowQueryByUserAgent";
            this.cbAllowQueryByUserAgent.Size = new System.Drawing.Size(84, 16);
            this.cbAllowQueryByUserAgent.TabIndex = 4;
            this.cbAllowQueryByUserAgent.Text = "启用该条件";
            this.cbAllowQueryByUserAgent.UseVisualStyleBackColor = true;
            // 
            // txtUserAgentList
            // 
            this.txtUserAgentList.Location = new System.Drawing.Point(8, 17);
            this.txtUserAgentList.Multiline = true;
            this.txtUserAgentList.Name = "txtUserAgentList";
            this.txtUserAgentList.Size = new System.Drawing.Size(672, 23);
            this.txtUserAgentList.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbAllowQueryByUserAgent);
            this.groupBox5.Controls.Add(this.txtUserAgentList);
            this.groupBox5.Location = new System.Drawing.Point(5, 303);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(781, 45);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "用户代理[多条记录之间用\",\"隔开]，部分匹配";
            // 
            // cbAllowQueryByUri
            // 
            this.cbAllowQueryByUri.AutoSize = true;
            this.cbAllowQueryByUri.Location = new System.Drawing.Point(691, 20);
            this.cbAllowQueryByUri.Name = "cbAllowQueryByUri";
            this.cbAllowQueryByUri.Size = new System.Drawing.Size(84, 16);
            this.cbAllowQueryByUri.TabIndex = 4;
            this.cbAllowQueryByUri.Text = "启用该条件";
            this.cbAllowQueryByUri.UseVisualStyleBackColor = true;
            // 
            // txtUriList
            // 
            this.txtUriList.Location = new System.Drawing.Point(8, 17);
            this.txtUriList.Multiline = true;
            this.txtUriList.Name = "txtUriList";
            this.txtUriList.Size = new System.Drawing.Size(672, 23);
            this.txtUriList.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbAllowQueryByUri);
            this.groupBox6.Controls.Add(this.txtUriList);
            this.groupBox6.Location = new System.Drawing.Point(5, 354);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(781, 45);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "请求地址[多个地址之间用\",\"隔开，不区分大小写]，模糊查询";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cbAllowQueryByReferer);
            this.groupBox7.Controls.Add(this.txtRefererList);
            this.groupBox7.Location = new System.Drawing.Point(5, 405);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(781, 45);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "引用地址[多个地址之间用\",\"隔开，不区分大小写]，部分匹配";
            // 
            // cbAllowQueryByReferer
            // 
            this.cbAllowQueryByReferer.AutoSize = true;
            this.cbAllowQueryByReferer.Location = new System.Drawing.Point(691, 20);
            this.cbAllowQueryByReferer.Name = "cbAllowQueryByReferer";
            this.cbAllowQueryByReferer.Size = new System.Drawing.Size(84, 16);
            this.cbAllowQueryByReferer.TabIndex = 4;
            this.cbAllowQueryByReferer.Text = "启用该条件";
            this.cbAllowQueryByReferer.UseVisualStyleBackColor = true;
            // 
            // txtRefererList
            // 
            this.txtRefererList.Location = new System.Drawing.Point(8, 17);
            this.txtRefererList.Multiline = true;
            this.txtRefererList.Name = "txtRefererList";
            this.txtRefererList.Size = new System.Drawing.Size(672, 23);
            this.txtRefererList.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(711, 507);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "IIS日志文件(*.log)|*.log|所有文件(*.*)|*.*";
            this.openFileDialog1.InitialDirectory = "C:\\WINDOWS\\system32\\LogFiles";
            this.openFileDialog1.Multiselect = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cbAllowQueryByStatus);
            this.groupBox8.Controls.Add(this.txtStatusList);
            this.groupBox8.Location = new System.Drawing.Point(5, 456);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(781, 45);
            this.groupBox8.TabIndex = 10;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "协议状态[多个状态之间用\",\"隔开]";
            // 
            // cbAllowQueryByStatus
            // 
            this.cbAllowQueryByStatus.AutoSize = true;
            this.cbAllowQueryByStatus.Location = new System.Drawing.Point(691, 20);
            this.cbAllowQueryByStatus.Name = "cbAllowQueryByStatus";
            this.cbAllowQueryByStatus.Size = new System.Drawing.Size(84, 16);
            this.cbAllowQueryByStatus.TabIndex = 4;
            this.cbAllowQueryByStatus.Text = "启用该条件";
            this.cbAllowQueryByStatus.UseVisualStyleBackColor = true;
            // 
            // txtStatusList
            // 
            this.txtStatusList.Location = new System.Drawing.Point(8, 17);
            this.txtStatusList.Multiline = true;
            this.txtStatusList.Name = "txtStatusList";
            this.txtStatusList.Size = new System.Drawing.Size(672, 23);
            this.txtStatusList.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(624, 507);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 512);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "方法";
            // 
            // rbtnAll
            // 
            this.rbtnAll.AutoSize = true;
            this.rbtnAll.Checked = true;
            this.rbtnAll.Location = new System.Drawing.Point(65, 510);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(41, 16);
            this.rbtnAll.TabIndex = 13;
            this.rbtnAll.TabStop = true;
            this.rbtnAll.Text = "All";
            this.rbtnAll.UseVisualStyleBackColor = true;
            // 
            // rbtnGet
            // 
            this.rbtnGet.AutoSize = true;
            this.rbtnGet.Location = new System.Drawing.Point(128, 510);
            this.rbtnGet.Name = "rbtnGet";
            this.rbtnGet.Size = new System.Drawing.Size(41, 16);
            this.rbtnGet.TabIndex = 14;
            this.rbtnGet.Text = "Get";
            this.rbtnGet.UseVisualStyleBackColor = true;
            // 
            // rbtnPost
            // 
            this.rbtnPost.AutoSize = true;
            this.rbtnPost.Location = new System.Drawing.Point(191, 510);
            this.rbtnPost.Name = "rbtnPost";
            this.rbtnPost.Size = new System.Drawing.Size(47, 16);
            this.rbtnPost.TabIndex = 15;
            this.rbtnPost.Text = "Post";
            this.rbtnPost.UseVisualStyleBackColor = true;
            // 
            // IISLogParseCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 533);
            this.Controls.Add(this.rbtnPost);
            this.Controls.Add(this.rbtnGet);
            this.Controls.Add(this.rbtnAll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "IISLogParseCondition";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择日志解析条件";
            this.Load += new System.EventHandler(this.IISLogParseCondition_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnRemoveFile;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.ListBox listBoxLogFiles;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpBeginTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.CheckBox cbAllowQueryByTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtIPList;
        private System.Windows.Forms.CheckBox cbAllowQueryByIP;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbAllowQueryByIPLocation;
        private System.Windows.Forms.TextBox txtIPLocationList;
        private System.Windows.Forms.CheckBox cbAllowQueryByUserAgent;
        private System.Windows.Forms.TextBox txtUserAgentList;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cbAllowQueryByUri;
        private System.Windows.Forms.TextBox txtUriList;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox cbAllowQueryByReferer;
        private System.Windows.Forms.TextBox txtRefererList;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckBox cbAllowQueryByStatus;
        private System.Windows.Forms.TextBox txtStatusList;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbtnAll;
        private System.Windows.Forms.RadioButton rbtnGet;
        private System.Windows.Forms.RadioButton rbtnPost;
    }
}