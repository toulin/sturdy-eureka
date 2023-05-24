using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace TestTimer
{
    public partial class Form1 : Form
    {
        private delegate void TestCallBack(int index);  

        System.Windows.Forms.Timer formTimer = new System.Windows.Forms.Timer();
        System.Timers.Timer systemTimer = new System.Timers.Timer();
        //System.Threading.Timer threadTimer = new System.Threading.Timer(new TimerCallback((o) =>
        //{
        //    Debug.WriteLine($"threadTimer threadID= {Thread.CurrentThread.ManagedThreadId} ");
        //}));
        public Form1()
        {
            InitializeComponent();
            formTimer.Tick += FormTimer_Tick;
            formTimer.Interval = 100;

            systemTimer.Elapsed += SystemTimer_Elapsed;
            systemTimer.Interval = 100;
            
        }
        /// <summary>
        /// 一段耗時的運算
        /// </summary>
        private void Process()
        {
            for (int i = 1; i < 99999999; i++)
            {
                long k = 0;
                k = k + i;
            }
        }
        
        private void SystemTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        { 
            Debug.WriteLine($"systemTimer threadID= {Thread.CurrentThread.ManagedThreadId} ");
        }

        private void FormTimer_Tick(object sender, EventArgs e)
        { 
            Debug.WriteLine($"FormTimer threadID= {Thread.CurrentThread.ManagedThreadId}  ");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AllStop();
            formTimer.Start();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AllStop();
            systemTimer.Start();
        }

        private void AllStop()
        { 
            systemTimer.Stop();
            formTimer.Stop(); 
        }
    }
}
