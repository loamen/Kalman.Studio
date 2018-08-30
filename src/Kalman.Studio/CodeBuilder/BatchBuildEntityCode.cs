using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Microsoft.VisualStudio.TextTemplating;
using Kalman.Studio.T4TemplateEngineHost;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Diagnostics;
using System.CodeDom.Compiler;
using Kalman.Extensions;
using Kalman.Data.SchemaObject;
using Kalman.Utilities;

namespace Kalman.Studio
{
    public partial class BatchBuildEntityCode : Form
    {
        SODatabase currentDatabase;
        List<SOTable> tableList = new List<SOTable>();
        string templatePath = Path.Combine(Application.StartupPath, "T4Template\\Entity");

        public BatchBuildEntityCode(SODatabase db)
        {
            InitializeComponent();
            currentDatabase = db;
            tableList = db.TableList;
        }

        private void BatchBuildEntityCode_Load(object sender, EventArgs e)
        {
            gbTableSelect.Text = string.Format("当前数据库[{0}]", currentDatabase);

            foreach (SOTable t in tableList)
            {
                listBox1.Items.Add(t);
            }

            string[] ss = Directory.GetFiles(templatePath, "*.tt");
            foreach (string s in ss)
            {
                cbTemplate.Items.Add(Path.GetFileName(s));
            }
            if (ss.Length > 0) cbTemplate.SelectedIndex = 0;

            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            txtOutputPath.Text = Path.Combine(Application.StartupPath, "Output\\EntityCode");
        }

        //预览模板
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (cbTemplate.SelectedItem == null) return;
            string fileName = Path.Combine(templatePath, cbTemplate.SelectedItem.ToString());
            PreviewFile pf = new PreviewFile(fileName, CodeType.CSHARP);
            pf.ShowDialog();
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
                MsgBox.Show("正在生成代码，请不要关闭窗口");
            }
        }

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
        string nameSpace = "Entity";
        string tablePrefix = string.Empty;
        string columnPrefix = string.Empty;
        int prefixLevel = 1;
        string templateFile = string.Empty;
        string outputPath = string.Empty;

        private void btnBuildCode_Click(object sender, EventArgs e)
        {
            outputPath = txtOutputPath.Text;
            if(txtNameSpace.Text.Trim() != "") nameSpace = txtNameSpace.Text.Trim();

            if (listBox2.Items.Count == 0) return;
            if (cbTemplate.SelectedItem == null) return;
            templateFile = Path.Combine(templatePath, cbTemplate.SelectedItem.ToString());

            if (txtTablePrefix.Text.Trim().Length > 0) tablePrefix = txtTablePrefix.Text.Trim();
            if (txtColumnPrefix.Text.Trim().Length > 0) columnPrefix = txtColumnPrefix.Text.Trim();
            prefixLevel = ConvertUtil.ToInt32(txtPrefixLevel.Text, 1);

            btnBuildCode.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void DoBuild()
        {
            int finish = 0;
            int total = listBox2.Items.Count;

            //遍历选中的表，一张表对应生成一个代码文件
            foreach (object item in listBox2.Items)
            {
                SOTable table = item as SOTable;
                string className = table.Name.RemovePrefix(tablePrefix, prefixLevel).Replace(" ", "");

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
                host.SetValue("ColumnPrefix", columnPrefix);
                host.SetValue("PrefixLevel", prefixLevel);

                Engine engine = new Engine();

                string outputContent = engine.ProcessTemplate(File.ReadAllText(templateFile), host);
                //string outputFile = Path.Combine(outputPath,string.Format("{0}.cs", className));
                string outputFile = Path.Combine(outputPath, string.Format("{0}{1}", className, host.FileExtention));

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

                finish = finish + 1;
                int percent = ConvertUtil.ToInt32(finish * 100 / total, 0);

                backgroundWorker1.ReportProgress(percent, table);
            }//end build code foreach
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DoBuild();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            SOTable table = e.UserState as SOTable;

            if (e.ProgressPercentage == 100)
            {
                lblMsg.Text = "代码已全部生成";
            }
            else
            {
                lblMsg.Text = string.Format("已完成：{0}%，正在处理：{1}", e.ProgressPercentage, table.Name);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult result = MsgBox.ShowQuestionMessage("代码生成成功，是否打开输出目录", "代码生成消息提示");
            if (result == DialogResult.Yes)
            {
                string cmd = "explorer.exe " + outputPath;
                Kalman.Command.CmdHelper.Execute(cmd);
            }
            btnBuildCode.Enabled = true;
        }
        #endregion

    }
}
