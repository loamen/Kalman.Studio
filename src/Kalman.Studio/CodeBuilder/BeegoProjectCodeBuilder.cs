using Kalman.Command;
using Kalman.Data;
using Kalman.Data.SchemaObject;
using Kalman.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalman.Studio
{
    public partial class BeegoProjectCodeBuilder : Form
    {
        DbConnDAL dal = new DbConnDAL();
        SODatabase currentDatabase;

        string GOROOT = Environment.GetEnvironmentVariable("GOROOT");
        string GOPATH = Environment.GetEnvironmentVariable("GOPATH");
        string codePath = string.Empty;

        public BeegoProjectCodeBuilder()
        {
            InitializeComponent();
        }

        private void BeegoProjectCodeBuilder_Load(object sender, EventArgs e)
        {
            RefreshDatabase();

            currentDatabase = Config.MainForm.toolItemDbList.SelectedItem as SODatabase;
            cbConnectStringName.SelectedValue = currentDatabase.Parent.DbProvider.ConnectionString;
            cbConnectStringName.Enabled = false;

            DbSchema dbSchema = DbSchemaFactory.Create(((ComboBoxItem)cbConnectStringName.SelectedItem).Text);
            IList<SODatabase> dbList = dbSchema.GetDatabaseList();
            cmbDatabase.Items.Clear();
            cmbDatabase.DataSource = dbList;

            cmbDatabase.Text = currentDatabase.Name;
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
            if (string.IsNullOrEmpty(cmbDatabase.Text))
            {
                MessageBox.Show("请选择数据库！");
                return;
            }

            if (string.IsNullOrEmpty(txtProjectName.Text.Trim()))
            {
                MessageBox.Show("请输入项目名称！");
                return;
            }

            if (string.IsNullOrEmpty(GOROOT))
            {
                MessageBox.Show("请先在选项中设置GOROOT环境变量！");
                return;
            }

            if (string.IsNullOrEmpty(GOPATH))
            {
                MessageBox.Show("请先在选项中设置GOPATH环境变量！");
                return;
            }

            if (currentDatabase.Parent.DbProvider.DatabaseType != DatabaseType.MySql)
            {
                MessageBox.Show("该数据库不是MySql，不支持该操作！");
                this.Close();
                return;
            }

            codePath = GOPATH + (GOPATH.EndsWith(@"\") ? "src" : @"\src") + @"\" + txtProjectName.Text.Trim();
            if (Directory.Exists(codePath))
            {
                OpenDirectory(string.Format("文件夹“{0}”已经存在，是否立即打开？", codePath));
                return;
            }

            SetBtnDisable();
            backgroundWorkerGenerate.RunWorkerAsync();
        }

        private void DoBuild()
        {
            backgroundWorkerGenerate.ReportProgress(1, "开始生成！");

            var cmdString = "bee {0} {1} -driver=\"mysql\" -conn=\"{2}:{3}@tcp({4}:{5})/{6}\"";
            string server="127.0.0.1", port = "3306", user="root", password="", db="";
            var connectionString = currentDatabase.Parent.DbProvider.ConnectionString;
            var conn = connectionString.Split(';');
            foreach (var item in conn)
            {
                var val = item.Split('=');
                if (val[0].ToLower().Trim() == "server"){
                    server = val[1];
                }
                if (val[0].ToLower().Trim() == "port")
                {
                    port = val[1];
                }
                if (val[0].ToLower().Trim() == "id")
                {
                    user = val[1];
                }
                if (val[0].ToLower().Trim() == "password")
                {
                    password = val[1];
                }
                if (val[0].ToLower().Trim() == "database")
                {
                    db = val[1];
                }
            }

            var result = string.Empty;
            if (rbWebProject.Checked)
            {
                var cmd = string.Format(cmdString,
                    " generate appcode ",
                    txtProjectName.Text.Trim(),
                    user,
                    password,
                    server,
                    port,
                    db);
            }
            else if (rbApiProject.Checked)
            {
                var cmd = string.Format(cmdString,
                    "api",
                    txtProjectName.Text.Trim(),
                    user,
                    password,
                    server,
                    port,
                    db);


                var path = GOPATH + (GOPATH.EndsWith(@"\") ? "src" : @"\src");

                result = CmdHelper.Execute(cmd,path);
                backgroundWorkerGenerate.ReportProgress(100, result);
            }
        }

        private void OpenDirectory(string message = "代码生成成功，是否打开输出目录")
        {
            DialogResult result = MessageBox.Show(message, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                if (Directory.Exists(codePath))
                {
                    Process p = new Process();
                    p.StartInfo = new ProcessStartInfo(codePath);
                    p.Start();
                }
            }
            this.Close();
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

        private void backgroundWorkerGenerate_DoWork(object sender, DoWorkEventArgs e)
        {
            DoBuild();
        }

        private void backgroundWorkerGenerate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarInfo.Value = e.ProgressPercentage;
            var message = e.UserState as string;

            if (e.ProgressPercentage == 100)
            {
                lblMsg.Text = "代码已全部生成";
            }
            else
            {
                lblMsg.Text = string.Format("已完成：{0}%，正在处理：{1}", e.ProgressPercentage, message);
            }
        }

        private void backgroundWorkerGenerate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetBtnEnable();
            OpenDirectory();
        }
    }
}