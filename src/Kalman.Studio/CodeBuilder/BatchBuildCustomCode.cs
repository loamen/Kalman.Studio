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
using System.Net.Mail;
using System.Net;
using System.Diagnostics;
using System.CodeDom.Compiler;
using Kalman.Extensions;
using Kalman.Data.SchemaObject;
using Kalman.Utilities;
using Kalman.Studio.T4TemplateEngineHost;
using Microsoft.VisualStudio.TextTemplating;

namespace Kalman.Studio
{
    public partial class BatchBuildCustomCode : Form
    {
        SODatabase currentDatabase;
        string templatePath = Path.Combine(Application.StartupPath, "T4Template");

        public BatchBuildCustomCode(SODatabase db)
        {
            InitializeComponent();
            currentDatabase = db;
        }

        private void BatchBuildCustomCode_Load(object sender, EventArgs e)
        {
            cbSchema.SelectedIndex = 0;
            List<SOTable> tableList = DbSchemaHelper.Instance.CurrentSchema.GetTableList(currentDatabase);
            gbTableSelect.Text = string.Format("当前数据库[{0}]", currentDatabase);

            foreach (SOTable t in tableList)
            {
                listBox1.Items.Add(t);
            }

            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            openFileDialog1.InitialDirectory = templatePath;
            txtOutputPath.Text = Path.Combine(Application.StartupPath, "Output\\CustomCode");
        }

        //选择模板文件
        private void btnSelectTemplate_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtTemplateFile.Text = openFileDialog1.FileName;
            }
        }

        //预览模板
        private void btnPreview_Click(object sender, EventArgs e)
        {
            string fileName = txtTemplateFile.Text;

            if (File.Exists(fileName))
            {
                PreviewFile pf = new PreviewFile(fileName, CodeType.CSHARP);
                pf.ShowDialog();
            }
            else
            {
                MessageBox.Show(string.Format("文件[{0}]不存在",fileName));
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtOutputPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        //处理窗体关闭事件
        protected override void OnClosing(CancelEventArgs e)
        {
            if (backgroundWorker1.IsBusy == false)
            {
                base.OnClosing(e);
            }
            else
            {
                e.Cancel = true;
                MessageBox.Show("正在生成代码，请不要关闭窗口");
            }
        }

        private void btnAddProperty_Click(object sender, EventArgs e)
        {
            string name = txtPName.Text.Trim();
            string value = txtPValue.Text.Trim().Replace("|", "[<->]");

            if (name == "" || value == "") return;

            string item = string.Format("{0}|{1}", name, value);
            if (listBox3.Items.Contains(item)) return;
            listBox3.Items.Add(item);
            txtPName.Text = string.Empty;
            txtPValue.Text = string.Empty;
        }

        private void btnRemoveProperty_Click(object sender, EventArgs e)
        {
            listBox3.Items.Remove(listBox3.SelectedItem);
        }

        private void listBox3_DoubleClick(object sender, EventArgs e)
        {
            if(listBox3.SelectedItem == null)return;

            string[] ss = listBox3.SelectedItem.ToString().Split('|');
            txtPName.Text = ss[0];
            txtPValue.Text = ss[1].Replace("[<->]", "|");
            listBox3.Items.Remove(listBox3.SelectedItem);
        }

        #region 列表选择相关
        private void cbSchema_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            if (cbSchema.SelectedIndex == 0)
            {
                List<SOTable> list = DbSchemaHelper.Instance.CurrentSchema.GetTableList(currentDatabase);
                foreach (SOTable t in list)
                {
                    listBox1.Items.Add(t);
                }
            }
            if (cbSchema.SelectedIndex == 1)
            {
                List<SOView> list = DbSchemaHelper.Instance.CurrentSchema.GetViewList(currentDatabase);
                foreach (SOView v in list)
                {
                    listBox1.Items.Add(v);
                }
            }
            if (cbSchema.SelectedIndex == 2)
            {
                List<SOCommand> list = DbSchemaHelper.Instance.CurrentSchema.GetCommandList(currentDatabase);
                foreach (SOCommand sp in list)
                {
                    listBox1.Items.Add(sp);
                }
            }
        }

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
            if (backgroundWorker1.IsBusy) return;
            if (listBox1.Items.Count > 0)
            {
                listBox2.Items.AddRange(listBox1.Items);
                listBox1.Items.Clear();
            }
        }

        private void SelectOne()
        {
            if (backgroundWorker1.IsBusy) return;
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
            if (backgroundWorker1.IsBusy) return;
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
            if (backgroundWorker1.IsBusy) return;
            if (listBox2.Items.Count > 0)
            {
                listBox1.Items.AddRange(listBox2.Items);
                listBox2.Items.Clear();
            }
        }
        #endregion

        #region 代码生成相关
        string templateFile = string.Empty;
        string outputPath = string.Empty;

        private void btnBuildCode_Click(object sender, EventArgs e)
        {
            outputPath = txtOutputPath.Text;

            if (listBox2.Items.Count == 0) return;

            templateFile = txtTemplateFile.Text;
            if (File.Exists(templateFile) == false)
            {
                MessageBox.Show("所选的模板文件不存在");
                return;
            }

            btnBuildCode.Enabled = false;
            cbSchema.Enabled = false;
            backgroundWorker1.RunWorkerAsync(cbSchema.SelectedIndex);
        }

        private void DoBuild(int selectedIndex)
        {
            int finish = 0;
            int total = listBox2.Items.Count;

            //遍历选中的表，一张表对应生成一个代码文件
            foreach (object item in listBox2.Items)
            {
                switch (selectedIndex)
                {
                    case 0:
                        BuildCodeByTableSchema(item);
                        break;
                    case 1:
                        BuildCodeByViewSchema(item);
                        break;
                    case 2:
                        BuildCodeBySPSchema(item);
                        break;
                    default:
                        break;
                }

                finish = finish + 1;
                int percent = ConvertUtil.ToInt32(finish * 100 / total, 0);

                backgroundWorker1.ReportProgress(percent, item);
            }//end build code foreach
        }

        private void BuildCodeByTableSchema(object item)
        {
            SOTable table = item as SOTable;
            List<SOColumn> columnList = table.ColumnList;//可能传入的是从PDObject对象转换过来的SODatabase对象
            if (columnList == null || columnList.Count == 0) columnList = DbSchemaHelper.Instance.CurrentSchema.GetTableColumnList(table);

            //生成代码文件
            TableHost host = new TableHost();
            host.Table = table;
            host.ColumnList = columnList;
            host.TemplateFile = templateFile;

            foreach (object obj in listBox3.Items)
            {
                string[] ss = obj.ToString().Split('|');

                host.SetValue(ss[0], ss[1].Replace("[<->]", "|"));
            }

            Engine engine = new Engine();

            string fileName = string.Empty;
            string separator = txtFileNamePrefix.Text.Trim();
            if (separator != "")
            {
                fileName = string.Format("{0}{1}", table.Name.RemovePrefix(separator,10), host.FileExtention);
            }
            else
            {
                fileName = string.Format("{0}{1}", table.Name, host.FileExtention);
            }

            string outputContent = engine.ProcessTemplate(File.ReadAllText(templateFile), host);
            string outputFile = Path.Combine(outputPath, fileName);

            StringBuilder sb = new StringBuilder();
            if (host.ErrorCollection.HasErrors)
            {
                foreach (CompilerError err in host.ErrorCollection)
                {
                    sb.AppendLine(err.ToString());
                }
                outputContent = outputContent + Environment.NewLine + sb.ToString();
                outputFile = outputFile + ".error";
            }

            if (Directory.Exists(outputPath) == false) Directory.CreateDirectory(outputPath);
            File.WriteAllText(outputFile, outputContent, Encoding.UTF8);
        }

        private void BuildCodeByViewSchema(object item)
        {
            SOView view = item as SOView;
            List<SOColumn> columnList = DbSchemaHelper.Instance.CurrentSchema.GetViewColumnList(view);

            //生成代码文件
            ViewHost host = new ViewHost();
            host.View = view;
            host.ColumnList = columnList;
            host.TemplateFile = templateFile;

            foreach (object obj in listBox3.Items)
            {
                string[] ss = obj.ToString().Split('|');

                host.SetValue(ss[0], ss[1].Replace("[<->]", "|"));
            }

            Engine engine = new Engine();

            string fileName = string.Empty;
            string separator = txtFileNamePrefix.Text.Trim();
            if (separator != "")
            {
                fileName = string.Format("{0}{1}", view.Name.RemovePrefix(separator, 10), host.FileExtention);
            }
            else
            {
                fileName = string.Format("{0}{1}", view.Name, host.FileExtention);
            }

            string outputContent = engine.ProcessTemplate(File.ReadAllText(templateFile), host);
            string outputFile = Path.Combine(outputPath, fileName);

            StringBuilder sb = new StringBuilder();
            if (host.ErrorCollection.HasErrors)
            {
                foreach (CompilerError err in host.ErrorCollection)
                {
                    sb.AppendLine(err.ToString());
                }
                outputContent = outputContent + Environment.NewLine + sb.ToString();
                outputFile = outputFile + ".error";
            }

            if (Directory.Exists(outputPath) == false) Directory.CreateDirectory(outputPath);
            File.WriteAllText(outputFile, outputContent, Encoding.UTF8);
        }

        private void BuildCodeBySPSchema(object item)
        {
            SOCommand sp = item as SOCommand;
            //List<SOCommandParameter> paramList = DbSchemaHelper.Instance.CurrentSchema.GetCommandParameterList(sp);

            //生成代码文件
            CommandHost host = new CommandHost();
            host.SP = sp;
            //host.ParamList = paramList;
            host.TemplateFile = templateFile;

            foreach (object obj in listBox3.Items)
            {
                string[] ss = obj.ToString().Split('|');

                host.SetValue(ss[0], ss[1].Replace("[<->]", "|"));
            }

            Engine engine = new Engine();

            string fileName = string.Empty;
            string separator = txtFileNamePrefix.Text.Trim();
            if (separator != "")
            {
                fileName = string.Format("{0}{1}", sp.Name.RemovePrefix(separator, 10), host.FileExtention);
            }
            else
            {
                fileName = string.Format("{0}{1}", sp.Name, host.FileExtention);
            }

            string outputContent = engine.ProcessTemplate(File.ReadAllText(templateFile), host);
            string outputFile = Path.Combine(outputPath, fileName);

            StringBuilder sb = new StringBuilder();
            if (host.ErrorCollection.HasErrors)
            {
                foreach (CompilerError err in host.ErrorCollection)
                {
                    sb.AppendLine(err.ToString());
                }
                outputContent = outputContent + Environment.NewLine + sb.ToString();
                outputFile = outputFile + ".error";
            }

            if (Directory.Exists(outputPath) == false) Directory.CreateDirectory(outputPath);
            File.WriteAllText(outputFile, outputContent, Encoding.UTF8);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int selectedIndex = ConvertUtil.ToInt32(e.Argument,0);
            DoBuild(selectedIndex);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;

            if (e.ProgressPercentage == 100)
            {
                lblMsg.Text = "代码已全部生成";
            }
            else
            {
                //SOTable dbTable = e.UserState as SOTable;
                lblMsg.Text = string.Format("已完成：{0}%，正在处理：{1}", e.ProgressPercentage, e.UserState.ToString());
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult result = MessageBox.Show("代码生成成功，是否打开输出目录", "代码生成消息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                string cmd = "explorer.exe " + outputPath;
                Kalman.Command.CmdHelper.Execute(cmd);
            }
            btnBuildCode.Enabled = true;
            cbSchema.Enabled = true;
        }
        #endregion

        

        
        

    }
}
