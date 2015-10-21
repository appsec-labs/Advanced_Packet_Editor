using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO.Pipes;
using System.Runtime.InteropServices;

namespace PacketEditor
{
    public partial class Sockets : Form
    {
        Glob.PipeHeader strPipeMsgOut = new Glob.PipeHeader();
        NamedPipeClientStream pipeOut;

        public Sockets(DataTable dtSockets, Main.SockInfo sinfo, NamedPipeClientStream pout)
        {
            int i;
            InitializeComponent();
            pipeOut = pout;
            foreach (DataRow drow in dtSockets.Rows)
            {
                i = dgridSockets.Rows.Add();
                dgridSockets.Rows[i].Cells["socket"].Value = ((int)drow["socket"]).ToString("X4");
                if (drow["proto"].ToString() != String.Empty)
                    dgridSockets.Rows[i].Cells["proto"].Value = sinfo.proto((int)drow["proto"]);
                if (drow["fam"].ToString() != String.Empty)
                    if (((int)drow["fam"] >= 0) && ((int)drow["fam"] <= sinfo.afamily.Length - 1))
                        dgridSockets.Rows[i].Cells["fam"].Value = sinfo.afamily[(int)drow["fam"]];
                if (drow["type"].ToString() != String.Empty)
                    if (((int)drow["type"] >= 0) && ((int)drow["type"] <= sinfo.atype.Length - 1))
                        dgridSockets.Rows[i].Cells["type"].Value = sinfo.atype[(int)drow["type"]];
                if (drow["lastapi"].ToString() != String.Empty)
                    dgridSockets.Rows[i].Cells["lastapi"].Value = sinfo.api((int)drow["lastapi"]);
                if (drow["lastmsg"].ToString() != String.Empty)
                    dgridSockets.Rows[i].Cells["lastmsg"].Value = sinfo.msg((int) drow["lastmsg"]);
                dgridSockets.Rows[i].Cells["local"].Value = drow["local"].ToString();
                dgridSockets.Rows[i].Cells["remote"].Value = drow["remote"].ToString();
            }
        }
        private void frmSockets_Activated(object sender, EventArgs e)
        {
            if (this.TopMost == true)
            {
                this.Opacity = 1;
            }
        }
        private void frmSockets_Deactivate(object sender, EventArgs e)
        {
            if (this.TopMost == true)
            {
                this.Opacity = .5;
            }
        }
        private void sDRECVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgridSockets.SelectedRows.Count != 0)
            {
                strPipeMsgOut.command = Glob.CMD_INJECT;
                strPipeMsgOut.sockid = Int32.Parse(dgridSockets.SelectedRows[0].Cells["socket"].Value.ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);
                strPipeMsgOut.function = Glob.FUNC_SHUTDOWN;
                strPipeMsgOut.extra = (int)SocketShutdown.Receive;
                strPipeMsgOut.datasize = 0;
                pipeOut.Write(Glob.RawSerializeEx(strPipeMsgOut), 0, Marshal.SizeOf(strPipeMsgOut));
            }
        }
        private void sDSENDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgridSockets.SelectedRows.Count != 0)
            {
                strPipeMsgOut.command = Glob.CMD_INJECT;
                strPipeMsgOut.sockid = Int32.Parse(dgridSockets.SelectedRows[0].Cells["socket"].Value.ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);
                strPipeMsgOut.function = Glob.FUNC_SHUTDOWN;
                strPipeMsgOut.extra = (int)SocketShutdown.Send;
                strPipeMsgOut.datasize = 0;
                pipeOut.Write(Glob.RawSerializeEx(strPipeMsgOut), 0, Marshal.SizeOf(strPipeMsgOut));
            }
        }
        private void sDBOTHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgridSockets.SelectedRows.Count != 0)
            {
                strPipeMsgOut.command = Glob.CMD_INJECT;
                strPipeMsgOut.sockid = Int32.Parse(dgridSockets.SelectedRows[0].Cells["socket"].Value.ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);
                strPipeMsgOut.function = Glob.FUNC_SHUTDOWN;
                strPipeMsgOut.extra = (int)SocketShutdown.Both;
                strPipeMsgOut.datasize = 0;
                pipeOut.Write(Glob.RawSerializeEx(strPipeMsgOut), 0, Marshal.SizeOf(strPipeMsgOut));

            }
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgridSockets.SelectedRows.Count != 0)
            {
                strPipeMsgOut.command = Glob.CMD_INJECT;
                strPipeMsgOut.sockid = Int32.Parse(dgridSockets.SelectedRows[0].Cells["socket"].Value.ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);
                strPipeMsgOut.function = Glob.FUNC_CLOSESOCKET;
                strPipeMsgOut.datasize = 0;
                pipeOut.Write(Glob.RawSerializeEx(strPipeMsgOut), 0, Marshal.SizeOf(strPipeMsgOut));
            }
        }
        private void replayEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgridSockets.SelectedRows.Count != 0)
            {
                byte[] zero = new byte[] { 0 };
                ReplayEditor frmChReplay = new ReplayEditor(new byte[0], Int32.Parse(dgridSockets.SelectedRows[0].Cells["socket"].Value.ToString(), System.Globalization.NumberStyles.AllowHexSpecifier), pipeOut);
                if (this.TopMost == true)
                    frmChReplay.TopMost = true;
                frmChReplay.Show();
            }
        }
        private void dgridSockets_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }
    }
}
