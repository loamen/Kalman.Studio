using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using Kalman.Data.SchemaObject;

namespace Kalman.Studio
{
    public partial class DbViewViewer : Form
    {
        SOView currentView;

        public DbViewViewer(SOView view)
        {
            InitializeComponent();
            currentView = view;
        }

        private void DbViewViewer_Load(object sender, EventArgs e)
        {
            dgv.AutoGenerateColumns = false;
            this.Text = string.Format("查看视图信息[{0}->{1}]", currentView.Database.Name, currentView.Name);
            dgv.DataSource = DbSchemaHelper.Instance.CurrentSchema.GetViewColumnList(currentView);

            IHighlightingStrategy strategy = HighlightingStrategyFactory.CreateHighlightingStrategy(CodeType.TSQL);
            textEditorControl1.Document.HighlightingStrategy = strategy;
            textEditorControl1.Text = currentView.SqlText;
        }
    }
}
