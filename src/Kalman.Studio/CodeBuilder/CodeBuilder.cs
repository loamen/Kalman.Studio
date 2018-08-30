using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using Microsoft.VisualStudio.TextTemplating;
using Kalman.Studio.T4TemplateEngineHost;
using System.CodeDom.Compiler;
using Kalman.Data.SchemaObject;
using System.Diagnostics;

namespace Kalman.Studio
{
    public partial class CodeBuilder : DockableForm
    {
        public CodeBuilder()
        {
            InitializeComponent();
        }

        string _CodeType = CodeType.CSHARP;
        public SOTable Table { get; set; }
        public List<SOColumn> ColumnList { get; set; }

        private void CodeBuilder_Load(object sender, EventArgs e)
        {
            base.MainForm.ShowBuildCodeIcon();

            SetDocumentCodeType(textEditorControl1, CodeType.CSHARP);
            SetDocumentCodeType(textEditorControl2, CodeType.CSHARP);

            LoadTemplateTree();
            LoadColumnList();
            ShowTitle();
        }

        public void LoadColumnList()
        {
            dataGridView1.AutoGenerateColumns = false;
            if (ColumnList != null)
            {
                this.dataGridView1.DataSource = ColumnList;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                    cell.ValueType = typeof(bool);
                    cell.Value = true;
                }
                ShowTitle();
            }
        }

        private void ShowTitle()
        {
            if (this.Table != null)
            {
                if (Table.Database != null)
                {
                    gbObjName.Text = string.Format("当前对象：{0} -> {1}", Table.Database, Table.Name);
                }
                else
                {
                    gbObjName.Text = string.Format("当前对象：{0}", Table.Name);
                }
            }
            else
            {
                gbObjName.Text = "没有选择表或视图";
            }
        }

        #region 模板树相关代码

        private void LoadTemplateTree()
        {
            string templatePath = Path.Combine(Application.StartupPath, "T4Template");

            TreeNode root = new TreeNode("T4Templates", 0, 0);
            root.ContextMenuStrip = cmsTree;
            tvTemplate.Nodes.Add(root);

            DirectoryInfo dirInfo = new DirectoryInfo(templatePath);
            ExpentTemplateDir(dirInfo, root);
        }

        //展开模板文件夹
        private void ExpentTemplateDir(DirectoryInfo rootDirInfo, TreeNode root)
        {
            DirectoryInfo[] dirs = rootDirInfo.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                TreeNode node = new TreeNode(dir.Name, 1, 1);
                node.Tag = dir;
                node.Name = dir.Name;
                if(root.Nodes.ContainsKey(node.Name) == false) root.Nodes.Add(node);
            }

            FileInfo[] files = rootDirInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                TreeNode node = new TreeNode(file.Name, 2, 2);
                node.Tag = file;
                node.Name = file.Name;
                if(root.Nodes.ContainsKey(node.Name) == false) root.Nodes.Add(node);
            }

            root.Expand();
        }

        private void tvTemplate_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeView tv = sender as TreeView;
                TreeNode tn = tv.GetNodeAt(e.X, e.Y);
                tv.SelectedNode = tn;
            }
        }

        private void tvTemplate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeView tv = sender as TreeView;
            TreeNode tn = tv.GetNodeAt(e.X, e.Y);

            if (tn.Tag is DirectoryInfo)
            {
                DirectoryInfo dir = (DirectoryInfo)tn.Tag;
                if (Directory.Exists(dir.FullName) == false)
                {
                    MsgBox.Show("目标可能被删除、移动、改名，请刷新模板树");
                    return;
                }
                ExpentTemplateDir(dir, tn);
            }
            if (tn.Tag is FileInfo)
            {
                FileInfo fi = tn.Tag as FileInfo;
                if (File.Exists(fi.FullName) == false)
                {
                    MsgBox.Show("目标可能被删除、移动、改名，请刷新模板树");
                    return;
                }
                textEditorControl1.LoadFile(fi.FullName);
                gbTemplateFile.Text = fi.FullName;
            }
            SetDocumentCodeType(textEditorControl1, CodeType.CSHARP);
        }

        //右键菜单项命令：刷新模板树
        private void menuItemRefresh_Click(object sender, EventArgs e)
        {
            tvTemplate.Nodes.Clear();
            LoadTemplateTree();
        }

        //右键菜单项命令：模板管理
        private void menuItemManage_Click(object sender, EventArgs e)
        {
            base.MainForm.ShowTemplateExplorer();
        }


        #endregion

        public void DoBuildCode()
        {
            Config.MainForm.SetStatusText("正在生成代码...");
            textEditorControl1.SaveFile(gbTemplateFile.Text);

            TableHost host = new TableHost();
            host.Table = this.Table;
            host.TemplateFile = gbTemplateFile.Text;

            List<SOColumn> columnList = new List<SOColumn>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].FormattedValue.ToString().ToLower() == "true")
                {
                    SOColumn c = row.DataBoundItem as SOColumn;
                    columnList.Add(c);
                }
            }

            host.ColumnList = columnList;
            Engine engine = new Engine();
            var sw = new Stopwatch();
            var content = File.ReadAllText(host.TemplateFile);
            string outputContent = engine.ProcessTemplate(content, host);

            StringBuilder sb = new StringBuilder();
            if (host.ErrorCollection.HasErrors)
            {
                foreach (CompilerError err in host.ErrorCollection)
                {
                    sb.AppendLine(err.ToString());
                }
                outputContent = outputContent + Environment.NewLine + sb.ToString();
            }

            textEditorControl2.Text = outputContent;
            tabControl1.SelectedTab = tabPage2;
            textEditorControl2.Refresh();

            Config.MainForm.SetStatusText();
        }

        #region SetDocumentCodeType
        void SetDocumentCodeType(TextEditorControl editor, string codeType)
        {
            IHighlightingStrategy strategy = HighlightingStrategyFactory.CreateHighlightingStrategy(codeType);
            editor.Document.HighlightingStrategy = strategy;
            _CodeType = codeType;
        }

        private void menuItemAspxCode_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in menuItemConfig.DropDownItems)
            {
                ((ToolStripMenuItem)item).Checked = false;
            }
            menuItemAspxCode.Checked = true;
            TextEditorControl editor = tabControl1.SelectedTab == tabPage1 ? textEditorControl1 : textEditorControl2;
            SetDocumentCodeType(editor, CodeType.ASPX);
        }

        private void menuItemCppCode_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in menuItemConfig.DropDownItems)
            {
                ((ToolStripMenuItem)item).Checked = false;
            }
            menuItemCppCode.Checked = true;
            TextEditorControl editor = tabControl1.SelectedTab == tabPage1 ? textEditorControl1 : textEditorControl2;
            SetDocumentCodeType(editor, CodeType.CPP);
        }

        private void menuItemCSharpCode_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in menuItemConfig.DropDownItems)
            {
                ((ToolStripMenuItem)item).Checked = false;
            }
            menuItemCSharpCode.Checked = true;
            TextEditorControl editor = tabControl1.SelectedTab == tabPage1 ? textEditorControl1 : textEditorControl2;
            SetDocumentCodeType(editor, CodeType.CSHARP);
        }

        private void menuItemHtmlCode_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in menuItemConfig.DropDownItems)
            {
                ((ToolStripMenuItem)item).Checked = false;
            }
            menuItemHtmlCode.Checked = true;
            TextEditorControl editor = tabControl1.SelectedTab == tabPage1 ? textEditorControl1 : textEditorControl2;
            SetDocumentCodeType(editor, CodeType.HTML);
        }

        private void menuItemJavaCode_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in menuItemConfig.DropDownItems)
            {
                ((ToolStripMenuItem)item).Checked = false;
            }
            menuItemJavaCode.Checked = true;
            TextEditorControl editor = tabControl1.SelectedTab == tabPage1 ? textEditorControl1 : textEditorControl2;
            SetDocumentCodeType(editor, CodeType.JAVA);
        }

        private void menuItemJsCode_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in menuItemConfig.DropDownItems)
            {
                ((ToolStripMenuItem)item).Checked = false;
            }
            menuItemJsCode.Checked = true;
            TextEditorControl editor = tabControl1.SelectedTab == tabPage1 ? textEditorControl1 : textEditorControl2;
            SetDocumentCodeType(editor, CodeType.JS);
        }

        private void menuItemPhpCode_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in menuItemConfig.DropDownItems)
            {
                ((ToolStripMenuItem)item).Checked = false;
            }
            menuItemPhpCode.Checked = true;
            TextEditorControl editor = tabControl1.SelectedTab == tabPage1 ? textEditorControl1 : textEditorControl2;
            SetDocumentCodeType(editor, CodeType.PHP);
        }

        private void menuItemTSQLCode_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in menuItemConfig.DropDownItems)
            {
                ((ToolStripMenuItem)item).Checked = false;
            }
            menuItemTSQLCode.Checked = true;
            TextEditorControl editor = tabControl1.SelectedTab == tabPage1 ? textEditorControl1 : textEditorControl2;
            SetDocumentCodeType(editor, CodeType.TSQL);
        }

        private void menuItemVBCode_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in menuItemConfig.DropDownItems)
            {
                ((ToolStripMenuItem)item).Checked = false;
            }
            menuItemVBCode.Checked = true;
            TextEditorControl editor = tabControl1.SelectedTab == tabPage1 ? textEditorControl1 : textEditorControl2;
            SetDocumentCodeType(editor, CodeType.VB);
        }

        private void menuItemXmlCode_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in menuItemConfig.DropDownItems)
            {
                ((ToolStripMenuItem)item).Checked = false;
            }
            menuItemXmlCode.Checked = true;
            TextEditorControl editor = tabControl1.SelectedTab == tabPage1 ? textEditorControl1 : textEditorControl2;
            SetDocumentCodeType(editor, CodeType.XML);
        }
        #endregion

        #region 处理编辑命令
        private void menuItemUndo_Click(object sender, EventArgs e) { Undo(tabControl1.SelectedTab == tabPage1 ? textEditorControl1 : textEditorControl2); }
        private void menuItemRedo_Click(object sender, EventArgs e) { Redo(tabControl1.SelectedTab == tabPage1 ? textEditorControl1 : textEditorControl2); }
        private void menuItemCut_Click(object sender, EventArgs e) { Cut(sender, e); }
        private void menuItemCopy_Click(object sender, EventArgs e) { Copy(sender, e); }
        private void menuItemPaste_Click(object sender, EventArgs e) { Paste(sender, e); }
        private void menuItemDelete_Click(object sender, EventArgs e) { Delete(sender, e); }
        private void menuItemSelectAll_Click(object sender, EventArgs e) { SelectAll(sender, e); }

        public void Undo(TextEditorControl editor) { editor.Undo(); }
        public void Redo(TextEditorControl editor) { editor.Redo(); }
        public void Cut(object sender, EventArgs e) { (tabControl1.SelectedTab == tabPage1 ? textEditorControl1 : textEditorControl2).ActiveTextAreaControl.TextArea.ClipboardHandler.Cut(sender, e); }
        public void Copy(object sender, EventArgs e) { (tabControl1.SelectedTab == tabPage1 ? textEditorControl1 : textEditorControl2).ActiveTextAreaControl.TextArea.ClipboardHandler.Copy(sender, e); }
        public void Paste(object sender, EventArgs e) { (tabControl1.SelectedTab == tabPage1 ? textEditorControl1 : textEditorControl2).ActiveTextAreaControl.TextArea.ClipboardHandler.Paste(sender, e); }
        public void Delete(object sender, EventArgs e) { (tabControl1.SelectedTab == tabPage1 ? textEditorControl1 : textEditorControl2).ActiveTextAreaControl.TextArea.ClipboardHandler.Delete(sender, e); }
        public void SelectAll(object sender, EventArgs e) { (tabControl1.SelectedTab == tabPage1 ? textEditorControl1 : textEditorControl2).ActiveTextAreaControl.TextArea.ClipboardHandler.SelectAll(sender, e); }
        #endregion

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                textEditorControl1.SaveFile(gbTemplateFile.Text);
            }
            else
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "所有文件 (*.*)|*.*";
                dialog.FileName = Table.Name + CodeTypeHelper.GetExtention(_CodeType);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textEditorControl2.SaveFile(dialog.FileName);
                }
            }
        }

        private void menuItemBuildCode_Click(object sender, EventArgs e)
        {
            DoBuildCode();  
        }

        private void CodeBuilder_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.MainForm.HideBuildCodeIcon();
        }

        //protected override void CloseDockToolWindow()
        //{
        //    base.MainForm.HideBuildCodeIcon();
        //    //base.CloseDockToolWindow();
        //    this.Hide();
        //}

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                bool val = (bool)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = !val;
            }
        }

        private void menuItemCheckAll_Click(object sender, EventArgs e)
        {
            dataGridView1.RefreshEdit();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                cell.Value = true;
            }
        }

        private void menuItemUnCheckAll_Click(object sender, EventArgs e)
        {
            dataGridView1.RefreshEdit();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                cell.Value = !(bool)cell.Value;
            }
        }

        
        
    }
}
