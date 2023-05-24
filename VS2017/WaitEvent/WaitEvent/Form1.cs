using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaitEvent
{
    public partial class Form1 : Form
    {
        public Example MyTest;
         

        public Form1()
        {
            InitializeComponent();
            MyTest = new Example(); 
        } 
        private void button1_Click(object sender, EventArgs e)
        {
            MyTest.Start();
        } 

        private void button2_Click(object sender, EventArgs e)
        {
            MyTest.DoSendMessage("TEST");
        }
    }
}
