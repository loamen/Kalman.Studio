using Kalman.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalman.Studio
{
    public partial class NewProjectForm : Form
    {
        /// <summary>
        /// 目录路径
        /// </summary>
        public string TemplatePath { get; set; }
        /// <summary>
        /// 输出目录
        /// </summary>
        public string OutputPath { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjctName { get; set; }

        public NewProjectForm()
        {
            InitializeComponent();
            InitTreeView();
            
        }

        #region 初始化项
        private void InitTreeView()
        {
            string path = Path.Combine(Application.StartupPath, "T4Template");
            var dics = Directory.GetDirectories(path);
            foreach (var dic in dics)
            {
                var dicInfo = new DirectoryInfo(dic);
                TreeNode node = new TreeNode(dicInfo.Name);
                node.Tag = dicInfo.FullName;
                node.ImageIndex = 0;
                treeView1.Nodes.Add(node);
            }
        }

        private void InitListView(string direcotry)
        {
            this.listView1.Columns.Clear();
            this.listView1.Items.Clear();
            this.listView1.LargeImageList = imageList1;
            this.listView1.View = View.LargeIcon;

            string path = Path.Combine(direcotry);
            var dics = Directory.GetDirectories(path);

            foreach (var dic in dics)
            {
                var dicInfo = new DirectoryInfo(dic);
               
                ListViewItem item1 = new ListViewItem(dicInfo.Name, 0);
                item1.SubItems.Add(dicInfo.Name);
                item1.ImageIndex = 1;
                item1.Group = listViewGroup1;
                item1.Tag = dicInfo.FullName;
                listView1.Items.AddRange(new ListViewItem[] { item1 });
            }
        }
        #endregion

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count < 1)
            {
                return;
            }
            string selstr = this.listView1.SelectedItems[0].Text;
            lblTooltip.Text = string.Format("“{0}”目录下所有模板",selstr);
        }
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count < 1)
            {
                MsgBox.Show("请选择模板目录！");
                return;
            }

            if (string.IsNullOrEmpty(txtProName.Text.Trim()))
            {
                MsgBox.Show("请填写项目名称！");
                return;
            }

            if (string.IsNullOrEmpty(txtProPath.Text.Trim()))
            {
                MsgBox.Show("请选择项目输出目录！");
                return;
            }

            TemplatePath = this.listView1.SelectedItems[0].Tag.ToString();
            OutputPath = txtProPath.Text.Trim();
            ProjctName = txtProName.Text.Trim();

            var outputCount = IOUtil.GetFilesCount(new DirectoryInfo(OutputPath));

            if (outputCount > 0)
            {
                if (MsgBox.ShowQuestionMessage("输出目录不为空，是否立即查看？") == DialogResult.Yes)
                {
                    DialogResult = DialogResult.Cancel;
                    Process p = new Process();
                    p.StartInfo = new ProcessStartInfo(OutputPath);
                    p.Start();
                    Close();
                }
                return;
            }

           
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            InitListView(node.Tag.ToString());
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            DialogResult result = folder.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                this.txtProPath.Text = folder.SelectedPath;
            }
        }

        private void linkLabelDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Help.ShowHelp(this, "https://github.com/loamen/Kalman.Studio/tree/master/Documents/Templates");
        }
    }
}
