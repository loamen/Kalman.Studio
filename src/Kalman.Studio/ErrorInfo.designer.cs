namespace Kalman.Studio
{
    partial class ErrorInfo
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpErrorInfo = new System.Windows.Forms.TabPage();
            this.tpErrorData = new System.Windows.Forms.TabPage();
            this.rtbErrorInfo = new System.Windows.Forms.RichTextBox();
            this.rtbErrorData = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tpErrorInfo.SuspendLayout();
            this.tpErrorData.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpErrorInfo);
            this.tabControl1.Controls.Add(this.tpErrorData);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(542, 340);
            this.tabControl1.TabIndex = 0;
            // 
            // tpErrorInfo
            // 
            this.tpErrorInfo.Controls.Add(this.rtbErrorInfo);
            this.tpErrorInfo.Location = new System.Drawing.Point(4, 21);
            this.tpErrorInfo.Name = "tpErrorInfo";
            this.tpErrorInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpErrorInfo.Size = new System.Drawing.Size(480, 409);
            this.tpErrorInfo.TabIndex = 0;
            this.tpErrorInfo.Text = "错误信息";
            this.tpErrorInfo.UseVisualStyleBackColor = true;
            // 
            // tpErrorData
            // 
            this.tpErrorData.Controls.Add(this.rtbErrorData);
            this.tpErrorData.Location = new System.Drawing.Point(4, 21);
            this.tpErrorData.Name = "tpErrorData";
            this.tpErrorData.Padding = new System.Windows.Forms.Padding(3);
            this.tpErrorData.Size = new System.Drawing.Size(534, 315);
            this.tpErrorData.TabIndex = 1;
            this.tpErrorData.Text = "相关数据";
            this.tpErrorData.UseVisualStyleBackColor = true;
            // 
            // rtbErrorInfo
            // 
            this.rtbErrorInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbErrorInfo.Location = new System.Drawing.Point(3, 3);
            this.rtbErrorInfo.Name = "rtbErrorInfo";
            this.rtbErrorInfo.Size = new System.Drawing.Size(474, 403);
            this.rtbErrorInfo.TabIndex = 0;
            this.rtbErrorInfo.Text = "";
            // 
            // rtbErrorData
            // 
            this.rtbErrorData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbErrorData.Location = new System.Drawing.Point(3, 3);
            this.rtbErrorData.Name = "rtbErrorData";
            this.rtbErrorData.Size = new System.Drawing.Size(528, 309);
            this.rtbErrorData.TabIndex = 0;
            this.rtbErrorData.Text = "";
            // 
            // ErrorInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 340);
            this.Controls.Add(this.tabControl1);
            this.Name = "ErrorInfo";
            this.Text = "错误信息";
            this.Load += new System.EventHandler(this.ErrorInfo_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpErrorInfo.ResumeLayout(false);
            this.tpErrorData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpErrorInfo;
        private System.Windows.Forms.RichTextBox rtbErrorInfo;
        private System.Windows.Forms.TabPage tpErrorData;
        private System.Windows.Forms.RichTextBox rtbErrorData;
    }
}