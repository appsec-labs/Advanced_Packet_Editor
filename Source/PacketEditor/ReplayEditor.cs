using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO.Pipes;
using Be.Windows.Forms;

namespace PacketEditor
{
    public partial class ReplayEditor : Form
    {
        ByteCollection bcBytes = new ByteCollection();
        NamedPipeClientStream pipeOut;
        int isocket = new int();
        Glob.PipeHeader strPipeMsgOut = new Glob.PipeHeader();

        public ReplayEditor(byte[] ReplayData, int socket, NamedPipeClientStream pipe)
        {
            InitializeComponent();
            
            DynamicByteProvider BytePro = new DynamicByteProvider(ReplayData);

            hexBox1.ByteProvider = BytePro;
            isocket = socket;
            pipeOut = pipe;
            txtSockID.Text = socket.ToString("X4");
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            isocket = 0;
            this.Close();
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            DynamicByteProvider BytePro = hexBox1.ByteProvider as DynamicByteProvider;
            try
            {
                strPipeMsgOut.sockid = int.Parse(txtSockID.Text, System.Globalization.NumberStyles.HexNumber);
            }
            catch
            {
                MessageBox.Show("Invalid socket ID.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSockID.SelectAll();
                txtSockID.Focus();
                return;
            }

            bcBytes = BytePro.Bytes;
            strPipeMsgOut.command = Glob.CMD_INJECT;
            strPipeMsgOut.function = Glob.FUNC_SEND;
            strPipeMsgOut.datasize = bcBytes.Count;

            for (int times = int.Parse(txtTimes.Text); times > 0; times--)
            {
                pipeOut.Write(Glob.RawSerializeEx(strPipeMsgOut), 0, Marshal.SizeOf(strPipeMsgOut));
                pipeOut.Write(bcBytes.GetBytes(), 0, strPipeMsgOut.datasize);
            }
        }
        private void frmReplayEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }
        private void hexBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }
        private void frmReplayEditor_Activated(object sender, EventArgs e)
        {
            if (this.TopMost == true)
            {
                this.Opacity = 1;
            }
        }
        private void frmReplayEditor_Deactivate(object sender, EventArgs e)
        {
            if (this.TopMost == true)
            {
                this.Opacity = .5;
            }
        }
    }
}
