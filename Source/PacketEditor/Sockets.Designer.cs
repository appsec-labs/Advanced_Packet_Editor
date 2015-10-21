namespace PacketEditor
{
    partial class Sockets
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sockets));
            this.dgridSockets = new System.Windows.Forms.DataGridView();
            this.socket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastapi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastmsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.local = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.replayEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.socketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sDRECVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sDSENDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sDBOTHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgridSockets)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgridSockets
            // 
            this.dgridSockets.AllowUserToAddRows = false;
            this.dgridSockets.AllowUserToDeleteRows = false;
            this.dgridSockets.AllowUserToOrderColumns = true;
            this.dgridSockets.AllowUserToResizeRows = false;
            this.dgridSockets.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgridSockets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgridSockets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgridSockets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridSockets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.socket,
            this.proto,
            this.fam,
            this.type,
            this.lastapi,
            this.lastmsg,
            this.local,
            this.remote});
            this.dgridSockets.ContextMenuStrip = this.contextMenuStrip1;
            this.dgridSockets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgridSockets.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgridSockets.Location = new System.Drawing.Point(0, 0);
            this.dgridSockets.Name = "dgridSockets";
            this.dgridSockets.ReadOnly = true;
            this.dgridSockets.RowHeadersVisible = false;
            this.dgridSockets.RowTemplate.Height = 18;
            this.dgridSockets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgridSockets.Size = new System.Drawing.Size(682, 208);
            this.dgridSockets.TabIndex = 0;
            this.dgridSockets.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgridSockets_KeyPress);
            // 
            // socket
            // 
            this.socket.HeaderText = "Socket";
            this.socket.Name = "socket";
            this.socket.ReadOnly = true;
            this.socket.Width = 50;
            // 
            // proto
            // 
            this.proto.HeaderText = "Proto";
            this.proto.Name = "proto";
            this.proto.ReadOnly = true;
            this.proto.Width = 60;
            // 
            // fam
            // 
            this.fam.HeaderText = "Family";
            this.fam.Name = "fam";
            this.fam.ReadOnly = true;
            this.fam.Width = 60;
            // 
            // type
            // 
            this.type.HeaderText = "Type";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Width = 60;
            // 
            // lastapi
            // 
            this.lastapi.HeaderText = "Last API";
            this.lastapi.Name = "lastapi";
            this.lastapi.ReadOnly = true;
            // 
            // lastmsg
            // 
            this.lastmsg.HeaderText = "Last Msg";
            this.lastmsg.Name = "lastmsg";
            this.lastmsg.ReadOnly = true;
            // 
            // local
            // 
            this.local.HeaderText = "Local Host";
            this.local.Name = "local";
            this.local.ReadOnly = true;
            // 
            // remote
            // 
            this.remote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.remote.HeaderText = "Remote Host";
            this.remote.Name = "remote";
            this.remote.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replayEditorToolStripMenuItem,
            this.socketToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip2";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // replayEditorToolStripMenuItem
            // 
            this.replayEditorToolStripMenuItem.Name = "replayEditorToolStripMenuItem";
            this.replayEditorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.replayEditorToolStripMenuItem.Text = "In&ject";
            this.replayEditorToolStripMenuItem.Click += new System.EventHandler(this.replayEditorToolStripMenuItem_Click);
            // 
            // socketToolStripMenuItem
            // 
            this.socketToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shutdownToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.socketToolStripMenuItem.Name = "socketToolStripMenuItem";
            this.socketToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.socketToolStripMenuItem.Text = "Socket";
            // 
            // shutdownToolStripMenuItem
            // 
            this.shutdownToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sDRECVToolStripMenuItem,
            this.sDSENDToolStripMenuItem,
            this.sDBOTHToolStripMenuItem});
            this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
            this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.shutdownToolStripMenuItem.Text = "shutdown";
            // 
            // sDRECVToolStripMenuItem
            // 
            this.sDRECVToolStripMenuItem.Name = "sDRECVToolStripMenuItem";
            this.sDRECVToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.sDRECVToolStripMenuItem.Text = "SD_RECEIVE";
            this.sDRECVToolStripMenuItem.Click += new System.EventHandler(this.sDRECVToolStripMenuItem_Click);
            // 
            // sDSENDToolStripMenuItem
            // 
            this.sDSENDToolStripMenuItem.Name = "sDSENDToolStripMenuItem";
            this.sDSENDToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.sDSENDToolStripMenuItem.Text = "SD_SEND";
            this.sDSENDToolStripMenuItem.Click += new System.EventHandler(this.sDSENDToolStripMenuItem_Click);
            // 
            // sDBOTHToolStripMenuItem
            // 
            this.sDBOTHToolStripMenuItem.Name = "sDBOTHToolStripMenuItem";
            this.sDBOTHToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.sDBOTHToolStripMenuItem.Text = "SD_BOTH";
            this.sDBOTHToolStripMenuItem.Click += new System.EventHandler(this.sDBOTHToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "closesocket";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // Sockets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 208);
            this.Controls.Add(this.dgridSockets);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(100, 100);
            this.Name = "Sockets";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sockets";
            this.Activated += new System.EventHandler(this.frmSockets_Activated);
            this.Deactivate += new System.EventHandler(this.frmSockets_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.dgridSockets)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgridSockets;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem replayEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem socketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sDRECVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sDSENDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sDBOTHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn socket;
        private System.Windows.Forms.DataGridViewTextBoxColumn proto;
        private System.Windows.Forms.DataGridViewTextBoxColumn fam;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastapi;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastmsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn local;
        private System.Windows.Forms.DataGridViewTextBoxColumn remote;
    }
}