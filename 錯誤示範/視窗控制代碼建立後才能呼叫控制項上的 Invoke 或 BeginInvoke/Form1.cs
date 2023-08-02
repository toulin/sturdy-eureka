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

namespace WindowsFormsApp30
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 建立一個新的執行緒來模擬非UI執行緒
            Thread thread = new Thread(UpdateLabel);
            thread.Start();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void UpdateLabel()
        {
            //WaitSeconds(3);
            label1.Invoke((MethodInvoker)delegate
            { 
                label1.Text = "已更新"; // 此處觸發錯誤
                Debug.WriteLine("已更新");
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //WaitSeconds(3);
            Debug.WriteLine("Form1_Load end");
        }


        private void WaitSeconds(int seconds)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int count = 0;
            do
            {
                count += 1;
                if (stopwatch.Elapsed.TotalSeconds > seconds)
                {
                    break;
                }
                if (count % 999 == 0)
                {
                    Application.DoEvents();
                    count = 0;
                }
            } while (true);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }
    }
}
