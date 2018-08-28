namespace Kalman.Studio
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.wbStatistics = new Loamen.WinControls.UI.WebBrowserEx();
            this.SuspendLayout();
            // 
            // wbStatistics
            // 
            this.wbStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbStatistics.Location = new System.Drawing.Point(0, 0);
            this.wbStatistics.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbStatistics.Name = "wbStatistics";
            this.wbStatistics.ProxyServer = null;
            this.wbStatistics.ScrollBarsEnabled = false;
            this.wbStatistics.Size = new System.Drawing.Size(423, 266);
            this.wbStatistics.TabIndex = 0;
            this.wbStatistics.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/4.0; SLCC2; .NET CLR 2" +
                ".0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C;" +
                " .NET4.0E)";
            this.wbStatistics.NavigateError += new Loamen.WinControls.UI.WebBrowserEx.WebBrowserNavigateErrorEventHandler(this.wbStatistics_NavigateError);
            this.wbStatistics.BeforeNewWindow += new System.EventHandler(this.wbStatistics_BeforeNewWindow);
            this.wbStatistics.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbStatistics_DocumentCompleted);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(423, 266);
            this.Controls.Add(this.wbStatistics);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartForm";
            this.Text = "起始页";
            this.ResumeLayout(false);

        }

        #endregion

        private Loamen.WinControls.UI.WebBrowserEx wbStatistics;
    }
}