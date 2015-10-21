namespace PacketEditor
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.dgridMain = new System.Windows.Forms.DataGridView();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.socket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rawdata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnuMsg = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuMsgCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMsgCopyASCII = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMsgCopyHex = new System.Windows.Forms.ToolStripMenuItem();
            this.copyForListenerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.injectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMsgReplay = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMsgSocket = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMsgSocketSD = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMsgSocketSDrecv = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMsgSocketSDsend = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMsgSocketSDboth = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMsgSocketClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAutoScroll = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showrecvRecvAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMsgClear = new System.Windows.Forms.ToolStripMenuItem();
            this.icoNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuNotifyRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNotifyExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDNS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDNSClear = new System.Windows.Forms.ToolStripMenuItem();
            this.treeAPI = new System.Windows.Forms.TreeView();
            this.mnuAPI = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAPIClear = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.treeDNS = new System.Windows.Forms.TreeView();
            this.txbRecordText = new System.Windows.Forms.TextBox();
            this.mnuReplay = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MIReplay = new System.Windows.Forms.ToolStripMenuItem();
            this.dsMain = new System.Data.DataSet();
            this.sockets = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.filters = new System.Data.DataTable();
            this.dataColumn11 = new System.Data.DataColumn();
            this.dataColumn14 = new System.Data.DataColumn();
            this.dataColumn12 = new System.Data.DataColumn();
            this.dataColumn13 = new System.Data.DataColumn();
            this.dataColumn15 = new System.Data.DataColumn();
            this.dataColumn16 = new System.Data.DataColumn();
            this.dataColumn17 = new System.Data.DataColumn();
            this.dataColumn18 = new System.Data.DataColumn();
            this.dataColumn19 = new System.Data.DataColumn();
            this.dataColumn20 = new System.Data.DataColumn();
            this.dataColumn21 = new System.Data.DataColumn();
            this.dataColumn22 = new System.Data.DataColumn();
            this.dataColumn23 = new System.Data.DataColumn();
            this.dataColumn24 = new System.Data.DataColumn();
            this.dataColumn25 = new System.Data.DataColumn();
            this.dataColumn26 = new System.Data.DataColumn();
            this.dataColumn27 = new System.Data.DataColumn();
            this.dns = new System.Data.DataTable();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileAttach = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileDetach = new System.Windows.Forms.ToolStripMenuItem();
            this.reAttachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInvoke = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInvokeFreeze = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsMonitor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuToolsProxy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToggleFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuToolsSockets = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuToolsFilters = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptionsOntop = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpWebsite = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsExternalFilter = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerPython = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgridMain)).BeginInit();
            this.mnuMsg.SuspendLayout();
            this.mnuNotify.SuspendLayout();
            this.mnuDNS.SuspendLayout();
            this.mnuAPI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.mnuReplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sockets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dns)).BeginInit();
            this.mnuMain.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgridMain
            // 
            this.dgridMain.AllowUserToAddRows = false;
            this.dgridMain.AllowUserToOrderColumns = true;
            this.dgridMain.AllowUserToResizeRows = false;
            this.dgridMain.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgridMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgridMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.time,
            this.socket,
            this.proto,
            this.method,
            this.size,
            this.data,
            this.rawdata});
            this.dgridMain.ContextMenuStrip = this.mnuMsg;
            this.dgridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgridMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgridMain.Location = new System.Drawing.Point(0, 0);
            this.dgridMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgridMain.Name = "dgridMain";
            this.dgridMain.ReadOnly = true;
            this.dgridMain.RowHeadersVisible = false;
            this.dgridMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgridMain.ShowCellErrors = false;
            this.dgridMain.Size = new System.Drawing.Size(1083, 252);
            this.dgridMain.TabIndex = 1;
            this.dgridMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgridMain_CellContentClick);
            this.dgridMain.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgridMain_CellDoubleClick);
            this.dgridMain.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgridMain_RowsAdded);
            // 
            // time
            // 
            this.time.HeaderText = "Timestamp";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.Width = 65;
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
            this.proto.Width = 50;
            // 
            // method
            // 
            this.method.HeaderText = "Method";
            this.method.Name = "method";
            this.method.ReadOnly = true;
            this.method.Width = 75;
            // 
            // size
            // 
            this.size.HeaderText = "Size";
            this.size.Name = "size";
            this.size.ReadOnly = true;
            this.size.Width = 50;
            // 
            // data
            // 
            this.data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.data.HeaderText = "Data";
            this.data.Name = "data";
            this.data.ReadOnly = true;
            // 
            // rawdata
            // 
            this.rawdata.HeaderText = "RawData";
            this.rawdata.Name = "rawdata";
            this.rawdata.ReadOnly = true;
            this.rawdata.Visible = false;
            // 
            // mnuMsg
            // 
            this.mnuMsg.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuMsg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMsgCopy,
            this.injectToolStripMenuItem,
            this.mnuMsgReplay,
            this.mnuMsgSocket,
            this.toolStripSeparator4,
            this.mnuAutoScroll,
            this.viewToolStripMenuItem,
            this.mnuMsgClear});
            this.mnuMsg.Name = "contextMenuStrip2";
            this.mnuMsg.Size = new System.Drawing.Size(164, 178);
            // 
            // mnuMsgCopy
            // 
            this.mnuMsgCopy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMsgCopyASCII,
            this.mnuMsgCopyHex,
            this.copyForListenerToolStripMenuItem});
            this.mnuMsgCopy.Name = "mnuMsgCopy";
            this.mnuMsgCopy.Size = new System.Drawing.Size(163, 24);
            this.mnuMsgCopy.Text = "&Copy";
            // 
            // mnuMsgCopyASCII
            // 
            this.mnuMsgCopyASCII.Name = "mnuMsgCopyASCII";
            this.mnuMsgCopyASCII.Size = new System.Drawing.Size(187, 24);
            this.mnuMsgCopyASCII.Text = "&ASCII";
            this.mnuMsgCopyASCII.Click += new System.EventHandler(this.mnuMsgCopyASCII_Click);
            // 
            // mnuMsgCopyHex
            // 
            this.mnuMsgCopyHex.Name = "mnuMsgCopyHex";
            this.mnuMsgCopyHex.Size = new System.Drawing.Size(187, 24);
            this.mnuMsgCopyHex.Text = "HE&X";
            this.mnuMsgCopyHex.Click += new System.EventHandler(this.mnuMsgCopyHex_Click);
            // 
            // copyForListenerToolStripMenuItem
            // 
            this.copyForListenerToolStripMenuItem.Name = "copyForListenerToolStripMenuItem";
            this.copyForListenerToolStripMenuItem.Size = new System.Drawing.Size(187, 24);
            this.copyForListenerToolStripMenuItem.Text = "Copy for listener";
            this.copyForListenerToolStripMenuItem.Click += new System.EventHandler(this.copyForListenerToolStripMenuItem_Click);
            // 
            // injectToolStripMenuItem
            // 
            this.injectToolStripMenuItem.Name = "injectToolStripMenuItem";
            this.injectToolStripMenuItem.Size = new System.Drawing.Size(163, 24);
            this.injectToolStripMenuItem.Text = "In&ject";
            this.injectToolStripMenuItem.Click += new System.EventHandler(this.injectToolStripMenuItem_Click);
            // 
            // mnuMsgReplay
            // 
            this.mnuMsgReplay.Name = "mnuMsgReplay";
            this.mnuMsgReplay.Size = new System.Drawing.Size(163, 24);
            this.mnuMsgReplay.Text = "&Edit / Replay";
            this.mnuMsgReplay.Click += new System.EventHandler(this.mnuMsgReplay_Click);
            // 
            // mnuMsgSocket
            // 
            this.mnuMsgSocket.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMsgSocketSD,
            this.mnuMsgSocketClose});
            this.mnuMsgSocket.Name = "mnuMsgSocket";
            this.mnuMsgSocket.Size = new System.Drawing.Size(163, 24);
            this.mnuMsgSocket.Text = "&Socket";
            // 
            // mnuMsgSocketSD
            // 
            this.mnuMsgSocketSD.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMsgSocketSDrecv,
            this.mnuMsgSocketSDsend,
            this.mnuMsgSocketSDboth});
            this.mnuMsgSocketSD.Name = "mnuMsgSocketSD";
            this.mnuMsgSocketSD.Size = new System.Drawing.Size(154, 24);
            this.mnuMsgSocketSD.Text = "shutdown";
            // 
            // mnuMsgSocketSDrecv
            // 
            this.mnuMsgSocketSDrecv.Name = "mnuMsgSocketSDrecv";
            this.mnuMsgSocketSDrecv.Size = new System.Drawing.Size(158, 24);
            this.mnuMsgSocketSDrecv.Text = "SD_RECEIVE";
            this.mnuMsgSocketSDrecv.Click += new System.EventHandler(this.mnuMsgSocketSDrecv_Click);
            // 
            // mnuMsgSocketSDsend
            // 
            this.mnuMsgSocketSDsend.Name = "mnuMsgSocketSDsend";
            this.mnuMsgSocketSDsend.Size = new System.Drawing.Size(158, 24);
            this.mnuMsgSocketSDsend.Text = "SD_SEND";
            this.mnuMsgSocketSDsend.Click += new System.EventHandler(this.mnuMsgSocketSDsend_Click);
            // 
            // mnuMsgSocketSDboth
            // 
            this.mnuMsgSocketSDboth.Name = "mnuMsgSocketSDboth";
            this.mnuMsgSocketSDboth.Size = new System.Drawing.Size(158, 24);
            this.mnuMsgSocketSDboth.Text = "SD_BOTH";
            this.mnuMsgSocketSDboth.Click += new System.EventHandler(this.mnuMsgSocketSDboth_Click);
            // 
            // mnuMsgSocketClose
            // 
            this.mnuMsgSocketClose.Name = "mnuMsgSocketClose";
            this.mnuMsgSocketClose.Size = new System.Drawing.Size(154, 24);
            this.mnuMsgSocketClose.Text = "closesocket";
            this.mnuMsgSocketClose.Click += new System.EventHandler(this.mnuMsgSocketClose_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(160, 6);
            // 
            // mnuAutoScroll
            // 
            this.mnuAutoScroll.CheckOnClick = true;
            this.mnuAutoScroll.Name = "mnuAutoScroll";
            this.mnuAutoScroll.Size = new System.Drawing.Size(163, 24);
            this.mnuAutoScroll.Text = "&Auto scroll";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.showrecvRecvAllToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(163, 24);
            this.viewToolStripMenuItem.Text = "&Filter view";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Checked = true;
            this.showToolStripMenuItem.CheckOnClick = true;
            this.showToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.showToolStripMenuItem.Text = "&Send methods";
            this.showToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showToolStripMenuItem_CheckedChanged);
            // 
            // showrecvRecvAllToolStripMenuItem
            // 
            this.showrecvRecvAllToolStripMenuItem.Checked = true;
            this.showrecvRecvAllToolStripMenuItem.CheckOnClick = true;
            this.showrecvRecvAllToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showrecvRecvAllToolStripMenuItem.Name = "showrecvRecvAllToolStripMenuItem";
            this.showrecvRecvAllToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.showrecvRecvAllToolStripMenuItem.Text = "&Recv methods";
            this.showrecvRecvAllToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showrecvRecvAllToolStripMenuItem_CheckedChanged);
            // 
            // mnuMsgClear
            // 
            this.mnuMsgClear.Name = "mnuMsgClear";
            this.mnuMsgClear.Size = new System.Drawing.Size(163, 24);
            this.mnuMsgClear.Text = "Clear &view";
            this.mnuMsgClear.Click += new System.EventHandler(this.mnuMsgClear_Click);
            // 
            // icoNotify
            // 
            this.icoNotify.ContextMenuStrip = this.mnuNotify;
            this.icoNotify.Icon = ((System.Drawing.Icon)(resources.GetObject("icoNotify.Icon")));
            this.icoNotify.Text = "PacketEditor";
            this.icoNotify.Visible = true;
            this.icoNotify.DoubleClick += new System.EventHandler(this.icoNotify_DoubleClick);
            // 
            // mnuNotify
            // 
            this.mnuNotify.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNotifyRestore,
            this.filtersToolStripMenuItem,
            this.mnuNotifyExit});
            this.mnuNotify.Name = "contextMenuStrip1";
            this.mnuNotify.ShowImageMargin = false;
            this.mnuNotify.Size = new System.Drawing.Size(93, 76);
            // 
            // mnuNotifyRestore
            // 
            this.mnuNotifyRestore.Name = "mnuNotifyRestore";
            this.mnuNotifyRestore.Size = new System.Drawing.Size(92, 24);
            this.mnuNotifyRestore.Text = "&Main";
            this.mnuNotifyRestore.Click += new System.EventHandler(this.icoNotify_DoubleClick);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.filtersToolStripMenuItem.Text = "&Filters";
            this.filtersToolStripMenuItem.Click += new System.EventHandler(this.filtersToolStripMenuItem_Click);
            // 
            // mnuNotifyExit
            // 
            this.mnuNotifyExit.Name = "mnuNotifyExit";
            this.mnuNotifyExit.Size = new System.Drawing.Size(92, 24);
            this.mnuNotifyExit.Text = "E&xit";
            this.mnuNotifyExit.Click += new System.EventHandler(this.mnuNotifyExit_Click);
            // 
            // mnuDNS
            // 
            this.mnuDNS.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuDNS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDNSClear});
            this.mnuDNS.Name = "mnuDNS";
            this.mnuDNS.Size = new System.Drawing.Size(147, 28);
            // 
            // mnuDNSClear
            // 
            this.mnuDNSClear.Name = "mnuDNSClear";
            this.mnuDNSClear.Size = new System.Drawing.Size(146, 24);
            this.mnuDNSClear.Text = "Clear &view";
            this.mnuDNSClear.Click += new System.EventHandler(this.mnuDNSClear_Click);
            // 
            // treeAPI
            // 
            this.treeAPI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeAPI.ContextMenuStrip = this.mnuAPI;
            this.treeAPI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeAPI.Location = new System.Drawing.Point(0, 0);
            this.treeAPI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeAPI.Name = "treeAPI";
            this.treeAPI.Size = new System.Drawing.Size(428, 255);
            this.treeAPI.TabIndex = 3;
            // 
            // mnuAPI
            // 
            this.mnuAPI.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuAPI.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAPIClear});
            this.mnuAPI.Name = "mnuAPI";
            this.mnuAPI.Size = new System.Drawing.Size(147, 28);
            // 
            // mnuAPIClear
            // 
            this.mnuAPIClear.Name = "mnuAPIClear";
            this.mnuAPIClear.Size = new System.Drawing.Size(146, 24);
            this.mnuAPIClear.Text = "Clear &view";
            this.mnuAPIClear.Click += new System.EventHandler(this.mnuAPIClear_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgridMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1083, 514);
            this.splitContainer1.SplitterDistance = 252;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.treeAPI);
            this.splitContainer2.Size = new System.Drawing.Size(1083, 257);
            this.splitContainer2.SplitterDistance = 648;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 4;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.treeDNS);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.txbRecordText);
            this.splitContainer3.Size = new System.Drawing.Size(646, 255);
            this.splitContainer3.SplitterDistance = 214;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 0;
            // 
            // treeDNS
            // 
            this.treeDNS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeDNS.ContextMenuStrip = this.mnuDNS;
            this.treeDNS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDNS.Location = new System.Drawing.Point(0, 0);
            this.treeDNS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeDNS.Name = "treeDNS";
            this.treeDNS.Size = new System.Drawing.Size(214, 255);
            this.treeDNS.TabIndex = 3;
            // 
            // txbRecordText
            // 
            this.txbRecordText.ContextMenuStrip = this.mnuReplay;
            this.txbRecordText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbRecordText.Location = new System.Drawing.Point(0, 0);
            this.txbRecordText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbRecordText.Multiline = true;
            this.txbRecordText.Name = "txbRecordText";
            this.txbRecordText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbRecordText.Size = new System.Drawing.Size(427, 255);
            this.txbRecordText.TabIndex = 0;
            // 
            // mnuReplay
            // 
            this.mnuReplay.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuReplay.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIReplay});
            this.mnuReplay.Name = "mnuReplay";
            this.mnuReplay.Size = new System.Drawing.Size(124, 28);
            // 
            // MIReplay
            // 
            this.MIReplay.Name = "MIReplay";
            this.MIReplay.Size = new System.Drawing.Size(123, 24);
            this.MIReplay.Text = "Replay";
            this.MIReplay.Click += new System.EventHandler(this.MIReplay_Click);
            // 
            // dsMain
            // 
            this.dsMain.DataSetName = "NewDataSet";
            this.dsMain.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.dsMain.Tables.AddRange(new System.Data.DataTable[] {
            this.sockets,
            this.filters,
            this.dns});
            // 
            // sockets
            // 
            this.sockets.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8});
            this.sockets.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "socket"}, true)});
            this.sockets.MinimumCapacity = 40;
            this.sockets.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColumn1};
            this.sockets.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.sockets.TableName = "sockets";
            // 
            // dataColumn1
            // 
            this.dataColumn1.AllowDBNull = false;
            this.dataColumn1.ColumnName = "socket";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "proto";
            this.dataColumn2.DataType = typeof(int);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "type";
            this.dataColumn3.DataType = typeof(int);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "lastapi";
            this.dataColumn4.DataType = typeof(int);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "fam";
            this.dataColumn5.DataType = typeof(int);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "lastmsg";
            this.dataColumn6.DataType = typeof(int);
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "local";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "remote";
            // 
            // filters
            // 
            this.filters.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn11,
            this.dataColumn14,
            this.dataColumn12,
            this.dataColumn13,
            this.dataColumn15,
            this.dataColumn16,
            this.dataColumn17,
            this.dataColumn18,
            this.dataColumn19,
            this.dataColumn20,
            this.dataColumn21,
            this.dataColumn22,
            this.dataColumn23,
            this.dataColumn24,
            this.dataColumn25,
            this.dataColumn26,
            this.dataColumn27});
            this.filters.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "id"}, true)});
            this.filters.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColumn11};
            this.filters.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.filters.TableName = "filters";
            // 
            // dataColumn11
            // 
            this.dataColumn11.AllowDBNull = false;
            this.dataColumn11.ColumnName = "id";
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "enabled";
            this.dataColumn14.DataType = typeof(bool);
            this.dataColumn14.DefaultValue = true;
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "MsgFunction";
            this.dataColumn12.DataType = typeof(byte[]);
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "MsgCatch";
            // 
            // dataColumn15
            // 
            this.dataColumn15.ColumnName = "MsgAction";
            this.dataColumn15.DataType = typeof(byte);
            // 
            // dataColumn16
            // 
            this.dataColumn16.ColumnName = "MsgReplace";
            // 
            // dataColumn17
            // 
            this.dataColumn17.ColumnName = "MsgError";
            this.dataColumn17.DataType = typeof(int);
            // 
            // dataColumn18
            // 
            this.dataColumn18.ColumnName = "APIFunction";
            this.dataColumn18.DataType = typeof(byte[]);
            // 
            // dataColumn19
            // 
            this.dataColumn19.ColumnName = "APICatch";
            // 
            // dataColumn20
            // 
            this.dataColumn20.ColumnName = "APIAction";
            this.dataColumn20.DataType = typeof(byte);
            // 
            // dataColumn21
            // 
            this.dataColumn21.ColumnName = "APIReplace";
            // 
            // dataColumn22
            // 
            this.dataColumn22.ColumnName = "APIError";
            this.dataColumn22.DataType = typeof(int);
            // 
            // dataColumn23
            // 
            this.dataColumn23.ColumnName = "DNSFunction";
            this.dataColumn23.DataType = typeof(byte[]);
            // 
            // dataColumn24
            // 
            this.dataColumn24.ColumnName = "DNSCatch";
            // 
            // dataColumn25
            // 
            this.dataColumn25.ColumnName = "DNSAction";
            this.dataColumn25.DataType = typeof(byte);
            // 
            // dataColumn26
            // 
            this.dataColumn26.ColumnName = "DNSReplace";
            // 
            // dataColumn27
            // 
            this.dataColumn27.ColumnName = "DNSError";
            this.dataColumn27.DataType = typeof(int);
            // 
            // dns
            // 
            this.dns.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn9,
            this.dataColumn10});
            this.dns.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "addr"}, true)});
            this.dns.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColumn9};
            this.dns.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.dns.TableName = "dns";
            // 
            // dataColumn9
            // 
            this.dataColumn9.AllowDBNull = false;
            this.dataColumn9.ColumnName = "addr";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "host";
            // 
            // mnuMain
            // 
            this.mnuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuInvoke,
            this.mnuTools,
            this.mnuOptions,
            this.helpToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mnuMain.Size = new System.Drawing.Size(1083, 28);
            this.mnuMain.TabIndex = 5;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.toolStripSeparator2,
            this.mnuFileAttach,
            this.mnuFileDetach,
            this.reAttachToolStripMenuItem,
            this.toolStripSeparator3,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(44, 24);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(167, 24);
            this.mnuFileOpen.Text = "&Open";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(164, 6);
            // 
            // mnuFileAttach
            // 
            this.mnuFileAttach.Name = "mnuFileAttach";
            this.mnuFileAttach.Size = new System.Drawing.Size(167, 24);
            this.mnuFileAttach.Text = "&Attach";
            this.mnuFileAttach.Click += new System.EventHandler(this.mnuFileAttach_Click);
            // 
            // mnuFileDetach
            // 
            this.mnuFileDetach.Enabled = false;
            this.mnuFileDetach.Name = "mnuFileDetach";
            this.mnuFileDetach.Size = new System.Drawing.Size(167, 24);
            this.mnuFileDetach.Text = "&Detach";
            this.mnuFileDetach.Click += new System.EventHandler(this.mnuFileDetach_Click);
            // 
            // reAttachToolStripMenuItem
            // 
            this.reAttachToolStripMenuItem.Enabled = false;
            this.reAttachToolStripMenuItem.Name = "reAttachToolStripMenuItem";
            this.reAttachToolStripMenuItem.Size = new System.Drawing.Size(167, 24);
            this.reAttachToolStripMenuItem.Text = "reAttach";
            this.reAttachToolStripMenuItem.Click += new System.EventHandler(this.reAttachToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(164, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(167, 24);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuInvoke
            // 
            this.mnuInvoke.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInvokeFreeze});
            this.mnuInvoke.Name = "mnuInvoke";
            this.mnuInvoke.Size = new System.Drawing.Size(64, 24);
            this.mnuInvoke.Text = "&Invoke";
            // 
            // mnuInvokeFreeze
            // 
            this.mnuInvokeFreeze.Name = "mnuInvokeFreeze";
            this.mnuInvokeFreeze.Size = new System.Drawing.Size(121, 24);
            this.mnuInvokeFreeze.Text = "Freeze";
            this.mnuInvokeFreeze.Click += new System.EventHandler(this.mnuInvokeFreeze_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuToolsMonitor,
            this.mnuToolsFilter,
            this.MnuToolsProxy,
            this.toolToggleFilter,
            this.toolStripSeparator1,
            this.mnuToolsSockets,
            this.toolStripSeparator5,
            this.mnuToolsFilters,
            this.toolStripSeparator6});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(57, 24);
            this.mnuTools.Text = "&Tools";
            // 
            // mnuToolsMonitor
            // 
            this.mnuToolsMonitor.Checked = true;
            this.mnuToolsMonitor.CheckOnClick = true;
            this.mnuToolsMonitor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuToolsMonitor.Name = "mnuToolsMonitor";
            this.mnuToolsMonitor.Size = new System.Drawing.Size(217, 26);
            this.mnuToolsMonitor.Text = "Enable &monitor";
            this.mnuToolsMonitor.CheckedChanged += new System.EventHandler(this.mnuToolsMonitor_CheckedChanged);
            // 
            // mnuToolsFilter
            // 
            this.mnuToolsFilter.Checked = true;
            this.mnuToolsFilter.CheckOnClick = true;
            this.mnuToolsFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuToolsFilter.Name = "mnuToolsFilter";
            this.mnuToolsFilter.Size = new System.Drawing.Size(217, 26);
            this.mnuToolsFilter.Text = "Enable &filters";
            this.mnuToolsFilter.CheckedChanged += new System.EventHandler(this.mnuToolsFilter_CheckedChanged);
            // 
            // MnuToolsProxy
            // 
            this.MnuToolsProxy.CheckOnClick = true;
            this.MnuToolsProxy.Name = "MnuToolsProxy";
            this.MnuToolsProxy.Size = new System.Drawing.Size(217, 26);
            this.MnuToolsProxy.Text = "&Listen for requests";
            this.MnuToolsProxy.Click += new System.EventHandler(this.MnuToolsProxy_Click);
            // 
            // toolToggleFilter
            // 
            this.toolToggleFilter.Name = "toolToggleFilter";
            this.toolToggleFilter.Size = new System.Drawing.Size(217, 26);
            this.toolToggleFilter.Text = "Enable &External Filter";
            this.toolToggleFilter.Click += new System.EventHandler(this.toolToggleFilter_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(214, 6);
            // 
            // mnuToolsSockets
            // 
            this.mnuToolsSockets.Name = "mnuToolsSockets";
            this.mnuToolsSockets.Size = new System.Drawing.Size(217, 26);
            this.mnuToolsSockets.Text = "Sockets";
            this.mnuToolsSockets.Click += new System.EventHandler(this.mnuToolsSockets_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(214, 6);
            // 
            // mnuToolsFilters
            // 
            this.mnuToolsFilters.Name = "mnuToolsFilters";
            this.mnuToolsFilters.Size = new System.Drawing.Size(217, 26);
            this.mnuToolsFilters.Text = "Set &internal filters";
            this.mnuToolsFilters.Click += new System.EventHandler(this.mnuToolsFilters_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(214, 6);
            // 
            // mnuOptions
            // 
            this.mnuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOptionsOntop});
            this.mnuOptions.Name = "mnuOptions";
            this.mnuOptions.Size = new System.Drawing.Size(73, 24);
            this.mnuOptions.Text = "&Options";
            // 
            // mnuOptionsOntop
            // 
            this.mnuOptionsOntop.CheckOnClick = true;
            this.mnuOptionsOntop.Name = "mnuOptionsOntop";
            this.mnuOptionsOntop.Size = new System.Drawing.Size(127, 24);
            this.mnuOptionsOntop.Text = "On Top";
            this.mnuOptionsOntop.CheckedChanged += new System.EventHandler(this.mnuOptionsOntop_CheckedChanged);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpHelp,
            this.mnuHelpWebsite});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // mnuHelpHelp
            // 
            this.mnuHelpHelp.Name = "mnuHelpHelp";
            this.mnuHelpHelp.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mnuHelpHelp.Size = new System.Drawing.Size(221, 24);
            this.mnuHelpHelp.Text = "PacketEditor &Help";
            this.mnuHelpHelp.Click += new System.EventHandler(this.mnuHelpHelp_Click);
            // 
            // mnuHelpWebsite
            // 
            this.mnuHelpWebsite.Name = "mnuHelpWebsite";
            this.mnuHelpWebsite.Size = new System.Drawing.Size(221, 24);
            this.mnuHelpWebsite.Text = "&About";
            this.mnuHelpWebsite.Click += new System.EventHandler(this.mnuHelpWebsite_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsExternalFilter});
            this.statusStrip1.Location = new System.Drawing.Point(0, 517);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1083, 25);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsExternalFilter
            // 
            this.tsExternalFilter.Name = "tsExternalFilter";
            this.tsExternalFilter.Size = new System.Drawing.Size(97, 20);
            this.tsExternalFilter.Text = "External filter";
            // 
            // timerPython
            // 
            this.timerPython.Interval = 1000;
            this.timerPython.Tick += new System.EventHandler(this.timerPython_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 542);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced Packet Editor - AppSec Labs";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.Deactivate += new System.EventHandler(this.frmMain_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgridMain)).EndInit();
            this.mnuMsg.ResumeLayout(false);
            this.mnuNotify.ResumeLayout(false);
            this.mnuDNS.ResumeLayout(false);
            this.mnuAPI.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.mnuReplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sockets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dns)).EndInit();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgridMain;
        private System.Windows.Forms.NotifyIcon icoNotify;
        private System.Windows.Forms.ContextMenuStrip mnuNotify;
        private System.Windows.Forms.ToolStripMenuItem mnuNotifyRestore;
        private System.Windows.Forms.ToolStripMenuItem mnuNotifyExit;
        private System.Windows.Forms.ContextMenuStrip mnuMsg;
        private System.Windows.Forms.ToolStripMenuItem mnuMsgReplay;
        private System.Windows.Forms.TreeView treeAPI;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripMenuItem mnuMsgSocket;
        private System.Windows.Forms.ToolStripMenuItem mnuMsgSocketSD;
        private System.Windows.Forms.ToolStripMenuItem mnuMsgSocketClose;
        private System.Windows.Forms.ToolStripMenuItem mnuMsgSocketSDrecv;
        private System.Windows.Forms.ToolStripMenuItem mnuMsgSocketSDsend;
        private System.Windows.Forms.ToolStripMenuItem mnuMsgSocketSDboth;
        private System.Data.DataTable sockets;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataTable filters;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn socket;
        private System.Windows.Forms.DataGridViewTextBoxColumn proto;
        private System.Windows.Forms.DataGridViewTextBoxColumn method;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn data;
        private System.Windows.Forms.DataGridViewTextBoxColumn rawdata;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileAttach;
        private System.Windows.Forms.ToolStripMenuItem mnuFileDetach;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsMonitor;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsFilter;
        private System.Windows.Forms.ToolStripMenuItem mnuOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuOptionsOntop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsSockets;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataTable dns;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn10;
        private System.Data.DataColumn dataColumn11;
        private System.Data.DataColumn dataColumn14;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsFilters;
        private System.Data.DataSet dsMain;
        private System.Data.DataColumn dataColumn12;
        private System.Data.DataColumn dataColumn13;
        private System.Data.DataColumn dataColumn15;
        private System.Data.DataColumn dataColumn16;
        private System.Data.DataColumn dataColumn17;
        private System.Data.DataColumn dataColumn18;
        private System.Data.DataColumn dataColumn19;
        private System.Data.DataColumn dataColumn20;
        private System.Data.DataColumn dataColumn21;
        private System.Data.DataColumn dataColumn22;
        private System.Data.DataColumn dataColumn23;
        private System.Data.DataColumn dataColumn24;
        private System.Data.DataColumn dataColumn25;
        private System.Data.DataColumn dataColumn26;
        private System.Data.DataColumn dataColumn27;
        private System.Windows.Forms.ToolStripMenuItem mnuInvoke;
        private System.Windows.Forms.ToolStripMenuItem mnuInvokeFreeze;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpWebsite;
        private System.Windows.Forms.ContextMenuStrip mnuDNS;
        private System.Windows.Forms.ToolStripMenuItem mnuDNSClear;
        private System.Windows.Forms.ContextMenuStrip mnuAPI;
        private System.Windows.Forms.ToolStripMenuItem mnuAPIClear;
        private System.Windows.Forms.ToolStripMenuItem mnuMsgClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuMsgCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuMsgCopyASCII;
        private System.Windows.Forms.ToolStripMenuItem mnuMsgCopyHex;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reAttachToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem injectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuToolsProxy;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showrecvRecvAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAutoScroll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TreeView treeDNS;
        private System.Windows.Forms.TextBox txbRecordText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsExternalFilter;
        private System.Windows.Forms.ToolStripMenuItem toolToggleFilter;
        private System.Windows.Forms.ContextMenuStrip mnuReplay;
        private System.Windows.Forms.ToolStripMenuItem MIReplay;
        private System.Windows.Forms.Timer timerPython;
        private System.Windows.Forms.ToolStripMenuItem copyForListenerToolStripMenuItem;
    }
}

