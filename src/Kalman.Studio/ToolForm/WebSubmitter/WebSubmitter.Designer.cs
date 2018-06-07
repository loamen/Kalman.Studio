namespace Kalman.Studio
{
    partial class WebSubmitter
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbParams = new System.Windows.Forms.ListBox();
            this.txtPName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPValue = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEncode = new System.Windows.Forms.TextBox();
            this.rbtnOther = new System.Windows.Forms.RadioButton();
            this.rbtnUnicode = new System.Windows.Forms.RadioButton();
            this.rbtnDefault = new System.Windows.Forms.RadioButton();
            this.rbtnGB2312 = new System.Windows.Forms.RadioButton();
            this.rbtnUTF8 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbIsPost = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rtbResponse = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbHistory = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemRemoveHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请求地址";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(67, 14);
            this.txtUrl.Multiline = true;
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(559, 61);
            this.txtUrl.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "参数名称";
            // 
            // lbParams
            // 
            this.lbParams.FormattingEnabled = true;
            this.lbParams.ItemHeight = 12;
            this.lbParams.Location = new System.Drawing.Point(361, 107);
            this.lbParams.Name = "lbParams";
            this.lbParams.Size = new System.Drawing.Size(391, 184);
            this.lbParams.TabIndex = 3;
            this.lbParams.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbParams_MouseDoubleClick);
            // 
            // txtPName
            // 
            this.txtPName.Location = new System.Drawing.Point(68, 107);
            this.txtPName.Name = "txtPName";
            this.txtPName.Size = new System.Drawing.Size(223, 21);
            this.txtPName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "参数值";
            // 
            // txtPValue
            // 
            this.txtPValue.Location = new System.Drawing.Point(67, 134);
            this.txtPValue.Multiline = true;
            this.txtPValue.Name = "txtPValue";
            this.txtPValue.Size = new System.Drawing.Size(223, 159);
            this.txtPValue.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtEncode);
            this.groupBox2.Controls.Add(this.rbtnOther);
            this.groupBox2.Controls.Add(this.rbtnUnicode);
            this.groupBox2.Controls.Add(this.rbtnDefault);
            this.groupBox2.Controls.Add(this.rbtnGB2312);
            this.groupBox2.Controls.Add(this.rbtnUTF8);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnImport);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnSubmit);
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.cbIsPost);
            this.groupBox2.Controls.Add(this.lbParams);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtPValue);
            this.groupBox2.Controls.Add(this.txtUrl);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtPName);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(5, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 300);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "请求设置";
            // 
            // txtEncode
            // 
            this.txtEncode.Location = new System.Drawing.Point(527, 81);
            this.txtEncode.Name = "txtEncode";
            this.txtEncode.Size = new System.Drawing.Size(101, 21);
            this.txtEncode.TabIndex = 20;
            // 
            // rbtnOther
            // 
            this.rbtnOther.AutoSize = true;
            this.rbtnOther.Location = new System.Drawing.Point(438, 83);
            this.rbtnOther.Name = "rbtnOther";
            this.rbtnOther.Size = new System.Drawing.Size(83, 16);
            this.rbtnOther.TabIndex = 19;
            this.rbtnOther.Text = "其他编码：";
            this.rbtnOther.UseVisualStyleBackColor = true;
            // 
            // rbtnUnicode
            // 
            this.rbtnUnicode.AutoSize = true;
            this.rbtnUnicode.Location = new System.Drawing.Point(254, 83);
            this.rbtnUnicode.Name = "rbtnUnicode";
            this.rbtnUnicode.Size = new System.Drawing.Size(65, 16);
            this.rbtnUnicode.TabIndex = 18;
            this.rbtnUnicode.Text = "Unicode";
            this.rbtnUnicode.UseVisualStyleBackColor = true;
            // 
            // rbtnDefault
            // 
            this.rbtnDefault.AutoSize = true;
            this.rbtnDefault.Checked = true;
            this.rbtnDefault.Location = new System.Drawing.Point(70, 83);
            this.rbtnDefault.Name = "rbtnDefault";
            this.rbtnDefault.Size = new System.Drawing.Size(71, 16);
            this.rbtnDefault.TabIndex = 17;
            this.rbtnDefault.TabStop = true;
            this.rbtnDefault.Text = "系统默认";
            this.rbtnDefault.UseVisualStyleBackColor = true;
            // 
            // rbtnGB2312
            // 
            this.rbtnGB2312.AutoSize = true;
            this.rbtnGB2312.Location = new System.Drawing.Point(349, 83);
            this.rbtnGB2312.Name = "rbtnGB2312";
            this.rbtnGB2312.Size = new System.Drawing.Size(59, 16);
            this.rbtnGB2312.TabIndex = 16;
            this.rbtnGB2312.Text = "GB2312";
            this.rbtnGB2312.UseVisualStyleBackColor = true;
            // 
            // rbtnUTF8
            // 
            this.rbtnUTF8.AutoSize = true;
            this.rbtnUTF8.Location = new System.Drawing.Point(171, 83);
            this.rbtnUTF8.Name = "rbtnUTF8";
            this.rbtnUTF8.Size = new System.Drawing.Size(53, 16);
            this.rbtnUTF8.TabIndex = 15;
            this.rbtnUTF8.Text = "UTF-8";
            this.rbtnUTF8.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "请求编码";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(301, 106);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(50, 23);
            this.btnImport.TabIndex = 13;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(301, 250);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(50, 23);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "重置";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(633, 38);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(120, 63);
            this.btnSubmit.TabIndex = 11;
            this.btnSubmit.Text = "提交请求";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(301, 200);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(50, 23);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "删除";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(301, 150);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbIsPost
            // 
            this.cbIsPost.AutoSize = true;
            this.cbIsPost.Location = new System.Drawing.Point(632, 16);
            this.cbIsPost.Name = "cbIsPost";
            this.cbIsPost.Size = new System.Drawing.Size(120, 16);
            this.cbIsPost.TabIndex = 8;
            this.cbIsPost.Text = "是否POST方式提交";
            this.cbIsPost.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(5, 305);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 268);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rtbResponse);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(752, 243);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "响应输出";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rtbResponse
            // 
            this.rtbResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbResponse.Location = new System.Drawing.Point(3, 3);
            this.rtbResponse.Name = "rtbResponse";
            this.rtbResponse.Size = new System.Drawing.Size(746, 237);
            this.rtbResponse.TabIndex = 1;
            this.rtbResponse.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.webBrowser1);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(752, 243);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "HTML预览";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(746, 237);
            this.webBrowser1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbHistory);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(752, 243);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "历史记录";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbHistory
            // 
            this.lbHistory.ContextMenuStrip = this.contextMenuStrip1;
            this.lbHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbHistory.FormattingEnabled = true;
            this.lbHistory.ItemHeight = 12;
            this.lbHistory.Location = new System.Drawing.Point(3, 3);
            this.lbHistory.Name = "lbHistory";
            this.lbHistory.ScrollAlwaysVisible = true;
            this.lbHistory.Size = new System.Drawing.Size(746, 232);
            this.lbHistory.TabIndex = 4;
            this.lbHistory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbHistory_MouseDoubleClick);
            this.lbHistory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbHistory_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemRemoveHistory});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 26);
            // 
            // menuItemRemoveHistory
            // 
            this.menuItemRemoveHistory.Name = "menuItemRemoveHistory";
            this.menuItemRemoveHistory.Size = new System.Drawing.Size(134, 22);
            this.menuItemRemoveHistory.Text = "移除该记录";
            this.menuItemRemoveHistory.Click += new System.EventHandler(this.menuItemRemoveHistory_Click);
            // 
            // WebSubmitter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 578);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Name = "WebSubmitter";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Web客户端模拟器";
            this.Load += new System.EventHandler(this.WebSubmitter_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WebSubmitter_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbParams;
        private System.Windows.Forms.TextBox txtPName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPValue;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbIsPost;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox rtbResponse;
        private System.Windows.Forms.ListBox lbHistory;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemRemoveHistory;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbtnGB2312;
        private System.Windows.Forms.RadioButton rbtnUTF8;
        private System.Windows.Forms.RadioButton rbtnDefault;
        private System.Windows.Forms.RadioButton rbtnUnicode;
        private System.Windows.Forms.TextBox txtEncode;
        private System.Windows.Forms.RadioButton rbtnOther;
    }
}