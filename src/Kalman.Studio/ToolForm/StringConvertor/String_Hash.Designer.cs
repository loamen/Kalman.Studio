namespace Kalman.Studio
{
    partial class String_Hash
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
            this.rbMD5 = new System.Windows.Forms.RadioButton();
            this.rbSHA1 = new System.Windows.Forms.RadioButton();
            this.rbSHA256 = new System.Windows.Forms.RadioButton();
            this.rbSHA384 = new System.Windows.Forms.RadioButton();
            this.rbSHA512 = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbBase64 = new System.Windows.Forms.CheckBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.cbFileHash = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbMD5
            // 
            this.rbMD5.AutoSize = true;
            this.rbMD5.Checked = true;
            this.rbMD5.Location = new System.Drawing.Point(20, 20);
            this.rbMD5.Name = "rbMD5";
            this.rbMD5.Size = new System.Drawing.Size(41, 16);
            this.rbMD5.TabIndex = 0;
            this.rbMD5.TabStop = true;
            this.rbMD5.Text = "MD5";
            this.rbMD5.UseVisualStyleBackColor = true;
            // 
            // rbSHA1
            // 
            this.rbSHA1.AutoSize = true;
            this.rbSHA1.Location = new System.Drawing.Point(20, 42);
            this.rbSHA1.Name = "rbSHA1";
            this.rbSHA1.Size = new System.Drawing.Size(47, 16);
            this.rbSHA1.TabIndex = 1;
            this.rbSHA1.Text = "SHA1";
            this.rbSHA1.UseVisualStyleBackColor = true;
            // 
            // rbSHA256
            // 
            this.rbSHA256.AutoSize = true;
            this.rbSHA256.Location = new System.Drawing.Point(20, 64);
            this.rbSHA256.Name = "rbSHA256";
            this.rbSHA256.Size = new System.Drawing.Size(59, 16);
            this.rbSHA256.TabIndex = 2;
            this.rbSHA256.Text = "SHA256";
            this.rbSHA256.UseVisualStyleBackColor = true;
            // 
            // rbSHA384
            // 
            this.rbSHA384.AutoSize = true;
            this.rbSHA384.Location = new System.Drawing.Point(20, 86);
            this.rbSHA384.Name = "rbSHA384";
            this.rbSHA384.Size = new System.Drawing.Size(59, 16);
            this.rbSHA384.TabIndex = 3;
            this.rbSHA384.Text = "SHA384";
            this.rbSHA384.UseVisualStyleBackColor = true;
            // 
            // rbSHA512
            // 
            this.rbSHA512.AutoSize = true;
            this.rbSHA512.Location = new System.Drawing.Point(20, 108);
            this.rbSHA512.Name = "rbSHA512";
            this.rbSHA512.Size = new System.Drawing.Size(59, 16);
            this.rbSHA512.TabIndex = 4;
            this.rbSHA512.Text = "SHA512";
            this.rbSHA512.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(220, 179);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbBase64
            // 
            this.cbBase64.AutoSize = true;
            this.cbBase64.Location = new System.Drawing.Point(16, 20);
            this.cbBase64.Name = "cbBase64";
            this.cbBase64.Size = new System.Drawing.Size(180, 16);
            this.cbBase64.TabIndex = 6;
            this.cbBase64.Text = "是否将结果转换为Base64编码";
            this.cbBase64.UseVisualStyleBackColor = true;
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(325, 179);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 7;
            this.btnReturn.Text = "返回";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // cbFileHash
            // 
            this.cbFileHash.AutoSize = true;
            this.cbFileHash.Location = new System.Drawing.Point(16, 43);
            this.cbFileHash.Name = "cbFileHash";
            this.cbFileHash.Size = new System.Drawing.Size(216, 16);
            this.cbFileHash.TabIndex = 8;
            this.cbFileHash.Text = "输入的是文件路径，计算文件哈希值";
            this.cbFileHash.UseVisualStyleBackColor = true;
            this.cbFileHash.CheckedChanged += new System.EventHandler(this.cbFileHash_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbMD5);
            this.groupBox1.Controls.Add(this.rbSHA1);
            this.groupBox1.Controls.Add(this.rbSHA256);
            this.groupBox1.Controls.Add(this.rbSHA384);
            this.groupBox1.Controls.Add(this.rbSHA512);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 148);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择哈希算法";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbBase64);
            this.groupBox2.Controls.Add(this.cbFileHash);
            this.groupBox2.Location = new System.Drawing.Point(151, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 148);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选项";
            // 
            // String_Hash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 223);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnOK);
            this.MaximumSize = new System.Drawing.Size(420, 250);
            this.MinimumSize = new System.Drawing.Size(420, 250);
            this.Name = "String_Hash";
            this.Text = "选择哈希算法";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbMD5;
        private System.Windows.Forms.RadioButton rbSHA1;
        private System.Windows.Forms.RadioButton rbSHA256;
        private System.Windows.Forms.RadioButton rbSHA384;
        private System.Windows.Forms.RadioButton rbSHA512;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox cbBase64;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.CheckBox cbFileHash;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}