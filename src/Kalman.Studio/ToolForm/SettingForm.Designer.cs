namespace Kalman.Studio.ToolForm
{
    partial class SettingForm
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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.tabPageGo = new System.Windows.Forms.TabPage();
            this.txtGoPath = new System.Windows.Forms.TextBox();
            this.lblGoPath = new System.Windows.Forms.Label();
            this.txtGoBin = new System.Windows.Forms.TextBox();
            this.lblGoBin = new System.Windows.Forms.Label();
            this.txtGoRoot = new System.Windows.Forms.TextBox();
            this.lblGoRoot = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabPageGo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageGeneral);
            this.tabControlMain.Controls.Add(this.tabPageGo);
            this.tabControlMain.Location = new System.Drawing.Point(12, 12);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(321, 259);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(313, 233);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "常规";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // tabPageGo
            // 
            this.tabPageGo.Controls.Add(this.txtGoPath);
            this.tabPageGo.Controls.Add(this.lblGoPath);
            this.tabPageGo.Controls.Add(this.txtGoBin);
            this.tabPageGo.Controls.Add(this.lblGoBin);
            this.tabPageGo.Controls.Add(this.txtGoRoot);
            this.tabPageGo.Controls.Add(this.lblGoRoot);
            this.tabPageGo.Location = new System.Drawing.Point(4, 22);
            this.tabPageGo.Name = "tabPageGo";
            this.tabPageGo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGo.Size = new System.Drawing.Size(313, 233);
            this.tabPageGo.TabIndex = 1;
            this.tabPageGo.Text = "GO设置";
            this.tabPageGo.UseVisualStyleBackColor = true;
            // 
            // txtGoPath
            // 
            this.txtGoPath.Location = new System.Drawing.Point(66, 67);
            this.txtGoPath.Name = "txtGoPath";
            this.txtGoPath.Size = new System.Drawing.Size(241, 21);
            this.txtGoPath.TabIndex = 5;
            // 
            // lblGoPath
            // 
            this.lblGoPath.AutoSize = true;
            this.lblGoPath.Location = new System.Drawing.Point(7, 71);
            this.lblGoPath.Name = "lblGoPath";
            this.lblGoPath.Size = new System.Drawing.Size(47, 12);
            this.lblGoPath.TabIndex = 4;
            this.lblGoPath.Text = "GOPATH:";
            // 
            // txtGoBin
            // 
            this.txtGoBin.Location = new System.Drawing.Point(66, 37);
            this.txtGoBin.Name = "txtGoBin";
            this.txtGoBin.Size = new System.Drawing.Size(241, 21);
            this.txtGoBin.TabIndex = 3;
            // 
            // lblGoBin
            // 
            this.lblGoBin.AutoSize = true;
            this.lblGoBin.Location = new System.Drawing.Point(7, 41);
            this.lblGoBin.Name = "lblGoBin";
            this.lblGoBin.Size = new System.Drawing.Size(41, 12);
            this.lblGoBin.TabIndex = 2;
            this.lblGoBin.Text = "GOBIN:";
            // 
            // txtGoRoot
            // 
            this.txtGoRoot.Location = new System.Drawing.Point(66, 7);
            this.txtGoRoot.Name = "txtGoRoot";
            this.txtGoRoot.Size = new System.Drawing.Size(241, 21);
            this.txtGoRoot.TabIndex = 1;
            // 
            // lblGoRoot
            // 
            this.lblGoRoot.AutoSize = true;
            this.lblGoRoot.Location = new System.Drawing.Point(7, 11);
            this.lblGoRoot.Name = "lblGoRoot";
            this.lblGoRoot.Size = new System.Drawing.Size(47, 12);
            this.lblGoRoot.TabIndex = 0;
            this.lblGoRoot.Text = "GOROOT:";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(177, 277);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(258, 277);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // SettingForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(347, 312);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SettingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选项";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageGo.ResumeLayout(false);
            this.tabPageGo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageGo;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtGoRoot;
        private System.Windows.Forms.Label lblGoRoot;
        private System.Windows.Forms.TextBox txtGoPath;
        private System.Windows.Forms.Label lblGoPath;
        private System.Windows.Forms.TextBox txtGoBin;
        private System.Windows.Forms.Label lblGoBin;
    }
}