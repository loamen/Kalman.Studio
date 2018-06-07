namespace Kalman.Studio
{
    partial class String_SymmetricAlgorithm
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
            this.btnReturn = new System.Windows.Forms.Button();
            this.rbtnDES = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnRijndael_256 = new System.Windows.Forms.RadioButton();
            this.rbtnTripleDES_192 = new System.Windows.Forms.RadioButton();
            this.rbtnRijndael_192 = new System.Windows.Forms.RadioButton();
            this.rbtnRC2_128 = new System.Windows.Forms.RadioButton();
            this.rbtnTripleDES_128 = new System.Windows.Forms.RadioButton();
            this.rbtnRijndael_128 = new System.Windows.Forms.RadioButton();
            this.rbtnRC2_40 = new System.Windows.Forms.RadioButton();
            this.rbtnRC2_64 = new System.Windows.Forms.RadioButton();
            this.rbtnRC2_96 = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtIV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnDE = new System.Windows.Forms.RadioButton();
            this.rbtnEN = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(353, 241);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 14;
            this.btnReturn.Text = "返回";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // rbtnDES
            // 
            this.rbtnDES.AutoSize = true;
            this.rbtnDES.Checked = true;
            this.rbtnDES.Location = new System.Drawing.Point(15, 20);
            this.rbtnDES.Name = "rbtnDES";
            this.rbtnDES.Size = new System.Drawing.Size(41, 16);
            this.rbtnDES.TabIndex = 0;
            this.rbtnDES.TabStop = true;
            this.rbtnDES.Text = "DES";
            this.rbtnDES.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnRijndael_256);
            this.groupBox1.Controls.Add(this.rbtnTripleDES_192);
            this.groupBox1.Controls.Add(this.rbtnRijndael_192);
            this.groupBox1.Controls.Add(this.rbtnRC2_128);
            this.groupBox1.Controls.Add(this.rbtnTripleDES_128);
            this.groupBox1.Controls.Add(this.rbtnRijndael_128);
            this.groupBox1.Controls.Add(this.rbtnDES);
            this.groupBox1.Controls.Add(this.rbtnRC2_40);
            this.groupBox1.Controls.Add(this.rbtnRC2_64);
            this.groupBox1.Controls.Add(this.rbtnRC2_96);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 135);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择对称加密算法";
            // 
            // rbtnRijndael_256
            // 
            this.rbtnRijndael_256.AutoSize = true;
            this.rbtnRijndael_256.Location = new System.Drawing.Point(165, 78);
            this.rbtnRijndael_256.Name = "rbtnRijndael_256";
            this.rbtnRijndael_256.Size = new System.Drawing.Size(95, 16);
            this.rbtnRijndael_256.TabIndex = 10;
            this.rbtnRijndael_256.Text = "Rijndael_256";
            this.rbtnRijndael_256.UseVisualStyleBackColor = true;
            // 
            // rbtnTripleDES_192
            // 
            this.rbtnTripleDES_192.AutoSize = true;
            this.rbtnTripleDES_192.Location = new System.Drawing.Point(285, 49);
            this.rbtnTripleDES_192.Name = "rbtnTripleDES_192";
            this.rbtnTripleDES_192.Size = new System.Drawing.Size(101, 16);
            this.rbtnTripleDES_192.TabIndex = 9;
            this.rbtnTripleDES_192.Text = "TripleDES_192";
            this.rbtnTripleDES_192.UseVisualStyleBackColor = true;
            // 
            // rbtnRijndael_192
            // 
            this.rbtnRijndael_192.AutoSize = true;
            this.rbtnRijndael_192.Location = new System.Drawing.Point(165, 49);
            this.rbtnRijndael_192.Name = "rbtnRijndael_192";
            this.rbtnRijndael_192.Size = new System.Drawing.Size(95, 16);
            this.rbtnRijndael_192.TabIndex = 8;
            this.rbtnRijndael_192.Text = "Rijndael_192";
            this.rbtnRijndael_192.UseVisualStyleBackColor = true;
            // 
            // rbtnRC2_128
            // 
            this.rbtnRC2_128.AutoSize = true;
            this.rbtnRC2_128.Location = new System.Drawing.Point(81, 107);
            this.rbtnRC2_128.Name = "rbtnRC2_128";
            this.rbtnRC2_128.Size = new System.Drawing.Size(65, 16);
            this.rbtnRC2_128.TabIndex = 3;
            this.rbtnRC2_128.Text = "RC2_128";
            this.rbtnRC2_128.UseVisualStyleBackColor = true;
            // 
            // rbtnTripleDES_128
            // 
            this.rbtnTripleDES_128.AutoSize = true;
            this.rbtnTripleDES_128.Location = new System.Drawing.Point(285, 20);
            this.rbtnTripleDES_128.Name = "rbtnTripleDES_128";
            this.rbtnTripleDES_128.Size = new System.Drawing.Size(101, 16);
            this.rbtnTripleDES_128.TabIndex = 6;
            this.rbtnTripleDES_128.Text = "TripleDES_128";
            this.rbtnTripleDES_128.UseVisualStyleBackColor = true;
            // 
            // rbtnRijndael_128
            // 
            this.rbtnRijndael_128.AutoSize = true;
            this.rbtnRijndael_128.Location = new System.Drawing.Point(165, 20);
            this.rbtnRijndael_128.Name = "rbtnRijndael_128";
            this.rbtnRijndael_128.Size = new System.Drawing.Size(95, 16);
            this.rbtnRijndael_128.TabIndex = 5;
            this.rbtnRijndael_128.Text = "Rijndael_128";
            this.rbtnRijndael_128.UseVisualStyleBackColor = true;
            // 
            // rbtnRC2_40
            // 
            this.rbtnRC2_40.AutoSize = true;
            this.rbtnRC2_40.Location = new System.Drawing.Point(81, 49);
            this.rbtnRC2_40.Name = "rbtnRC2_40";
            this.rbtnRC2_40.Size = new System.Drawing.Size(59, 16);
            this.rbtnRC2_40.TabIndex = 1;
            this.rbtnRC2_40.Text = "RC2_40";
            this.rbtnRC2_40.UseVisualStyleBackColor = true;
            // 
            // rbtnRC2_64
            // 
            this.rbtnRC2_64.AutoSize = true;
            this.rbtnRC2_64.Location = new System.Drawing.Point(81, 20);
            this.rbtnRC2_64.Name = "rbtnRC2_64";
            this.rbtnRC2_64.Size = new System.Drawing.Size(59, 16);
            this.rbtnRC2_64.TabIndex = 2;
            this.rbtnRC2_64.Text = "RC2_64";
            this.rbtnRC2_64.UseVisualStyleBackColor = true;
            // 
            // rbtnRC2_96
            // 
            this.rbtnRC2_96.AutoSize = true;
            this.rbtnRC2_96.Location = new System.Drawing.Point(81, 78);
            this.rbtnRC2_96.Name = "rbtnRC2_96";
            this.rbtnRC2_96.Size = new System.Drawing.Size(59, 16);
            this.rbtnRC2_96.TabIndex = 4;
            this.rbtnRC2_96.Text = "RC2_96";
            this.rbtnRC2_96.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(255, 241);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "加密密钥";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(95, 18);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(237, 21);
            this.txtKey.TabIndex = 17;
            // 
            // txtIV
            // 
            this.txtIV.Location = new System.Drawing.Point(95, 50);
            this.txtIV.Name = "txtIV";
            this.txtIV.Size = new System.Drawing.Size(237, 21);
            this.txtIV.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "初始化向量";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnDE);
            this.groupBox2.Controls.Add(this.rbtnEN);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtIV);
            this.groupBox2.Controls.Add(this.txtKey);
            this.groupBox2.Location = new System.Drawing.Point(8, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 86);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选项";
            // 
            // rbtnDE
            // 
            this.rbtnDE.AutoSize = true;
            this.rbtnDE.Location = new System.Drawing.Point(356, 52);
            this.rbtnDE.Name = "rbtnDE";
            this.rbtnDE.Size = new System.Drawing.Size(47, 16);
            this.rbtnDE.TabIndex = 21;
            this.rbtnDE.Text = "解密";
            this.rbtnDE.UseVisualStyleBackColor = true;
            // 
            // rbtnEN
            // 
            this.rbtnEN.AutoSize = true;
            this.rbtnEN.Checked = true;
            this.rbtnEN.Location = new System.Drawing.Point(356, 20);
            this.rbtnEN.Name = "rbtnEN";
            this.rbtnEN.Size = new System.Drawing.Size(47, 16);
            this.rbtnEN.TabIndex = 20;
            this.rbtnEN.TabStop = true;
            this.rbtnEN.Text = "加密";
            this.rbtnEN.UseVisualStyleBackColor = true;
            // 
            // String_SymmetricAlgorithm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 271);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.Name = "String_SymmetricAlgorithm";
            this.Text = "加密与解密";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.RadioButton rbtnDES;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnRC2_40;
        private System.Windows.Forms.RadioButton rbtnRC2_64;
        private System.Windows.Forms.RadioButton rbtnRC2_128;
        private System.Windows.Forms.RadioButton rbtnRC2_96;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton rbtnRijndael_256;
        private System.Windows.Forms.RadioButton rbtnTripleDES_192;
        private System.Windows.Forms.RadioButton rbtnRijndael_192;
        private System.Windows.Forms.RadioButton rbtnTripleDES_128;
        private System.Windows.Forms.RadioButton rbtnRijndael_128;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtIV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnDE;
        private System.Windows.Forms.RadioButton rbtnEN;
    }
}