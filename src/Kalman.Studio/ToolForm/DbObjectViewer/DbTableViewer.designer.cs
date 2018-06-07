namespace Kalman.Studio
{
    partial class DbTableViewer
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NativeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nullable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Identify = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ForeignKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PrimaryKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PrimaryKey,
            this.ForeignKey,
            this.Identify,
            this.Nullable,
            this.FieldName,
            this.NativeType,
            this.Length,
            this.Precision,
            this.Scale,
            this.DefaultValue,
            this.DataType,
            this.Comment});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv.Size = new System.Drawing.Size(792, 473);
            this.dgv.TabIndex = 1;
            // 
            // Comment
            // 
            this.Comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Comment.DataPropertyName = "Comment";
            this.Comment.HeaderText = "注释";
            this.Comment.Name = "Comment";
            // 
            // DataType
            // 
            this.DataType.DataPropertyName = "DataType";
            this.DataType.HeaderText = "转换类型";
            this.DataType.MinimumWidth = 80;
            this.DataType.Name = "DataType";
            this.DataType.ToolTipText = "特定数据库中定义的数据类型对应的.Net Framework类型";
            this.DataType.Width = 80;
            // 
            // DefaultValue
            // 
            this.DefaultValue.DataPropertyName = "DefaultValue";
            this.DefaultValue.HeaderText = "默认值";
            this.DefaultValue.MinimumWidth = 80;
            this.DefaultValue.Name = "DefaultValue";
            this.DefaultValue.Width = 80;
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
            // Precision
            // 
            this.Precision.DataPropertyName = "Precision";
            this.Precision.Frozen = true;
            this.Precision.HeaderText = "精度";
            this.Precision.MinimumWidth = 40;
            this.Precision.Name = "Precision";
            this.Precision.Width = 40;
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
            // NativeType
            // 
            this.NativeType.DataPropertyName = "NativeType";
            this.NativeType.Frozen = true;
            this.NativeType.HeaderText = "原生类型";
            this.NativeType.MaxInputLength = 200;
            this.NativeType.Name = "NativeType";
            this.NativeType.ToolTipText = "对应数据库定义的原生类型";
            this.NativeType.Width = 120;
            // 
            // FieldName
            // 
            this.FieldName.DataPropertyName = "Name";
            this.FieldName.Frozen = true;
            this.FieldName.HeaderText = "字段名";
            this.FieldName.MaxInputLength = 100;
            this.FieldName.Name = "FieldName";
            this.FieldName.Width = 120;
            // 
            // Nullable
            // 
            this.Nullable.DataPropertyName = "Nullable";
            this.Nullable.FalseValue = "";
            this.Nullable.Frozen = true;
            this.Nullable.HeaderText = "N";
            this.Nullable.MinimumWidth = 20;
            this.Nullable.Name = "Nullable";
            this.Nullable.ReadOnly = true;
            this.Nullable.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Nullable.ToolTipText = "允许为空";
            this.Nullable.TrueValue = "";
            this.Nullable.Width = 20;
            // 
            // Identify
            // 
            this.Identify.DataPropertyName = "Identify";
            this.Identify.Frozen = true;
            this.Identify.HeaderText = "I";
            this.Identify.MinimumWidth = 20;
            this.Identify.Name = "Identify";
            this.Identify.ReadOnly = true;
            this.Identify.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Identify.ToolTipText = "是否为标志列";
            this.Identify.Width = 20;
            // 
            // ForeignKey
            // 
            this.ForeignKey.DataPropertyName = "ForeignKey";
            this.ForeignKey.Frozen = true;
            this.ForeignKey.HeaderText = "F";
            this.ForeignKey.MinimumWidth = 20;
            this.ForeignKey.Name = "ForeignKey";
            this.ForeignKey.ReadOnly = true;
            this.ForeignKey.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ForeignKey.ToolTipText = "是否为外键";
            this.ForeignKey.Width = 20;
            // 
            // PrimaryKey
            // 
            this.PrimaryKey.DataPropertyName = "PrimaryKey";
            this.PrimaryKey.Frozen = true;
            this.PrimaryKey.HeaderText = "P";
            this.PrimaryKey.MinimumWidth = 20;
            this.PrimaryKey.Name = "PrimaryKey";
            this.PrimaryKey.ReadOnly = true;
            this.PrimaryKey.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PrimaryKey.ToolTipText = "是否为主键";
            this.PrimaryKey.Width = 20;
            // 
            // DbTableViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 473);
            this.Controls.Add(this.dgv);
            this.Name = "DbTableViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DbTableViewer";
            this.Load += new System.EventHandler(this.DbTableViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PrimaryKey;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ForeignKey;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Identify;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Nullable;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NativeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precision;
        private System.Windows.Forms.DataGridViewTextBoxColumn Scale;
        private System.Windows.Forms.DataGridViewTextBoxColumn DefaultValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
    }
}