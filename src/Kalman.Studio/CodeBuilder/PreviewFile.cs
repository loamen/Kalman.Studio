using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ICSharpCode.TextEditor.Document;

namespace Kalman.Studio
{
    public partial class PreviewFile : Form
    {
        string _FileName = string.Empty;
        string _CodeType = CodeType.CSHARP;

        public PreviewFile(string fileName, string codeType)
        {
            InitializeComponent();

            _FileName = fileName;
            _CodeType = codeType;
        }

        private void PreviewTemplate_Load(object sender, EventArgs e)
        {
            if (File.Exists(_FileName))
            {
                IHighlightingStrategy strategy = HighlightingStrategyFactory.CreateHighlightingStrategy(_CodeType);
                textEditorControl1.Document.HighlightingStrategy = strategy;
                textEditorControl1.Text = File.ReadAllText(_FileName);
            }
            this.Text = string.Concat("预览文件 - ", _FileName);
            textEditorControl1.TextChanged += new EventHandler(textEditorControl1_TextChanged);
        }

        private void Save()
        {
            File.WriteAllText(_FileName, textEditorControl1.Text, Encoding.UTF8);
            this.Text = this.Text.TrimEnd('*');
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.Text.EndsWith("*"))
            {
                if (MsgBox.ShowQuestionMessage("文件内容已改变，是否保存文件", "信息提示") == DialogResult.Yes)
                {
                    Save();
                }
            }

            base.OnClosing(e);
        }

        void textEditorControl1_TextChanged(object sender, EventArgs e)
        {
            if(this.Text.EndsWith("*")) return;
            this.Text = this.Text + "*";
        }

        private void menuItemUndo_Click(object sender, EventArgs e)
        {
            textEditorControl1.Undo();
        }

        private void menuItemRedo_Click(object sender, EventArgs e)
        {
            textEditorControl1.Redo();
        }

        private void menuItemReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }
    }
}
