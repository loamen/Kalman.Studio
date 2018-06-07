namespace Kalman.Studio
{
    partial class String_Random
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
            this.label1 = new System.Windows.Forms.Label();
            this.numLength = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbSymbol = new System.Windows.Forms.CheckBox();
            this.cbCapital = new System.Windows.Forms.CheckBox();
            this.cbLower = new System.Windows.Forms.CheckBox();
            this.cbDigital = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCharList = new System.Windows.Forms.TextBox();
            this.cbCustomBuild = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.numCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSplit = new System.Windows.Forms.TextBox();
            this.cbSaveToFile = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "长度";
            // 
            // numLength
            // 
            this.numLength.Location = new System.Drawing.Point(51, 169);
            this.numLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLength.Name = "numLength";
            this.numLength.Size = new System.Drawing.Size(60, 21);
            this.numLength.TabIndex = 1;
            this.numLength.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbSymbol);
            this.groupBox1.Controls.Add(this.cbCapital);
            this.groupBox1.Controls.Add(this.cbLower);
            this.groupBox1.Controls.Add(this.cbDigital);
            this.groupBox1.Location = new System.Drawing.Point(6, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 49);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "生成选项";
            // 
            // cbSymbol
            // 
            this.cbSymbol.AutoSize = true;
            this.cbSymbol.Location = new System.Drawing.Point(338, 20);
            this.cbSymbol.Name = "cbSymbol";
            this.cbSymbol.Size = new System.Drawing.Size(72, 16);
            this.cbSymbol.TabIndex = 3;
            this.cbSymbol.Text = "标点符号";
            this.cbSymbol.UseVisualStyleBackColor = true;
            // 
            // cbCapital
            // 
            this.cbCapital.AutoSize = true;
            this.cbCapital.Location = new System.Drawing.Point(223, 20);
            this.cbCapital.Name = "cbCapital";
            this.cbCapital.Size = new System.Drawing.Size(102, 16);
            this.cbCapital.TabIndex = 2;
            this.cbCapital.Text = "大写字母[A-Z]";
            this.cbCapital.UseVisualStyleBackColor = true;
            // 
            // cbLower
            // 
            this.cbLower.AutoSize = true;
            this.cbLower.Location = new System.Drawing.Point(108, 20);
            this.cbLower.Name = "cbLower";
            this.cbLower.Size = new System.Drawing.Size(102, 16);
            this.cbLower.TabIndex = 1;
            this.cbLower.Text = "小写字母[a-z]";
            this.cbLower.UseVisualStyleBackColor = true;
            // 
            // cbDigital
            // 
            this.cbDigital.AutoSize = true;
            this.cbDigital.Checked = true;
            this.cbDigital.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDigital.Location = new System.Drawing.Point(17, 20);
            this.cbDigital.Name = "cbDigital";
            this.cbDigital.Size = new System.Drawing.Size(78, 16);
            this.cbDigital.TabIndex = 0;
            this.cbDigital.Text = "数字[0-9]";
            this.cbDigital.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCharList);
            this.groupBox2.Location = new System.Drawing.Point(6, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 97);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "自定义生成";
            // 
            // txtCharList
            // 
            this.txtCharList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCharList.Location = new System.Drawing.Point(3, 17);
            this.txtCharList.Multiline = true;
            this.txtCharList.Name = "txtCharList";
            this.txtCharList.Size = new System.Drawing.Size(418, 77);
            this.txtCharList.TabIndex = 0;
            // 
            // cbCustomBuild
            // 
            this.cbCustomBuild.AutoSize = true;
            this.cbCustomBuild.Location = new System.Drawing.Point(237, 204);
            this.cbCustomBuild.Name = "cbCustomBuild";
            this.cbCustomBuild.Size = new System.Drawing.Size(108, 16);
            this.cbCustomBuild.TabIndex = 4;
            this.cbCustomBuild.Text = "使用自定义生成";
            this.cbCustomBuild.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(355, 168);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 54);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // numCount
            // 
            this.numCount.Location = new System.Drawing.Point(168, 169);
            this.numCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCount.Name = "numCount";
            this.numCount.Size = new System.Drawing.Size(60, 21);
            this.numCount.TabIndex = 7;
            this.numCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "数量";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "分隔符";
            // 
            // txtSplit
            // 
            this.txtSplit.Location = new System.Drawing.Point(297, 169);
            this.txtSplit.Name = "txtSplit";
            this.txtSplit.Size = new System.Drawing.Size(48, 21);
            this.txtSplit.TabIndex = 9;
            this.txtSplit.Text = "\\r\\n";
            // 
            // cbSaveToFile
            // 
            this.cbSaveToFile.AutoSize = true;
            this.cbSaveToFile.Location = new System.Drawing.Point(144, 204);
            this.cbSaveToFile.Name = "cbSaveToFile";
            this.cbSaveToFile.Size = new System.Drawing.Size(84, 16);
            this.cbSaveToFile.TabIndex = 10;
            this.cbSaveToFile.Text = "保存到文件";
            this.cbSaveToFile.UseVisualStyleBackColor = true;
            // 
            // String_Random
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 229);
            this.Controls.Add(this.cbSaveToFile);
            this.Controls.Add(this.txtSplit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbCustomBuild);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numLength);
            this.Controls.Add(this.label1);
            this.Name = "String_Random";
            this.Text = "随机字符串生成";
            this.Load += new System.EventHandler(this.String_Random_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numLength)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numLength;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbSymbol;
        private System.Windows.Forms.CheckBox cbCapital;
        private System.Windows.Forms.CheckBox cbLower;
        private System.Windows.Forms.CheckBox cbDigital;
        private System.Windows.Forms.CheckBox cbCustomBuild;
        private System.Windows.Forms.TextBox txtCharList;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.NumericUpDown numCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSplit;
        private System.Windows.Forms.CheckBox cbSaveToFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}