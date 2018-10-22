namespace Kalman.Studio
{
    partial class Terminal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Terminal));
            this.rtbCommand = new Kalman.Command.RichConsoleBox();
            this.SuspendLayout();
            // 
            // rtbCommand
            // 
            this.rtbCommand.AcceptsTab = true;
            this.rtbCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbCommand.Font = new System.Drawing.Font("Lucida Console", 8F);
            this.rtbCommand.Location = new System.Drawing.Point(0, 0);
            this.rtbCommand.Name = "rtbCommand";
            this.rtbCommand.Size = new System.Drawing.Size(575, 178);
            this.rtbCommand.TabIndex = 1;
            this.rtbCommand.Text = "";
            this.rtbCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbCommand_KeyDown);
            // 
            // Terminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 178);
            this.Controls.Add(this.rtbCommand);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Terminal";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottomAutoHide;
            this.Text = "终端";
            this.ResumeLayout(false);

        }

        #endregion

        private Command.RichConsoleBox rtbCommand;
    }
}