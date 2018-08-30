using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kalman.PdmParser;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;
using Kalman.Command;
using Kalman.Data.SchemaObject;

namespace Kalman.Studio
{
    public partial class PdmExplorer : DockExplorer
    {
        List<string> pdmFileList = new List<string>(); //PDM文件列表
        string configFile = Path.Combine(Application.StartupPath, "config\\PDMFileList.config");

        public PdmExplorer()
        {
            InitializeComponent();
        }

        private void PdmExplorer_Load(object sender, EventArgs e)
        {
            TreeNode root = new TreeNode("PDM文件列表", 0, 0);
            root.ContextMenuStrip = cms;
            tv.Nodes.Add(root);
            root.Expand();
            LoadFileNodes();
        }

        #region private method

        void LoadFileNodes()
        {
            //读配置文件
            if (File.Exists(configFile))
            {
                string[] ss = File.ReadAllLines(configFile);
                foreach (string s in ss)
                {
                    if (File.Exists(s) && pdmFileList.Contains(s) == false) pdmFileList.Add(s);
                }
                SaveFile();
            }
            //初始化pdm文件节点
            foreach (string fileName in pdmFileList)
            {
                AddFileNode(fileName);
            }
        }

        //增加一个文件节点
        void AddFileNode(string fileName)
        {
            TreeNode root = tv.Nodes[0];
            //先判断要增加的文件节点是否已存在
            foreach (TreeNode node in root.Nodes)
            {
                if (node.Tag.ToString() == fileName) return;
            }

            string name = Path.GetFileName(fileName);
            TreeNode tn = new TreeNode(name, 1, 1);
            tn.ToolTipText = fileName;
            tn.Tag = fileName;
            tn.ContextMenuStrip = cmsFile;

            root.Nodes.Add(tn);
            root.Expand();
            SaveFile();
        }
        //移除一个文件节点
        void RemoveFileNode(TreeNode node)
        {
            tv.Nodes.Remove(node);
            pdmFileList.Remove(node.Tag.ToString());
            SaveFile();
        }
        //保存配置文件
        void SaveFile()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in pdmFileList)
            {
                sb.AppendLine(s);
            }
            File.WriteAllText(configFile, sb.ToString(), Encoding.UTF8);
        }

        #endregion

        #region 模型树事件处理

        //解决右键点击节点定位的问题
        private void tv_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeView tv = sender as TreeView;
                TreeNode tn = tv.GetNodeAt(e.X, e.Y);
                tv.SelectedNode = tn;
            }
        }

        private void tv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeView tv = sender as TreeView;
            TreeNode tn = tv.GetNodeAt(e.X, e.Y);

            if (tn.Level == 1 && tn.Nodes.Count == 0)
            {
                LoadModel(tn);
                tn.Expand();
            }
        }

        #endregion

        #region 加载PDM模型对象节点

        string FormatNodeToolTip(PDObject o)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ID:" + o.ID);
            sb.AppendLine("Name:" + o.Name);
            sb.AppendLine("Code:" + o.Code);
            sb.AppendLine("Comment:" + o.Comment);
            return sb.ToString();
        }

        //加载模型节点
        private void LoadModel(TreeNode fileNode)
        {
            string fileName = fileNode.Tag.ToString();
            PdmReader reader = new PdmReader(fileName);
            PDModel m = reader.BuildModel();

            TreeNode node = new TreeNode(m.Name, 2, 2);
            node.ToolTipText = FormatNodeToolTip(m);
            node.Tag = m;
            node.ContextMenuStrip = cmsModel;

            LoadPackages(m.PackageList, node);

            if (m.TableList.Count > 0)
            {
                TreeNode tablesNode = new TreeNode("Tables", 4, 4);
                tablesNode.Tag = m.TableList;
                LoadTables(m.TableList, tablesNode);
                node.Nodes.Add(tablesNode);
            }

            fileNode.Nodes.Add(node);
            node.Expand();
        }

        //加载包节点
        void LoadPackages(IList<PDPackage> packageList, TreeNode root)
        {
            foreach (PDPackage package in packageList)
            {
                TreeNode node = new TreeNode(package.Name, 3, 3);
                node.Tag = package;
                node.ToolTipText = FormatNodeToolTip(package);
                node.ContextMenuStrip = cmsModel;

                if (package.TableList.Count > 0)
                {
                    TreeNode tablesNode = new TreeNode("Tables", 4, 4);
                    tablesNode.Tag = package.TableList;
                    LoadTables(package.TableList, tablesNode);
                    node.Nodes.Add(tablesNode);
                }

                root.Nodes.Add(node);

                LoadPackages(package.ChildrenList, node);
            }
        }

        //加载表节点
        void LoadTables(IList<PDTable> tableList, TreeNode root)
        {
            foreach (PDTable table in tableList)
            {
                TreeNode node = new TreeNode(table.Name,5,5);
                node.Tag = table;
                node.ToolTipText = FormatNodeToolTip(table);
                node.ContextMenuStrip = cmsTable;

                if (table.ColumnList.Count > 0)
                {
                    TreeNode columnsNode = new TreeNode("Columns", 4, 4);
                    columnsNode.Tag = table.ColumnList;
                    LoadColumns(table.ColumnList, columnsNode);
                    node.Nodes.Add(columnsNode);
                }

                if (table.KeyList.Count > 0)
                {
                    TreeNode keysNode = new TreeNode("Keys", 4, 4);
                    keysNode.Tag = table.KeyList;
                    LoadKeys(table.KeyList, keysNode);
                    node.Nodes.Add(keysNode);
                }

                if (table.IndexList.Count > 0)
                {
                    TreeNode indexesNode = new TreeNode("Indexes", 4, 4);
                    indexesNode.Tag = table.IndexList;
                    LoadIndexes(table.IndexList, indexesNode);
                    node.Nodes.Add(indexesNode);
                }

                root.Nodes.Add(node);
            }
        }

        //加载列节点
        private void LoadColumns(IList<PDColumn> columnList, TreeNode root)
        {
            foreach (PDColumn column in columnList)
            {
                TreeNode columnNode = new TreeNode(column.Name, 6, 6);
                columnNode.Tag = column;
                columnNode.ToolTipText = FormatNodeToolTip(column);

                root.Nodes.Add(columnNode);
            }
        }

        //加载键节点
        private void LoadKeys(IList<PDKey> keyList, TreeNode root)
        {
            foreach (PDKey key in keyList)
            {
                TreeNode keyNode = new TreeNode(key.Name, 7, 7);
                keyNode.Tag = key;
                keyNode.ToolTipText = FormatNodeToolTip(key);

                root.Nodes.Add(keyNode);
            }
        }

        //加载索引节点
        private void LoadIndexes(IList<PDIndex> indexList, TreeNode root)
        {
            foreach (PDIndex index in indexList)
            {
                TreeNode indexNode = new TreeNode(index.Name, 8, 8);
                indexNode.Tag = index;
                indexNode.ToolTipText = FormatNodeToolTip(index);

                root.Nodes.Add(index.Name);
            }
        }
        
        #endregion

        #region 模型树右键菜单事件处理
        private void menuItemLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "pdm文件(*.pdm)|*.pdm|所有文件 (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pdmFileList.Add(dialog.FileName);
                AddFileNode(dialog.FileName);
            }
        }

        

        #endregion

        #region 文件节点右键菜单事件处理

        private void menuItemRemoveFile_Click(object sender, EventArgs e)
        {
            TreeNode node = tv.SelectedNode;
            RemoveFileNode(node);
        }

        private void menuItemReload_Click(object sender, EventArgs e)
        {
            TreeNode node = tv.SelectedNode;
            node.Nodes.Clear();
            LoadModel(node);
        }

        #endregion

        #region 模型和包节点右键菜单事件处理

        private void menuItemBrowserModel_Click(object sender, EventArgs e)
        {
            PdmModelViewer viewer = null;
            foreach (IDockContent content in DockPanel.Documents)
            {
                if (content is PdmModelViewer) viewer = content as PdmModelViewer;
            }

            if (viewer == null) viewer = new PdmModelViewer();

            TreeNode node = tv.SelectedNode;

            if (node.Tag.GetType().Name == typeof(PDModel).Name)
            {
                PDModel m = node.Tag as PDModel;
                viewer.LoadModel(m);
            }
            if (node.Tag.GetType().Name == typeof(PDPackage).Name)
            {
                PDPackage p = node.Tag as PDPackage;
                viewer.LoadPackage(p);
            }

            viewer.Show(this.DockPanel);
        }

        private void menuItemBuildWord_Click(object sender, EventArgs e)
        {
            IList<PDTable> tableList = new List<PDTable>();
            string title = string.Empty;
            TreeNode node = tv.SelectedNode;

            if (node.Tag is PDModel)
            {
                PDModel m = node.Tag as PDModel;
                tableList = m.AllTableList;
                title = m.Name;
            }
            if (node.Tag is PDPackage)
            {
                PDPackage p = node.Tag as PDPackage;
                tableList = p.TableList;
                title = p.Name;
            }

            saveFileDialog1.FileName = title;
            saveFileDialog1.Filter = "rtf文件(*.rtf)|*.rtf|所有文件(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;

                iTextExporter exporter = new iTextExporter(fileName);
                exporter.PDModel2Rtf(tableList,title);

                if (MsgBox.ShowQuestionMessage("数据库文档生成成功，是否打开文档", "提示信息") == DialogResult.Yes)
                {
                    CmdHelper.Execute(fileName);
                }
            }
        }

        private void menuItemBuildPdf_Click(object sender, EventArgs e)
        {
            IList<PDTable> tableList = new List<PDTable>();
            string title = string.Empty;
            TreeNode node = tv.SelectedNode;

            if (node.Tag is PDModel)
            {
                PDModel m = node.Tag as PDModel;
                tableList = m.AllTableList;
                title = m.Name;
            }
            if (node.Tag is PDPackage)
            {
                PDPackage p = node.Tag as PDPackage;
                tableList = p.TableList;
                title = p.Name;
            }

            saveFileDialog1.FileName = title;
            saveFileDialog1.Filter = "pdf文件(*.pdf)|*.pdf|所有文件(*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;

                iTextExporter exporter = new iTextExporter(fileName);
                exporter.PDModel2Pdf(tableList, title);

                if (MsgBox.ShowQuestionMessage("数据库文档生成成功，是否打开文档", "提示信息") == DialogResult.Yes)
                {
                    CmdHelper.Execute(fileName);
                }
            }
        }

        ////使用实体层模板批量生成代码
        //private void menuItemBatchBuildEnityCode_Click(object sender, EventArgs e)
        //{
        //    SODatabase db = null;
        //    TreeNode node = tv.SelectedNode;

        //    if (node.Tag is PDModel)
        //    {
        //        PDModel m = node.Tag as PDModel;
        //        db = SOConverter.ToSODatabase(m);
        //    }
        //    else
        //    {
        //        PDPackage p = node.Tag as PDPackage;
        //        db = SOConverter.ToSODatabase(p);
        //    }

        //    BatchBuildEntityCode dialog = new BatchBuildEntityCode(db);
        //    dialog.ShowDialog();
        //}

        ////使用数据层模板批量生成代码
        //private void menuItemBatchBuildDALCode_Click(object sender, EventArgs e)
        //{
        //    SODatabase db = null;
        //    TreeNode node = tv.SelectedNode;

        //    if (node.Tag is PDModel)
        //    {
        //        PDModel m = node.Tag as PDModel;
        //        db = SOConverter.ToSODatabase(m);
        //    }
        //    else
        //    {
        //        PDPackage p = node.Tag as PDPackage;
        //        db = SOConverter.ToSODatabase(p);
        //    }

        //    BatchBuildDALCode dialog = new BatchBuildDALCode(db);
        //    dialog.ShowDialog();
        //}

        //批量生成代码

        private void menuItemBatchBuildCode_Click(object sender, EventArgs e)
        {
            SODatabase db = null;
            TreeNode node = tv.SelectedNode;

            if (node.Tag is PDModel)
            {
                PDModel m = node.Tag as PDModel;
                db = SOConverter.ToSODatabase(m);
            }
            else
            {
                PDPackage p = node.Tag as PDPackage;
                db = SOConverter.ToSODatabase(p);
            }

            BatchBuildCode dialog = new BatchBuildCode(db);
            dialog.Show(this.DockPanel);
        }

        //使用自定义模板批量生成代码
        //private void menuItemBatchBuildCustomCode_Click(object sender, EventArgs e)
        //{
        //    SODatabase db = null;
        //    TreeNode node = tv.SelectedNode;

        //    if (node.Tag is PDModel)
        //    {
        //        PDModel m = node.Tag as PDModel;
        //        db = SOConverter.ToSODatabase(m);
        //    }
        //    else
        //    {
        //        PDPackage p = node.Tag as PDPackage;
        //        db = SOConverter.ToSODatabase(p);
        //    }

        //    BatchBuildCustomCode dialog = new BatchBuildCustomCode(db);
        //    dialog.ShowDialog();
        //}

        #endregion

        #region 表节点右键菜单事件处理

        //代码生成器
        private void menuItemBuildCodeForTable_Click(object sender, EventArgs e)
        {
            TreeNode tn = tv.SelectedNode;
            SOTable table = SOConverter.ToSOTable(tn.Tag as PDTable);
            CodeBuilder builder = null;

            //保证代码生成器使用一个实例
            if (this.DockPanel.ActiveDocument != null && this.DockPanel.ActiveDocument is CodeBuilder)
            {
                builder = this.DockPanel.ActiveDocument as CodeBuilder;
                builder.Table = table;
                builder.ColumnList = table.ColumnList;
                builder.LoadColumnList();
            }
            else
            {
                builder = new CodeBuilder();
                builder.Table = table;
                builder.ColumnList = table.ColumnList;
                builder.LoadColumnList();
                builder.Show(this.DockPanel);
            }
        }

        #endregion
    }
}
