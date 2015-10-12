namespace Kalman.Studio
{
    partial class BatchBuildCode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchBuildCode));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.gbTableSelect = new System.Windows.Forms.GroupBox();
            this.btnRemoveOne = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnSelectOne = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTablePrefix = new System.Windows.Forms.TextBox();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbClassNameIsFileName = new System.Windows.Forms.CheckBox();
            this.cbAddSuffix = new System.Windows.Forms.CheckBox();
            this.cbClassNamePascal = new System.Windows.Forms.CheckBox();
            this.cbDeleteTablePrifix = new System.Windows.Forms.CheckBox();
            this.txtClassSuffix = new System.Windows.Forms.TextBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnBuildCode = new System.Windows.Forms.Button();
            this.txtPrefixLevel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gbTemplateList = new System.Windows.Forms.GroupBox();
            this.tvTemplate = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.gbTemplateFile = new System.Windows.Forms.GroupBox();
            this.textEditorControl1 = new ICSharpCode.TextEditor.TextEditorControl();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemCut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemManage = new System.Windows.Forms.ToolStripMenuItem();
            this.txtClassPrefix = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbClassNameRemovePlural = new System.Windows.Forms.CheckBox();
            this.gbTableSelect.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gbTemplateList.SuspendLayout();
            this.gbTemplateFile.SuspendLayout();
            this.cms.SuspendLayout();
            this.cmsTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 20);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(180, 196);
            this.listBox1.TabIndex = 0;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // gbTableSelect
            // 
            this.gbTableSelect.Controls.Add(this.btnRemoveOne);
            this.gbTableSelect.Controls.Add(this.btnRemoveAll);
            this.gbTableSelect.Controls.Add(this.btnSelectOne);
            this.gbTableSelect.Controls.Add(this.listBox2);
            this.gbTableSelect.Controls.Add(this.btnSelectAll);
            this.gbTableSelect.Controls.Add(this.listBox1);
            this.gbTableSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTableSelect.Location = new System.Drawing.Point(0, 0);
            this.gbTableSelect.Name = "gbTableSelect";
            this.gbTableSelect.Size = new System.Drawing.Size(421, 230);
            this.gbTableSelect.TabIndex = 1;
            this.gbTableSelect.TabStop = false;
            this.gbTableSelect.Text = "groupBox1";
            // 
            // btnRemoveOne
            // 
            this.btnRemoveOne.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveOne.Location = new System.Drawing.Point(198, 132);
            this.btnRemoveOne.Name = "btnRemoveOne";
            this.btnRemoveOne.Size = new System.Drawing.Size(28, 25);
            this.btnRemoveOne.TabIndex = 9;
            this.btnRemoveOne.Text = "<";
            this.btnRemoveOne.UseVisualStyleBackColor = true;
            this.btnRemoveOne.Click += new System.EventHandler(this.btnRemoveOne_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveAll.Location = new System.Drawing.Point(198, 182);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(28, 25);
            this.btnRemoveAll.TabIndex = 8;
            this.btnRemoveAll.Text = "<<";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnSelectOne
            // 
            this.btnSelectOne.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectOne.Location = new System.Drawing.Point(198, 82);
            this.btnSelectOne.Name = "btnSelectOne";
            this.btnSelectOne.Size = new System.Drawing.Size(28, 25);
            this.btnSelectOne.TabIndex = 7;
            this.btnSelectOne.Text = ">";
            this.btnSelectOne.UseVisualStyleBackColor = true;
            this.btnSelectOne.Click += new System.EventHandler(this.btnSelectOne_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(232, 20);
            this.listBox2.Name = "listBox2";
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox2.Size = new System.Drawing.Size(180, 196);
            this.listBox2.TabIndex = 6;
            this.listBox2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox2_MouseDoubleClick);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectAll.Location = new System.Drawing.Point(198, 32);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(28, 25);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = ">>";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "命名空间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "前缀分隔符";
            // 
            // txtTablePrefix
            // 
            this.txtTablePrefix.Location = new System.Drawing.Point(224, 50);
            this.txtTablePrefix.Name = "txtTablePrefix";
            this.txtTablePrefix.Size = new System.Drawing.Size(30, 21);
            this.txtTablePrefix.TabIndex = 5;
            this.txtTablePrefix.Text = "_";
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Location = new System.Drawing.Point(68, 23);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(285, 21);
            this.txtNameSpace.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbClassNameRemovePlural);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtClassPrefix);
            this.groupBox1.Controls.Add(this.cbClassNameIsFileName);
            this.groupBox1.Controls.Add(this.cbAddSuffix);
            this.groupBox1.Controls.Add(this.cbClassNamePascal);
            this.groupBox1.Controls.Add(this.cbDeleteTablePrifix);
            this.groupBox1.Controls.Add(this.txtClassSuffix);
            this.groupBox1.Controls.Add(this.lblMsg);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.btnBuildCode);
            this.groupBox1.Controls.Add(this.txtPrefixLevel);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnBrowser);
            this.groupBox1.Controls.Add(this.txtOutputPath);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTablePrefix);
            this.groupBox1.Controls.Add(this.txtNameSpace);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 230);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数设置";
            // 
            // cbClassNameIsFileName
            // 
            this.cbClassNameIsFileName.AutoSize = true;
            this.cbClassNameIsFileName.Checked = true;
            this.cbClassNameIsFileName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbClassNameIsFileName.Location = new System.Drawing.Point(9, 127);
            this.cbClassNameIsFileName.Name = "cbClassNameIsFileName";
            this.cbClassNameIsFileName.Size = new System.Drawing.Size(108, 16);
            this.cbClassNameIsFileName.TabIndex = 27;
            this.cbClassNameIsFileName.Text = "类名作为文件名";
            this.cbClassNameIsFileName.UseVisualStyleBackColor = true;
            // 
            // cbAddSuffix
            // 
            this.cbAddSuffix.AutoSize = true;
            this.cbAddSuffix.Location = new System.Drawing.Point(9, 102);
            this.cbAddSuffix.Name = "cbAddSuffix";
            this.cbAddSuffix.Size = new System.Drawing.Size(108, 16);
            this.cbAddSuffix.TabIndex = 26;
            this.cbAddSuffix.Text = "类名添加前后缀";
            this.cbAddSuffix.UseVisualStyleBackColor = true;
            // 
            // cbClassNamePascal
            // 
            this.cbClassNamePascal.AutoSize = true;
            this.cbClassNamePascal.Location = new System.Drawing.Point(9, 77);
            this.cbClassNamePascal.Name = "cbClassNamePascal";
            this.cbClassNamePascal.Size = new System.Drawing.Size(180, 16);
            this.cbClassNamePascal.TabIndex = 25;
            this.cbClassNamePascal.Text = "规范化类名，按Pascal大小写";
            this.cbClassNamePascal.UseVisualStyleBackColor = true;
            // 
            // cbDeleteTablePrifix
            // 
            this.cbDeleteTablePrifix.AutoSize = true;
            this.cbDeleteTablePrifix.Location = new System.Drawing.Point(9, 52);
            this.cbDeleteTablePrifix.Name = "cbDeleteTablePrifix";
            this.cbDeleteTablePrifix.Size = new System.Drawing.Size(96, 16);
            this.cbDeleteTablePrifix.TabIndex = 24;
            this.cbDeleteTablePrifix.Text = "删除表名前缀";
            this.cbDeleteTablePrifix.UseVisualStyleBackColor = true;
            // 
            // txtClassSuffix
            // 
            this.txtClassSuffix.Location = new System.Drawing.Point(242, 100);
            this.txtClassSuffix.Name = "txtClassSuffix";
            this.txtClassSuffix.Size = new System.Drawing.Size(76, 21);
            this.txtClassSuffix.TabIndex = 23;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(6, 191);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(101, 12);
            this.lblMsg.TabIndex = 21;
            this.lblMsg.Text = "代码生成进度显示";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.ForeColor = System.Drawing.Color.ForestGreen;
            this.progressBar1.Location = new System.Drawing.Point(3, 209);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(444, 18);
            this.progressBar1.Step = 2;
            this.progressBar1.TabIndex = 20;
            // 
            // btnBuildCode
            // 
            this.btnBuildCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuildCode.Location = new System.Drawing.Point(368, 182);
            this.btnBuildCode.Name = "btnBuildCode";
            this.btnBuildCode.Size = new System.Drawing.Size(75, 23);
            this.btnBuildCode.TabIndex = 18;
            this.btnBuildCode.Text = "生成代码";
            this.btnBuildCode.UseVisualStyleBackColor = true;
            this.btnBuildCode.Click += new System.EventHandler(this.btnBuildCode_Click);
            // 
            // txtPrefixLevel
            // 
            this.txtPrefixLevel.Location = new System.Drawing.Point(323, 50);
            this.txtPrefixLevel.Name = "txtPrefixLevel";
            this.txtPrefixLevel.Size = new System.Drawing.Size(30, 21);
            this.txtPrefixLevel.TabIndex = 16;
            this.txtPrefixLevel.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(268, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "前缀层次";
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(368, 151);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnBrowser.TabIndex = 12;
            this.btnBrowser.Text = "浏览...";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(83, 152);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(282, 21);
            this.txtOutputPath.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "代码输出路径";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer1.Panel1.Margin = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(885, 543);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.TabIndex = 11;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(5, 5);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.gbTableSelect);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer3.Size = new System.Drawing.Size(875, 230);
            this.splitContainer3.SplitterDistance = 421;
            this.splitContainer3.TabIndex = 11;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gbTemplateList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gbTemplateFile);
            this.splitContainer2.Size = new System.Drawing.Size(885, 299);
            this.splitContainer2.SplitterDistance = 192;
            this.splitContainer2.TabIndex = 1;
            // 
            // gbTemplateList
            // 
            this.gbTemplateList.Controls.Add(this.tvTemplate);
            this.gbTemplateList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTemplateList.Location = new System.Drawing.Point(0, 0);
            this.gbTemplateList.Name = "gbTemplateList";
            this.gbTemplateList.Size = new System.Drawing.Size(192, 299);
            this.gbTemplateList.TabIndex = 1;
            this.gbTemplateList.TabStop = false;
            this.gbTemplateList.Text = "选择代码模板";
            // 
            // tvTemplate
            // 
            this.tvTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTemplate.ImageIndex = 0;
            this.tvTemplate.ImageList = this.imgList;
            this.tvTemplate.Location = new System.Drawing.Point(3, 17);
            this.tvTemplate.Name = "tvTemplate";
            this.tvTemplate.SelectedImageIndex = 0;
            this.tvTemplate.Size = new System.Drawing.Size(186, 279);
            this.tvTemplate.TabIndex = 0;
            this.tvTemplate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tvTemplate_MouseClick);
            this.tvTemplate.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tvTemplate_MouseDoubleClick);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "templateRoot.png");
            this.imgList.Images.SetKeyName(1, "templateDir.png");
            this.imgList.Images.SetKeyName(2, "templateFile.png");
            // 
            // gbTemplateFile
            // 
            this.gbTemplateFile.Controls.Add(this.textEditorControl1);
            this.gbTemplateFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTemplateFile.Location = new System.Drawing.Point(0, 0);
            this.gbTemplateFile.Name = "gbTemplateFile";
            this.gbTemplateFile.Size = new System.Drawing.Size(689, 299);
            this.gbTemplateFile.TabIndex = 2;
            this.gbTemplateFile.TabStop = false;
            this.gbTemplateFile.Text = "模板预览";
            // 
            // textEditorControl1
            // 
            this.textEditorControl1.ContextMenuStrip = this.cms;
            this.textEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorControl1.IsReadOnly = false;
            this.textEditorControl1.Location = new System.Drawing.Point(3, 17);
            this.textEditorControl1.Name = "textEditorControl1";
            this.textEditorControl1.Size = new System.Drawing.Size(683, 279);
            this.textEditorControl1.TabIndex = 1;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemUndo,
            this.menuItemRedo,
            this.toolStripSeparator5,
            this.menuItemCut,
            this.menuItemCopy,
            this.menuItemPaste,
            this.menuItemDelete,
            this.toolStripSeparator1,
            this.menuItemSelectAll,
            this.toolStripSeparator2,
            this.menuItemSave});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(163, 198);
            // 
            // menuItemUndo
            // 
            this.menuItemUndo.Image = ((System.Drawing.Image)(resources.GetObject("menuItemUndo.Image")));
            this.menuItemUndo.Name = "menuItemUndo";
            this.menuItemUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.menuItemUndo.Size = new System.Drawing.Size(162, 22);
            this.menuItemUndo.Text = "撤销(&Z)";
            this.menuItemUndo.Click += new System.EventHandler(this.menuItemUndo_Click);
            // 
            // menuItemRedo
            // 
            this.menuItemRedo.Image = ((System.Drawing.Image)(resources.GetObject("menuItemRedo.Image")));
            this.menuItemRedo.Name = "menuItemRedo";
            this.menuItemRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.menuItemRedo.Size = new System.Drawing.Size(162, 22);
            this.menuItemRedo.Text = "重复(&R)";
            this.menuItemRedo.Click += new System.EventHandler(this.menuItemRedo_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(159, 6);
            // 
            // menuItemCut
            // 
            this.menuItemCut.Image = ((System.Drawing.Image)(resources.GetObject("menuItemCut.Image")));
            this.menuItemCut.Name = "menuItemCut";
            this.menuItemCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.menuItemCut.Size = new System.Drawing.Size(162, 22);
            this.menuItemCut.Text = "剪切(&X)";
            this.menuItemCut.Click += new System.EventHandler(this.menuItemCut_Click);
            // 
            // menuItemCopy
            // 
            this.menuItemCopy.Image = ((System.Drawing.Image)(resources.GetObject("menuItemCopy.Image")));
            this.menuItemCopy.Name = "menuItemCopy";
            this.menuItemCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.menuItemCopy.Size = new System.Drawing.Size(162, 22);
            this.menuItemCopy.Text = "复制(&C)";
            this.menuItemCopy.Click += new System.EventHandler(this.menuItemCopy_Click);
            // 
            // menuItemPaste
            // 
            this.menuItemPaste.Image = ((System.Drawing.Image)(resources.GetObject("menuItemPaste.Image")));
            this.menuItemPaste.Name = "menuItemPaste";
            this.menuItemPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.menuItemPaste.Size = new System.Drawing.Size(162, 22);
            this.menuItemPaste.Text = "粘贴(&V)";
            this.menuItemPaste.Click += new System.EventHandler(this.menuItemPaste_Click);
            // 
            // menuItemDelete
            // 
            this.menuItemDelete.Image = ((System.Drawing.Image)(resources.GetObject("menuItemDelete.Image")));
            this.menuItemDelete.Name = "menuItemDelete";
            this.menuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.menuItemDelete.Size = new System.Drawing.Size(162, 22);
            this.menuItemDelete.Text = "删除(&D)";
            this.menuItemDelete.Click += new System.EventHandler(this.menuItemDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // menuItemSelectAll
            // 
            this.menuItemSelectAll.Name = "menuItemSelectAll";
            this.menuItemSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.menuItemSelectAll.Size = new System.Drawing.Size(162, 22);
            this.menuItemSelectAll.Text = "全选(&A)";
            this.menuItemSelectAll.Click += new System.EventHandler(this.menuItemSelectAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // menuItemSave
            // 
            this.menuItemSave.Image = ((System.Drawing.Image)(resources.GetObject("menuItemSave.Image")));
            this.menuItemSave.Name = "menuItemSave";
            this.menuItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuItemSave.Size = new System.Drawing.Size(162, 22);
            this.menuItemSave.Text = "保存(&S)";
            this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
            // 
            // cmsTree
            // 
            this.cmsTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemRefresh,
            this.menuItemManage});
            this.cmsTree.Name = "cmsTree";
            this.cmsTree.Size = new System.Drawing.Size(125, 48);
            // 
            // menuItemRefresh
            // 
            this.menuItemRefresh.Name = "menuItemRefresh";
            this.menuItemRefresh.Size = new System.Drawing.Size(124, 22);
            this.menuItemRefresh.Text = "刷新";
            this.menuItemRefresh.Click += new System.EventHandler(this.menuItemRefresh_Click);
            // 
            // menuItemManage
            // 
            this.menuItemManage.Name = "menuItemManage";
            this.menuItemManage.Size = new System.Drawing.Size(124, 22);
            this.menuItemManage.Text = "模板管理";
            this.menuItemManage.Click += new System.EventHandler(this.menuItemManage_Click);
            // 
            // txtClassPrefix
            // 
            this.txtClassPrefix.Location = new System.Drawing.Point(118, 100);
            this.txtClassPrefix.Name = "txtClassPrefix";
            this.txtClassPrefix.Size = new System.Drawing.Size(71, 21);
            this.txtClassPrefix.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 29;
            this.label3.Text = "+类名+";
            // 
            // cbClassNameRemovePlural
            // 
            this.cbClassNameRemovePlural.AutoSize = true;
            this.cbClassNameRemovePlural.Location = new System.Drawing.Point(134, 127);
            this.cbClassNameRemovePlural.Name = "cbClassNameRemovePlural";
            this.cbClassNameRemovePlural.Size = new System.Drawing.Size(96, 16);
            this.cbClassNameRemovePlural.TabIndex = 30;
            this.cbClassNameRemovePlural.Text = "去掉类名复数";
            this.cbClassNameRemovePlural.UseVisualStyleBackColor = true;
            // 
            // BatchBuildCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 543);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "BatchBuildCode";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量生成代码";
            this.Load += new System.EventHandler(this.BatchBuildCode_Load);
            this.gbTableSelect.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.gbTemplateList.ResumeLayout(false);
            this.gbTemplateFile.ResumeLayout(false);
            this.cms.ResumeLayout(false);
            this.cmsTree.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuildCode;
        private System.Windows.Forms.TextBox txtPrefixLevel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTablePrefix;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnRemoveOne;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnSelectOne;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.GroupBox gbTableSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.ListBox listBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox gbTemplateList;
        private System.Windows.Forms.TreeView tvTemplate;
        private System.Windows.Forms.GroupBox gbTemplateFile;
        private ICSharpCode.TextEditor.TextEditorControl textEditorControl1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ContextMenuStrip cmsTree;
        private System.Windows.Forms.ToolStripMenuItem menuItemRefresh;
        private System.Windows.Forms.ToolStripMenuItem menuItemManage;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem menuItemUndo;
        private System.Windows.Forms.ToolStripMenuItem menuItemRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem menuItemCut;
        private System.Windows.Forms.ToolStripMenuItem menuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem menuItemPaste;
        private System.Windows.Forms.ToolStripMenuItem menuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuItemSave;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.TextBox txtClassSuffix;
        private System.Windows.Forms.CheckBox cbDeleteTablePrifix;
        private System.Windows.Forms.CheckBox cbClassNamePascal;
        private System.Windows.Forms.CheckBox cbClassNameIsFileName;
        private System.Windows.Forms.CheckBox cbAddSuffix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtClassPrefix;
        private System.Windows.Forms.CheckBox cbClassNameRemovePlural;
    }
}