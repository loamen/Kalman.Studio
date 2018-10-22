namespace Kalman.Studio
{
    partial class Terminal
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
            this.rtbCommand = new Command.RichConsoleBox();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbCommand
            // 
            this.rtbCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbCommand.Location = new System.Drawing.Point(0, 0);
            this.rtbCommand.Name = "rtbCommand";
            this.rtbCommand.Size = new System.Drawing.Size(575, 178);
            this.rtbCommand.TabIndex = 1;
            this.rtbCommand.Text = "";
            this.rtbCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbCommand_KeyDown);
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCopy,
            this.menuItemSelectAll,
            this.menuItemClear});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(162, 70);
            // 
            // menuItemCopy
            // 
            this.menuItemCopy.Name = "menuItemCopy";
            this.menuItemCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.menuItemCopy.Size = new System.Drawing.Size(161, 22);
            this.menuItemCopy.Text = "复制(&C)";
            // 
            // menuItemSelectAll
            // 
            this.menuItemSelectAll.Name = "menuItemSelectAll";
            this.menuItemSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.menuItemSelectAll.Size = new System.Drawing.Size(161, 22);
            this.menuItemSelectAll.Text = "全选(&A)";
            // 
            // menuItemClear
            // 
            this.menuItemClear.Name = "menuItemClear";
            this.menuItemClear.Size = new System.Drawing.Size(161, 22);
            this.menuItemClear.Text = "全部清除";
            // 
            // Terminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 178);
            this.Controls.Add(this.rtbCommand);
            this.Name = "Terminal";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottomAutoHide;
            this.Text = "终端";
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Command.RichConsoleBox rtbCommand;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem menuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem menuItemSelectAll;
        private System.Windows.Forms.ToolStripMenuItem menuItemClear;
    }
}