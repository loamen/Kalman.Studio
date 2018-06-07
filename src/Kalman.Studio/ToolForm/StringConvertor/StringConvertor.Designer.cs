namespace Kalman.Studio
{
    partial class StringConvertor
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gb23 = new System.Windows.Forms.GroupBox();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.rtb2 = new System.Windows.Forms.RichTextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnToLower = new System.Windows.Forms.Button();
            this.btnToUpper = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.rtb1 = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbtnGB2312Encoding = new System.Windows.Forms.RadioButton();
            this.txtEncoding = new System.Windows.Forms.TextBox();
            this.rbtnOtherEncoding = new System.Windows.Forms.RadioButton();
            this.rbtnUTF8Encoding = new System.Windows.Forms.RadioButton();
            this.rbtnUnicodeEncoding = new System.Windows.Forms.RadioButton();
            this.rbtnDefaultEncoding = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRandomString = new System.Windows.Forms.Button();
            this.btnSecure = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnToHash = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gb23.SuspendLayout();
            this.gb2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gb1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gb23);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(792, 573);
            this.splitContainer1.SplitterDistance = 628;
            this.splitContainer1.TabIndex = 0;
            // 
            // gb23
            // 
            this.gb23.Controls.Add(this.gb2);
            this.gb23.Controls.Add(this.groupBox6);
            this.gb23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb23.Location = new System.Drawing.Point(0, 273);
            this.gb23.Name = "gb23";
            this.gb23.Size = new System.Drawing.Size(628, 300);
            this.gb23.TabIndex = 1;
            this.gb23.TabStop = false;
            this.gb23.Text = "输出结果";
            // 
            // gb2
            // 
            this.gb2.Controls.Add(this.rtb2);
            this.gb2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb2.Location = new System.Drawing.Point(3, 17);
            this.gb2.Name = "gb2";
            this.gb2.Size = new System.Drawing.Size(502, 280);
            this.gb2.TabIndex = 2;
            this.gb2.TabStop = false;
            this.gb2.Text = "内容";
            // 
            // rtb2
            // 
            this.rtb2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb2.Location = new System.Drawing.Point(3, 17);
            this.rtb2.Name = "rtb2";
            this.rtb2.Size = new System.Drawing.Size(496, 260);
            this.rtb2.TabIndex = 0;
            this.rtb2.Text = "";
            this.rtb2.TextChanged += new System.EventHandler(this.rtb2_TextChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnReplace);
            this.groupBox6.Controls.Add(this.btnToLower);
            this.groupBox6.Controls.Add(this.btnToUpper);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox6.Location = new System.Drawing.Point(505, 17);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(120, 280);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "转换";
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(16, 128);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(75, 23);
            this.btnReplace.TabIndex = 3;
            this.btnReplace.Text = "替换";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnToLower
            // 
            this.btnToLower.Location = new System.Drawing.Point(16, 78);
            this.btnToLower.Name = "btnToLower";
            this.btnToLower.Size = new System.Drawing.Size(75, 23);
            this.btnToLower.TabIndex = 1;
            this.btnToLower.Text = "转小写";
            this.btnToLower.UseVisualStyleBackColor = true;
            this.btnToLower.Click += new System.EventHandler(this.btnToLower_Click);
            // 
            // btnToUpper
            // 
            this.btnToUpper.Location = new System.Drawing.Point(16, 31);
            this.btnToUpper.Name = "btnToUpper";
            this.btnToUpper.Size = new System.Drawing.Size(75, 23);
            this.btnToUpper.TabIndex = 0;
            this.btnToUpper.Text = "转大写";
            this.btnToUpper.UseVisualStyleBackColor = true;
            this.btnToUpper.Click += new System.EventHandler(this.btnToUpper_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gb1);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(628, 273);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "原始字符串";
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.rtb1);
            this.gb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb1.Location = new System.Drawing.Point(3, 17);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(502, 253);
            this.gb1.TabIndex = 2;
            this.gb1.TabStop = false;
            this.gb1.Text = "内容";
            // 
            // rtb1
            // 
            this.rtb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb1.Location = new System.Drawing.Point(3, 17);
            this.rtb1.Name = "rtb1";
            this.rtb1.Size = new System.Drawing.Size(496, 233);
            this.rtb1.TabIndex = 0;
            this.rtb1.Text = "";
            this.rtb1.TextChanged += new System.EventHandler(this.rtb1_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbtnGB2312Encoding);
            this.groupBox4.Controls.Add(this.txtEncoding);
            this.groupBox4.Controls.Add(this.rbtnOtherEncoding);
            this.groupBox4.Controls.Add(this.rbtnUTF8Encoding);
            this.groupBox4.Controls.Add(this.rbtnUnicodeEncoding);
            this.groupBox4.Controls.Add(this.rbtnDefaultEncoding);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox4.Location = new System.Drawing.Point(505, 17);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(120, 253);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "编码";
            // 
            // rbtnGB2312Encoding
            // 
            this.rbtnGB2312Encoding.AutoSize = true;
            this.rbtnGB2312Encoding.Location = new System.Drawing.Point(16, 108);
            this.rbtnGB2312Encoding.Name = "rbtnGB2312Encoding";
            this.rbtnGB2312Encoding.Size = new System.Drawing.Size(59, 16);
            this.rbtnGB2312Encoding.TabIndex = 6;
            this.rbtnGB2312Encoding.TabStop = true;
            this.rbtnGB2312Encoding.Text = "GB2312";
            this.rbtnGB2312Encoding.UseVisualStyleBackColor = true;
            // 
            // txtEncoding
            // 
            this.txtEncoding.Location = new System.Drawing.Point(16, 164);
            this.txtEncoding.Name = "txtEncoding";
            this.txtEncoding.Size = new System.Drawing.Size(80, 21);
            this.txtEncoding.TabIndex = 5;
            this.txtEncoding.Text = "gb2312";
            // 
            // rbtnOtherEncoding
            // 
            this.rbtnOtherEncoding.AutoSize = true;
            this.rbtnOtherEncoding.Location = new System.Drawing.Point(16, 136);
            this.rbtnOtherEncoding.Name = "rbtnOtherEncoding";
            this.rbtnOtherEncoding.Size = new System.Drawing.Size(71, 16);
            this.rbtnOtherEncoding.TabIndex = 4;
            this.rbtnOtherEncoding.TabStop = true;
            this.rbtnOtherEncoding.Text = "指定编码";
            this.rbtnOtherEncoding.UseVisualStyleBackColor = true;
            // 
            // rbtnUTF8Encoding
            // 
            this.rbtnUTF8Encoding.AutoSize = true;
            this.rbtnUTF8Encoding.Location = new System.Drawing.Point(16, 80);
            this.rbtnUTF8Encoding.Name = "rbtnUTF8Encoding";
            this.rbtnUTF8Encoding.Size = new System.Drawing.Size(53, 16);
            this.rbtnUTF8Encoding.TabIndex = 3;
            this.rbtnUTF8Encoding.TabStop = true;
            this.rbtnUTF8Encoding.Text = "UTF-8";
            this.rbtnUTF8Encoding.UseVisualStyleBackColor = true;
            // 
            // rbtnUnicodeEncoding
            // 
            this.rbtnUnicodeEncoding.AutoSize = true;
            this.rbtnUnicodeEncoding.Location = new System.Drawing.Point(16, 52);
            this.rbtnUnicodeEncoding.Name = "rbtnUnicodeEncoding";
            this.rbtnUnicodeEncoding.Size = new System.Drawing.Size(65, 16);
            this.rbtnUnicodeEncoding.TabIndex = 2;
            this.rbtnUnicodeEncoding.TabStop = true;
            this.rbtnUnicodeEncoding.Text = "Unicode";
            this.rbtnUnicodeEncoding.UseVisualStyleBackColor = true;
            // 
            // rbtnDefaultEncoding
            // 
            this.rbtnDefaultEncoding.AutoSize = true;
            this.rbtnDefaultEncoding.Checked = true;
            this.rbtnDefaultEncoding.Location = new System.Drawing.Point(16, 24);
            this.rbtnDefaultEncoding.Name = "rbtnDefaultEncoding";
            this.rbtnDefaultEncoding.Size = new System.Drawing.Size(71, 16);
            this.rbtnDefaultEncoding.TabIndex = 1;
            this.rbtnDefaultEncoding.TabStop = true;
            this.rbtnDefaultEncoding.Text = "系统默认";
            this.rbtnDefaultEncoding.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.btnRandomString);
            this.groupBox3.Controls.Add(this.btnSecure);
            this.groupBox3.Controls.Add(this.btnConvert);
            this.groupBox3.Controls.Add(this.btnToHash);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(160, 573);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "字符串操作";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // btnRandomString
            // 
            this.btnRandomString.Location = new System.Drawing.Point(19, 149);
            this.btnRandomString.Name = "btnRandomString";
            this.btnRandomString.Size = new System.Drawing.Size(120, 23);
            this.btnRandomString.TabIndex = 15;
            this.btnRandomString.Text = "随机字符串";
            this.btnRandomString.UseVisualStyleBackColor = true;
            this.btnRandomString.Click += new System.EventHandler(this.btnRandomString_Click);
            // 
            // btnSecure
            // 
            this.btnSecure.Location = new System.Drawing.Point(19, 105);
            this.btnSecure.Name = "btnSecure";
            this.btnSecure.Size = new System.Drawing.Size(120, 23);
            this.btnSecure.TabIndex = 13;
            this.btnSecure.Text = "加密解密";
            this.btnSecure.UseVisualStyleBackColor = true;
            this.btnSecure.Click += new System.EventHandler(this.btnSecure_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(19, 61);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(120, 23);
            this.btnConvert.TabIndex = 11;
            this.btnConvert.Text = "常用转换";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnToHash
            // 
            this.btnToHash.Location = new System.Drawing.Point(19, 17);
            this.btnToHash.Name = "btnToHash";
            this.btnToHash.Size = new System.Drawing.Size(120, 23);
            this.btnToHash.TabIndex = 5;
            this.btnToHash.Text = "计算哈希值";
            this.btnToHash.UseVisualStyleBackColor = true;
            this.btnToHash.Click += new System.EventHandler(this.btnToHash_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(19, 523);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            // 
            // StringConvertor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "StringConvertor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "字符串转换工具";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.gb23.ResumeLayout(false);
            this.gb2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gb1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gb23;
        private System.Windows.Forms.RichTextBox rtb2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtb1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnToHash;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnRandomString;
        private System.Windows.Forms.Button btnSecure;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rbtnDefaultEncoding;
        private System.Windows.Forms.RadioButton rbtnUnicodeEncoding;
        private System.Windows.Forms.RadioButton rbtnUTF8Encoding;
        private System.Windows.Forms.RadioButton rbtnOtherEncoding;
        private System.Windows.Forms.TextBox txtEncoding;
        private System.Windows.Forms.Button btnToLower;
        private System.Windows.Forms.Button btnToUpper;
        private System.Windows.Forms.RadioButton rbtnGB2312Encoding;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button button1;
    }
}