namespace Kalman.Studio
{
    partial class String_Guid
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
            this.rbtnToLower = new System.Windows.Forms.RadioButton();
            this.rbtnToUpper = new System.Windows.Forms.RadioButton();
            this.cbRemove = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbtnToLower
            // 
            this.rbtnToLower.AutoSize = true;
            this.rbtnToLower.Location = new System.Drawing.Point(100, 35);
            this.rbtnToLower.Name = "rbtnToLower";
            this.rbtnToLower.Size = new System.Drawing.Size(59, 16);
            this.rbtnToLower.TabIndex = 12;
            this.rbtnToLower.TabStop = true;
            this.rbtnToLower.Text = "转小写";
            this.rbtnToLower.UseVisualStyleBackColor = true;
            // 
            // rbtnToUpper
            // 
            this.rbtnToUpper.AutoSize = true;
            this.rbtnToUpper.Location = new System.Drawing.Point(24, 35);
            this.rbtnToUpper.Name = "rbtnToUpper";
            this.rbtnToUpper.Size = new System.Drawing.Size(59, 16);
            this.rbtnToUpper.TabIndex = 11;
            this.rbtnToUpper.TabStop = true;
            this.rbtnToUpper.Text = "转大写";
            this.rbtnToUpper.UseVisualStyleBackColor = true;
            // 
            // cbRemove
            // 
            this.cbRemove.AutoSize = true;
            this.cbRemove.Location = new System.Drawing.Point(183, 36);
            this.cbRemove.Name = "cbRemove";
            this.cbRemove.Size = new System.Drawing.Size(114, 16);
            this.cbRemove.TabIndex = 13;
            this.cbRemove.Text = "移除连接字符[-]";
            this.cbRemove.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(260, 98);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // String_Guid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 151);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbRemove);
            this.Controls.Add(this.rbtnToLower);
            this.Controls.Add(this.rbtnToUpper);
            this.Name = "String_Guid";
            this.Text = "GUID生成器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnToLower;
        private System.Windows.Forms.RadioButton rbtnToUpper;
        private System.Windows.Forms.CheckBox cbRemove;
        private System.Windows.Forms.Button btnOK;
    }
}