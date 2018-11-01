namespace Kalman.Studio
{
    partial class DbDocBuilder
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
            this.cbDatabase = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbConnectionStrings = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnHtml = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.rbtnPdf = new System.Windows.Forms.RadioButton();
            this.rbtnWord = new System.Windows.Forms.RadioButton();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnSelectOne = new System.Windows.Forms.Button();
            this.btnRemoveOne = new System.Windows.Forms.Button();
            this.gbTableSelect = new System.Windows.Forms.GroupBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbTableSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbDatabase);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbConnectionStrings);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择数据库";
            // 
            // cbDatabase
            // 
            this.cbDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDatabase.FormattingEnabled = true;
            this.cbDatabase.Location = new System.Drawing.Point(410, 16);
            this.cbDatabase.Name = "cbDatabase";
            this.cbDatabase.Size = new System.Drawing.Size(158, 20);
            this.cbDatabase.TabIndex = 4;
            this.cbDatabase.SelectedIndexChanged += new System.EventHandler(this.cbDatabase_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "选择数据库";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "选择数据库连接字符串";
            // 
            // cbConnectionStrings
            // 
            this.cbConnectionStrings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConnectionStrings.FormattingEnabled = true;
            this.cbConnectionStrings.Location = new System.Drawing.Point(143, 16);
            this.cbConnectionStrings.Name = "cbConnectionStrings";
            this.cbConnectionStrings.Size = new System.Drawing.Size(168, 20);
            this.cbConnectionStrings.TabIndex = 1;
            this.cbConnectionStrings.SelectedIndexChanged += new System.EventHandler(this.cbConnectionStrings_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnHtml);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnOK);
            this.groupBox2.Controls.Add(this.rbtnPdf);
            this.groupBox2.Controls.Add(this.rbtnWord);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(5, 319);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(574, 57);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择文档输出格式";
            // 
            // rbtnHtml
            // 
            this.rbtnHtml.AutoSize = true;
            this.rbtnHtml.Location = new System.Drawing.Point(167, 23);
            this.rbtnHtml.Name = "rbtnHtml";
            this.rbtnHtml.Size = new System.Drawing.Size(71, 16);
            this.rbtnHtml.TabIndex = 6;
            this.rbtnHtml.TabStop = true;
            this.rbtnHtml.Text = "Html格式";
            this.rbtnHtml.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(491, 20);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(410, 20);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rbtnPdf
            // 
            this.rbtnPdf.AutoSize = true;
            this.rbtnPdf.Checked = true;
            this.rbtnPdf.Location = new System.Drawing.Point(17, 23);
            this.rbtnPdf.Name = "rbtnPdf";
            this.rbtnPdf.Size = new System.Drawing.Size(65, 16);
            this.rbtnPdf.TabIndex = 1;
            this.rbtnPdf.TabStop = true;
            this.rbtnPdf.Text = "Pdf格式";
            this.rbtnPdf.UseVisualStyleBackColor = true;
            // 
            // rbtnWord
            // 
            this.rbtnWord.AutoSize = true;
            this.rbtnWord.Location = new System.Drawing.Point(89, 23);
            this.rbtnWord.Name = "rbtnWord";
            this.rbtnWord.Size = new System.Drawing.Size(71, 16);
            this.rbtnWord.TabIndex = 0;
            this.rbtnWord.TabStop = true;
            this.rbtnWord.Text = "Word格式";
            this.rbtnWord.UseVisualStyleBackColor = true;
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveAll.Location = new System.Drawing.Point(271, 189);
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
            this.btnSelectOne.Location = new System.Drawing.Point(271, 105);
            this.btnSelectOne.Name = "btnSelectOne";
            this.btnSelectOne.Size = new System.Drawing.Size(50, 25);
            this.btnSelectOne.TabIndex = 7;
            this.btnSelectOne.Text = ">";
            this.btnSelectOne.UseVisualStyleBackColor = true;
            this.btnSelectOne.Click += new System.EventHandler(this.btnSelectOne_Click);
            // 
            // btnRemoveOne
            // 
            this.btnRemoveOne.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveOne.Location = new System.Drawing.Point(271, 147);
            this.btnRemoveOne.Name = "btnRemoveOne";
            this.btnRemoveOne.Size = new System.Drawing.Size(50, 25);
            this.btnRemoveOne.TabIndex = 9;
            this.btnRemoveOne.Text = "<";
            this.btnRemoveOne.UseVisualStyleBackColor = true;
            this.btnRemoveOne.Click += new System.EventHandler(this.btnRemoveOne_Click);
            // 
            // gbTableSelect
            // 
            this.gbTableSelect.Controls.Add(this.btnRemoveOne);
            this.gbTableSelect.Controls.Add(this.btnRemoveAll);
            this.gbTableSelect.Controls.Add(this.btnSelectOne);
            this.gbTableSelect.Controls.Add(this.listBox2);
            this.gbTableSelect.Controls.Add(this.btnSelectAll);
            this.gbTableSelect.Controls.Add(this.listBox1);
            this.gbTableSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTableSelect.Location = new System.Drawing.Point(5, 49);
            this.gbTableSelect.Margin = new System.Windows.Forms.Padding(10);
            this.gbTableSelect.Name = "gbTableSelect";
            this.gbTableSelect.Padding = new System.Windows.Forms.Padding(10);
            this.gbTableSelect.Size = new System.Drawing.Size(574, 270);
            this.gbTableSelect.TabIndex = 2;
            this.gbTableSelect.TabStop = false;
            this.gbTableSelect.Text = "选择表";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(340, 20);
            this.listBox2.Name = "listBox2";
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox2.Size = new System.Drawing.Size(231, 244);
            this.listBox2.TabIndex = 6;
            this.listBox2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox2_MouseDoubleClick);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectAll.Location = new System.Drawing.Point(271, 63);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(50, 25);
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
            this.listBox1.Size = new System.Drawing.Size(240, 244);
            this.listBox1.TabIndex = 0;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "pdf文件(*.pdf)|*.pdf|所有文件(*.*)|*.*";
            // 
            // DbDocBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 381);
            this.Controls.Add(this.gbTableSelect);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(600, 420);
            this.MinimumSize = new System.Drawing.Size(600, 420);
            this.Name = "DbDocBuilder";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库文档生成器";
            this.Load += new System.EventHandler(this.DbDocBuilder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbTableSelect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnSelectOne;
        private System.Windows.Forms.Button btnRemoveOne;
        private System.Windows.Forms.GroupBox gbTableSelect;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox cbDatabase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbConnectionStrings;
        private System.Windows.Forms.RadioButton rbtnWord;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton rbtnPdf;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.RadioButton rbtnHtml;
    }
}