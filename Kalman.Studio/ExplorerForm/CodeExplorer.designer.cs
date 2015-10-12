namespace Kalman.Studio
{
    partial class CodeExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeExplorer));
            this.tvCode = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.cmsDir = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewDir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBrowserDir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDeleteDir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRenameDir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemEditFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDeleteFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRenameFile = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDir.SuspendLayout();
            this.cmsFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvCode
            // 
            this.tvCode.AllowDrop = true;
            this.tvCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCode.ImageIndex = 0;
            this.tvCode.ImageList = this.imgList;
            this.tvCode.LabelEdit = true;
            this.tvCode.Location = new System.Drawing.Point(0, 0);
            this.tvCode.Margin = new System.Windows.Forms.Padding(5);
            this.tvCode.Name = "tvCode";
            this.tvCode.SelectedImageIndex = 0;
            this.tvCode.Size = new System.Drawing.Size(253, 531);
            this.tvCode.TabIndex = 0;
            this.tvCode.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tvCode_MouseDoubleClick);
            this.tvCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tvCode_MouseClick);
            this.tvCode.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvCode_AfterLabelEdit);
            this.tvCode.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvCode_DragDrop);
            this.tvCode.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvCode_DragEnter);
            this.tvCode.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvCode_ItemDrag);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "codeRoot.png");
            this.imgList.Images.SetKeyName(1, "codeFolder.png");
            // 
            // cmsDir
            // 
            this.cmsDir.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNew,
            this.menuItemBrowserDir,
            this.menuItemDeleteDir,
            this.menuItemRenameDir,
            this.menuItemRefresh});
            this.cmsDir.Name = "cmsDir";
            this.cmsDir.Size = new System.Drawing.Size(123, 114);
            // 
            // menuItemNew
            // 
            this.menuItemNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNewFile,
            this.menuItemNewDir});
            this.menuItemNew.Name = "menuItemNew";
            this.menuItemNew.Size = new System.Drawing.Size(122, 22);
            this.menuItemNew.Text = "新建";
            // 
            // menuItemNewFile
            // 
            this.menuItemNewFile.Name = "menuItemNewFile";
            this.menuItemNewFile.Size = new System.Drawing.Size(122, 22);
            this.menuItemNewFile.Text = "代码文件";
            this.menuItemNewFile.Click += new System.EventHandler(this.menuItemNewFile_Click);
            // 
            // menuItemNewDir
            // 
            this.menuItemNewDir.Name = "menuItemNewDir";
            this.menuItemNewDir.Size = new System.Drawing.Size(122, 22);
            this.menuItemNewDir.Text = "代码目录";
            this.menuItemNewDir.Click += new System.EventHandler(this.menuItemNewDir_Click);
            // 
            // menuItemBrowserDir
            // 
            this.menuItemBrowserDir.Name = "menuItemBrowserDir";
            this.menuItemBrowserDir.Size = new System.Drawing.Size(122, 22);
            this.menuItemBrowserDir.Text = "浏览目录";
            this.menuItemBrowserDir.Click += new System.EventHandler(this.menuItemBrowserDir_Click);
            // 
            // menuItemDeleteDir
            // 
            this.menuItemDeleteDir.Name = "menuItemDeleteDir";
            this.menuItemDeleteDir.Size = new System.Drawing.Size(122, 22);
            this.menuItemDeleteDir.Text = "删除";
            this.menuItemDeleteDir.Click += new System.EventHandler(this.menuItemDeleteDir_Click);
            // 
            // menuItemRenameDir
            // 
            this.menuItemRenameDir.Name = "menuItemRenameDir";
            this.menuItemRenameDir.Size = new System.Drawing.Size(122, 22);
            this.menuItemRenameDir.Text = "重命名";
            this.menuItemRenameDir.Click += new System.EventHandler(this.menuItemRenameDir_Click);
            // 
            // menuItemRefresh
            // 
            this.menuItemRefresh.Name = "menuItemRefresh";
            this.menuItemRefresh.Size = new System.Drawing.Size(122, 22);
            this.menuItemRefresh.Text = "刷新";
            this.menuItemRefresh.Click += new System.EventHandler(this.menuItemRefresh_Click);
            // 
            // cmsFile
            // 
            this.cmsFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemEditFile,
            this.menuItemDeleteFile,
            this.menuItemRenameFile});
            this.cmsFile.Name = "cmsFile";
            this.cmsFile.Size = new System.Drawing.Size(111, 70);
            // 
            // menuItemEditFile
            // 
            this.menuItemEditFile.Name = "menuItemEditFile";
            this.menuItemEditFile.Size = new System.Drawing.Size(110, 22);
            this.menuItemEditFile.Text = "编辑";
            this.menuItemEditFile.Click += new System.EventHandler(this.menuItemEditFile_Click);
            // 
            // menuItemDeleteFile
            // 
            this.menuItemDeleteFile.Name = "menuItemDeleteFile";
            this.menuItemDeleteFile.Size = new System.Drawing.Size(110, 22);
            this.menuItemDeleteFile.Text = "删除";
            this.menuItemDeleteFile.Click += new System.EventHandler(this.menuItemDeleteFile_Click);
            // 
            // menuItemRenameFile
            // 
            this.menuItemRenameFile.Name = "menuItemRenameFile";
            this.menuItemRenameFile.Size = new System.Drawing.Size(110, 22);
            this.menuItemRenameFile.Text = "重命名";
            this.menuItemRenameFile.Click += new System.EventHandler(this.menuItemRenameFile_Click);
            // 
            // CodeExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 531);
            this.Controls.Add(this.tvCode);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CodeExplorer";
            this.Text = "代码资源管理器";
            this.Load += new System.EventHandler(this.CodeExplorer_Load);
            this.cmsDir.ResumeLayout(false);
            this.cmsFile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvCode;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ContextMenuStrip cmsDir;
        private System.Windows.Forms.ToolStripMenuItem menuItemNew;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewDir;
        private System.Windows.Forms.ToolStripMenuItem menuItemBrowserDir;
        private System.Windows.Forms.ToolStripMenuItem menuItemDeleteDir;
        private System.Windows.Forms.ToolStripMenuItem menuItemRenameDir;
        private System.Windows.Forms.ToolStripMenuItem menuItemRefresh;
        private System.Windows.Forms.ContextMenuStrip cmsFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemEditFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemDeleteFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemRenameFile;
    }
}