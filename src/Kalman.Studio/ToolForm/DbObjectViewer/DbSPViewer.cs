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
    public partial class DbSPViewer : Form
    {
        SOCommand currentSP;

        public DbSPViewer(SOCommand sp)
        {
            InitializeComponent();
            currentSP = sp;
        }

        private void DbSPViewer_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("查看存储过程信息[{0}->{1}]", currentSP.Database.Name, currentSP.Name);
            dgv.DataSource = DbSchemaHelper.Instance.CurrentSchema.GetCommandParameterList(currentSP);

            IHighlightingStrategy strategy = HighlightingStrategyFactory.CreateHighlightingStrategy(CodeType.TSQL);
            textEditorControl1.Document.HighlightingStrategy = strategy;
            textEditorControl1.Text = currentSP.SqlText;
        }
    }
}
