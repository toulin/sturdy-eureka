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

namespace AwaitAwait
{
    public partial class Form1 : Form
    {
        TestSend Send = new TestSend();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Send.Test();    //不等待，將直接繼續執行下列流程
            Debug.WriteLine("client");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await Send.Test();  //會等待執行結束，再繼續執行下列流程
            Debug.WriteLine("client");
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            //參考 https://blog.darkthread.net/blog/await-task-block-deadlock/
            Send.TestGet2Async().Wait();
            Debug.WriteLine("client"); 
        } 
        private void button3_Click(object sender, EventArgs e)
        {
            //修改TestGet1Async 裡的方法 設定 ConfigureAwait(false)
            //var tast = Send.TestGet2Async();
            Task task = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(3000);
            });
            await task;
            Debug.WriteLine("ccccccccccccccccccccccccc");
            //Task.Run()
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Send.TestGet1Async().Wait();
            Debug.WriteLine("ccccccccccccccccccccccccc");
        }
    }
}
