using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestFinally
{
    public class TestTimerWithoutFinally
    {
        private Timer timer = new Timer();

        public TestTimerWithoutFinally()
        {
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            try
            {
                await CheckPopulationAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Timer事件例外：{DateTime.Now} - {ex}");
            }
            Console.WriteLine($"Timer事件結束，重新啟動Timer：{DateTime.Now}");
            timer.Start();
        }

        public void Start()
        {
            timer.Start();
        }

        private async Task CheckPopulationAsync()
        {
            Console.WriteLine($"準備檢查人口總人數：{DateTime.Now}");
            // 在這裡實作檢查人口總人數的非同步邏輯
            // 可以呼叫相關的 API 或從資料庫取得人口資料等等
            await Task.Delay(10000); // 模擬耗時的非同步操作
            Console.WriteLine($"檢查完畢：{DateTime.Now}");
        }
    }
}
