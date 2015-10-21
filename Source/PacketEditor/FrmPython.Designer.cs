namespace PacketEditor
{
    partial class FrmPython
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPython));
            this.tabLog = new System.Windows.Forms.TabControl();
            this.tabOutput = new System.Windows.Forms.TabPage();
            this.txbOutput = new System.Windows.Forms.TextBox();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabFilter = new System.Windows.Forms.TabPage();
            this.txbFilter = new System.Windows.Forms.RichTextBox();
            this.tabLog.SuspendLayout();
            this.tabOutput.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.tabFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.tabOutput);
            this.tabLog.Controls.Add(this.tabFilter);
            this.tabLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabLog.Location = new System.Drawing.Point(0, 24);
            this.tabLog.Name = "tabLog";
            this.tabLog.SelectedIndex = 0;
            this.tabLog.Size = new System.Drawing.Size(524, 367);
            this.tabLog.TabIndex = 0;
            // 
            // tabOutput
            // 
            this.tabOutput.Controls.Add(this.txbOutput);
            this.tabOutput.Location = new System.Drawing.Point(4, 22);
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tabOutput.Size = new System.Drawing.Size(516, 341);
            this.tabOutput.TabIndex = 0;
            this.tabOutput.Text = "Output";
            this.tabOutput.UseVisualStyleBackColor = true;
            // 
            // txbOutput
            // 
            this.txbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbOutput.Location = new System.Drawing.Point(3, 3);
            this.txbOutput.Multiline = true;
            this.txbOutput.Name = "txbOutput";
            this.txbOutput.ReadOnly = true;
            this.txbOutput.Size = new System.Drawing.Size(510, 335);
            this.txbOutput.TabIndex = 0;
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(524, 24);
            this.menuMain.TabIndex = 1;
            this.menuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveFilterToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveFilterToolStripMenuItem
            // 
            this.saveFilterToolStripMenuItem.Name = "saveFilterToolStripMenuItem";
            this.saveFilterToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.saveFilterToolStripMenuItem.Text = "&Save Filter...";
            this.saveFilterToolStripMenuItem.Click += new System.EventHandler(this.saveFilterToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabFilter
            // 
            this.tabFilter.Controls.Add(this.txbFilter);
            this.tabFilter.Location = new System.Drawing.Point(4, 22);
            this.tabFilter.Name = "tabFilter";
            this.tabFilter.Padding = new System.Windows.Forms.Padding(3);
            this.tabFilter.Size = new System.Drawing.Size(516, 341);
            this.tabFilter.TabIndex = 1;
            this.tabFilter.Text = "Filter";
            this.tabFilter.UseVisualStyleBackColor = true;
            // 
            // txbFilter
            // 
            this.txbFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbFilter.Location = new System.Drawing.Point(3, 3);
            this.txbFilter.Name = "txbFilter";
            this.txbFilter.Size = new System.Drawing.Size(510, 335);
            this.txbFilter.TabIndex = 0;
            this.txbFilter.Text = "";
            // 
            // FrmPython
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(524, 391);
            this.Controls.Add(this.tabLog);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.Name = "FrmPython";
            this.Load += new System.EventHandler(this.FrmPython_Load);
            this.tabLog.ResumeLayout(false);
            this.tabOutput.ResumeLayout(false);
            this.tabOutput.PerformLayout();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.tabFilter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabLog;
        private System.Windows.Forms.TabPage tabOutput;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFilterToolStripMenuItem;
        private System.Windows.Forms.TextBox txbOutput;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tabFilter;
        private System.Windows.Forms.RichTextBox txbFilter;
    }
}