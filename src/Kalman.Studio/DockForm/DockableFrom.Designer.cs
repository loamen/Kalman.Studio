namespace Kalman.Studio
{
    partial class DockableForm
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
            this.cmsDock = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCloseOther = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDock.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsDock
            // 
            this.cmsDock.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemClose,
            this.menuItemCloseOther,
            this.menuItemCloseAll});
            this.cmsDock.Name = "cmsDock";
            this.cmsDock.Size = new System.Drawing.Size(167, 70);
            // 
            // menuItemClose
            // 
            this.menuItemClose.Name = "menuItemClose";
            this.menuItemClose.Size = new System.Drawing.Size(166, 22);
            this.menuItemClose.Text = "关闭";
            this.menuItemClose.Click += new System.EventHandler(this.menuItemClose_Click);
            // 
            // menuItemCloseOther
            // 
            this.menuItemCloseOther.Name = "menuItemCloseOther";
            this.menuItemCloseOther.Size = new System.Drawing.Size(166, 22);
            this.menuItemCloseOther.Text = "除此之外全部关闭";
            this.menuItemCloseOther.Click += new System.EventHandler(this.menuItemCloseOther_Click);
            // 
            // menuItemCloseAll
            // 
            this.menuItemCloseAll.Name = "menuItemCloseAll";
            this.menuItemCloseAll.Size = new System.Drawing.Size(166, 22);
            this.menuItemCloseAll.Text = "全部关闭";
            this.menuItemCloseAll.Click += new System.EventHandler(this.menuItemCloseAll_Click);
            // 
            // DockableFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Name = "DockableFrom";
            this.TabPageContextMenuStrip = this.cmsDock;
            this.Text = "DockableFrom";
            this.cmsDock.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsDock;
        private System.Windows.Forms.ToolStripMenuItem menuItemClose;
        private System.Windows.Forms.ToolStripMenuItem menuItemCloseOther;
        private System.Windows.Forms.ToolStripMenuItem menuItemCloseAll;
    }
}