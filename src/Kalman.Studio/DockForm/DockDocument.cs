using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using ICSharpCode.TextEditor.Document;
using System.IO;
using ICSharpCode.TextEditor;

namespace Kalman.Studio
{
    public partial class DockDocument : DockFormBase, IDockDocument
    {
        public DockDocument()
        {
            InitializeComponent();
        }

        Main main = null;
        private void DockDocument_Load(object sender, EventArgs e)
        {
            main = this.ParentForm as Main;
            this.ToolTipText = textEditorControl1.FileName;

            textEditorControl1.Document.FoldingManager.FoldingStrategy = new VariXFolding();
            textEditorControl1.Document.FoldingManager.UpdateFoldings(null, null);
        }

        #region Global Methods
        public string FileName
        {
            get { return textEditorControl1.FileName; }
            set { textEditorControl1.FileName = value; }
        }

        public void LoadTextContent(string content, string codeType)
        {
            if (content != null) textEditorControl1.Text = content;
            if (codeType != null) SetDocumentCodeType(codeType);
        }

        /// <summary>
        /// 加载文件内容
        /// </summary>
        /// <param name="fileName">文件完整路径</param>
        public void LoadFileContent(string fileName)
        {
            if (File.Exists(fileName))
            {
                textEditorControl1.LoadFile(fileName, true, true);
                this.Text = Path.GetFileName(textEditorControl1.FileName);
            }
        }

        public void Save()
        {
            if (string.IsNullOrEmpty(textEditorControl1.FileName) == false)
            {
                textEditorControl1.SaveFile(textEditorControl1.FileName);
                this.Text = Path.GetFileName(textEditorControl1.FileName);
            }
            else
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "所有文件 (*.*)|*.*";
                dialog.FileName = this.Text.TrimEnd('*');
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textEditorControl1.SaveFile(dialog.FileName);
                    this.Text = Path.GetFileName(textEditorControl1.FileName);
                }
            }
        }

        public void SaveAs()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "所有文件 (*.*)|*.*";
            dialog.FileName = this.Text.TrimEnd('*');
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textEditorControl1.SaveFile(dialog.FileName);
                this.Text = Path.GetFileName(textEditorControl1.FileName);
            }
        }

        #endregion

        #region SetDocumentCodeType
        public void SetDocumentCodeType(string codeType)
        {
            if (string.IsNullOrEmpty(codeType)) return;
            IHighlightingStrategy strategy = HighlightingStrategyFactory.CreateHighlightingStrategy(codeType);
            textEditorControl1.Document.HighlightingStrategy = strategy;
            //textEditorControl1.Document.FoldingManager.FoldingStrategy = FoldingStrategyFactory
        }

        private void menuItemAspxCode_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in menuItemConfig.DropDownItems)
            {
                ((ToolStripMenuItem)item).Checked = false;
            }
            menuItemAspxCode.Checked = true;
            SetDocumentCodeType(CodeType.ASPX);
        }

        private void menuItemCppCode_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in menuItemConfig.DropDownItems)
            {
                ((ToolStripMenuItem)item).Checked = false;
            }
            menuItemCppCode.Checked = true;
            SetDocumentCodeType(CodeType.CPP);
        }

        private void menuItemCSharpCode_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in menuItemConfig.DropDownItems)
            {
                ((ToolStripMenuItem)item).Checked = false;
            }
            menuItemCSharpCode.Checked = true;
            SetDocumentCodeType(CodeType.CSHARP);
        }

        private void menuItemHtmlCode_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in menuItemConfig.DropDownItems)
            {
                ((ToolStripMenuItem)item).Checked = false;
            }
            menuItemHtmlCode.Checked = true;
            SetDocumentCodeType(CodeType.HTML);
        }

        private void menuItemJavaCode_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in menuItemConfig.DropDownItems)
            {
                ((ToolStripMenuItem)item).Checked = false;
            }
            menuItemJavaCode.Checked = true;
            SetDocumentCodeType(CodeType.JAVA);
        }

        private void menuItemJsCode_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in menuItemConfig.DropDownItems)
            {
                ((ToolStripMenuItem)item).Checked = false;
            }
            menuItemJsCode.Checked = true;
            SetDocumentCodeType(CodeType.JS);
        }

        private void menuItemPhpCode_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in menuItemConfig.DropDownItems)
            {
                ((ToolStripMenuItem)item).Checked = false;
            }
            menuItemPhpCode.Checked = true;
            SetDocumentCodeType(CodeType.PHP);
        }

        private void menuItemTSQLCode_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in menuItemConfig.DropDownItems)
            {
                ((ToolStripMenuItem)item).Checked = false;
            }
            menuItemTSQLCode.Checked = true;
            SetDocumentCodeType(CodeType.TSQL);
        }

        private void menuItemVBCode_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in menuItemConfig.DropDownItems)
            {
                ((ToolStripMenuItem)item).Checked = false;
            }
            menuItemVBCode.Checked = true;
            SetDocumentCodeType(CodeType.VB);
        }

        private void menuItemXmlCode_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in menuItemConfig.DropDownItems)
            {
                ((ToolStripMenuItem)item).Checked = false;
            }
            menuItemXmlCode.Checked = true;
            SetDocumentCodeType(CodeType.XML);
        }
        #endregion

        #region 处理文档右键菜单命令
        private void menuItemSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void menuItemSaveAs_Click(object sender, EventArgs e)
        {
            this.SaveAs();
        }

        private void menuItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItemCloseOther_Click(object sender, EventArgs e)
        {
            main.CloseOtherDockDocument();
        }

        private void menuItemCloseAll_Click(object sender, EventArgs e)
        {
            main.CloseAllDockDocument();
        }

        private void menuItemOpenFolder_Click(object sender, EventArgs e)
        {
            if (File.Exists(textEditorControl1.FileName))
            {
                Kalman.Command.CmdHelper.Execute(string.Format("explorer.exe {0}", Path.GetDirectoryName(textEditorControl1.FileName)));
            }
        }
        #endregion

        private void textEditorControl1_TextChanged(object sender, EventArgs e)
        {
            if (this.Text.EndsWith("*")) return;
            this.Text = this.Text + "*";
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.Text.EndsWith("*"))
            {
                if (MsgBox.ShowQuestionMessage("是否保存文件" + this.Text.TrimEnd('*'), "信息提示") == DialogResult.Yes)
                {
                    Save();
                }
            }

            base.OnClosing(e);
        }


        #region 处理编辑命令
        private void menuItemUndo_Click(object sender, EventArgs e) { Undo(); }
        private void menuItemRedo_Click(object sender, EventArgs e) { Redo(); }
        private void menuItemCut_Click(object sender, EventArgs e) { Cut(sender, e); }
        private void menuItemCopy_Click(object sender, EventArgs e) { Copy(sender, e); }
        private void menuItemPaste_Click(object sender, EventArgs e) { Paste(sender, e); }
        private void menuItemDelete_Click(object sender, EventArgs e) { Delete(sender, e); }
        private void menuItemSelectAll_Click(object sender, EventArgs e) { SelectAll(sender, e); }

        public void Undo() { textEditorControl1.Undo(); }
        public void Redo() { textEditorControl1.Redo(); }
        public void Cut(object sender, EventArgs e) { textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.Cut(sender, e); }
        public void Copy(object sender, EventArgs e) { textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.Copy(sender, e); }
        public void Paste(object sender, EventArgs e) { textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.Paste(sender, e); }
        public void Delete(object sender, EventArgs e) { textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.Delete(sender, e); }
        public void SelectAll(object sender, EventArgs e) { textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.SelectAll(sender, e); }
        #endregion

    }//
}
