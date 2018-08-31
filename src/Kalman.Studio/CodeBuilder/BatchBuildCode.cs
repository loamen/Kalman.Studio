using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Microsoft.VisualStudio.TextTemplating;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Diagnostics;
using System.CodeDom.Compiler;
using Kalman.Data.SchemaObject;
using Kalman.Utilities;
using Kalman.Extensions;
using Kalman.Studio.T4TemplateEngineHost;
using ICSharpCode.TextEditor.Document;
using ICSharpCode.TextEditor;

namespace Kalman.Studio
{
    public partial class BatchBuildCode : DockableForm
    {
        string _CodeType = CodeType.CSHARP;
        SODatabase currentDatabase;
        List<SOTable> tableList = new List<SOTable>();
        Dictionary<string, string> dicTemp = new Dictionary<string, string>();

        public BatchBuildCode(SODatabase db)
        {
            InitializeComponent();
            currentDatabase = db;
            tableList = db.TableList;
        }

        private void BatchBuildCode_Load(object sender, EventArgs e)
        {
            gbTableSelect.Text = string.Format("当前数据库[{0}]", currentDatabase);

            foreach (SOTable t in tableList)
            {
                listBox1.Items.Add(t);
            }

            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            txtOutputPath.Text = Path.Combine(Application.StartupPath, "Output");
            txtNameSpace.Text = nameSpace;

            SetDocumentCodeType(textEditorControl1, CodeType.CSHARP);
            LoadTemplateTree();
        }
        //选择代码输出目录
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtOutputPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        //处理窗体关闭事件
        protected override void OnClosing(CancelEventArgs e)
        {
            if (backgroundWorker1.IsBusy == false)
            {
                base.OnClosing(e);
            }
            else
            {
                e.Cancel = true;
                MsgBox.Show("正在生成代码，请不要关闭窗口");
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
                if (root.Nodes.ContainsKey(node.Name) == false) root.Nodes.Add(node);
            }

            FileInfo[] files = rootDirInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                TreeNode node = new TreeNode(file.Name, 2, 2);
                node.Tag = file;
                node.Name = file.Name;
                if (root.Nodes.ContainsKey(node.Name) == false) root.Nodes.Add(node);
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

        void SetDocumentCodeType(TextEditorControl editor, string codeType)
        {
            IHighlightingStrategy strategy = HighlightingStrategyFactory.CreateHighlightingStrategy(codeType);
            editor.Document.HighlightingStrategy = strategy;
            _CodeType = codeType;
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

        #region 处理编辑命令
        private void menuItemUndo_Click(object sender, EventArgs e) { Undo(textEditorControl1); }
        private void menuItemRedo_Click(object sender, EventArgs e) { Redo(textEditorControl1); }
        private void menuItemCut_Click(object sender, EventArgs e) { Cut(sender, e); }
        private void menuItemCopy_Click(object sender, EventArgs e) { Copy(sender, e); }
        private void menuItemPaste_Click(object sender, EventArgs e) { Paste(sender, e); }
        private void menuItemDelete_Click(object sender, EventArgs e) { Delete(sender, e); }
        private void menuItemSelectAll_Click(object sender, EventArgs e) { SelectAll(sender, e); }

        public void Undo(TextEditorControl editor) { editor.Undo(); }
        public void Redo(TextEditorControl editor) { editor.Redo(); }
        public void Cut(object sender, EventArgs e) { textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.Cut(sender, e); }
        public void Copy(object sender, EventArgs e) { textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.Copy(sender, e); }
        public void Paste(object sender, EventArgs e) { textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.Paste(sender, e); }
        public void Delete(object sender, EventArgs e) { textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.Delete(sender, e); }
        public void SelectAll(object sender, EventArgs e) { textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.SelectAll(sender, e); }
        #endregion

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            textEditorControl1.SaveFile(gbTemplateFile.Text);
        }

        #region 列表选择相关
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectOne();
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RemoveOne();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }
        private void btnSelectOne_Click(object sender, EventArgs e)
        {
            SelectOne();
        }
        private void btnRemoveOne_Click(object sender, EventArgs e)
        {
            RemoveOne();
        }
        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            RemoveAll();
        }

        private void SelectAll()
        {
            if (backgroundWorker1.IsBusy) return;
            if (listBox1.Items.Count > 0)
            {
                listBox2.Items.AddRange(listBox1.Items);
                listBox1.Items.Clear();
            }
        }

        private void SelectOne()
        {
            if (backgroundWorker1.IsBusy) return;
            object[] items = new object[listBox1.SelectedItems.Count];
            listBox1.SelectedItems.CopyTo(items, 0);
            listBox2.Items.AddRange(items);

            foreach (var item in items)
            {
                listBox1.Items.Remove(item);
            }
        }

        private void RemoveOne()
        {
            if (backgroundWorker1.IsBusy) return;
            object[] items = new object[listBox2.SelectedItems.Count];
            listBox2.SelectedItems.CopyTo(items, 0);
            listBox1.Items.AddRange(items);

            foreach (var item in items)
            {
                listBox2.Items.Remove(item);
            }
        }

        private void RemoveAll()
        {
            if (backgroundWorker1.IsBusy) return;
            if (listBox2.Items.Count > 0)
            {
                listBox1.Items.AddRange(listBox2.Items);
                listBox2.Items.Clear();
            }
        }
        #endregion

        #region 代码生成相关
        string nameSpace = "Loamen";
        string tablePrefix = string.Empty;
        int prefixLevel = 1;
        string templateFile = string.Empty;
        string outputPath = string.Empty;

        private void btnBuildCode_Click(object sender, EventArgs e)
        {
            templateFile = gbTemplateFile.Text;
            if (!File.Exists(templateFile)) return;
            if (listBox2.Items.Count == 0) return;

            textEditorControl1.SaveFile(templateFile);
            outputPath = txtOutputPath.Text;
            if (txtNameSpace.Text.Trim() != "") nameSpace = txtNameSpace.Text.Trim();

            if (cbDeleteTablePrifix.Checked && txtTablePrefix.Text.Trim().Length > 0) tablePrefix = txtTablePrefix.Text.Trim();
            prefixLevel = ConvertUtil.ToInt32(txtPrefixLevel.Text, 1);

            btnBuildCode.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void DoBuild()
        {
            int finish = 0;
            int total = listBox2.Items.Count;

            //遍历选中的表，一张表对应生成一个代码文件
            foreach (object item in listBox2.Items)
            {
                SOTable table = item as SOTable;
                string className = table.Name;
                if (cbDeleteTablePrifix.Checked)className = table.Name.RemovePrefix(tablePrefix, prefixLevel).Replace(" ", "");
                if (cbClassNamePascal.Checked) className = className.InitialToUpperMulti();
                if (cbClassNameRemovePlural.Checked) className = className.EndsWith("s") ? className.TrimEnd('s') : className.Trim();
                if (cbAddSuffix.Checked) className = txtClassPrefix.Text.Trim() + className + txtClassSuffix.Text.Trim();

                templateFile = gbTemplateFile.Text;

                List<SOColumn> columnList = table.ColumnList;//可能传入的是从PDObject对象转换过来的SODatabase对象
                if (columnList == null || columnList.Count == 0) columnList = DbSchemaHelper.Instance.CurrentSchema.GetTableColumnList(table);

                //生成代码文件
                TableHost host = new TableHost();
                host.Table = table;
                host.ColumnList = columnList;
                host.TemplateFile = templateFile;
                host.SetValue("NameSpace", nameSpace);
                host.SetValue("ClassName", className);
                host.SetValue("TablePrefix", tablePrefix);
                //host.SetValue("ColumnPrefix", columnPrefix);
                host.SetValue("PrefixLevel", prefixLevel);

                Engine engine = new Engine();
                string templateContent = string.Empty;
                if (dicTemp.ContainsKey(templateFile))
                {
                    templateContent = dicTemp[templateFile];
                }
                else
                {
                    templateContent = File.ReadAllText(templateFile);
                    dicTemp.Add(templateFile, templateContent);
                }

                var outputContent = engine.ProcessTemplate(templateContent, host); 
                //string outputFile = Path.Combine(outputPath, string.Format("{0}.cs", className));
                string outputFile = Path.Combine(outputPath, string.Format("{0}{1}", table.Name, host.FileExtention));
                if(cbClassNameIsFileName.Checked)outputFile = Path.Combine(outputPath, string.Format("{0}{1}", className, host.FileExtention));

                StringBuilder sb = new StringBuilder();
                if (host.ErrorCollection != null && host.ErrorCollection.HasErrors)
                {
                    foreach (CompilerError err in host.ErrorCollection)
                    {
                        sb.AppendLine(err.ToString());
                    }
                    outputContent = outputContent + Environment.NewLine + sb.ToString();
                    outputFile = outputFile + ".error";
                }

                if (Directory.Exists(outputPath) == false) Directory.CreateDirectory(outputPath);
                File.WriteAllText(outputFile, outputContent, Encoding.UTF8);

                finish = finish + 1;
                int percent = ConvertUtil.ToInt32(finish * 100 / total, 0);

                backgroundWorker1.ReportProgress(percent, table);
            }//end build code foreach
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DoBuild();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            SOTable table = e.UserState as SOTable;

            if (e.ProgressPercentage == 100)
            {
                lblMsg.Text = "代码已全部生成";
            }
            else
            {
                lblMsg.Text = string.Format("已完成：{0}%，正在处理：{1}", e.ProgressPercentage, table.Name);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult result = MsgBox.ShowQuestionMessage("代码生成成功，是否打开输出目录", "代码生成消息提示");
            if (result == DialogResult.Yes)
            {
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(outputPath);
                p.Start();
            }
            btnBuildCode.Enabled = true;
        }
        #endregion

    }
}
