using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PacketEditor
{
    public partial class Filters : Form
    {
        DataTable dtFilters;
        Main.SockInfo sinfo;

        public Filters(DataTable dt, Main.SockInfo si)
        {
            InitializeComponent();
            dtFilters = dt;
            sinfo = si;
            int i;
            string funs;

            foreach (DataRow dr in dt.Rows)
            {
                i = dgridFilters.Rows.Add();
                funs = "";
                dgridFilters.Rows[i].Cells["name"].Value = dr["id"].ToString();
                dgridFilters.Rows[i].Cells["enabled"].Value = dr["enabled"];
                foreach (byte f in (byte[])dr["MsgFunction"])
                {
                    funs += si.msg(f) + " ";
                }
                foreach (byte f in (byte[])dr["APIFunction"])
                {
                    funs += si.api(f) + " ";
                }
                foreach (byte f in (byte[])dr["DNSFunction"])
                {
                    funs += si.api(f) + " ";
                }
                if (funs != string.Empty)
                {
                    dgridFilters.Rows[i].Cells["function"].Value = funs.TrimEnd();
                }
            }
        }
        private void frmFilters_Activated(object sender, EventArgs e)
        {
            if (this.TopMost == true)
            {
                this.Opacity = 1;
            }
        }
        private void frmFilters_Deactivate(object sender, EventArgs e)
        {
            if (this.TopMost == true)
            {
                this.Opacity = .5;
            }
        }
        private void dgridFilters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
            else if (e.KeyChar == 32)
            {
                if ((bool)dgridFilters.SelectedRows[0].Cells["enabled"].Value == false)
                {
                    dgridFilters.SelectedRows[0].Cells["enabled"].Value = true;
                    dtFilters.Rows.Find(dgridFilters.SelectedRows[0].Cells["name"].Value)["enabled"] = true;
                }
                else
                {
                    dgridFilters.SelectedRows[0].Cells["enabled"].Value = false;
                    dtFilters.Rows.Find(dgridFilters.SelectedRows[0].Cells["name"].Value)["enabled"] = false;
                }
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            DataRow drsock; // = dsMain.Tables["sockets"].Rows.Find(strPipeMsgIn.sockid);
            foreach (DataGridViewRow srow in dgridFilters.SelectedRows)
            {
                drsock = dtFilters.Rows.Find(srow.Cells["name"].Value);
                if (drsock != null)
                {
                    drsock.Delete();
                }
                dgridFilters.Rows.Remove(srow);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow dr = dtFilters.NewRow();
            EditFilter frmChReplay = new EditFilter(dr, sinfo, dtFilters, dgridFilters, 0);
            if (this.TopMost == true)
                frmChReplay.TopMost = true;
            frmChReplay.Show();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgridFilters_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex != 0) && (e.RowIndex != -1))
            {
                DataRow dr = dtFilters.Rows[e.RowIndex];
                EditFilter frmChReplay = new EditFilter(dr, sinfo, dtFilters, dgridFilters, e.RowIndex);
                if (this.TopMost == true)
                    frmChReplay.TopMost = true;
                frmChReplay.Show();
            }
        }
        private void dgridFilters_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.ColumnIndex == 0) && (e.RowIndex != -1))
            {
                if (dgridFilters[e.ColumnIndex, e.RowIndex].GetContentBounds(e.RowIndex).Contains(e.Location))
                {
                    if ((bool)dgridFilters.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == false)
                    {
                        dgridFilters.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                        dtFilters.Rows.Find(dgridFilters.Rows[e.RowIndex].Cells["name"].Value)["enabled"] = true;
                    }
                    else
                    {
                        dgridFilters.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        dtFilters.Rows.Find(dgridFilters.Rows[e.RowIndex].Cells["name"].Value)["enabled"] = false;
                    }
                }
            }
        }
    }
}
