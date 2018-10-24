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
    public partial class BeegoProjectCodeBuilder : Form
    {
        DbConnDAL dal = new DbConnDAL();
        SODatabase currentDatabase;
        List<SOTable> tableList = new List<SOTable>();

        string GOROOT = Environment.GetEnvironmentVariable("GOROOT") ?? string.Empty;
        string GOPATH = Environment.GetEnvironmentVariable("GOPATH") ?? string.Empty;
        string codePath = string.Empty;

        public BeegoProjectCodeBuilder()
        {
            InitializeComponent();
        }

        ~BeegoProjectCodeBuilder()
        {
            var proecesses = Process.GetProcesses();
            foreach (var process in proecesses)
            {
                if (process.ProcessName == "bee")
                {
                    process.Kill(); //杀死bee进程
                }
            }
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

            this.Height -= gbTableSelect.Height;
            this.Height += gbApiSetting.Height;
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
            if (!CheckGoEnvironment())
            {
                if (MsgBox.ShowQuestionMessage("检测到未安装GO环境！是否查看帮助？") == DialogResult.Yes)
                {
                    Help.ShowHelp(this,"https://jingyan.baidu.com/article/d2b1d102cbac775c7f37d477.html");
                }
                return;
            }

            if (!CheckBeeEnvironment())
            {
                if (MsgBox.ShowQuestionMessage("检测到未安装Bee工具！是否查看帮助？") == DialogResult.Yes)
                {

                    CmdHelper.CreateBat(Config.TEMP_BAT_FILENAME, "go get -u github.com/astaxie/beego \r\ngo get -u github.com/beego/bee");
                    //CmdHelper.RunApp(Config.TEMP_BAT_FILENAME, ProcessWindowStyle.Normal, GOPATH);
                    Config.MainForm.RunApp(Config.TEMP_BAT_FILENAME, GOPATH);
                    Help.ShowHelp(this, "https://beego.me/quickstart");
                };
                return;
            }

            if (string.IsNullOrEmpty(cmbDatabase.Text))
            {
                MsgBox.Show("请选择数据库！");
                return;
            }

            if (string.IsNullOrEmpty(txtProjectName.Text.Trim()))
            {
                MsgBox.Show("请输入项目名称！");
                return;
            }

            if (string.IsNullOrEmpty(GOROOT))
            {
                MsgBox.Show("请先在选项中设置GOROOT环境变量！");
                return;
            }

            if (string.IsNullOrEmpty(GOPATH))
            {
                MsgBox.Show("请先在选项中设置GOPATH环境变量！");
                return;
            }

            if (currentDatabase.Parent.DbProvider.DatabaseType != DatabaseType.MySql)
            {
                MsgBox.Show("该数据库不是MySql，不支持该操作！");
                this.Close();
                return;
            }

            if (rbWebProject.Checked)
            {
                if (listBox2.Items.Count == 0)
                {
                    MsgBox.Show("请选择要生成的表！");
                    return;
                }
            }

            codePath = GOPATH + (GOPATH.EndsWith(@"\") ? "src" : @"\src") + @"\" + txtProjectName.Text.Trim();
            if (Directory.Exists(codePath))
            {
                OpenDirectory(string.Format("文件夹“{0}”已经存在，是否立即打开？", codePath));
                this.Close();
                return;
            }

            SetBtnDisable();
            backgroundWorkerGenerate.RunWorkerAsync();
        }

        private string DoBuild()
        {
            backgroundWorkerGenerate.ReportProgress(1, "开始生成！");

            var cmdString = "bee {0} {1} -driver=\"mysql\" -conn=\"{2}:{3}@tcp({4}:{5})/{6}\"";

            if (currentDatabase.Parent.DbProvider.DatabaseType == DatabaseType.SQLite)
            {
                cmdString = "bee {0} {1} -driver=\"sqlite\" -conn=\"{2}\"";
            }

            string server = "127.0.0.1", port = "3306", user = "root", password = "", db = currentDatabase.Name;
            var connectionString = currentDatabase.Parent.DbProvider.ConnectionString;
            var conn = connectionString.Split(';');
            #region 获取服务器信息
            foreach (var item in conn)
            {
                if (currentDatabase.Parent.DbProvider.DatabaseType == DatabaseType.MySql)
                {
                    var val = item.Split('=');
                    if (val[0].ToLower().Trim() == "server")
                    {
                        server = val[1].Trim();
                    }
                    if (val[0].ToLower().Trim() == "port")
                    {
                        port = val[1].Trim();
                    }
                    if (val[0].ToLower().Trim() == "id")
                    {
                        user = val[1].Trim();
                    }
                    if (val[0].ToLower().Trim() == "password")
                    {
                        password = val[1].Trim();
                    }
                    //if (val[0].ToLower().Trim() == "database")
                    //{
                    //    db = val[1].Trim();
                    //}
                }
                else if (currentDatabase.Parent.DbProvider.DatabaseType == DatabaseType.SQLite)
                {
                    var val = item.Split('=');
                    if (val[0].ToLower().Trim() == "data source")
                    {
                        server = val[1].Trim();
                        break;
                    }
                }
            }
            #endregion

            var result = string.Empty;
            var path = GOPATH + (GOPATH.EndsWith(@"\") ? "src" : @"\src");

            if (rbWebProject.Checked)
            {
                List<string> temp = new List<string>();
                foreach (var item in this.listBox2.Items)
                {
                    temp.Add(item.ToString());
                }

                var cmd = string.Format(cmdString + " -level=3 -tables=\"{7}\"",
                    " generate appcode ",
                    string.Empty,
                    user,
                    password,
                    server,
                    port,
                    db,
                    string.Join(",", temp));

                var newCmd = "bee new " + txtProjectName.Text.Trim();
                result = CmdHelper.Execute(newCmd, path);

                if (result.Contains("success"))
                {
                    var msg = "正在生成剩余项";
                    Config.Console(msg + "，详细信息如下：\n" + result);

                    backgroundWorkerGenerate.ReportProgress(50, msg);
                    cmd = string.Format("cd /d \"{0}\" \r\n{1}", codePath, cmd);
                    CmdHelper.CreateBat(Config.TEMP_BAT_FILENAME, cmd);
                    //CmdHelper.RunApp(Config.TEMP_BAT_FILENAME, ProcessWindowStyle.Normal, codePath);
                    Config.MainForm.RunApp(Config.TEMP_BAT_FILENAME, codePath);

                    msg = "代码生成成功，是否打开目录？";
                    Config.Console(msg + "详细信息如下：\n" + result);
                    result = msg;
                }
                backgroundWorkerGenerate.ReportProgress(100, result);
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

                if (currentDatabase.Parent.DbProvider.DatabaseType == DatabaseType.SQLite)
                {
                    cmd = string.Format(cmdString,
                       "api",
                       txtProjectName.Text.Trim(),
                       server);
                }

                result = CmdHelper.Execute(cmd, path);

                var msg = "创建项目成功";
                if (result.Contains("success") && cbGenerateSwagger.Checked)
                {
                    msg = "正在生成Swagger";
                    Config.Console(msg + "，详细信息如下：\n" + result);

                    backgroundWorkerGenerate.ReportProgress(50, msg);
                    cmd = string.Format("cd /d \"{0}\" \r\n", codePath);
                    cmd += "bee run -gendoc=true -downdoc=true";

                    CmdHelper.CreateBat(Config.TEMP_BAT_FILENAME, cmd);
                    //CmdHelper.RunApp(Config.TEMP_BAT_FILENAME, ProcessWindowStyle.Normal, codePath);
                    Config.MainForm.RunApp(Config.TEMP_BAT_FILENAME, codePath);

                    msg = "代码生成成功，是否打开目录？";
                    Config.Console(msg + "详细信息如下：\n" + result);
                    result = msg;
                }
                else
                {
                    msg = "代码生成失败，是否打开目录？";
                    Config.Console(msg + "详细信息如下：\n" + result);
                    result = msg;
                }

                backgroundWorkerGenerate.ReportProgress(100, result);
            }

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
            this.DialogResult = result;
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

        private void rbWebProject_CheckedChanged(object sender, EventArgs e)
        {
            var check = ((RadioButton)sender).Checked;
            if (check)
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (SOTable t in tableList)
                {
                    listBox1.Items.Add(t);
                }
                this.Height += gbTableSelect.Height;
                this.Height -= gbApiSetting.Height;
                gbApiSetting.Visible = !check;
                gbTableSelect.Visible = check;
            }
        }

        private void rbApiProject_CheckedChanged(object sender, EventArgs e)
        {
            var check = ((RadioButton)sender).Checked;
            if (check)
            {
                gbApiSetting.Visible = check;
                gbTableSelect.Visible = !check;
                this.Height -= gbTableSelect.Height;
                this.Height += gbApiSetting.Height;
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

        /// <summary>
        /// 检查是否已安装beego环境
        /// </summary>
        /// <returns></returns>
        private bool CheckBeeEnvironment()
        {
            return File.Exists(GOPATH + (GOPATH.EndsWith(@"\") ? string.Empty : @"\") + @"bin\bee.exe");
        }

        /// <summary>
        /// 检测是否已安装GO环境
        /// </summary>
        /// <returns></returns>
        private bool CheckGoEnvironment()
        {
            return File.Exists(GOROOT + (GOROOT.EndsWith(@"\") ? string.Empty : @"\") + @"bin\go.exe");
        }
    }
}