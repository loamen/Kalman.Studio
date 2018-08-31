using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;
using System.Windows.Forms;
using System.IO;

namespace Kalman.Studio
{
    public partial class Main
    {
        public DockPanel MainDockPanel
        {
            get { return this.dockPanel; }
        }

        public IDockContent FindDockDocument(string text)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    if (form.Text.TrimEnd('*') == text) 
                        return form as IDockContent;

                return null;
            }
            else
            {
                foreach (IDockContent content in dockPanel.Documents)
                    if (content.DockHandler.TabText.TrimEnd('*') == text) 
                        return content;

                return null;
            }
        }

        /// <summary>
        /// 新建文档
        /// </summary>
        /// <param name="caption">文档所在窗体的标题，如“Class1.cs”</param>
        /// <param name="codeType">代码类型</param>
        /// <param name="content">文档文本内容</param>
        public void NewDockDocument(string caption, string codeType, string content,string extention = null)
        {
            DockDocument doc = new DockDocument();

            int count = 1;
            string ext = CodeTypeHelper.GetExtention(codeType);

            if (!string.IsNullOrEmpty(extention))
            {
                ext = extention;
            }

            string text = string.Format("{0}{1}{2}", caption, count.ToString(), ext);
            while (FindDockDocument(text) != null)
            {
                count++;
                if (count > 1)
                {
                    text = string.Format("{0}{1}{2}", caption, count.ToString(), ext);
                }
                else
                {
                    text = string.Format("{0}{1}", caption, ext);
                }
            }
            doc.Text = text;
            doc.LoadTextContent(content, codeType);

            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                doc.MdiParent = this;
                doc.Show();
            }
            else
                doc.Show(dockPanel);
        }

        public void OpenDockDocument(string fileName, string codeType)
        {
            //打开文件判断文件大小，不打开过大的文件
            FileInfo fi = new FileInfo(fileName);
            if (fi.Length > 2 * 1024 * 1024)
            {
                MsgBox.Show("大于2M的文件请用其他编辑器打开");
                return;
            }

            if (FindDockDocument(fileName) != null)
            {
                MsgBox.Show(string.Format("文件[{0}]已经打开", fileName));
                return;
            }

            DockDocument doc = new DockDocument();
            doc.LoadFileContent(fileName);
            doc.SetDocumentCodeType(codeType);

            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                doc.MdiParent = this;
                doc.Show();
            }
            else
                doc.Show(dockPanel);
        }

        public void OpenNewProjectDialog(string projectName, string outputPath, string templatePath)
        {
            ProjectCodeBuilder projectCodeBuilder = new ProjectCodeBuilder(projectName, outputPath, templatePath);
            projectCodeBuilder.Show();
        }

        public void OpenNewProjectForm()
        {
            if (string.IsNullOrEmpty(toolItemDbList.Text.Trim()))
            {
                MsgBox.Show("请先选择数据库！");
                return;
            }

            NewProjectForm form = new NewProjectForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                OpenNewProjectDialog(form.ProjctName, form.OutputPath, form.TemplatePath);
            }
        }

        //打开文档
        void OpenDockDocument()
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.InitialDirectory = Application.ExecutablePath;
            openFile.Filter = "所有文件 (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFile.FileName;
                OpenDockDocument(fileName, CodeTypeHelper.GetCodeType(Path.GetExtension(fileName)));
            }
        }

        //除此之外全部关闭
        public void CloseOtherDockDocument()
        {
            foreach (IDockContent content in dockPanel.DocumentsToArray())
            {
                if (content is DockExplorer) continue;
                if (!content.DockHandler.IsActivated)
                {
                    if (content is StartForm) continue;
                    //if (content is DockToolWindow) content.DockHandler.Hide();
                    //else content.DockHandler.Close();

                    content.DockHandler.Close(); 
                }
            }
        }

        //全部关闭
        public void CloseAllDockDocument()
        {
            for (int i = dockPanel.Contents.Count - 1; i >= 0; i--)
            {
                if (dockPanel.Contents[i] is IDockContent)
                {
                    IDockContent content = (IDockContent)dockPanel.Contents[i];
                    if (content is DockExplorer || content is StartForm) continue;

                    //if (content is DockToolWindow) content.DockHandler.Hide();
                    //else content.DockHandler.Close();
                    content.DockHandler.Close();
                }
            }
        }
    }
}
