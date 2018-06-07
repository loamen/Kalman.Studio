namespace Kalman.Studio
{
    partial class PdmExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdmExplorer));
            this.tv = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemLoadFile = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemRemoveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReload = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsModel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemBrowserModel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBuildWord = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBuildPdf = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBatchBuildCode = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cmsTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemBuildCodeForTable = new System.Windows.Forms.ToolStripMenuItem();
            this.cms.SuspendLayout();
            this.cmsFile.SuspendLayout();
            this.cmsModel.SuspendLayout();
            this.cmsTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // tv
            // 
            this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv.HotTracking = true;
            this.tv.ImageIndex = 8;
            this.tv.ImageList = this.imgList;
            this.tv.ItemHeight = 18;
            this.tv.Location = new System.Drawing.Point(0, 0);
            this.tv.Name = "tv";
            this.tv.SelectedImageIndex = 8;
            this.tv.ShowNodeToolTips = true;
            this.tv.Size = new System.Drawing.Size(239, 489);
            this.tv.TabIndex = 4;
            this.tv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tv_MouseDoubleClick);
            this.tv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tv_MouseClick);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "pd.ico");
            this.imgList.Images.SetKeyName(1, "pdm.ICO");
            this.imgList.Images.SetKeyName(2, "bigdb.ICO");
            this.imgList.Images.SetKeyName(3, "package.ICO");
            this.imgList.Images.SetKeyName(4, "folder.ICO");
            this.imgList.Images.SetKeyName(5, "table.ICO");
            this.imgList.Images.SetKeyName(6, "column.ICO");
            this.imgList.Images.SetKeyName(7, "key.ICO");
            this.imgList.Images.SetKeyName(8, "index.ICO");
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemLoadFile});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(125, 26);
            // 
            // menuItemLoadFile
            // 
            this.menuItemLoadFile.Name = "menuItemLoadFile";
            this.menuItemLoadFile.Size = new System.Drawing.Size(124, 22);
            this.menuItemLoadFile.Text = "加载文件";
            this.menuItemLoadFile.Click += new System.EventHandler(this.menuItemLoadFile_Click);
            // 
            // cmsFile
            // 
            this.cmsFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemRemoveFile,
            this.menuItemReload});
            this.cmsFile.Name = "cmsFile";
            this.cmsFile.Size = new System.Drawing.Size(125, 48);
            // 
            // menuItemRemoveFile
            // 
            this.menuItemRemoveFile.Name = "menuItemRemoveFile";
            this.menuItemRemoveFile.Size = new System.Drawing.Size(124, 22);
            this.menuItemRemoveFile.Text = "移除文件";
            this.menuItemRemoveFile.Click += new System.EventHandler(this.menuItemRemoveFile_Click);
            // 
            // menuItemReload
            // 
            this.menuItemReload.Name = "menuItemReload";
            this.menuItemReload.Size = new System.Drawing.Size(124, 22);
            this.menuItemReload.Text = "重新加载";
            this.menuItemReload.Click += new System.EventHandler(this.menuItemReload_Click);
            // 
            // cmsModel
            // 
            this.cmsModel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemBrowserModel,
            this.menuItemBuildWord,
            this.menuItemBuildPdf,
            this.menuItemBatchBuildCode});
            this.cmsModel.Name = "cmsModel";
            this.cmsModel.Size = new System.Drawing.Size(158, 114);
            // 
            // menuItemBrowserModel
            // 
            this.menuItemBrowserModel.Name = "menuItemBrowserModel";
            this.menuItemBrowserModel.Size = new System.Drawing.Size(157, 22);
            this.menuItemBrowserModel.Text = "浏览模型";
            this.menuItemBrowserModel.Click += new System.EventHandler(this.menuItemBrowserModel_Click);
            // 
            // menuItemBuildWord
            // 
            this.menuItemBuildWord.Name = "menuItemBuildWord";
            this.menuItemBuildWord.Size = new System.Drawing.Size(157, 22);
            this.menuItemBuildWord.Text = "生成Word文档";
            this.menuItemBuildWord.Click += new System.EventHandler(this.menuItemBuildWord_Click);
            // 
            // menuItemBuildPdf
            // 
            this.menuItemBuildPdf.Name = "menuItemBuildPdf";
            this.menuItemBuildPdf.Size = new System.Drawing.Size(157, 22);
            this.menuItemBuildPdf.Text = "生成Pdf文档";
            this.menuItemBuildPdf.Click += new System.EventHandler(this.menuItemBuildPdf_Click);
            // 
            // menuItemBatchBuildCode
            // 
            this.menuItemBatchBuildCode.Name = "menuItemBatchBuildCode";
            this.menuItemBatchBuildCode.Size = new System.Drawing.Size(157, 22);
            this.menuItemBatchBuildCode.Text = "批量生成代码";
            this.menuItemBatchBuildCode.Click += new System.EventHandler(this.menuItemBatchBuildCode_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "pdf文件(*.pdf)|*.pdf|所有文件(*.*)|*.*";
            // 
            // cmsTable
            // 
            this.cmsTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemBuildCodeForTable});
            this.cmsTable.Name = "cmsTable";
            this.cmsTable.Size = new System.Drawing.Size(137, 26);
            // 
            // menuItemBuildCodeForTable
            // 
            this.menuItemBuildCodeForTable.Name = "menuItemBuildCodeForTable";
            this.menuItemBuildCodeForTable.Size = new System.Drawing.Size(136, 22);
            this.menuItemBuildCodeForTable.Text = "代码生成器";
            this.menuItemBuildCodeForTable.Click += new System.EventHandler(this.menuItemBuildCodeForTable_Click);
            // 
            // PdmExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 489);
            this.Controls.Add(this.tv);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PdmExplorer";
            this.Text = "PDM模型对象浏览器";
            this.Load += new System.EventHandler(this.PdmExplorer_Load);
            this.cms.ResumeLayout(false);
            this.cmsFile.ResumeLayout(false);
            this.cmsModel.ResumeLayout(false);
            this.cmsTable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem menuItemLoadFile;
        private System.Windows.Forms.ContextMenuStrip cmsFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemRemoveFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemReload;
        private System.Windows.Forms.ContextMenuStrip cmsModel;
        private System.Windows.Forms.ToolStripMenuItem menuItemBrowserModel;
        private System.Windows.Forms.ToolStripMenuItem menuItemBuildWord;
        private System.Windows.Forms.ToolStripMenuItem menuItemBuildPdf;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem menuItemBatchBuildCode;
        private System.Windows.Forms.ContextMenuStrip cmsTable;
        private System.Windows.Forms.ToolStripMenuItem menuItemBuildCodeForTable;
        private System.Windows.Forms.ImageList imgList;
    }
}