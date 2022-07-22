using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace ProgressSample
{
    public class MyDoSomething
    {
        private IProgress<ProgressArg> MyProgress;
        private Timer Timer = new Timer();
        /// <summary>
        /// 初始化時，DI注入一個進度介面；在本例中 該介面由 Form1實作)
        /// </summary>
        /// <param name="progress"></param>
        public MyDoSomething(IProgress<ProgressArg> progress)
        {
            MyProgress = progress;
            Timer.Interval = 2000;
            Timer.Tick += Timer_Tick;
        }

        private int Count = 0;
        private async void Timer_Tick(object sender, EventArgs e)
        {
           var value= await DoAsyns();
            var arg = new ProgressArg { StateMessage = $"已執行{value}次" };
            MyProgress.Report(arg);
        }

        private async Task<int> DoAsyns()
        {
            HttpClient httpClient = new HttpClient();
            var test= await httpClient.GetAsync("http://google.com.tw");
            Count += 1;
            return Count;
        }

        public void Start()
        {
            Timer.Start();
        }
    }
}
