namespace PacketEditor
{
    partial class EditFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditFilter));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rdoMsgMethodH = new System.Windows.Forms.RadioButton();
            this.rdoMsgMethodA = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtMsgReplace = new System.Windows.Forms.TextBox();
            this.rdoMsgActionR = new System.Windows.Forms.RadioButton();
            this.rdoMsgActionE = new System.Windows.Forms.RadioButton();
            this.cmbMsgActionE = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtMsgCatch = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkMsg = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rdoAPIMethodH = new System.Windows.Forms.RadioButton();
            this.rdoAPIMethodA = new System.Windows.Forms.RadioButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtAPICatch = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtAPIReplace = new System.Windows.Forms.TextBox();
            this.rdoAPIActionR = new System.Windows.Forms.RadioButton();
            this.rdoAPIActionE = new System.Windows.Forms.RadioButton();
            this.cmbAPIActionE = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAPI = new System.Windows.Forms.CheckedListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.rdoDNSMethodH = new System.Windows.Forms.RadioButton();
            this.rdoDNSMethodA = new System.Windows.Forms.RadioButton();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.txtDNSCatch = new System.Windows.Forms.TextBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.txtDNSReplace = new System.Windows.Forms.TextBox();
            this.rdoDNSActionR = new System.Windows.Forms.RadioButton();
            this.rdoDNSActionE = new System.Windows.Forms.RadioButton();
            this.cmbDNSActionE = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkDNS = new System.Windows.Forms.CheckedListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(541, 298);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(533, 272);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Message";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rdoMsgMethodH);
            this.groupBox6.Controls.Add(this.rdoMsgMethodA);
            this.groupBox6.Location = new System.Drawing.Point(162, 235);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(363, 31);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Method";
            // 
            // rdoMsgMethodH
            // 
            this.rdoMsgMethodH.AutoSize = true;
            this.rdoMsgMethodH.Location = new System.Drawing.Point(212, 11);
            this.rdoMsgMethodH.Name = "rdoMsgMethodH";
            this.rdoMsgMethodH.Size = new System.Drawing.Size(44, 17);
            this.rdoMsgMethodH.TabIndex = 1;
            this.rdoMsgMethodH.Text = "Hex";
            this.rdoMsgMethodH.UseVisualStyleBackColor = true;
            // 
            // rdoMsgMethodA
            // 
            this.rdoMsgMethodA.AutoSize = true;
            this.rdoMsgMethodA.Checked = true;
            this.rdoMsgMethodA.Location = new System.Drawing.Point(91, 11);
            this.rdoMsgMethodA.Name = "rdoMsgMethodA";
            this.rdoMsgMethodA.Size = new System.Drawing.Size(52, 17);
            this.rdoMsgMethodA.TabIndex = 0;
            this.rdoMsgMethodA.TabStop = true;
            this.rdoMsgMethodA.Text = "ASCII";
            this.rdoMsgMethodA.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtMsgReplace);
            this.groupBox5.Controls.Add(this.rdoMsgActionR);
            this.groupBox5.Controls.Add(this.rdoMsgActionE);
            this.groupBox5.Controls.Add(this.cmbMsgActionE);
            this.groupBox5.Location = new System.Drawing.Point(162, 87);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(363, 142);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Action";
            // 
            // txtMsgReplace
            // 
            this.txtMsgReplace.Location = new System.Drawing.Point(3, 42);
            this.txtMsgReplace.Multiline = true;
            this.txtMsgReplace.Name = "txtMsgReplace";
            this.txtMsgReplace.Size = new System.Drawing.Size(357, 56);
            this.txtMsgReplace.TabIndex = 1;
            this.txtMsgReplace.TextChanged += new System.EventHandler(this.txtMsgReplace_TextChanged);
            // 
            // rdoMsgActionR
            // 
            this.rdoMsgActionR.AutoSize = true;
            this.rdoMsgActionR.Location = new System.Drawing.Point(6, 19);
            this.rdoMsgActionR.Name = "rdoMsgActionR";
            this.rdoMsgActionR.Size = new System.Drawing.Size(65, 17);
            this.rdoMsgActionR.TabIndex = 0;
            this.rdoMsgActionR.Text = "Replace";
            this.rdoMsgActionR.UseVisualStyleBackColor = true;
            // 
            // rdoMsgActionE
            // 
            this.rdoMsgActionE.AutoSize = true;
            this.rdoMsgActionE.Checked = true;
            this.rdoMsgActionE.Location = new System.Drawing.Point(6, 108);
            this.rdoMsgActionE.Name = "rdoMsgActionE";
            this.rdoMsgActionE.Size = new System.Drawing.Size(108, 17);
            this.rdoMsgActionE.TabIndex = 2;
            this.rdoMsgActionE.TabStop = true;
            this.rdoMsgActionE.Text = "WSASetLastError";
            this.rdoMsgActionE.UseVisualStyleBackColor = true;
            // 
            // cmbMsgActionE
            // 
            this.cmbMsgActionE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMsgActionE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMsgActionE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMsgActionE.Items.AddRange(new object[] {
            "NO_ERROR",
            "WSAEACCES",
            "WSAECONNABORTED",
            "WSAECONNRESET",
            "WSAEFAULT",
            "WSAEHOSTUNREACH",
            "WSAEINPROGRESS",
            "WSAEINTR",
            "WSAEINVAL",
            "WSAEMSGSIZE",
            "WSAENETDOWN",
            "WSAENETRESET",
            "WSAENOBUFS",
            "WSAENOTCONN",
            "WSAENOTSOCK",
            "WSAEOPNOTSUPP",
            "WSAESHUTDOWN",
            "WSAETIMEDOUT",
            "WSAEWOULDBLOCK",
            "WSANOTINITIALISED"});
            this.cmbMsgActionE.Location = new System.Drawing.Point(120, 108);
            this.cmbMsgActionE.Name = "cmbMsgActionE";
            this.cmbMsgActionE.Size = new System.Drawing.Size(237, 21);
            this.cmbMsgActionE.Sorted = true;
            this.cmbMsgActionE.TabIndex = 3;
            this.cmbMsgActionE.SelectedIndexChanged += new System.EventHandler(this.cmbMsgActionE_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtMsgCatch);
            this.groupBox4.Location = new System.Drawing.Point(162, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(363, 75);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Catch";
            // 
            // txtMsgCatch
            // 
            this.txtMsgCatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsgCatch.Location = new System.Drawing.Point(3, 16);
            this.txtMsgCatch.Multiline = true;
            this.txtMsgCatch.Name = "txtMsgCatch";
            this.txtMsgCatch.Size = new System.Drawing.Size(357, 56);
            this.txtMsgCatch.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkMsg);
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 263);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Function";
            // 
            // chkMsg
            // 
            this.chkMsg.CheckOnClick = true;
            this.chkMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkMsg.FormattingEnabled = true;
            this.chkMsg.Items.AddRange(new object[] {
            "send()",
            "sendto()",
            "WSASend()",
            "WSASendTo()",
            "WSASendDisconnect()",
            "recv()",
            "recvfrom()",
            "WSARecv()",
            "WSARecvFrom()",
            "WSARecvDisconnect()"});
            this.chkMsg.Location = new System.Drawing.Point(3, 16);
            this.chkMsg.Name = "chkMsg";
            this.chkMsg.Size = new System.Drawing.Size(139, 244);
            this.chkMsg.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.groupBox8);
            this.tabPage2.Controls.Add(this.groupBox9);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(533, 272);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "API";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rdoAPIMethodH);
            this.groupBox7.Controls.Add(this.rdoAPIMethodA);
            this.groupBox7.Location = new System.Drawing.Point(162, 235);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(363, 31);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Method";
            // 
            // rdoAPIMethodH
            // 
            this.rdoAPIMethodH.AutoSize = true;
            this.rdoAPIMethodH.Location = new System.Drawing.Point(212, 11);
            this.rdoAPIMethodH.Name = "rdoAPIMethodH";
            this.rdoAPIMethodH.Size = new System.Drawing.Size(44, 17);
            this.rdoAPIMethodH.TabIndex = 1;
            this.rdoAPIMethodH.Text = "Hex";
            this.rdoAPIMethodH.UseVisualStyleBackColor = true;
            // 
            // rdoAPIMethodA
            // 
            this.rdoAPIMethodA.AutoSize = true;
            this.rdoAPIMethodA.Checked = true;
            this.rdoAPIMethodA.Location = new System.Drawing.Point(91, 11);
            this.rdoAPIMethodA.Name = "rdoAPIMethodA";
            this.rdoAPIMethodA.Size = new System.Drawing.Size(52, 17);
            this.rdoAPIMethodA.TabIndex = 0;
            this.rdoAPIMethodA.TabStop = true;
            this.rdoAPIMethodA.Text = "ASCII";
            this.rdoAPIMethodA.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtAPICatch);
            this.groupBox8.Location = new System.Drawing.Point(162, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(363, 75);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Catch";
            // 
            // txtAPICatch
            // 
            this.txtAPICatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAPICatch.Location = new System.Drawing.Point(3, 16);
            this.txtAPICatch.Multiline = true;
            this.txtAPICatch.Name = "txtAPICatch";
            this.txtAPICatch.Size = new System.Drawing.Size(357, 56);
            this.txtAPICatch.TabIndex = 0;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.txtAPIReplace);
            this.groupBox9.Controls.Add(this.rdoAPIActionR);
            this.groupBox9.Controls.Add(this.rdoAPIActionE);
            this.groupBox9.Controls.Add(this.cmbAPIActionE);
            this.groupBox9.Location = new System.Drawing.Point(162, 87);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(363, 142);
            this.groupBox9.TabIndex = 2;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Action";
            // 
            // txtAPIReplace
            // 
            this.txtAPIReplace.Location = new System.Drawing.Point(3, 42);
            this.txtAPIReplace.Multiline = true;
            this.txtAPIReplace.Name = "txtAPIReplace";
            this.txtAPIReplace.Size = new System.Drawing.Size(357, 56);
            this.txtAPIReplace.TabIndex = 1;
            this.txtAPIReplace.TextChanged += new System.EventHandler(this.txtAPIReplace_TextChanged);
            // 
            // rdoAPIActionR
            // 
            this.rdoAPIActionR.AutoSize = true;
            this.rdoAPIActionR.Location = new System.Drawing.Point(6, 19);
            this.rdoAPIActionR.Name = "rdoAPIActionR";
            this.rdoAPIActionR.Size = new System.Drawing.Size(65, 17);
            this.rdoAPIActionR.TabIndex = 0;
            this.rdoAPIActionR.Text = "Replace";
            this.rdoAPIActionR.UseVisualStyleBackColor = true;
            // 
            // rdoAPIActionE
            // 
            this.rdoAPIActionE.AutoSize = true;
            this.rdoAPIActionE.Checked = true;
            this.rdoAPIActionE.Location = new System.Drawing.Point(6, 108);
            this.rdoAPIActionE.Name = "rdoAPIActionE";
            this.rdoAPIActionE.Size = new System.Drawing.Size(108, 17);
            this.rdoAPIActionE.TabIndex = 2;
            this.rdoAPIActionE.TabStop = true;
            this.rdoAPIActionE.Text = "WSASetLastError";
            this.rdoAPIActionE.UseVisualStyleBackColor = true;
            // 
            // cmbAPIActionE
            // 
            this.cmbAPIActionE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAPIActionE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAPIActionE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAPIActionE.Items.AddRange(new object[] {
            "NO_ERROR",
            "WSAEACCES",
            "WSAEADDRINUSE",
            "WSAEADDRNOTAVAIL",
            "WSAEAFNOSUPPORT",
            "WSAEALREADY",
            "WSAECONNABORTED",
            "WSAECONNREFUSED",
            "WSAECONNRESET",
            "WSAEDESTADDRREQ",
            "WSAEDISCON",
            "WSAEFAULT",
            "WSAEINPROGRESS",
            "WSAEINTR",
            "WSAEINVAL",
            "WSAEISCONN",
            "WSAEMFILE",
            "WSAEMSGSIZE",
            "WSAENETDOWN",
            "WSAENETRESET",
            "WSAENETUNREACH",
            "WSAENOBUFS",
            "WSAENOPROTOOPT",
            "WSAENOTCONN",
            "WSAENOTSOCK",
            "WSAEOPNOTSUPP",
            "WSAEPROTONOSUPPORT",
            "WSAEPROTOTYPE",
            "WSAESHUTDOWN",
            "WSAESOCKTNOSUPPORT",
            "WSAETIMEDOUT",
            "WSAEWOULDBLOCK",
            "WSANOTINITIALISED",
            "WSATRY_AGAIN"});
            this.cmbAPIActionE.Location = new System.Drawing.Point(120, 108);
            this.cmbAPIActionE.Name = "cmbAPIActionE";
            this.cmbAPIActionE.Size = new System.Drawing.Size(237, 21);
            this.cmbAPIActionE.Sorted = true;
            this.cmbAPIActionE.TabIndex = 3;
            this.cmbAPIActionE.SelectedIndexChanged += new System.EventHandler(this.cmbAPIActionE_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAPI);
            this.groupBox2.Location = new System.Drawing.Point(0, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(145, 263);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Function";
            // 
            // chkAPI
            // 
            this.chkAPI.CheckOnClick = true;
            this.chkAPI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkAPI.FormattingEnabled = true;
            this.chkAPI.Items.AddRange(new object[] {
            "WSAAccept()",
            "accept()",
            "WSAConnect()",
            "connect()",
            "WSASocket()",
            "bind()",
            "WSASendTo()",
            "WSARecvFrom()",
            "sendto()",
            "recvfrom()",
            "socket()",
            "closesocket()",
            "listen()",
            "shutdown()"});
            this.chkAPI.Location = new System.Drawing.Point(3, 16);
            this.chkAPI.Name = "chkAPI";
            this.chkAPI.Size = new System.Drawing.Size(139, 244);
            this.chkAPI.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox10);
            this.tabPage3.Controls.Add(this.groupBox11);
            this.tabPage3.Controls.Add(this.groupBox12);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(533, 272);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "DNS";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.rdoDNSMethodH);
            this.groupBox10.Controls.Add(this.rdoDNSMethodA);
            this.groupBox10.Location = new System.Drawing.Point(162, 235);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(363, 31);
            this.groupBox10.TabIndex = 3;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Method";
            // 
            // rdoDNSMethodH
            // 
            this.rdoDNSMethodH.AutoSize = true;
            this.rdoDNSMethodH.Location = new System.Drawing.Point(212, 11);
            this.rdoDNSMethodH.Name = "rdoDNSMethodH";
            this.rdoDNSMethodH.Size = new System.Drawing.Size(44, 17);
            this.rdoDNSMethodH.TabIndex = 1;
            this.rdoDNSMethodH.Text = "Hex";
            this.rdoDNSMethodH.UseVisualStyleBackColor = true;
            // 
            // rdoDNSMethodA
            // 
            this.rdoDNSMethodA.AutoSize = true;
            this.rdoDNSMethodA.Checked = true;
            this.rdoDNSMethodA.Location = new System.Drawing.Point(91, 11);
            this.rdoDNSMethodA.Name = "rdoDNSMethodA";
            this.rdoDNSMethodA.Size = new System.Drawing.Size(52, 17);
            this.rdoDNSMethodA.TabIndex = 0;
            this.rdoDNSMethodA.TabStop = true;
            this.rdoDNSMethodA.Text = "ASCII";
            this.rdoDNSMethodA.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.txtDNSCatch);
            this.groupBox11.Location = new System.Drawing.Point(162, 6);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(363, 75);
            this.groupBox11.TabIndex = 1;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Catch";
            // 
            // txtDNSCatch
            // 
            this.txtDNSCatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDNSCatch.Location = new System.Drawing.Point(3, 16);
            this.txtDNSCatch.Multiline = true;
            this.txtDNSCatch.Name = "txtDNSCatch";
            this.txtDNSCatch.Size = new System.Drawing.Size(357, 56);
            this.txtDNSCatch.TabIndex = 0;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.txtDNSReplace);
            this.groupBox12.Controls.Add(this.rdoDNSActionR);
            this.groupBox12.Controls.Add(this.rdoDNSActionE);
            this.groupBox12.Controls.Add(this.cmbDNSActionE);
            this.groupBox12.Location = new System.Drawing.Point(162, 87);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(363, 142);
            this.groupBox12.TabIndex = 2;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Action";
            // 
            // txtDNSReplace
            // 
            this.txtDNSReplace.Location = new System.Drawing.Point(3, 42);
            this.txtDNSReplace.Multiline = true;
            this.txtDNSReplace.Name = "txtDNSReplace";
            this.txtDNSReplace.Size = new System.Drawing.Size(357, 56);
            this.txtDNSReplace.TabIndex = 1;
            this.txtDNSReplace.TextChanged += new System.EventHandler(this.txtDNSReplace_TextChanged);
            // 
            // rdoDNSActionR
            // 
            this.rdoDNSActionR.AutoSize = true;
            this.rdoDNSActionR.Location = new System.Drawing.Point(6, 19);
            this.rdoDNSActionR.Name = "rdoDNSActionR";
            this.rdoDNSActionR.Size = new System.Drawing.Size(65, 17);
            this.rdoDNSActionR.TabIndex = 0;
            this.rdoDNSActionR.Text = "Replace";
            this.rdoDNSActionR.UseVisualStyleBackColor = true;
            // 
            // rdoDNSActionE
            // 
            this.rdoDNSActionE.AutoSize = true;
            this.rdoDNSActionE.Checked = true;
            this.rdoDNSActionE.Location = new System.Drawing.Point(6, 108);
            this.rdoDNSActionE.Name = "rdoDNSActionE";
            this.rdoDNSActionE.Size = new System.Drawing.Size(108, 17);
            this.rdoDNSActionE.TabIndex = 2;
            this.rdoDNSActionE.TabStop = true;
            this.rdoDNSActionE.Text = "WSASetLastError";
            this.rdoDNSActionE.UseVisualStyleBackColor = true;
            // 
            // cmbDNSActionE
            // 
            this.cmbDNSActionE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDNSActionE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDNSActionE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDNSActionE.Items.AddRange(new object[] {
            "NO_ERROR",
            "WSAEAFNOSUPPORT",
            "WSAEFAULT",
            "WSAEFAULT",
            "WSAEINPROGRESS",
            "WSAEINTR",
            "WSAENETDOWN",
            "WSAHOST_NOT_FOUND",
            "WSANO_DATA",
            "WSANO_RECOVERY",
            "WSANOTINITIALISED",
            "WSATRY_AGAIN"});
            this.cmbDNSActionE.Location = new System.Drawing.Point(120, 108);
            this.cmbDNSActionE.Name = "cmbDNSActionE";
            this.cmbDNSActionE.Size = new System.Drawing.Size(237, 21);
            this.cmbDNSActionE.Sorted = true;
            this.cmbDNSActionE.TabIndex = 3;
            this.cmbDNSActionE.SelectedIndexChanged += new System.EventHandler(this.cmbDNSActionE_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkDNS);
            this.groupBox3.Location = new System.Drawing.Point(0, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(145, 263);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Function";
            // 
            // chkDNS
            // 
            this.chkDNS.CheckOnClick = true;
            this.chkDNS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkDNS.FormattingEnabled = true;
            this.chkDNS.Items.AddRange(new object[] {
            "gethostname()",
            "gethostbyname()",
            "gethostbyaddr()"});
            this.chkDNS.Location = new System.Drawing.Point(3, 16);
            this.chkDNS.Name = "chkDNS";
            this.chkDNS.Size = new System.Drawing.Size(139, 244);
            this.chkDNS.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.Location = new System.Drawing.Point(459, 304);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOK.Location = new System.Drawing.Point(297, 304);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filter Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(73, 306);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(136, 20);
            this.txtName.TabIndex = 0;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(226, 308);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkEnabled.TabIndex = 2;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnApply.Location = new System.Drawing.Point(378, 304);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 6;
            this.btnApply.Text = "&Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // EditFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 331);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EditFilter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Filter";
            this.Activated += new System.EventHandler(this.frmEditFilters_Activated);
            this.Deactivate += new System.EventHandler(this.frmEditFilters_Deactivate);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox chkMsg;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox chkAPI;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox chkDNS;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtMsgCatch;
        private System.Windows.Forms.ComboBox cmbMsgActionE;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rdoMsgMethodH;
        private System.Windows.Forms.RadioButton rdoMsgMethodA;
        private System.Windows.Forms.TextBox txtMsgReplace;
        private System.Windows.Forms.RadioButton rdoMsgActionR;
        private System.Windows.Forms.RadioButton rdoMsgActionE;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton rdoAPIMethodH;
        private System.Windows.Forms.RadioButton rdoAPIMethodA;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox txtAPICatch;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox txtAPIReplace;
        private System.Windows.Forms.RadioButton rdoAPIActionR;
        private System.Windows.Forms.RadioButton rdoAPIActionE;
        private System.Windows.Forms.ComboBox cmbAPIActionE;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.RadioButton rdoDNSMethodH;
        private System.Windows.Forms.RadioButton rdoDNSMethodA;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox txtDNSCatch;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.TextBox txtDNSReplace;
        private System.Windows.Forms.RadioButton rdoDNSActionR;
        private System.Windows.Forms.RadioButton rdoDNSActionE;
        private System.Windows.Forms.ComboBox cmbDNSActionE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Button btnApply;
    }
}