using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalman.Studio
{
    public partial class NewFileForm : Form
    {
        public NewFileForm()
        {
            InitializeComponent();
            InitTreeView();
            InitListView();
        }

        #region 初始化tree
        private void InitTreeView()
        {
            TreeNode tnEnviroment = new TreeNode("模版", 0, 1);
            //TreeNode tnEditor = new TreeNode("模版", 2, 3);

            this.treeView1.Nodes.Add(tnEnviroment);
            //this.treeView1.Nodes.Add(tnEditor);

        }
        #endregion

        #region 初始化项

        private void InitListView()
        {
            this.listView1.Columns.Clear();
            this.listView1.Items.Clear();
            this.listView1.LargeImageList = imageList1;
            this.listView1.View = View.LargeIcon;

            ListViewGroup listViewGroup1 = new ListViewGroup("KalmanStudio 已安装的模版", HorizontalAlignment.Left);
            listViewGroup1.Header = "KalmanStudio 已安装的模版";
            listViewGroup1.Name = "listViewGroup1";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});

            string path = Path.Combine(Application.StartupPath, "Template");
            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                string strname = fileInfo.Extension;
                ListViewItem item1 = new ListViewItem(strname, 0);
                item1.SubItems.Add(strname);
                var imageIndex = imageList1.Images.IndexOfKey(strname.Remove(0, 1) + ".png");
                item1.ImageIndex = imageIndex < 0 ? 0 : imageIndex;
                item1.Group = listViewGroup1;
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
            lblTooltip.Text = string.Format("“{0}”文件",selstr);
        }
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count < 1)
            {
                return;
            }

            string selstr = this.listView1.SelectedItems[0].Text;
            Config.MainForm.NewDockDocument("Class", CodeType.CSHARP, Config.MainForm.GetCodeTemplateText(selstr));
            Close();
        }

    }
}
