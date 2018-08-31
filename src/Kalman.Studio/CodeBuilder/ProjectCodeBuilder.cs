using Kalman.Command;
using Kalman.Data;
using Kalman.Data.SchemaObject;
using Kalman.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Kalman.Studio
{
    public partial class ProjectCodeBuilder : Form
    {
        DbConnDAL dal = new DbConnDAL();
        SODatabase currentDatabase;
        List<SOTable> tableList = new List<SOTable>();

        string projectName = string.Empty;
        string codePath = string.Empty;

        public ProjectCodeBuilder()
        {
            InitializeComponent();
        }

        public ProjectCodeBuilder(string path,string projectName)
        {
            this.projectName = projectName;
            this.codePath = path;
            InitializeComponent();
        }

        private void BeegoProjectCodeBuilder_Load(object sender, EventArgs e)
        {
            RefreshDatabase();

            currentDatabase = Config.MainForm.toolItemDbList.SelectedItem as SODatabase;
            tableList = currentDatabase.TableList;

            cbConnectStringName.SelectedValue = currentDatabase.Parent.DbProvider.ConnectionString;
            cbConnectStringName.Enabled = false;

            DbSchema dbSchema = DbSchemaFactory.Create(((ComboBoxItem)cbConnectStringName.SelectedItem).Text);
            IList<SODatabase> dbList = dbSchema.GetDatabaseList();
            cmbDatabase.Items.Clear();
            cmbDatabase.DataSource = dbList;

            cmbDatabase.Text = currentDatabase.Name;

            InitListView();
        }

        private void RefreshDatabase()
        {
            cbConnectStringName.Items.Clear();

            var list = dal.FindAll().ToList();
            var itemList = new List<ComboBoxItem>();
            foreach (var item in list)
            {
                if (item.IsActive)
                {
                    var boxItem = new ComboBoxItem();
                    boxItem.Text = item.Name;
                    boxItem.Value = item.ConnectionString;
                    if (!itemList.Contains(boxItem))
                    {
                        itemList.Add(boxItem);
                    }
                }
            }

            cbConnectStringName.DataSource = itemList;
            cbConnectStringName.DisplayMember = "Text";
            cbConnectStringName.ValueMember = "Value";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SetBtnDisable();
            backgroundWorkerGenerate.RunWorkerAsync();
        }

        private string DoBuild()
        {
            var result = string.Empty;
            backgroundWorkerGenerate.ReportProgress(1, "开始生成！");
            

            return result;
        }

        private void OpenDirectory(string message = "代码生成成功，是否打开输出目录")
        {
            DialogResult result = MsgBox.ShowQuestionMessage(message, "提示");
            if (result == DialogResult.Yes)
            {
                if (Directory.Exists(codePath))
                {
                    Process p = new Process();
                    p.StartInfo = new ProcessStartInfo(codePath);
                    p.Start();
                }
            }
        }

        #region 控件设置      
        public void SetBtnEnable()
        {
            this.btnOK.Enabled = true;
            this.btnCancel.Enabled = true;
        }
        public void SetBtnDisable()
        {
            this.btnOK.Enabled = false;
            this.btnCancel.Enabled = false;
        }

        #endregion

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
            if (backgroundWorkerGenerate.IsBusy) return;
            if (listBox1.Items.Count > 0)
            {
                listBox2.Items.AddRange(listBox1.Items);
                listBox1.Items.Clear();
            }
        }

        private void SelectOne()
        {
            if (backgroundWorkerGenerate.IsBusy) return;
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
            if (backgroundWorkerGenerate.IsBusy) return;
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
            if (backgroundWorkerGenerate.IsBusy) return;
            if (listBox2.Items.Count > 0)
            {
                listBox1.Items.AddRange(listBox2.Items);
                listBox2.Items.Clear();
            }
        }
        #endregion

        private void backgroundWorkerGenerate_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = DoBuild();
        }

        private void backgroundWorkerGenerate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarInfo.Value = e.ProgressPercentage;
            var message = e.UserState as string;

            if (e.ProgressPercentage == 100)
            {
                lblMsg.Text = "代码生成完成";
            }
            else
            {
                lblMsg.Text = string.Format("已完成：{0}%，正在处理：{1}", e.ProgressPercentage, message);
            }
        }

        private void backgroundWorkerGenerate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetBtnEnable();
            OpenDirectory(e.Result.ToString());
        }

        private void InitListView()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            foreach (SOTable t in tableList)
            {
                listBox1.Items.Add(t);
            }
        }

        private void BeegoProjectCodeBuilder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorkerGenerate.IsBusy)
            {
                DialogResult result = MsgBox.ShowQuestionMessage("正在生成代码，强制关闭可能会导致错误，是否关闭？");
                if (result == DialogResult.Yes)
                {
                    var processes = Process.GetProcesses();
                    foreach (var pro in processes)
                    {
                        if (pro.ProcessName == "cmd" || pro.ProcessName == "cnnhost" || pro.ProcessName == "bee")
                        {
                            pro.Kill();
                        }
                    }
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }
    }
}