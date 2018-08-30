using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;

namespace Kalman.Studio
{
    public partial class TemplateExplorer : DockExplorer
    {
        Main main = null;
        public TemplateExplorer()
        {
            InitializeComponent();
        }

        private void TemplateExplorer_Load(object sender, EventArgs e)
        {
            main = this.ParentForm as Main;
            LoadTemplateTree();
        }

        private void LoadTemplateTree()
        {
            string templatePath = Path.Combine(Application.StartupPath, "T4Template");
            DirectoryInfo rootDir = new DirectoryInfo(templatePath);

            TreeNode root = new TreeNode("T4Templates", 0, 0);
            root.Tag = rootDir;
            root.ContextMenuStrip = cmsDir;
            tvTemplate.Nodes.Add(root);

            DirectoryInfo dirInfo = new DirectoryInfo(templatePath);
            ExpendTemplateDir(dirInfo, root);
        }

        //展开模板文件夹
        private void ExpendTemplateDir(DirectoryInfo rootDirInfo, TreeNode root)
        {
            if (root.Nodes.Count > 0) root.Nodes.Clear();
            DirectoryInfo[] dirs = rootDirInfo.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                TreeNode node = new TreeNode(dir.Name, 1, 1);
                node.Tag = dir;
                root.Nodes.Add(node);
                node.ContextMenuStrip = cmsDir;
            }

            FileInfo[] files = rootDirInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                TreeNode node = new TreeNode(file.Name, 2, 2);
                node.Tag = file;
                root.Nodes.Add(node);
                node.ContextMenuStrip = cmsFile;
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
                ExpendTemplateDir((DirectoryInfo)tn.Tag, tn);
            }
            if (tn.Tag is FileInfo)
            {
                FileInfo fi = tn.Tag as FileInfo;
                OpenTemplateFile(fi.FullName);
            }
        }

        void OpenTemplateFile(string fileName)
        {
            foreach (IDockContent content in this.DockPanel.Documents)
            {
                if (content is DockDocument)
                {
                    DockDocument doc = content as DockDocument;
                    if (doc.FileName == fileName)
                    {
                        doc.DockHandler.Activate();
                        return;
                    }
                }
            }

            main.OpenDockDocument(fileName, CodeType.CSHARP);
        }

        #region 右键菜单命令处理
        //新建模板文件
        private void menuItemNewTemplateFile_Click(object sender, EventArgs e)
        {
            TreeNode dirNode = tvTemplate.SelectedNode;
            DirectoryInfo dir = dirNode.Tag as DirectoryInfo;
            string fileName = "NewTemplate";

            int n = 1;
            while (true)
            {
                fileName = Path.Combine(dir.FullName,string.Format("NewTemplate{0}.tt", n));
                n = n + 1;
                if (File.Exists(fileName) == false) break;
            }

            File.WriteAllText(fileName, "<#@ template language=\"C#v3.5\" hostSpecific=\"true\" debug=\"true\" #>", Encoding.UTF8);
            FileInfo fi = new FileInfo(fileName);

            TreeNode fileNode = new TreeNode(Path.GetFileName(fileName), 2, 2);
            fileNode.Tag = fi;
            fileNode.ContextMenuStrip = cmsFile;
            dirNode.Nodes.Add(fileNode);

            tvTemplate.SelectedNode = fileNode;
            fileNode.BeginEdit();
        }
        //新建模板目录
        private void menuItemNewTemplateDir_Click(object sender, EventArgs e)
        {
            TreeNode dirNode = tvTemplate.SelectedNode;
            DirectoryInfo dir = dirNode.Tag as DirectoryInfo;
            string dirName = "NewFolder";

            int n = 1;
            while (true)
            {
                dirName = Path.Combine(dir.FullName, string.Format("NewFolder{0}", n));
                n = n + 1;
                if (Directory.Exists(dirName) == false) break;
            }

            Directory.CreateDirectory(dirName);
            DirectoryInfo newDir = new DirectoryInfo(dirName);

            TreeNode newDirNode = new TreeNode(newDir.Name, 1, 1);
            newDirNode.Tag = newDir;
            newDirNode.ContextMenuStrip = cmsDir;
            dirNode.Nodes.Add(newDirNode);

            tvTemplate.SelectedNode = newDirNode;
            newDirNode.BeginEdit();
        }
        //浏览模板目录
        private void menuItemBrowserDir_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = tvTemplate.SelectedNode.Tag as DirectoryInfo;
            Kalman.Command.CmdHelper.Execute(string.Format("explorer.exe {0}", di.FullName));
        }
        //删除模板目录
        private void menuItemDeleteDir_Click(object sender, EventArgs e)
        {
            if (MsgBox.ShowQuestionMessage("确定删除该模板目录吗，这将会删除该目录下所有模板文件", "提示信息") == DialogResult.Yes)
            {
                TreeNode dirNode = tvTemplate.SelectedNode;
                tvTemplate.Nodes.Remove(dirNode);
                DirectoryInfo di = dirNode.Tag as DirectoryInfo;
                string dirName = di.FullName;
                di.Delete(true);

                //删除模板目录时，同时关闭该目录下已打开的模板文档
                List<IDockContent> deletingDocs = new List<IDockContent>();
                foreach (IDockContent content in this.DockPanel.Documents)
                {
                    if (content is DockDocument)
                    {
                        DockDocument doc = content as DockDocument;
                        //判断模板文档所属目录是否是该删除目录，若是则将其关闭
                        if (Path.GetDirectoryName(doc.FileName) == dirName)
                        {
                            deletingDocs.Add(doc);
                        }
                    }
                }
                foreach (IDockContent content in deletingDocs)
                {
                    content.DockHandler.Close();
                }
            }
        }
        //重命名模板目录
        private void menuItemRenameDir_Click(object sender, EventArgs e)
        {
            tvTemplate.SelectedNode.BeginEdit();
        }
        //刷新模板目录
        private void menuItemRefresh_Click(object sender, EventArgs e)
        {
            ExpendTemplateDir((DirectoryInfo)tvTemplate.SelectedNode.Tag, tvTemplate.SelectedNode);
        }
        //打开编辑模板文件
        private void menuItemEditTemplate_Click(object sender, EventArgs e)
        {
            FileInfo fi = tvTemplate.SelectedNode.Tag as FileInfo;
            OpenTemplateFile(fi.FullName);
        }
        //删除模板文件
        private void menuItemDeleteTemplate_Click(object sender, EventArgs e)
        {
            if (MsgBox.ShowQuestionMessage("确定删除该模板文件吗", "提示信息") == DialogResult.Yes)
            {
                TreeNode fileNode = tvTemplate.SelectedNode;
                tvTemplate.Nodes.Remove(fileNode);

                FileInfo fi = fileNode.Tag as FileInfo;
                string oldFileName = fi.FullName;
                File.Delete(fi.FullName);

                //若删除的模板文档已经打开，则将其关闭
                IDockContent deletingDoc = null;
                foreach (IDockContent content in this.DockPanel.Documents)
                {
                    if (content is DockDocument)
                    {
                        DockDocument doc = content as DockDocument;
                        if (doc.FileName == oldFileName)
                        {
                            deletingDoc = doc;
                            break;
                        }
                    }
                }
                if (deletingDoc != null) deletingDoc.DockHandler.Close();
            }
        }
        //重命名模板文件
        private void menuItemRenameTemplate_Click(object sender, EventArgs e)
        {
            tvTemplate.SelectedNode.BeginEdit();
        }
        #endregion

        private void tvTemplate_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if(string.IsNullOrEmpty(e.Label))return;

            //节点重命名后，更新对应的Tag对象
            if (e.Label == e.Node.Text) return;//标签文本没有改变

            if (e.Node.Tag is DirectoryInfo)
            {
                DirectoryInfo di = e.Node.Tag as DirectoryInfo;
                string oldDirName = di.FullName;
                string newDirName = Path.Combine(di.Parent.FullName, e.Label);

                di.MoveTo(newDirName);
                e.Node.Tag = new DirectoryInfo(newDirName);

                //重命名模板目录后，需要更新该目录下已打开模板文档的FileName属性
                foreach (IDockContent content in this.DockPanel.Documents)
                {
                    if (content is DockDocument)
                    {
                        DockDocument doc = content as DockDocument;
                        //判断模板文档所属目录是否是该删除目录，若是则将其关闭
                        if (Path.GetDirectoryName(doc.FileName) == oldDirName)
                        {
                            doc.FileName = doc.FileName.Replace(oldDirName, newDirName);
                        }
                    }
                }
            }
            if (e.Node.Tag is FileInfo)
            {
                FileInfo fi = e.Node.Tag as FileInfo;
                string oldFileName = fi.FullName;
                string newFileName = Path.Combine(fi.DirectoryName, e.Label);
              
                fi.MoveTo(newFileName);
                e.Node.Tag = new FileInfo(newFileName);

                //如果被重命名的文件已经被打开，更新打开的文档实例
                foreach (IDockContent content in this.DockPanel.Documents)
                {
                    if (content is DockDocument)
                    {
                        DockDocument doc = content as DockDocument;
                        if (doc.FileName == oldFileName)
                        {
                            doc.Text = Path.GetFileName(newFileName);
                            doc.FileName = newFileName;
                            //doc.DockHandler.Activate();
                            break;
                        }
                    }
                }
            }
        }

        #region 处理拖放操作

        TreeNode srcNode = null;    //拖放起始节点
        private void tvTemplate_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode node = e.Item as TreeNode;
            string data = string.Empty;

            if (node.Tag is FileInfo)
            {
                FileInfo fi = node.Tag as FileInfo;
                data = fi.FullName;
            }
            else if (node.Tag is DirectoryInfo)
            {
                DirectoryInfo di = node.Tag as DirectoryInfo;
                data = di.FullName;
            }
            else
            {
                return;
            }

            srcNode = e.Item as TreeNode;
            DoDragDrop(data, DragDropEffects.Move);
        }

        private void tvTemplate_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void tvTemplate_DragDrop(object sender, DragEventArgs e)
        {
            //string path = (string)e.Data.GetData(DataFormats.Text); //拖放源节点的文件或目录路径

            Point p = new Point(e.X, e.Y);
            p = tvTemplate.PointToClient(p);//转换坐标
            TreeNode destNode = tvTemplate.GetNodeAt(p);
            if (destNode == null) return;
            if (destNode.Tag is FileInfo) return;   //如果目标节点是文件节点则不处理拖放动作

            if (destNode.Tag is DirectoryInfo)
            {
                DirectoryInfo destDir = destNode.Tag as DirectoryInfo;

                if (srcNode.Tag is FileInfo)
                {
                    FileInfo srcFile = srcNode.Tag as FileInfo;
                    string srcFileName = srcFile.FullName;
                    string destFileName = srcFile.FullName.Replace(Path.GetDirectoryName(srcFile.FullName), destDir.FullName);
                    if (srcFile.DirectoryName == destDir.FullName) return;

                    //如果被移动文件已经被打开，更新打开的文档实例
                    //foreach (IDockContent content in this.DockPanel.Documents)
                    //{
                    //    if (content is DockDocument)
                    //    {
                    //        DockDocument doc = content as DockDocument;
                    //        if (doc.FileName == srcFileName)
                    //        {
                    //            doc.FileName = destFileName;
                    //            break;
                    //        }
                    //    }
                    //}

                    srcFile.MoveTo(destFileName);
                    tvTemplate.Nodes.Remove(srcNode);
                    ExpendTemplateDir(destDir, destNode);
                }
                if (srcNode.Tag is DirectoryInfo)
                {
                    DirectoryInfo srcDir = srcNode.Tag as DirectoryInfo;
                    string srcDirName = srcDir.FullName;
                    string destDirName = srcDir.FullName.Replace(srcDir.Parent.FullName, destDir.FullName);
                    if (srcDir.FullName == destDir.FullName) return;

                    //移动模板目录后，需要更新该目录下已打开模板文档的FileName属性
                    //foreach (IDockContent content in this.DockPanel.Documents)
                    //{
                    //    if (content is DockDocument)
                    //    {
                    //        DockDocument doc = content as DockDocument;
                    //        //判断模板文档所属目录是否是该删除目录，若是则将其关闭
                    //        if (Path.GetDirectoryName(doc.FileName) == srcDirName)
                    //        {
                    //            doc.FileName = doc.FileName.Replace(srcDir.FullName, destDirName);
                    //        }
                    //    }
                    //}

                    srcDir.MoveTo(destDirName);
                    tvTemplate.Nodes.Remove(srcNode);
                    ExpendTemplateDir(destDir, destNode);
                }
            }
        }

        #endregion

    }
}
