namespace Kalman.Studio
{
    partial class TestDataGenerator
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestDataGenerator));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbObjName = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIdentify = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colAllowDBNull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNativeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPercision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemUnCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemImport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerator = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textEditorControl2 = new ICSharpCode.TextEditor.TextEditorControl();
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
            this.menuItemConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAspxCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCppCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCSharpCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHtmlCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemJavaCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemJsCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPhpCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTSQLCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemVBCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemXmlCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBuildCode = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbObjName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.cmsGrid.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(808, 528);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(800, 502);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "生成选项";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbObjName);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.btnGenerator);
            this.splitContainer1.Panel2.Controls.Add(this.btnPreview);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(794, 496);
            this.splitContainer1.SplitterDistance = 263;
            this.splitContainer1.TabIndex = 0;
            // 
            // gbObjName
            // 
            this.gbObjName.Controls.Add(this.dataGridView1);
            this.gbObjName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbObjName.Location = new System.Drawing.Point(0, 0);
            this.gbObjName.Name = "gbObjName";
            this.gbObjName.Size = new System.Drawing.Size(794, 263);
            this.gbObjName.TabIndex = 2;
            this.gbObjName.TabStop = false;
            this.gbObjName.Text = "groupBox1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.colName,
            this.colPK,
            this.colIdentify,
            this.colAllowDBNull,
            this.colNativeType,
            this.colLength,
            this.colPercision,
            this.colScale,
            this.colDefaultValue,
            this.colDescription});
            this.dataGridView1.ContextMenuStrip = this.cmsGrid;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(788, 243);
            this.dataGridView1.TabIndex = 0;
            // 
            // colSelect
            // 
            this.colSelect.HeaderText = "选择";
            this.colSelect.MinimumWidth = 50;
            this.colSelect.Name = "colSelect";
            this.colSelect.Width = 50;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "字段名";
            this.colName.Name = "colName";
            this.colName.Width = 160;
            // 
            // colPK
            // 
            this.colPK.DataPropertyName = "PrimaryKey";
            this.colPK.HeaderText = "P";
            this.colPK.Name = "colPK";
            this.colPK.ReadOnly = true;
            this.colPK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colPK.ToolTipText = "是否为主键";
            this.colPK.Width = 25;
            // 
            // colIdentify
            // 
            this.colIdentify.DataPropertyName = "Identify";
            this.colIdentify.HeaderText = "I";
            this.colIdentify.Name = "colIdentify";
            this.colIdentify.ReadOnly = true;
            this.colIdentify.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIdentify.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIdentify.ToolTipText = "是否为标识列";
            this.colIdentify.Width = 25;
            // 
            // colAllowDBNull
            // 
            this.colAllowDBNull.DataPropertyName = "Nullable";
            this.colAllowDBNull.HeaderText = "N";
            this.colAllowDBNull.Name = "colAllowDBNull";
            this.colAllowDBNull.ReadOnly = true;
            this.colAllowDBNull.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAllowDBNull.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colAllowDBNull.ToolTipText = "是否允许为空";
            this.colAllowDBNull.Width = 25;
            // 
            // colNativeType
            // 
            this.colNativeType.DataPropertyName = "NativeType";
            this.colNativeType.HeaderText = "数据类型";
            this.colNativeType.Name = "colNativeType";
            this.colNativeType.ToolTipText = "数据库定义的数据类型";
            this.colNativeType.Width = 120;
            // 
            // colLength
            // 
            this.colLength.DataPropertyName = "Length";
            this.colLength.HeaderText = "长度";
            this.colLength.Name = "colLength";
            this.colLength.Width = 60;
            // 
            // colPercision
            // 
            this.colPercision.DataPropertyName = "Percision";
            this.colPercision.HeaderText = "精度";
            this.colPercision.Name = "colPercision";
            this.colPercision.Width = 60;
            // 
            // colScale
            // 
            this.colScale.DataPropertyName = "Scale";
            this.colScale.HeaderText = "小数";
            this.colScale.Name = "colScale";
            this.colScale.ToolTipText = "小数位数";
            this.colScale.Width = 60;
            // 
            // colDefaultValue
            // 
            this.colDefaultValue.DataPropertyName = "DefaultValue";
            this.colDefaultValue.HeaderText = "默认值";
            this.colDefaultValue.Name = "colDefaultValue";
            this.colDefaultValue.Width = 80;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Comment";
            this.colDescription.HeaderText = "注释";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 120;
            // 
            // cmsGrid
            // 
            this.cmsGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCheckAll,
            this.menuItemUnCheckAll,
            this.menuItemImport,
            this.menuItemExport});
            this.cmsGrid.Name = "cmsGrid";
            this.cmsGrid.Size = new System.Drawing.Size(171, 92);
            // 
            // menuItemCheckAll
            // 
            this.menuItemCheckAll.Name = "menuItemCheckAll";
            this.menuItemCheckAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.menuItemCheckAll.Size = new System.Drawing.Size(170, 22);
            this.menuItemCheckAll.Text = "全选(&A)";
            // 
            // menuItemUnCheckAll
            // 
            this.menuItemUnCheckAll.Name = "menuItemUnCheckAll";
            this.menuItemUnCheckAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.menuItemUnCheckAll.Size = new System.Drawing.Size(170, 22);
            this.menuItemUnCheckAll.Text = "反选(&U)";
            // 
            // menuItemImport
            // 
            this.menuItemImport.Name = "menuItemImport";
            this.menuItemImport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.menuItemImport.Size = new System.Drawing.Size(170, 22);
            this.menuItemImport.Text = "导入(&I)...";
            // 
            // menuItemExport
            // 
            this.menuItemExport.Name = "menuItemExport";
            this.menuItemExport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.menuItemExport.Size = new System.Drawing.Size(170, 22);
            this.menuItemExport.Text = "导出(&E)...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "生成测试数据行数";
            // 
            // btnGenerator
            // 
            this.btnGenerator.Location = new System.Drawing.Point(668, 59);
            this.btnGenerator.Name = "btnGenerator";
            this.btnGenerator.Size = new System.Drawing.Size(75, 23);
            this.btnGenerator.TabIndex = 2;
            this.btnGenerator.Text = "生成";
            this.btnGenerator.UseVisualStyleBackColor = true;
            this.btnGenerator.Click += new System.EventHandler(this.btnGenerator_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(668, 15);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 1;
            this.btnPreview.Text = "预览";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "生成测试数据行数";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textEditorControl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(800, 502);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "输出脚本";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textEditorControl2
            // 
            this.textEditorControl2.ContextMenuStrip = this.cms;
            this.textEditorControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorControl2.IsReadOnly = false;
            this.textEditorControl2.Location = new System.Drawing.Point(3, 3);
            this.textEditorControl2.Name = "textEditorControl2";
            this.textEditorControl2.Size = new System.Drawing.Size(794, 496);
            this.textEditorControl2.TabIndex = 1;
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
            this.menuItemConfig,
            this.menuItemSave,
            this.menuItemBuildCode});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(163, 242);
            // 
            // menuItemUndo
            // 
            this.menuItemUndo.Image = ((System.Drawing.Image)(resources.GetObject("menuItemUndo.Image")));
            this.menuItemUndo.Name = "menuItemUndo";
            this.menuItemUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.menuItemUndo.Size = new System.Drawing.Size(162, 22);
            this.menuItemUndo.Text = "撤销(&Z)";
            // 
            // menuItemRedo
            // 
            this.menuItemRedo.Image = ((System.Drawing.Image)(resources.GetObject("menuItemRedo.Image")));
            this.menuItemRedo.Name = "menuItemRedo";
            this.menuItemRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.menuItemRedo.Size = new System.Drawing.Size(162, 22);
            this.menuItemRedo.Text = "重复(&R)";
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
            // 
            // menuItemCopy
            // 
            this.menuItemCopy.Image = ((System.Drawing.Image)(resources.GetObject("menuItemCopy.Image")));
            this.menuItemCopy.Name = "menuItemCopy";
            this.menuItemCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.menuItemCopy.Size = new System.Drawing.Size(162, 22);
            this.menuItemCopy.Text = "复制(&C)";
            // 
            // menuItemPaste
            // 
            this.menuItemPaste.Image = ((System.Drawing.Image)(resources.GetObject("menuItemPaste.Image")));
            this.menuItemPaste.Name = "menuItemPaste";
            this.menuItemPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.menuItemPaste.Size = new System.Drawing.Size(162, 22);
            this.menuItemPaste.Text = "粘贴(&V)";
            // 
            // menuItemDelete
            // 
            this.menuItemDelete.Image = ((System.Drawing.Image)(resources.GetObject("menuItemDelete.Image")));
            this.menuItemDelete.Name = "menuItemDelete";
            this.menuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.menuItemDelete.Size = new System.Drawing.Size(162, 22);
            this.menuItemDelete.Text = "删除(&D)";
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
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // menuItemConfig
            // 
            this.menuItemConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAspxCode,
            this.menuItemCppCode,
            this.menuItemCSharpCode,
            this.menuItemHtmlCode,
            this.menuItemJavaCode,
            this.menuItemJsCode,
            this.menuItemPhpCode,
            this.menuItemTSQLCode,
            this.menuItemVBCode,
            this.menuItemXmlCode});
            this.menuItemConfig.Name = "menuItemConfig";
            this.menuItemConfig.Size = new System.Drawing.Size(162, 22);
            this.menuItemConfig.Text = "选择配置";
            // 
            // menuItemAspxCode
            // 
            this.menuItemAspxCode.Name = "menuItemAspxCode";
            this.menuItemAspxCode.Size = new System.Drawing.Size(133, 22);
            this.menuItemAspxCode.Text = "Aspx";
            // 
            // menuItemCppCode
            // 
            this.menuItemCppCode.Name = "menuItemCppCode";
            this.menuItemCppCode.Size = new System.Drawing.Size(133, 22);
            this.menuItemCppCode.Text = "C/C++";
            // 
            // menuItemCSharpCode
            // 
            this.menuItemCSharpCode.Name = "menuItemCSharpCode";
            this.menuItemCSharpCode.Size = new System.Drawing.Size(133, 22);
            this.menuItemCSharpCode.Text = "C#";
            // 
            // menuItemHtmlCode
            // 
            this.menuItemHtmlCode.Name = "menuItemHtmlCode";
            this.menuItemHtmlCode.Size = new System.Drawing.Size(133, 22);
            this.menuItemHtmlCode.Text = "Html";
            // 
            // menuItemJavaCode
            // 
            this.menuItemJavaCode.Name = "menuItemJavaCode";
            this.menuItemJavaCode.Size = new System.Drawing.Size(133, 22);
            this.menuItemJavaCode.Text = "Java";
            // 
            // menuItemJsCode
            // 
            this.menuItemJsCode.Name = "menuItemJsCode";
            this.menuItemJsCode.Size = new System.Drawing.Size(133, 22);
            this.menuItemJsCode.Text = "Javascript";
            // 
            // menuItemPhpCode
            // 
            this.menuItemPhpCode.Name = "menuItemPhpCode";
            this.menuItemPhpCode.Size = new System.Drawing.Size(133, 22);
            this.menuItemPhpCode.Text = "PHP";
            // 
            // menuItemTSQLCode
            // 
            this.menuItemTSQLCode.Name = "menuItemTSQLCode";
            this.menuItemTSQLCode.Size = new System.Drawing.Size(133, 22);
            this.menuItemTSQLCode.Text = "TSQL";
            // 
            // menuItemVBCode
            // 
            this.menuItemVBCode.Name = "menuItemVBCode";
            this.menuItemVBCode.Size = new System.Drawing.Size(133, 22);
            this.menuItemVBCode.Text = "VB.NET";
            // 
            // menuItemXmlCode
            // 
            this.menuItemXmlCode.Name = "menuItemXmlCode";
            this.menuItemXmlCode.Size = new System.Drawing.Size(133, 22);
            this.menuItemXmlCode.Text = "XML";
            // 
            // menuItemSave
            // 
            this.menuItemSave.Image = ((System.Drawing.Image)(resources.GetObject("menuItemSave.Image")));
            this.menuItemSave.Name = "menuItemSave";
            this.menuItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuItemSave.Size = new System.Drawing.Size(162, 22);
            this.menuItemSave.Text = "保存(&S)";
            // 
            // menuItemBuildCode
            // 
            this.menuItemBuildCode.Name = "menuItemBuildCode";
            this.menuItemBuildCode.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.menuItemBuildCode.Size = new System.Drawing.Size(162, 22);
            this.menuItemBuildCode.Text = "生成代码";
            // 
            // TestDataGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 528);
            this.Controls.Add(this.tabControl1);
            this.Name = "TestDataGenerator";
            this.Text = "测试数据生成器";
            this.Load += new System.EventHandler(this.TestDataGenerator_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbObjName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.cmsGrid.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ContextMenuStrip cmsGrid;
        private System.Windows.Forms.ToolStripMenuItem menuItemCheckAll;
        private System.Windows.Forms.ToolStripMenuItem menuItemUnCheckAll;
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
        private System.Windows.Forms.ToolStripMenuItem menuItemConfig;
        private System.Windows.Forms.ToolStripMenuItem menuItemAspxCode;
        private System.Windows.Forms.ToolStripMenuItem menuItemCppCode;
        private System.Windows.Forms.ToolStripMenuItem menuItemCSharpCode;
        private System.Windows.Forms.ToolStripMenuItem menuItemHtmlCode;
        private System.Windows.Forms.ToolStripMenuItem menuItemJavaCode;
        private System.Windows.Forms.ToolStripMenuItem menuItemJsCode;
        private System.Windows.Forms.ToolStripMenuItem menuItemPhpCode;
        private System.Windows.Forms.ToolStripMenuItem menuItemTSQLCode;
        private System.Windows.Forms.ToolStripMenuItem menuItemVBCode;
        private System.Windows.Forms.ToolStripMenuItem menuItemXmlCode;
        private System.Windows.Forms.ToolStripMenuItem menuItemSave;
        private System.Windows.Forms.ToolStripMenuItem menuItemBuildCode;
        private System.Windows.Forms.TabPage tabPage2;
        private ICSharpCode.TextEditor.TextEditorControl textEditorControl2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbObjName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGenerator;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem menuItemImport;
        private System.Windows.Forms.ToolStripMenuItem menuItemExport;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPK;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIdentify;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAllowDBNull;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNativeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPercision;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScale;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDefaultValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}