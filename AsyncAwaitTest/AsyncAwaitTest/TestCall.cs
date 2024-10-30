using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwaitTest
{
    internal class TestCall
    {
        private CallAP callAP = new CallAP();

        public async Task<bool> T1()
        {
            //此處實例化表單或自訂控制項會使 之後awiat捕捉錯誤的上下文
            var form = new Form();

            //為了避免這個問題，請在UI執行緒實例化表單或自訂控制項
            //使用UI執行緒實例化表單或自訂控制項
            //Program.form1.uiContext.Post(_ =>
            //{
            //    var form = new Form();
            //    // 這裡可以進行其他 UI 控制項的操作
            //    form.ShowDialog();
            //}, null); 


            Debug.WriteLine($"T1 Start ThreadId={Thread.CurrentThread.ManagedThreadId}");
            var result = await T10();

            //var form = new Form();
            Debug.WriteLine($"T1 Done ThreadId={Thread.CurrentThread.ManagedThreadId}");
            return result;
        }
        private async Task<bool> T2()
        {
            Debug.WriteLine($"T2 Start ThreadId={Thread.CurrentThread.ManagedThreadId}");
            var result = await T3();
            Debug.WriteLine($"T2 Done ThreadId={Thread.CurrentThread.ManagedThreadId}");
            return result;
        }

        private async Task<bool> T3()
        {
            Debug.WriteLine($"T3 Start ThreadId={Thread.CurrentThread.ManagedThreadId}");
            var result = await T4();
            Debug.WriteLine($"T3 Done ThreadId={Thread.CurrentThread.ManagedThreadId}");
            return result;
        }
        private async Task<bool> T4()
        {
            Debug.WriteLine($"T4 Start ThreadId={Thread.CurrentThread.ManagedThreadId}");
            var result = await T5(); 
            Debug.WriteLine($"T4 Done ThreadId={Thread.CurrentThread.ManagedThreadId}");
            return result;
        }

        private async Task<bool> T5()
        {
            Debug.WriteLine($"T5 Start ThreadId={Thread.CurrentThread.ManagedThreadId}");
            var result = await T6();
            Debug.WriteLine($"T5 Done ThreadId={Thread.CurrentThread.ManagedThreadId}");
            return result;
        }

        private async Task<bool> T6()
        {
            Debug.WriteLine($"T6 Start ThreadId={Thread.CurrentThread.ManagedThreadId}");
            var result = await T7();
            Debug.WriteLine($"T6 Done ThreadId={Thread.CurrentThread.ManagedThreadId}");
            return result;
        }

        private async Task<bool> T7()
        {
            Debug.WriteLine($"T7 Start ThreadId={Thread.CurrentThread.ManagedThreadId}");
            var result = await T8();
            Debug.WriteLine($"T7 Done ThreadId={Thread.CurrentThread.ManagedThreadId}");
            return result;
        }
        private async Task<bool> T8()
        {
            Debug.WriteLine($"T8 Start ThreadId={Thread.CurrentThread.ManagedThreadId}");
            var result = await T9();
            Debug.WriteLine($"T8 Done ThreadId={Thread.CurrentThread.ManagedThreadId}");
            return result;
        }

        private async Task<bool> T9()
        {
            
            Debug.WriteLine($"T9 Start ThreadId={Thread.CurrentThread.ManagedThreadId}");
            var result = await T10();
            Debug.WriteLine($"T9 Done ThreadId={Thread.CurrentThread.ManagedThreadId}");
            return result;
        }
        private async Task<bool> T10()
        {
            Debug.WriteLine($"T10 Start ThreadId={Thread.CurrentThread.ManagedThreadId}");
            await callAP.GetDataNo();
            Debug.WriteLine($"T10 Done ThreadId={Thread.CurrentThread.ManagedThreadId}");
            return true;
        }
    }
}
