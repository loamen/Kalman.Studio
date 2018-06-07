using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using Kalman.Data.SchemaObject;

namespace Kalman.Studio
{
    public partial class Main : Form
    {
        DatabaseExplorer dbExplorer = new DatabaseExplorer();
        Output output = new Output();
        //DbSchemaViewer viewer = new DbSchemaViewer();
        CodeExplorer codeExplorer = new CodeExplorer();
        TemplateExplorer templateExplorer = new TemplateExplorer();
        PdmExplorer pdmExplorer = new PdmExplorer();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            output.Show(dockPanel);
            dbExplorer.Show(dockPanel);
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = ((Exception)e.ExceptionObject);
            Log(ex);
            MessageBox.Show(ex.Message);
        }

        void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Log(e.Exception);
            MessageBox.Show(e.Exception.Message);
        }

        void Log(Exception ex)
        {
            if (output == null) output = new Output();

            output.ClearText();
            output.AppendText(ex.ToString());
            output.DockState = DockState.DockBottom;
            output.Activate();

            string logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
            File.AppendAllText(logFile, string.Format("{0}\r\n{1}\r\n", ex.Message, ex.StackTrace));
        }

        #region 文件菜单项事件处理

        //当文件菜单打开的时候，初始化子菜单项状态
        private void menuItemFile_DropDownOpening(object sender, EventArgs e)
        {
            //没有激活的文档窗体时，禁用关闭菜单项
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                menuItemClose.Enabled =
                menuItemCloseOther.Enabled =
                menuItemCloseAll.Enabled = 
                menuItemSave.Enabled =
                menuItemSaveAs.Enabled = (ActiveMdiChild != null);
            }
            else
            {
                menuItemClose.Enabled = (dockPanel.ActiveDocument != null);
                menuItemCloseOther.Enabled = (dockPanel.ActiveDocument != null);
                menuItemCloseAll.Enabled = 
                menuItemSave.Enabled =
                menuItemSaveAs.Enabled = (dockPanel.DocumentsCount > 0);
            }
        }

        #region 新建文档

        string GetCodeTemplateText(string ext)
        {
            string text = "";
            string path = Path.Combine(Application.StartupPath, "Template\\template" + ext);

            if (File.Exists(path)) text = File.ReadAllText(path);
            return text;
        }

        private void menuItemNewAspx_Click(object sender, EventArgs e)
        {
            NewDockDocument("WebForm", CodeType.ASPX, GetCodeTemplateText(".aspx"));
        }

        private void menuItemNewCpp_Click(object sender, EventArgs e)
        {
            NewDockDocument("Class", CodeType.CPP, GetCodeTemplateText(".cpp"));
        }

        private void menuItemNewCSharp_Click(object sender, EventArgs e)
        {
            NewDockDocument("Class", CodeType.CSHARP, GetCodeTemplateText(".cs"));
        }

        private void menuItemNewHtml_Click(object sender, EventArgs e)
        {
            NewDockDocument("Page", CodeType.HTML, GetCodeTemplateText(".htm"));
        }

        private void menuItemNewJava_Click(object sender, EventArgs e)
        {
            NewDockDocument("Class", CodeType.JAVA, GetCodeTemplateText(".java"));
        }

        private void menuItemNewJavascript_Click(object sender, EventArgs e)
        {
            NewDockDocument("Script", CodeType.JS, GetCodeTemplateText(".js"));
        }

        private void menuItemNewPHP_Click(object sender, EventArgs e)
        {
            NewDockDocument("Page", CodeType.PHP, GetCodeTemplateText(".php"));
        }

        private void menuItemNewText_Click(object sender, EventArgs e)
        {
            NewDockDocument("TextFile", null, null);
        }

        private void menuItemNewTSQL_Click(object sender, EventArgs e)
        {
            NewDockDocument("Query", CodeType.TSQL, GetCodeTemplateText(".sql"));
        }

        private void menuItemNewVB_Click(object sender, EventArgs e)
        {
            NewDockDocument("Class", CodeType.VB, GetCodeTemplateText(".vb"));
        }

        private void menuItemNewXML_Click(object sender, EventArgs e)
        {
            NewDockDocument("XmlFile", CodeType.XML, GetCodeTemplateText(".xml"));
        }

        #endregion

        //打开文档
        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            OpenDockDocument();
        }

        //关闭当前激活的文档
        private void menuItemClose_Click(object sender, EventArgs e)
        {
            if (dockPanel.ActiveDocument is DockExplorer) return;
            if (dockPanel.ActiveDocument != null)
            {
                dockPanel.ActiveDocument.DockHandler.Close();
            }
        }

        //除此之外全部关闭
        private void menuItemCloseOther_Click(object sender, EventArgs e)
        {
            CloseOtherDockDocument();
        }

        //全部关闭
        private void menuItemCloseAll_Click(object sender, EventArgs e)
        {
            CloseAllDockDocument();
        }

        //保存
        private void menuItemSave_Click(object sender, EventArgs e)
        {
            if (dockPanel.ActiveDocument is IDockDocument)
            {
                ((IDockDocument)dockPanel.ActiveDocument).Save();
            }
        }

        //另存为
        private void menuItemSaveAs_Click(object sender, EventArgs e)
        {
            if (dockPanel.ActiveDocument is IDockDocument)
            {
                ((IDockDocument)dockPanel.ActiveDocument).SaveAs();
            }
        }

         //退出程序
        private void menuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        #endregion

        #region 编辑菜单项事件处理

        private void menuItemEdit_DropDownOpening(object sender, EventArgs e)
        {
            //没有激活的文档窗体时，禁用关闭菜单项
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                menuItemUndo.Enabled =
                menuItemRedo.Enabled =
                menuItemCut.Enabled =
                menuItemPaste.Enabled =
                menuItemCopy.Enabled =
                menuItemDelete.Enabled =
                menuItemSelectAll.Enabled = (ActiveMdiChild != null);
            }
            else
            {
                menuItemUndo.Enabled =
                menuItemRedo.Enabled =
                menuItemCut.Enabled =
                menuItemPaste.Enabled =
                menuItemCopy.Enabled =
                menuItemDelete.Enabled =
                menuItemSelectAll.Enabled = (dockPanel.DocumentsCount > 0);
            }
        }

        private void menuItemUndo_Click(object sender, EventArgs e)
        {
            if (dockPanel.ActiveContent is IDockDocument) ((IDockDocument)dockPanel.ActiveContent).Undo();
        }

        private void menuItemRedo_Click(object sender, EventArgs e)
        {
            if (dockPanel.ActiveContent is IDockDocument) ((IDockDocument)dockPanel.ActiveContent).Redo();
        }

        private void menuItemCut_Click(object sender, EventArgs e)
        {
            if (dockPanel.ActiveContent is IDockDocument) ((IDockDocument)dockPanel.ActiveContent).Cut(sender, e);
        }

        private void menuItemCopy_Click(object sender, EventArgs e)
        {
            if (dockPanel.ActiveContent is IDockDocument) ((IDockDocument)dockPanel.ActiveContent).Copy(sender, e);
        }

        private void menuItemPaste_Click(object sender, EventArgs e)
        {
            if (dockPanel.ActiveContent is IDockDocument) ((IDockDocument)dockPanel.ActiveContent).Paste(sender, e);
        }

        private void menuItemDelete_Click(object sender, EventArgs e)
        {
            if (dockPanel.ActiveContent is IDockDocument) ((IDockDocument)dockPanel.ActiveContent).Delete(sender, e);
        }

        private void menuItemSelectAll_Click(object sender, EventArgs e)
        {
            if (dockPanel.ActiveContent is IDockDocument) ((IDockDocument)dockPanel.ActiveContent).SelectAll(sender, e);
        }
        #endregion

        #region 视图菜单项事件处理
        //
        private void menuItemView_DropDownOpening(object sender, EventArgs e)
        {
            menuItemDatabaseExplorer.Checked = !dbExplorer.IsHidden;
            //menuItemCodeExplorer.Checked = !codeExplorer.IsHidden;
            //menuItemTemplateExplorer.Checked = !templateExplorer.IsHidden;
            menuItemOutput.Checked = !output.IsHidden;
            //menuItemPdmExplorer.Checked = !pdmExplorer.IsHidden;
        }

        //数据库连接管理器
        private void menuItemDatabaseExplorer_Click(object sender, EventArgs e)
        {
            ShowDbExplorer();
        }

        //代码管理器
        private void menuItemCodeExplorer_Click(object sender, EventArgs e)
        {
            ShowCodeExplorer();
        }
        //模板管理器
        private void menuItemTemplateExplorer_Click(object sender, EventArgs e)
        {
            ShowTemplateExplorer();
        }
        //PDM文件管理器
        private void menuItemPdmExplorer_Click(object sender, EventArgs e)
        {
            ShowPdmExplorer();
        }
        //输出
        private void menuItemOutput_Click(object sender, EventArgs e)
        {
            ShowOutput();
        }

        #region DoShow
        public void ShowDbExplorer()
        {
            if (menuItemDatabaseExplorer.Checked == false)
            {
                dbExplorer.Show(dockPanel);
                menuItemDatabaseExplorer.Checked = true;
            }
            else
            {
                dbExplorer.Hide();
                menuItemDatabaseExplorer.Checked = false;
            }
        }
        public void ShowCodeExplorer()
        {
            if (menuItemCodeExplorer.Checked == false)
            {
                codeExplorer.Show(dockPanel);
                menuItemCodeExplorer.Checked = true;
            }
            else
            {
                codeExplorer.Hide();
                menuItemCodeExplorer.Checked = false;
            }
        }
        public void ShowTemplateExplorer()
        {
            if (menuItemTemplateExplorer.Checked == false)
            {
                templateExplorer.Show(dockPanel);
                menuItemTemplateExplorer.Checked = true;
            }
            else
            {
                templateExplorer.Hide();
                menuItemTemplateExplorer.Checked = false;
            }
        }
        public void ShowPdmExplorer()
        {
            if (menuItemPdmExplorer.Checked == false)
            {
                pdmExplorer.Show(dockPanel, DockState.DockLeft);
                menuItemPdmExplorer.Checked = true;
            }
            else
            {
                pdmExplorer.Hide();
                menuItemPdmExplorer.Checked = false;
            }
        }
        public void ShowOutput()
        {
            if (menuItemOutput.Checked == false)
            {
                output.Show(dockPanel);
                menuItemOutput.Checked = true;
            }
            else
            {
                output.Hide();
                menuItemOutput.Checked = false;
            }
        }
        #endregion

        #endregion

        #region 工具菜单项事件处理

        #region DoShow

        void ShowDbSchemaViewer()
        {
            foreach (IDockContent dc in dockPanel.Documents)
            {
                if (dc is DbSchemaViewer)
                {
                    dc.DockHandler.Activate();
                    return;
                }
            }

            DbSchemaViewer viewer = new DbSchemaViewer();
            viewer.Show(dockPanel);
        }

        void ShowWebSubmitter()
        {
            //foreach (IDockContent dc in dockPanel.Documents)
            //{
            //    if (dc is WebSubmitter)
            //    {
            //        dc.DockHandler.Activate();
            //        return;
            //    }
            //}

            WebSubmitter ws = new WebSubmitter();
            //ws.Show(dockPanel);
            //ws.ShowDialog();
            ws.Show();
        }

        #endregion

        private void menuItemDbSchemaViewer_Click(object sender, EventArgs e)
        {
            ShowDbSchemaViewer();
        }

        private void menuItemWebSubmitter_Click(object sender, EventArgs e)
        {
            ShowWebSubmitter();
        }

        private void menuItemDbDocBuilder_Click(object sender, EventArgs e)
        {
            DbDocBuilder doc = new DbDocBuilder();
            doc.ShowDialog();
        }

        private void menuItemIisLogParser_Click(object sender, EventArgs e)
        {
            IISLogParseCondition condition = new IISLogParseCondition(this.dockPanel);
            condition.Show();
        }

        private void menuItemQueryTools_Click(object sender, EventArgs e)
        {
            //QueryTools qt = new QueryTools();
            //qt.Show();
        }

        private void menuItemStringConnector_Click(object sender, EventArgs e)
        {
            //foreach (IDockContent dc in dockPanel.Documents)
            //{
            //    if (dc is StringConnector)
            //    {
            //        dc.DockHandler.Activate();
            //        return;
            //    }
            //}
            StringConnector connector = new StringConnector();
            connector.ShowDialog();
        }

        private void menuItemStringConverter_Click(object sender, EventArgs e)
        {
            StringConvertor convertor = new StringConvertor();
            convertor.ShowDialog();
        }

        #endregion

        #region 帮助菜单项事件处理

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            //(new About()).ShowDialog();
        }

        #endregion

        #region 工具栏命令事件处理

        private void toolItemNewFile_Click(object sender, EventArgs e)
        {
            NewDockDocument("Document", null, null);
        }

        private void toolItemOpenFile_Click(object sender, EventArgs e)
        {
            OpenDockDocument();
        }

        private void toolItemDbExplorer_Click(object sender, EventArgs e)
        {
            ShowDbExplorer();
        }
        private void toolItemCodeExplorer_Click(object sender, EventArgs e)
        {
            ShowCodeExplorer();
        }
        private void toolItemPdmExplorer_Click(object sender, EventArgs e)
        {
            ShowPdmExplorer();
        }
        private void toolItemTemplateExplorer_Click(object sender, EventArgs e)
        {
            ShowTemplateExplorer();
        }
        private void toolItemDbSchema_Click(object sender, EventArgs e)
        {
            ShowDbSchemaViewer();
        }
        private void toolItemWebSubmitter_Click(object sender, EventArgs e)
        {
            ShowWebSubmitter();
        }

        //选择数据库改变时，同时改变当前激活的查询分析器的DbName属性
        private void toolItemDbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dockPanel.ActiveDocument != null)
            {
                if (this.dockPanel.ActiveDocument is QueryAnalyzer)
                {
                    ((QueryAnalyzer)this.dockPanel.ActiveDocument).CurrentDatabase = toolItemDbList.SelectedItem as SODatabase;
                }
            }
        }
        //执行SQL语句
        private void toolItemExecSql_Click(object sender, EventArgs e)
        {
            if (this.dockPanel.ActiveDocument != null)
            {
                if (this.dockPanel.ActiveDocument is QueryAnalyzer)
                {
                    ((QueryAnalyzer)this.dockPanel.ActiveDocument).ExecuteSql();
                }
            }
        }
        //生成代码
        private void toolItemBuildCode_Click(object sender, EventArgs e)
        {
            if (this.dockPanel.ActiveDocument != null)
            {
                if (this.dockPanel.ActiveDocument is CodeBuilder)
                {
                    ((CodeBuilder)this.dockPanel.ActiveDocument).DoBuildCode();
                }
            }
        }


        #region 控制生成代码工具栏图标的显示和隐藏
        public void ShowBuildCodeIcon()
        {
            toolItemBuildCode.Visible = true;
            toolItemBuildCodeSeparator.Visible = true;
        }
        public void HideBuildCodeIcon()
        {
            toolItemBuildCode.Visible = false;
            toolItemBuildCodeSeparator.Visible = false;
        }
        #endregion

        private void toolItemExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退出Kalman Studio", "信息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        #region 工具栏数据库下拉列表相关操作
        public void AddDbListItem(SODatabase db)
        {
            try
            {
                toolItemDbList.Items.Add(db);
            }
            catch { }
        }
        public void ClearDbList()
        {
            toolItemDbList.Items.Clear();
        }
        public SODatabase GetCurrentDatabase()
        {
            return toolItemDbList.SelectedItem as SODatabase;
        }
        public void SetCurrentDB(SODatabase db)
        {
            foreach (object item in toolItemDbList.Items)
            {
                if (item.ToString() == db.Name) toolItemDbList.SelectedItem = item;
            }
        }
        #endregion

        

        #endregion

        #region 封装对输出窗体的操作

        /// <summary>
        /// 向输出窗体追加一行文本
        /// </summary>
        /// <param name="s"></param>
        public void AppendOutputLine(string s)
        {
            if (output == null) output = new Output();
            output.AppendLine(s);
            output.Activate();
        }
        /// <summary>
        /// 清除所有输出内容
        /// </summary>
        public void ClearOutputText()
        {
            if (output == null) return;
            output.ClearText();
        }

        #endregion

        private void menuItemAbout_Click_1(object sender, EventArgs e)
        {
            (new About()).ShowDialog();
        }

        
    }
}
