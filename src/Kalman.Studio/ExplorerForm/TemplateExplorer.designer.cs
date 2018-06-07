namespace Kalman.Studio
{
    partial class TemplateExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateExplorer));
            this.tvTemplate = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.cmsDir = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewTemplateFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewTemplateDir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBrowserDir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDeleteDir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRenameDir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemEditTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDeleteTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRenameTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDir.SuspendLayout();
            this.cmsFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvTemplate
            // 
            this.tvTemplate.AllowDrop = true;
            this.tvTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTemplate.ImageIndex = 0;
            this.tvTemplate.ImageList = this.imgList;
            this.tvTemplate.LabelEdit = true;
            this.tvTemplate.Location = new System.Drawing.Point(0, 0);
            this.tvTemplate.Name = "tvTemplate";
            this.tvTemplate.SelectedImageIndex = 0;
            this.tvTemplate.Size = new System.Drawing.Size(230, 537);
            this.tvTemplate.TabIndex = 0;
            this.tvTemplate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tvTemplate_MouseDoubleClick);
            this.tvTemplate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tvTemplate_MouseClick);
            this.tvTemplate.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvTemplate_AfterLabelEdit);
            this.tvTemplate.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvTemplate_DragDrop);
            this.tvTemplate.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvTemplate_DragEnter);
            this.tvTemplate.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvTemplate_ItemDrag);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "templateRoot.png");
            this.imgList.Images.SetKeyName(1, "templateDir.png");
            this.imgList.Images.SetKeyName(2, "templateFile.png");
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
            this.menuItemNewTemplateFile,
            this.menuItemNewTemplateDir});
            this.menuItemNew.Name = "menuItemNew";
            this.menuItemNew.Size = new System.Drawing.Size(122, 22);
            this.menuItemNew.Text = "新建";
            // 
            // menuItemNewTemplateFile
            // 
            this.menuItemNewTemplateFile.Name = "menuItemNewTemplateFile";
            this.menuItemNewTemplateFile.Size = new System.Drawing.Size(122, 22);
            this.menuItemNewTemplateFile.Text = "模板文件";
            this.menuItemNewTemplateFile.Click += new System.EventHandler(this.menuItemNewTemplateFile_Click);
            // 
            // menuItemNewTemplateDir
            // 
            this.menuItemNewTemplateDir.Name = "menuItemNewTemplateDir";
            this.menuItemNewTemplateDir.Size = new System.Drawing.Size(122, 22);
            this.menuItemNewTemplateDir.Text = "模板目录";
            this.menuItemNewTemplateDir.Click += new System.EventHandler(this.menuItemNewTemplateDir_Click);
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
            this.menuItemEditTemplate,
            this.menuItemDeleteTemplate,
            this.menuItemRenameTemplate});
            this.cmsFile.Name = "cmsFile";
            this.cmsFile.Size = new System.Drawing.Size(111, 70);
            // 
            // menuItemEditTemplate
            // 
            this.menuItemEditTemplate.Name = "menuItemEditTemplate";
            this.menuItemEditTemplate.Size = new System.Drawing.Size(110, 22);
            this.menuItemEditTemplate.Text = "编辑";
            this.menuItemEditTemplate.Click += new System.EventHandler(this.menuItemEditTemplate_Click);
            // 
            // menuItemDeleteTemplate
            // 
            this.menuItemDeleteTemplate.Name = "menuItemDeleteTemplate";
            this.menuItemDeleteTemplate.Size = new System.Drawing.Size(110, 22);
            this.menuItemDeleteTemplate.Text = "删除";
            this.menuItemDeleteTemplate.Click += new System.EventHandler(this.menuItemDeleteTemplate_Click);
            // 
            // menuItemRenameTemplate
            // 
            this.menuItemRenameTemplate.Name = "menuItemRenameTemplate";
            this.menuItemRenameTemplate.Size = new System.Drawing.Size(110, 22);
            this.menuItemRenameTemplate.Text = "重命名";
            this.menuItemRenameTemplate.Click += new System.EventHandler(this.menuItemRenameTemplate_Click);
            // 
            // TemplateExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 537);
            this.Controls.Add(this.tvTemplate);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TemplateExplorer";
            this.Text = "模板资源管理器";
            this.Load += new System.EventHandler(this.TemplateExplorer_Load);
            this.cmsDir.ResumeLayout(false);
            this.cmsFile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvTemplate;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ContextMenuStrip cmsDir;
        private System.Windows.Forms.ContextMenuStrip cmsFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemNew;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewTemplateDir;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewTemplateFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemBrowserDir;
        private System.Windows.Forms.ToolStripMenuItem menuItemDeleteDir;
        private System.Windows.Forms.ToolStripMenuItem menuItemRenameDir;
        private System.Windows.Forms.ToolStripMenuItem menuItemRefresh;
        private System.Windows.Forms.ToolStripMenuItem menuItemEditTemplate;
        private System.Windows.Forms.ToolStripMenuItem menuItemDeleteTemplate;
        private System.Windows.Forms.ToolStripMenuItem menuItemRenameTemplate;
    }
}