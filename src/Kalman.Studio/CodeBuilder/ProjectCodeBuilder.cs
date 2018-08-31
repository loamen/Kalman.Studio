using Kalman.Command;
using Kalman.Data;
using Kalman.Data.SchemaObject;
using Kalman.Database;
using Kalman.Studio.T4TemplateEngineHost;
using Kalman.Utilities;
using Microsoft.VisualStudio.TextTemplating;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kalman.Extensions;

namespace Kalman.Studio
{
    public partial class ProjectCodeBuilder : Form
    {
        #region 变量
        DbConnDAL dal = new DbConnDAL();
        SODatabase currentDatabase;
        List<SOTable> tableList = new List<SOTable>();
        Dictionary<string, string> dicTemp = new Dictionary<string, string>();

        string projectName = string.Empty;
        string outputPath = string.Empty;
        string templatePath = string.Empty;

        string nameSpace = "Loamen";
        string tablePrefix = string.Empty;
        int prefixLevel = 1;
        string templateFile = string.Empty;
        int percent = 0;//生成进度
        int maxCount = 100;//最大数量
        #endregion

        #region 构造函数

        public ProjectCodeBuilder()
        {
            InitializeComponent();
        }

        public ProjectCodeBuilder(string projectName,string outputPath,string templatePath)
        {
            this.nameSpace = this.projectName = projectName;
            this.outputPath = outputPath;
            this.templatePath = templatePath;
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

            txtNameSpace.Text = this.nameSpace;
        }

        #endregion

        #region 数据初始化
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

        private void InitListView()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            foreach (SOTable t in tableList)
            {
                listBox1.Items.Add(t);
            }
        }
        #endregion

        #region 界面操作
        private void btnOK_Click(object sender, EventArgs e)
        {
            percent = 0;

            if(listBox2.Items.Count == 0)
            {
                MsgBox.Show("请选择待生成的表！");
                return;
            }

            var dicInfo = new DirectoryInfo(templatePath);
            var totalCount = IOUtil.GetFilesCount(dicInfo); //所有文件
            var templateCount = IOUtil.GetFilesCount(dicInfo, "*.tt");//模板文件
            if (totalCount == 0)
            {
                MsgBox.Show("该模板文件夹下没有任何文件！");
                return;
            }

            maxCount = totalCount - templateCount + templateCount * listBox2.Items.Count; //生成文件总数
            this.progressBarInfo.Maximum = maxCount;

            if (txtNameSpace.Text.Trim() != "") nameSpace = txtNameSpace.Text.Trim();

            if (cbDeleteTablePrifix.Checked && txtTablePrefix.Text.Trim().Length > 0) tablePrefix = txtTablePrefix.Text.Trim();
            prefixLevel = ConvertUtil.ToInt32(txtPrefixLevel.Text, 1);

            SetBtnDisable();
            backgroundWorkerGenerate.RunWorkerAsync();
        }

        private void BeegoProjectCodeBuilder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorkerGenerate.IsBusy)
            {
                DialogResult result = MsgBox.ShowQuestionMessage("正在生成代码，强制关闭可能会导致错误，是否关闭？");
                if (result == DialogResult.Yes)
                {
                    backgroundWorkerGenerate.CancelAsync();
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }
        #endregion


        private void OpenDirectory(string message = "代码生成成功，是否打开输出目录")
        {
            DialogResult result = MsgBox.ShowQuestionMessage(message, "提示");
            if (result == DialogResult.Yes)
            {
                if (Directory.Exists(outputPath))
                {
                    Process p = new Process();
                    p.StartInfo = new ProcessStartInfo(outputPath);
                    p.Start();
                    this.Close();
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

        #region BackWork
        private void backgroundWorkerGenerate_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = DoBuild();
        }

        private void backgroundWorkerGenerate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarInfo.Value = e.ProgressPercentage;
            var message = e.UserState as string;

            if (maxCount > 0 && e.ProgressPercentage == maxCount)
            {
                lblMsg.Text = "代码生成完成";
            }
            else
            {
                lblMsg.Text = string.Format("已完成：{0}%，正在处理：{1}", (((double)e.ProgressPercentage / maxCount) * 100).ToString("F0"), message);
            }
        }

        private void backgroundWorkerGenerate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetBtnEnable();
            if (e.Cancelled)
            {
                MsgBox.Show("操作中止！");
            }
            else
            {
                OpenDirectory(e.Result.ToString());
            }
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 生成操作
        /// </summary>
        /// <returns></returns>
        private string DoBuild()
        {
            backgroundWorkerGenerate.ReportProgress(percent, "开始生成！");
            var result = CopyDir(templatePath, outputPath);
            return result;
        }

        /// <summary>
        /// 生成
        /// </summary>
        private string Generate(string templateFile, string toDic)
        {
            string result = string.Empty;

            try
            {
                //遍历选中的表，一张表对应生成一个代码文件
                foreach (object item in listBox2.Items)
                {
                    SOTable table = item as SOTable;
                    string className = table.Name;
                    if (cbDeleteTablePrifix.Checked) className = table.Name.RemovePrefix(tablePrefix, prefixLevel).Replace(" ", "");
                    if (cbClassNamePascal.Checked) className = className.InitialToUpperMulti();
                    if (cbClassNameRemovePlural.Checked) className = className.EndsWith("s") ? className.TrimEnd('s') : className.Trim();
                    if (cbAddSuffix.Checked) className = txtClassPrefix.Text.Trim() + className + txtClassSuffix.Text.Trim();

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
                    var templateFileInfo = new FileInfo(templateFile);
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
                    var extName = templateFileInfo.Name.Replace(templateFileInfo.Extension, ""); //模板名称

                    var fileNameFormat = new StringBuilder("{0}");
                    string outputFile = string.Empty;

                    if (cbTemplateName.Checked || cbClassNameIsFileName.Checked)
                    {
                        if (cbClassNameIsFileName.Checked && cbTemplateName.Checked)
                        {
                            outputFile = Path.Combine(toDic, string.Format("{0}{1}{2}", className, extName, host.FileExtention)); //类名和模板名作为文件名
                        }
                        else
                        {
                            if (cbClassNameIsFileName.Checked)
                            {
                                outputFile = Path.Combine(toDic, string.Format("{0}{1}", className, host.FileExtention)); //类名作为文件名
                            }
                            else if (cbTemplateName.Checked)
                            {
                                outputFile = Path.Combine(toDic, string.Format("{0}{1}", extName, host.FileExtention)); //模板名作为文件名
                            }
                        }
                    }
                    else
                    {
                        outputFile = Path.Combine(toDic, string.Format("{0}{1}", table.Name, host.FileExtention)); //表名作为文件名
                    }
                    
                    
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

                    if (Directory.Exists(toDic) == false) Directory.CreateDirectory(toDic);
                    File.WriteAllText(outputFile, outputContent, Encoding.UTF8);
                    result = table.Name + "生成成功";
                    Config.Console(string.Format("根据模板文件“{0}”生成“{1}”成功！", templateFile, outputFile));
                    percent += 1;

                    backgroundWorkerGenerate.ReportProgress(percent, table.Name);
                }
            }
            catch (Exception ex)
            {
                Config.ConsoleException(ex);
                result = ex.Message;
                this.backgroundWorkerGenerate.CancelAsync(); //中止
            }

            return result;
        }

        public string CopyDir(string fromDir, string toDir)
        {
            string result = string.Empty;
            if (!Directory.Exists(fromDir))
            {
                result = string.Format("文件夹“{0}”不存在", fromDir);
                return result;
            }

            if (!Directory.Exists(toDir))
            {
                Directory.CreateDirectory(toDir);
            }

            string[] files = Directory.GetFiles(fromDir);
            foreach (string formFileName in files)
            {
                var fileInfo = new FileInfo(formFileName);
                if (!fileInfo.Exists) continue;

                if (fileInfo.Extension == ".tt")
                {
                    result =  Generate(fileInfo.FullName, toDir); //生成代码
                }
                else
                {
                    string fileName = Path.GetFileName(formFileName);
                    string toFileName = Path.Combine(toDir, fileName);
                    try
                    {
                        File.Copy(formFileName, toFileName, true); //复制到指定目录
                        Config.Console(string.Format("复制“{0}”到“{1}”成功！", formFileName, toFileName));
                    }catch(Exception ex)
                    {
                        Config.Console(string.Format("复制“{0}”到“{1}”失败：{2}", formFileName, toFileName, ex.ToString()));
                    }
                    percent += 1;
                    backgroundWorkerGenerate.ReportProgress(percent, fileName);
                }
            }

            string[] fromDirs = Directory.GetDirectories(fromDir);
            foreach (string fromDirName in fromDirs)
            {
                string dirName = Path.GetFileName(fromDirName);
                string toDirName = Path.Combine(toDir, dirName);
                CopyDir(fromDirName, toDirName);
            }

            result = "全部生成完成，是否立即查看？";

            return result;
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerGenerate.IsBusy)
            {
                backgroundWorkerGenerate.CancelAsync();
            }
            this.Close();
        }
    }
}