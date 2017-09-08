using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NLog;
namespace NLog_Try
{
    public partial class Form1 : Form
    {
        NLog.Logger log;
        public Form1()
        {
            InitializeComponent();
            log = NLog.LogManager.GetCurrentClassLogger();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Test(); 
        }
        private void Test()
        {
            log.Trace("Trace-1");
            log.Error("Error-1");
            log.Warn("Warn-1");
            //MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }
         
    }
}
