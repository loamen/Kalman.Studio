namespace Kalman.Studio
{
    partial class DbViewViewer
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
            this.textEditorControl1 = new ICSharpCode.TextEditor.TextEditorControl();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.FieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NativeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // textEditorControl1
            // 
            this.textEditorControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textEditorControl1.IsReadOnly = false;
            this.textEditorControl1.Location = new System.Drawing.Point(0, 0);
            this.textEditorControl1.Name = "textEditorControl1";
            this.textEditorControl1.Size = new System.Drawing.Size(792, 357);
            this.textEditorControl1.TabIndex = 3;
            this.textEditorControl1.Text = "textEditorControl1";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FieldName,
            this.NativeType,
            this.Length,
            this.Precision,
            this.Scale,
            this.DataType,
            this.Comment});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 357);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv.Size = new System.Drawing.Size(792, 216);
            this.dgv.TabIndex = 4;
            // 
            // FieldName
            // 
            this.FieldName.DataPropertyName = "Name";
            this.FieldName.Frozen = true;
            this.FieldName.HeaderText = "字段名";
            this.FieldName.MaxInputLength = 100;
            this.FieldName.Name = "FieldName";
            this.FieldName.Width = 150;
            // 
            // NativeType
            // 
            this.NativeType.DataPropertyName = "NativeType";
            this.NativeType.Frozen = true;
            this.NativeType.HeaderText = "原生类型";
            this.NativeType.MaxInputLength = 200;
            this.NativeType.Name = "NativeType";
            this.NativeType.ToolTipText = "对应数据库定义的原生类型";
            this.NativeType.Width = 150;
            // 
            // Length
            // 
            this.Length.DataPropertyName = "Length";
            this.Length.Frozen = true;
            this.Length.HeaderText = "长度";
            this.Length.MinimumWidth = 40;
            this.Length.Name = "Length";
            this.Length.Width = 40;
            // 
            // Precision
            // 
            this.Precision.DataPropertyName = "Precision";
            this.Precision.Frozen = true;
            this.Precision.HeaderText = "精度";
            this.Precision.MinimumWidth = 40;
            this.Precision.Name = "Precision";
            this.Precision.Width = 40;
            // 
            // Scale
            // 
            this.Scale.DataPropertyName = "Scale";
            this.Scale.Frozen = true;
            this.Scale.HeaderText = "小数";
            this.Scale.MinimumWidth = 40;
            this.Scale.Name = "Scale";
            this.Scale.ToolTipText = "小数位数";
            this.Scale.Width = 40;
            // 
            // DataType
            // 
            this.DataType.DataPropertyName = "DataType";
            this.DataType.HeaderText = "转换类型";
            this.DataType.MinimumWidth = 100;
            this.DataType.Name = "DataType";
            this.DataType.ToolTipText = "特定数据库中定义的数据类型对应的.Net Framework类型";
            // 
            // Comment
            // 
            this.Comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Comment.DataPropertyName = "Comment";
            this.Comment.HeaderText = "注释";
            this.Comment.Name = "Comment";
            // 
            // DbViewViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.textEditorControl1);
            this.Name = "DbViewViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DbViewViewer";
            this.Load += new System.EventHandler(this.DbViewViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ICSharpCode.TextEditor.TextEditorControl textEditorControl1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NativeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precision;
        private System.Windows.Forms.DataGridViewTextBoxColumn Scale;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
    }
}