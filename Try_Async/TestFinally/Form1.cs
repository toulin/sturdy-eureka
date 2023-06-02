using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestFinally
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void UsingFinallyButton_Click(object sender, EventArgs e)
        {
            TestTimerUsingFinally testTimerUsingFinally = new TestTimerUsingFinally();
            //啟動Timer
            testTimerUsingFinally.Start(); 
        }

        private void WithoutFinallyButton_Click(object sender, EventArgs e)
        {
            TestTimerWithoutFinally testTimerWithoutFinally = new TestTimerWithoutFinally();
            //啟動Timer
            testTimerWithoutFinally.Start(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SystemTimerWithoutFinally systemTimerWithoutFinally = new SystemTimerWithoutFinally();
            //啟動Timer
            systemTimerWithoutFinally.Start();
        }

        private void SystemTimerUsingFinallyButton_Click(object sender, EventArgs e)
        {
            SystemTimerUsingFinally systemTimerUsingFinally = new SystemTimerUsingFinally();
            systemTimerUsingFinally.Start();
        }
    }
}
