namespace Kalman.Studio
{
    partial class ImportPostParams
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSeparator1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSeparator2 = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbTrim = new System.Windows.Forms.CheckBox();
            this.cbUrlDecode = new System.Windows.Forms.CheckBox();
            this.cbMutilRow = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbMutilRow);
            this.groupBox1.Controls.Add(this.cbUrlDecode);
            this.groupBox1.Controls.Add(this.cbTrim);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.txtSeparator2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSeparator1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 296);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "解析选项";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(592, 296);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "原始字符串";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 17);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(586, 276);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "参数分隔符";
            // 
            // txtSeparator1
            // 
            this.txtSeparator1.Location = new System.Drawing.Point(82, 16);
            this.txtSeparator1.Name = "txtSeparator1";
            this.txtSeparator1.Size = new System.Drawing.Size(100, 21);
            this.txtSeparator1.TabIndex = 1;
            this.txtSeparator1.Text = "&";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "键值分隔符";
            // 
            // txtSeparator2
            // 
            this.txtSeparator2.Location = new System.Drawing.Point(269, 16);
            this.txtSeparator2.Name = "txtSeparator2";
            this.txtSeparator2.Size = new System.Drawing.Size(100, 21);
            this.txtSeparator2.TabIndex = 3;
            this.txtSeparator2.Text = "=";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(505, 20);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 45);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbTrim
            // 
            this.cbTrim.AutoSize = true;
            this.cbTrim.Checked = true;
            this.cbTrim.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTrim.Location = new System.Drawing.Point(6, 48);
            this.cbTrim.Name = "cbTrim";
            this.cbTrim.Size = new System.Drawing.Size(96, 16);
            this.cbTrim.TabIndex = 5;
            this.cbTrim.Text = "移除首尾空格";
            this.cbTrim.UseVisualStyleBackColor = true;
            // 
            // cbUrlDecode
            // 
            this.cbUrlDecode.AutoSize = true;
            this.cbUrlDecode.Location = new System.Drawing.Point(115, 48);
            this.cbUrlDecode.Name = "cbUrlDecode";
            this.cbUrlDecode.Size = new System.Drawing.Size(66, 16);
            this.cbUrlDecode.TabIndex = 6;
            this.cbUrlDecode.Text = "Url解码";
            this.cbUrlDecode.UseVisualStyleBackColor = true;
            // 
            // cbMutilRow
            // 
            this.cbMutilRow.AutoSize = true;
            this.cbMutilRow.Location = new System.Drawing.Point(195, 48);
            this.cbMutilRow.Name = "cbMutilRow";
            this.cbMutilRow.Size = new System.Drawing.Size(240, 16);
            this.cbMutilRow.TabIndex = 7;
            this.cbMutilRow.Text = "一行一个参数，相当于参数分隔符为回车";
            this.cbMutilRow.UseVisualStyleBackColor = true;
            // 
            // ImportPostParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 373);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "ImportPostParams";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "导入Post参数";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSeparator1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox cbTrim;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtSeparator2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbUrlDecode;
        private System.Windows.Forms.CheckBox cbMutilRow;
    }
}