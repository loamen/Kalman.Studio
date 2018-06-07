namespace Kalman.Studio
{
    partial class DockDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockDocument));
            this.textEditorControl1 = new ICSharpCode.TextEditor.TextEditorControl();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemCut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAspxCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCppCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCSharpCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHtmlCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemJavaCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemJsCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPhpCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTSQLCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVBCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemXmlCode = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDock = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCloseOther = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.cms.SuspendLayout();
            this.cmsDock.SuspendLayout();
            this.SuspendLayout();
            // 
            // textEditorControl1
            // 
            this.textEditorControl1.AllowDrop = true;
            this.textEditorControl1.ContextMenuStrip = this.cms;
            this.textEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorControl1.IsReadOnly = false;
            this.textEditorControl1.Location = new System.Drawing.Point(0, 0);
            this.textEditorControl1.Name = "textEditorControl1";
            this.textEditorControl1.Size = new System.Drawing.Size(575, 333);
            this.textEditorControl1.TabIndex = 0;
            this.textEditorControl1.TextChanged += new System.EventHandler(this.textEditorControl1_TextChanged);
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemUndo,
            this.menuItemRedo,
            this.toolStripSeparator5,
            this.menuItemCut,
            this.menuItemCopy,
            this.menuItemPaste,
            this.menuItemDelete,
            this.toolStripSeparator1,
            this.menuItemSelectAll,
            this.toolStripSeparator2,
            this.menuItemConfig});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(154, 198);
            // 
            // menuItemUndo
            // 
            this.menuItemUndo.Image = ((System.Drawing.Image)(resources.GetObject("menuItemUndo.Image")));
            this.menuItemUndo.Name = "menuItemUndo";
            this.menuItemUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.menuItemUndo.Size = new System.Drawing.Size(153, 22);
            this.menuItemUndo.Text = "撤销(&Z)";
            this.menuItemUndo.Click += new System.EventHandler(this.menuItemUndo_Click);
            // 
            // menuItemRedo
            // 
            this.menuItemRedo.Image = ((System.Drawing.Image)(resources.GetObject("menuItemRedo.Image")));
            this.menuItemRedo.Name = "menuItemRedo";
            this.menuItemRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.menuItemRedo.Size = new System.Drawing.Size(153, 22);
            this.menuItemRedo.Text = "重复(&R)";
            this.menuItemRedo.Click += new System.EventHandler(this.menuItemRedo_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(150, 6);
            // 
            // menuItemCut
            // 
            this.menuItemCut.Image = ((System.Drawing.Image)(resources.GetObject("menuItemCut.Image")));
            this.menuItemCut.Name = "menuItemCut";
            this.menuItemCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.menuItemCut.Size = new System.Drawing.Size(153, 22);
            this.menuItemCut.Text = "剪切(&X)";
            this.menuItemCut.Click += new System.EventHandler(this.menuItemCut_Click);
            // 
            // menuItemCopy
            // 
            this.menuItemCopy.Image = ((System.Drawing.Image)(resources.GetObject("menuItemCopy.Image")));
            this.menuItemCopy.Name = "menuItemCopy";
            this.menuItemCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.menuItemCopy.Size = new System.Drawing.Size(153, 22);
            this.menuItemCopy.Text = "复制(&C)";
            this.menuItemCopy.Click += new System.EventHandler(this.menuItemCopy_Click);
            // 
            // menuItemPaste
            // 
            this.menuItemPaste.Image = ((System.Drawing.Image)(resources.GetObject("menuItemPaste.Image")));
            this.menuItemPaste.Name = "menuItemPaste";
            this.menuItemPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.menuItemPaste.Size = new System.Drawing.Size(153, 22);
            this.menuItemPaste.Text = "粘贴(&V)";
            this.menuItemPaste.Click += new System.EventHandler(this.menuItemPaste_Click);
            // 
            // menuItemDelete
            // 
            this.menuItemDelete.Image = ((System.Drawing.Image)(resources.GetObject("menuItemDelete.Image")));
            this.menuItemDelete.Name = "menuItemDelete";
            this.menuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.menuItemDelete.Size = new System.Drawing.Size(153, 22);
            this.menuItemDelete.Text = "删除(&D)";
            this.menuItemDelete.Click += new System.EventHandler(this.menuItemDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // menuItemSelectAll
            // 
            this.menuItemSelectAll.Name = "menuItemSelectAll";
            this.menuItemSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.menuItemSelectAll.Size = new System.Drawing.Size(153, 22);
            this.menuItemSelectAll.Text = "全选(&A)";
            this.menuItemSelectAll.Click += new System.EventHandler(this.menuItemSelectAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(150, 6);
            // 
            // menuItemConfig
            // 
            this.menuItemConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAspxCode,
            this.menuItemCppCode,
            this.menuItemCSharpCode,
            this.menuItemHtmlCode,
            this.menuItemJavaCode,
            this.menuItemJsCode,
            this.menuItemPhpCode,
            this.menuItemTSQLCode,
            this.menuItemVBCode,
            this.menuItemXmlCode});
            this.menuItemConfig.Name = "menuItemConfig";
            this.menuItemConfig.Size = new System.Drawing.Size(153, 22);
            this.menuItemConfig.Text = "选择配置";
            // 
            // menuItemAspxCode
            // 
            this.menuItemAspxCode.Name = "menuItemAspxCode";
            this.menuItemAspxCode.Size = new System.Drawing.Size(130, 22);
            this.menuItemAspxCode.Text = "Aspx";
            this.menuItemAspxCode.Click += new System.EventHandler(this.menuItemAspxCode_Click);
            // 
            // menuItemCppCode
            // 
            this.menuItemCppCode.Name = "menuItemCppCode";
            this.menuItemCppCode.Size = new System.Drawing.Size(130, 22);
            this.menuItemCppCode.Text = "C/C++";
            this.menuItemCppCode.Click += new System.EventHandler(this.menuItemCppCode_Click);
            // 
            // menuItemCSharpCode
            // 
            this.menuItemCSharpCode.Name = "menuItemCSharpCode";
            this.menuItemCSharpCode.Size = new System.Drawing.Size(130, 22);
            this.menuItemCSharpCode.Text = "C#";
            this.menuItemCSharpCode.Click += new System.EventHandler(this.menuItemCSharpCode_Click);
            // 
            // menuItemHtmlCode
            // 
            this.menuItemHtmlCode.Name = "menuItemHtmlCode";
            this.menuItemHtmlCode.Size = new System.Drawing.Size(130, 22);
            this.menuItemHtmlCode.Text = "Html";
            this.menuItemHtmlCode.Click += new System.EventHandler(this.menuItemHtmlCode_Click);
            // 
            // menuItemJavaCode
            // 
            this.menuItemJavaCode.Name = "menuItemJavaCode";
            this.menuItemJavaCode.Size = new System.Drawing.Size(130, 22);
            this.menuItemJavaCode.Text = "Java";
            this.menuItemJavaCode.Click += new System.EventHandler(this.menuItemJavaCode_Click);
            // 
            // menuItemJsCode
            // 
            this.menuItemJsCode.Name = "menuItemJsCode";
            this.menuItemJsCode.Size = new System.Drawing.Size(130, 22);
            this.menuItemJsCode.Text = "Javascript";
            this.menuItemJsCode.Click += new System.EventHandler(this.menuItemJsCode_Click);
            // 
            // menuItemPhpCode
            // 
            this.menuItemPhpCode.Name = "menuItemPhpCode";
            this.menuItemPhpCode.Size = new System.Drawing.Size(130, 22);
            this.menuItemPhpCode.Text = "PHP";
            this.menuItemPhpCode.Click += new System.EventHandler(this.menuItemPhpCode_Click);
            // 
            // menuItemTSQLCode
            // 
            this.menuItemTSQLCode.Name = "menuItemTSQLCode";
            this.menuItemTSQLCode.Size = new System.Drawing.Size(130, 22);
            this.menuItemTSQLCode.Text = "TSQL";
            this.menuItemTSQLCode.Click += new System.EventHandler(this.menuItemTSQLCode_Click);
            // 
            // menuItemVBCode
            // 
            this.menuItemVBCode.Name = "menuItemVBCode";
            this.menuItemVBCode.Size = new System.Drawing.Size(130, 22);
            this.menuItemVBCode.Text = "VB.NET";
            this.menuItemVBCode.Click += new System.EventHandler(this.menuItemVBCode_Click);
            // 
            // menuItemXmlCode
            // 
            this.menuItemXmlCode.Name = "menuItemXmlCode";
            this.menuItemXmlCode.Size = new System.Drawing.Size(130, 22);
            this.menuItemXmlCode.Text = "XML";
            this.menuItemXmlCode.Click += new System.EventHandler(this.menuItemXmlCode_Click);
            // 
            // cmsDock
            // 
            this.cmsDock.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSave,
            this.menuItemSaveAs,
            this.toolStripSeparator3,
            this.menuItemClose,
            this.menuItemCloseOther,
            this.menuItemCloseAll,
            this.toolStripSeparator4,
            this.menuItemOpenFolder});
            this.cmsDock.Name = "cmsDock";
            this.cmsDock.Size = new System.Drawing.Size(167, 148);
            // 
            // menuItemSave
            // 
            this.menuItemSave.Image = ((System.Drawing.Image)(resources.GetObject("menuItemSave.Image")));
            this.menuItemSave.Name = "menuItemSave";
            this.menuItemSave.Size = new System.Drawing.Size(166, 22);
            this.menuItemSave.Text = "保存";
            this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
            // 
            // menuItemSaveAs
            // 
            this.menuItemSaveAs.Name = "menuItemSaveAs";
            this.menuItemSaveAs.Size = new System.Drawing.Size(166, 22);
            this.menuItemSaveAs.Text = "另存为...";
            this.menuItemSaveAs.Click += new System.EventHandler(this.menuItemSaveAs_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(163, 6);
            // 
            // menuItemClose
            // 
            this.menuItemClose.Image = ((System.Drawing.Image)(resources.GetObject("menuItemClose.Image")));
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(163, 6);
            // 
            // menuItemOpenFolder
            // 
            this.menuItemOpenFolder.Name = "menuItemOpenFolder";
            this.menuItemOpenFolder.Size = new System.Drawing.Size(166, 22);
            this.menuItemOpenFolder.Text = "打开所在文件夹";
            this.menuItemOpenFolder.Click += new System.EventHandler(this.menuItemOpenFolder_Click);
            // 
            // DockDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 333);
            this.Controls.Add(this.textEditorControl1);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DockDocument";
            this.TabPageContextMenuStrip = this.cmsDock;
            this.Text = "DockDocument";
            this.Load += new System.EventHandler(this.DockDocument_Load);
            this.cms.ResumeLayout(false);
            this.cmsDock.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ICSharpCode.TextEditor.TextEditorControl textEditorControl1;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem menuItemConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuItemCSharpCode;
        private System.Windows.Forms.ToolStripMenuItem menuItemTSQLCode;
        private System.Windows.Forms.ToolStripMenuItem menuItemHtmlCode;
        private System.Windows.Forms.ToolStripMenuItem menuItemJsCode;
        private System.Windows.Forms.ToolStripMenuItem menuItemAspxCode;
        private System.Windows.Forms.ToolStripMenuItem menuItemCppCode;
        private System.Windows.Forms.ToolStripMenuItem menuItemJavaCode;
        private System.Windows.Forms.ToolStripMenuItem menuItemPhpCode;
        private System.Windows.Forms.ToolStripMenuItem menuItemVBCode;
        private System.Windows.Forms.ToolStripMenuItem menuItemXmlCode;
        private System.Windows.Forms.ContextMenuStrip cmsDock;
        private System.Windows.Forms.ToolStripMenuItem menuItemClose;
        private System.Windows.Forms.ToolStripMenuItem menuItemSave;
        private System.Windows.Forms.ToolStripMenuItem menuItemCloseOther;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuItemCloseAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menuItemUndo;
        private System.Windows.Forms.ToolStripMenuItem menuItemRedo;
        private System.Windows.Forms.ToolStripMenuItem menuItemCut;
        private System.Windows.Forms.ToolStripMenuItem menuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem menuItemPaste;
        private System.Windows.Forms.ToolStripMenuItem menuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem menuItemSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}