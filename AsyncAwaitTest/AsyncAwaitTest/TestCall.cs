using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitTest
{
    internal class TestCall
    {
        private CallAP callAP = new CallAP();

        public async Task<bool> T1()
        {
            Debug.WriteLine($"T1 Start ThreadId={Thread.CurrentThread.ManagedThreadId}");
            var result = await T2();
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
