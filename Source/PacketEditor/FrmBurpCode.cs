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
    public partial class FrmBurpCode : Form
    {
        public FrmBurpCode(string code)
        {
            InitializeComponent();
            txbBurpCode.Text = code;
        }

        private void FrmBurpCode_Load(object sender, EventArgs e)
        {

        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
