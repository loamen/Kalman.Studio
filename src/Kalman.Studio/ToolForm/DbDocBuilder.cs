using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Kalman.Command;
using Kalman.Data;
using Kalman.Data.SchemaObject;
using Kalman.Database;

namespace Kalman.Studio
{
    public partial class DbDocBuilder : DockableForm
    {
        public DbDocBuilder()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 连接字符串名称
        /// </summary>
        public string CSName { get; set; }
        /// <summary>
        /// 数据库名称
        /// </summary>
        public SODatabase CurrentDatabase { get; set; }

        DbSchema currentSchema;

        private void DbDocBuilder_Load(object sender, EventArgs e)
        {
            var dal = new DbConnDAL();
            //dal.InitData();

            var list = dal.FindAll().ToList();

            foreach (var item in list)
            {
                if (item.IsActive)
                    cbConnectionStrings.Items.Add(item.Name);
            }

            if (string.IsNullOrEmpty(CSName) == false)
            {
                ChangeConnection(CSName);
            }
            if (CurrentDatabase != null)
            {
                ChangeDatabase(CurrentDatabase);
            }
        }
        //改变连接
        void ChangeConnection(string csName)
        {
            DbConnDAL dal = new DbConnDAL();

            var model = dal.FindOne(csName);

            currentSchema = DbSchemaFactory.Create(model.Name);

            List<SODatabase> dbList = currentSchema.GetDatabaseList();
            cbDatabase.Items.Clear();
            foreach (SODatabase db in dbList)
            {
                if (db.IsSystemDatabase) continue;
                cbDatabase.Items.Add(db);
            }

            //if (cbDatabase.Items.Count > 0)
            //{
            //    DbName = cbDatabase.Items[0].ToString();
            //    cbDatabase.SelectedIndex = 0;
            //}
            //else
            //{
            //    DbName = string.Empty;
            //}

            foreach (object item in cbConnectionStrings.Items)
            {
                if (item.ToString() == CSName)
                {
                    cbConnectionStrings.SelectedItem = item;
                    break;
                }
            }
        }
        //改变数据库
        void ChangeDatabase(SODatabase db)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            CurrentDatabase = db;
            List<SOTable> list = currentSchema.GetTableList(db);
            foreach (SOTable table in list)
            {
                listBox1.Items.Add(table);
            }

            foreach (object item in cbDatabase.Items)
            {
                if (item.ToString() == CurrentDatabase.Name)
                {
                    cbDatabase.SelectedItem = item;
                    break;
                }
            }
        }

        private void cbConnectionStrings_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeConnection(cbConnectionStrings.SelectedItem.ToString());
        }

        private void cbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeDatabase(cbDatabase.SelectedItem as SODatabase);
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
            if (listBox1.Items.Count > 0)
            {
                listBox2.Items.AddRange(listBox1.Items);
                listBox1.Items.Clear();
            }
        }

        private void SelectOne()
        {
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
            if (listBox2.Items.Count > 0)
            {
                listBox1.Items.AddRange(listBox2.Items);
                listBox2.Items.Clear();
            }
        }
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            List<SOTable> list = new List<SOTable>();
            foreach (object item in listBox2.Items)
            {
                list.Add(item as SOTable);
            }
            if (list.Count == 0) return;

            if (rbtnPdf.Checked)
            {
                saveFileDialog1.Filter = "pdf文件(*.pdf)|*.pdf|所有文件(*.*)|*.*";
                saveFileDialog1.FileName = CurrentDatabase.Name;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog1.FileName;

                    iTextExporter exporter = new iTextExporter(fileName);
                    exporter.DbSchema2Pdf(currentSchema, CurrentDatabase, list);

                    if (MsgBox.ShowQuestionMessage("数据库文档生成成功，是否打开文档", "提示信息") == DialogResult.Yes)
                    {
                        CmdHelper.Execute(fileName);
                    }
                }
            }

            if (rbtnWord.Checked)
            {
                saveFileDialog1.Filter = "rtf文件(*.rtf)|*.rtf|所有文件(*.*)|*.*";
                saveFileDialog1.FileName = CurrentDatabase.Name;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog1.FileName;

                    iTextExporter exporter = new iTextExporter(fileName);
                    exporter.DbSchema2Rtf(currentSchema, CurrentDatabase, list);

                    if (MsgBox.ShowQuestionMessage("数据库文档生成成功，是否打开文档", "提示信息") == DialogResult.Yes)
                    {
                        CmdHelper.Execute(fileName);
                    }
                }
            }

            if (rbtnHtml.Checked)
            {
                saveFileDialog1.Filter = "Html文件(*.html)|*.html|所有文件(*.*)|*.*";
                saveFileDialog1.FileName = CurrentDatabase.Name;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog1.FileName;

                    iTextExporter exporter = new iTextExporter(fileName);
                    exporter.DbSchema2Html(currentSchema, CurrentDatabase, list);

                    if (MsgBox.ShowQuestionMessage("数据库文档生成成功，是否打开文档", "提示信息") == DialogResult.Yes)
                    {
                        CmdHelper.Execute(fileName);
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
