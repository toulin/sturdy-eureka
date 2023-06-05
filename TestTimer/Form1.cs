using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //測試 只在需要時 實例化Timer ，觀察記憶體使用狀態
            DateTime startTime = DateTime.Now;
            DateTime lastTime = DateTime.Now;
            TimeSpan timeSpan;
            //CreateTimerToDoSomething();
            do
            {
                if ((DateTime.Now - lastTime).TotalSeconds > 1)
                {
                    //每秒執行一次CreateTimerToDoSomething
                    CreateTimerToDoSomething();
                    lastTime = DateTime.Now;
                }
                //回圈持續執行2分鐘
                timeSpan = DateTime.Now - startTime;
                Application.DoEvents();
            } while (timeSpan.TotalMinutes < 2);

        }
        private int count =0;
        private void CreateTimerToDoSomething()
        {
            count++;
            Console.WriteLine($"執行{count}次");
            Timer timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var timer = (sender as Timer);
            timer.Stop();
            Console.WriteLine($"Timer_Tick Sender HashCode= {timer.GetHashCode()}");            
            this.Text = DateTime.Now.ToString();
            long test = 0;
            for (int i = 1; i < 99999; i++)
            {
                test = i + 1;
            }
        }

        private async Task DoSomethindByTask()
        {
            //此方法將發生 跨執行緒例外
            await Task.Factory.StartNew(()=>
            {
                Console.WriteLine($"DoSomethindByTaske");
                PrintLog($"DoSomethindByTask at {DateTime.Now}");
                long test = 0;
                for (int i = 1; i < 999999; i++)
                {
                    test = i + 1;
                }
                PrintLog($"Complated at {DateTime.Now}");
            });
        }

        private async Task DoSomethingByTask_Fix()
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"DoSomethingByTask");
                // 將UI操作委託到UI執行緒上下文
                this.Invoke(new Action(() =>
                {
                    PrintLog($"DoSomethingByTask at {DateTime.Now}");
                }));
                
                long test = 0;
                for (int i = 1; i < 999999; i++)
                {
                    test = i + 1;
                }

                // 將UI操作委託到UI執行緒上下文
                this.Invoke(new Action(() =>
                {
                    PrintLog($"Completed at {DateTime.Now}");
                }));
            });
        }

        private void PrintLog(string msg)
        {
            logText.Text += Environment.NewLine + msg;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await DoSomethindByTask();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await DoSomethingByTask_Fix();
        }
    }
}
