using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace PacketEditor
{
    public partial class FrmPython : Form
    {  
      
        string _path;
        public FrmPython(string PathToFile)
        {
            InitializeComponent();
            _path = PathToFile;
           
           
       
       

            timer1.Start();
           


            
            
            
            
        }
       
        void _pythonProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            try
            {
              //  txbOutput.AppendText(PythonOutput.ReadToEnd());
               
            }
            catch (Exception) { }
        }

     

        private void FrmPython_Load(object sender, EventArgs e)
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Scripts\\filter.py"))
            {
                txbFilter.Text = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Scripts\\filter.py");
            }
        }
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
  

        private void saveFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Scripts\\filter.py", txbFilter.Text);
        }

        private void txbFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 190 && txbFilter.Text.IndexOf(".") > 0)
            {
                txbFilter.SelectionStart = txbFilter.Text.IndexOf(".") + 1;
                txbFilter.SelectionLength = 2;
                e.SuppressKeyPress = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                txbOutput.Text = File.ReadAllText(_path);
            }
            catch (Exception ex)
            {
                txbOutput.Text = ex.Message;
            }
          
        }
    }
}
