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
    public partial class CodeExplorer : DockExplorer
    {
        public CodeExplorer()
        {
            InitializeComponent();
        }

        private void CodeExplorer_Load(object sender, EventArgs e)
        {
            LoadCodeTree();
        }

        private void LoadCodeTree()
        {
            string codePath = Path.Combine(Application.StartupPath, "CodeLib");
            DirectoryInfo rootDir = new DirectoryInfo(codePath);

            TreeNode root = new TreeNode("代码库", 0, 0);
            root.Tag = rootDir;
            root.ContextMenuStrip = cmsDir;
            tvCode.Nodes.Add(root);

            DirectoryInfo dirInfo = new DirectoryInfo(codePath);
            ExpendCodeDir(dirInfo, root);
        }

        //展开文件夹
        private void ExpendCodeDir(DirectoryInfo rootDirInfo, TreeNode root)
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
                int iconIndex = GetFileIconIndex(file);
                TreeNode node = new TreeNode(file.Name, iconIndex, iconIndex);
                node.Tag = file;
                root.Nodes.Add(node);
                node.ContextMenuStrip = cmsFile;
            }

            root.Expand();
        }

        //获取文件对应的图标索引
        private int GetFileIconIndex(FileInfo fi)
        {
            FileShellInfo fsi = Win32Shell.GetFileInfo(fi.FullName);
            if (imgList.Images.ContainsKey(fsi.szTypeName) == false)
            {
                imgList.Images.Add(fsi.szTypeName, fsi.Icon);
            }
            int iconIndex = imgList.Images.IndexOfKey(fsi.szTypeName);
            return iconIndex;
        }

        private void tvCode_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeView tv = sender as TreeView;
                TreeNode tn = tv.GetNodeAt(e.X, e.Y);
                tv.SelectedNode = tn;
            }
        }

        private void tvCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeView tv = sender as TreeView;
            TreeNode tn = tv.GetNodeAt(e.X, e.Y);

            if (tn.Tag is DirectoryInfo)
            {
                ExpendCodeDir((DirectoryInfo)tn.Tag, tn);
            }
            if (tn.Tag is FileInfo)
            {
                FileInfo fi = tn.Tag as FileInfo;
                OpenCodeFile(fi.FullName);
            }
        }

        void OpenCodeFile(string fileName)
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

            base.MainForm.OpenDockDocument(fileName, CodeType.CSHARP);
        }

        #region 右键菜单命令处理
        //新建文件
        private void menuItemNewFile_Click(object sender, EventArgs e)
        {
            TreeNode dirNode = tvCode.SelectedNode;
            DirectoryInfo dir = dirNode.Tag as DirectoryInfo;
            string fileName = "NewFile";

            int n = 1;
            while (true)
            {
                fileName = Path.Combine(dir.FullName,string.Format("NewFile{0}.cs", n));
                n = n + 1;
                if (File.Exists(fileName) == false) break;
            }

            File.WriteAllText(fileName, "", Encoding.UTF8);
            FileInfo fi = new FileInfo(fileName);

            int iconIndex = GetFileIconIndex(fi);
            TreeNode fileNode = new TreeNode(Path.GetFileName(fileName), iconIndex, iconIndex);
            fileNode.Tag = fi;
            fileNode.ContextMenuStrip = cmsFile;
            dirNode.Nodes.Add(fileNode);

            tvCode.SelectedNode = fileNode;
            fileNode.BeginEdit();
        }
        //新建目录
        private void menuItemNewDir_Click(object sender, EventArgs e)
        {
            TreeNode dirNode = tvCode.SelectedNode;
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

            tvCode.SelectedNode = newDirNode;
            newDirNode.BeginEdit();
        }
        //浏览目录
        private void menuItemBrowserDir_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = tvCode.SelectedNode.Tag as DirectoryInfo;
            Kalman.Command.CmdHelper.Execute(string.Format("explorer.exe {0}", di.FullName));
        }
        //删除目录
        private void menuItemDeleteDir_Click(object sender, EventArgs e)
        {
            if (MsgBox.ShowQuestionMessage("确定删除该目录吗，这将会删除该目录下所有文件", "提示信息") == DialogResult.Yes)
            {
                TreeNode dirNode = tvCode.SelectedNode;
                tvCode.Nodes.Remove(dirNode);
                DirectoryInfo di = dirNode.Tag as DirectoryInfo;
                string dirName = di.FullName;
                di.Delete(true);

                //删除目录时，同时关闭该目录下已打开的文档
                List<IDockContent> deletingDocs = new List<IDockContent>();
                foreach (IDockContent content in this.DockPanel.Documents)
                {
                    if (content is DockDocument)
                    {
                        DockDocument doc = content as DockDocument;
                        //判断文档所属目录是否是该删除目录，若是则将其关闭
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
        //重命名目录
        private void menuItemRenameDir_Click(object sender, EventArgs e)
        {
            tvCode.SelectedNode.BeginEdit();
        }
        //刷新目录
        private void menuItemRefresh_Click(object sender, EventArgs e)
        {
            ExpendCodeDir((DirectoryInfo)tvCode.SelectedNode.Tag, tvCode.SelectedNode);
        }
        //打开编辑文件
        private void menuItemEditFile_Click(object sender, EventArgs e)
        {
            FileInfo fi = tvCode.SelectedNode.Tag as FileInfo;
            OpenCodeFile(fi.FullName);
        }
        //删除文件
        private void menuItemDeleteFile_Click(object sender, EventArgs e)
        {
            if (MsgBox.ShowQuestionMessage("确定删除该文件吗", "提示信息") == DialogResult.Yes)
            {
                TreeNode fileNode = tvCode.SelectedNode;
                tvCode.Nodes.Remove(fileNode);

                FileInfo fi = fileNode.Tag as FileInfo;
                string oldFileName = fi.FullName;
                File.Delete(fi.FullName);

                //若删除的文档已经打开，则将其关闭
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
        //重命名文件
        private void menuItemRenameFile_Click(object sender, EventArgs e)
        {
            tvCode.SelectedNode.BeginEdit();
        }
        #endregion

        private void tvCode_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
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

                //重命名目录后，需要更新该目录下已打开文档的FileName属性
                foreach (IDockContent content in this.DockPanel.Documents)
                {
                    if (content is DockDocument)
                    {
                        DockDocument doc = content as DockDocument;
                        //判断文档所属目录是否是该删除目录，若是则将其关闭
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
                e.Node.EndEdit(false);
                ExpendCodeDir(new DirectoryInfo(fi.DirectoryName), e.Node.Parent);

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
        private void tvCode_ItemDrag(object sender, ItemDragEventArgs e)
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

        private void tvCode_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void tvCode_DragDrop(object sender, DragEventArgs e)
        {
            //string path = (string)e.Data.GetData(DataFormats.Text); //拖放源节点的文件或目录路径

            Point p = new Point(e.X, e.Y);
            p = tvCode.PointToClient(p);//转换坐标
            TreeNode destNode = tvCode.GetNodeAt(p);
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

                    srcFile.MoveTo(destFileName);
                    tvCode.Nodes.Remove(srcNode);
                    ExpendCodeDir(destDir, destNode);
                }
                if (srcNode.Tag is DirectoryInfo)
                {
                    DirectoryInfo srcDir = srcNode.Tag as DirectoryInfo;
                    string srcDirName = srcDir.FullName;
                    string destDirName = srcDir.FullName.Replace(srcDir.Parent.FullName, destDir.FullName);
                    if (srcDir.FullName == destDir.FullName) return;

                    srcDir.MoveTo(destDirName);
                    tvCode.Nodes.Remove(srcNode);
                    ExpendCodeDir(destDir, destNode);
                }
            }
        }

        #endregion
    }
}
