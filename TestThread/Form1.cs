using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace TestThread
{
    public partial class Form1 : Form
    {
        public Form1(string title)
        {
            InitializeComponent();
            this.Text = title;
            MyTimer.Tick += MyTimer_Tick;
            PrintThreadID("Form1");
        }
        private void PrintThreadID(string title)
        {
            Debug.WriteLine($"title={title}, threadID={ Thread.CurrentThread.ManagedThreadId}");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            PrintThreadID("button1_Click 1");
            await Test();
            PrintThreadID("button1_Click 2");
        }
        private async Task Test()
        {
            HttpClient httpClient = new HttpClient();
            PrintThreadID("Test 1");
            var context = await httpClient.GetAsync(@"http://www.cmoney.com.tw");
            PrintThreadID("Test 2");
        }
        System.Windows.Forms.Timer MyTimer = new System.Windows.Forms.Timer();
        AutoResetEvent ResetEvent = new AutoResetEvent(false);
        private async Task Test2()
        {
            MyTimer.Interval = 1000;
            MyTimer.Start();
            TaskFactory taskFactory = new TaskFactory();
            await taskFactory.StartNew(new Action(() =>
            {
                PrintThreadID($"task before wait");
                ResetEvent.WaitOne();
                PrintThreadID($"task after wait");
            }));
        }

        int count = 0;
        private void MyTimer_Tick(object sender, EventArgs e)
        {
            count += 1;
            if(count>10)
            {
                ResetEvent.Set();
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            PrintThreadID("button2_Click 1");
            await Test2();
            PrintThreadID("button2_Click 2");
        }
    }
}
