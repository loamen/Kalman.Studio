using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using ICSharpCode.TextEditor.Document;
using System.IO;
using Kalman.Command;
using Kalman.Data.SchemaObject;

namespace Kalman.Studio
{
    public partial class QueryAnalyzer : DockableForm, IDockDocument
    {
        public QueryAnalyzer()
        {
            InitializeComponent();
        }

        public string FileName { get; set; }

        /// <summary>
        /// 当前数据库
        /// </summary>
        public SODatabase CurrentDatabase { get; set; }

        /// <summary>
        /// Sql查询文本
        /// </summary>
        public string SqlText { get; set; }

        private void QueryAnalyzer_Load(object sender, EventArgs e)
        {
            this.Text = FileName;

            IHighlightingStrategy strategy = HighlightingStrategyFactory.CreateHighlightingStrategy(CodeType.TSQL);
            textEditorControl1.Document.HighlightingStrategy = strategy;

            if (DbSchemaHelper.Instance.CurrentSchema == null || string.IsNullOrEmpty(SqlText)) return;
            
            textEditorControl1.Text = SqlText;
            ExecuteSql();
        }

        private void QueryAnalyzer_Activated(object sender, EventArgs e)
        {
            base.MainForm.SetCurrentDB(this.CurrentDatabase);
        }

        public void ExecuteSql()
        {
            try
            {
                SODatabase db = base.MainForm.GetCurrentDatabase();
                string cmdText = textEditorControl1.Text;

                if (this.CurrentDatabase != db) this.CurrentDatabase = db;

                DataSet ds = DbSchemaHelper.Instance.CurrentSchema.ExecuteQuery(CurrentDatabase, cmdText);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables[0].DefaultView;
                    richTextBox1.Text = string.Format("({0} 行受影响)", ds.Tables[0].Rows.Count);
                    tabControl1.SelectedTab = tabPage1;
                }
                else
                {
                    richTextBox1.Text = "已成功执行查询";
                    dataGridView1.DataSource = null;
                    tabControl1.SelectedTab = tabPage2;
                }
            }
            catch (Exception ex)
            {
                tabControl1.SelectedTab = tabPage2;
                richTextBox1.Text = ex.ToString();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.ToString() == "F5")
            {
                ExecuteSql();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void Save()
        {
            if (string.IsNullOrEmpty(textEditorControl1.FileName) == false)
            {
                textEditorControl1.SaveFile(textEditorControl1.FileName);
                this.Text = Path.GetFileName(textEditorControl1.FileName);
            }
            else
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "所有文件 (*.*)|*.*";
                dialog.FileName = this.Text.TrimEnd('*');
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textEditorControl1.SaveFile(dialog.FileName);
                    this.Text = Path.GetFileName(textEditorControl1.FileName);
                }
            }
        }

        public void SaveAs()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "所有文件 (*.*)|*.*";
            dialog.FileName = this.Text.TrimEnd('*');
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textEditorControl1.SaveFile(dialog.FileName);
                this.Text = Path.GetFileName(textEditorControl1.FileName);
            }
        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void menuItemSaveAs_Click(object sender, EventArgs e)
        {
            this.SaveAs();
        }

        private void menuItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItemCloseOther_Click(object sender, EventArgs e)
        {
            base.MainForm.CloseOtherDockDocument();
        }

        private void menuItemCloseAll_Click(object sender, EventArgs e)
        {
            base.MainForm.CloseAllDockDocument();
        }

        private void textEditorControl1_TextChanged(object sender, EventArgs e)
        {
            if (this.Text.EndsWith("*") == false) this.Text = this.Text + "*";
        }

        private void menuItemOpenFolder_Click(object sender, EventArgs e)
        {
            if (File.Exists(textEditorControl1.FileName))
            {
                CmdHelper.Execute(string.Format("explorer.exe {0}", Path.GetDirectoryName(textEditorControl1.FileName)));
            }
        }

        #region 处理编辑命令
        private void menuItemUndo_Click(object sender, EventArgs e) { Undo(); }
        private void menuItemRedo_Click(object sender, EventArgs e) { Redo(); }
        private void menuItemCut_Click(object sender, EventArgs e) { Cut(sender, e); }
        private void menuItemCopy_Click(object sender, EventArgs e) { Copy(sender, e); }
        private void menuItemPaste_Click(object sender, EventArgs e) { Paste(sender, e); }
        private void menuItemDelete_Click(object sender, EventArgs e) { Delete(sender, e); }
        private void menuItemSelectAll_Click(object sender, EventArgs e) { SelectAll(sender, e); }

        public void Undo() { textEditorControl1.Undo(); }
        public void Redo() { textEditorControl1.Redo(); }
        public void Cut(object sender, EventArgs e) { textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.Cut(sender, e); }
        public void Copy(object sender, EventArgs e) { textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.Copy(sender, e); }
        public void Paste(object sender, EventArgs e) { textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.Paste(sender, e); }
        public void Delete(object sender, EventArgs e) { textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.Delete(sender, e); }
        public void SelectAll(object sender, EventArgs e) { textEditorControl1.ActiveTextAreaControl.TextArea.ClipboardHandler.SelectAll(sender, e); }
        #endregion

    }
}
