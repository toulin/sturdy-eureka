using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressSample
{
    public partial class Form1 : Form , IProgress<ProgressArg>
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Report(ProgressArg value)
        {
            ProgressStateLabel.Text = value.StateMessage;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            MyDoSomething doSomething = new MyDoSomething(this);
            doSomething.Start();
        }
    }
}
