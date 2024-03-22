using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestThread
{    
    internal class CustomClass
    {
        private System.Timers.Timer MyTimer = new System.Timers.Timer();

        internal delegate void MyDelegate(CustomClass sender,string param);

        internal MyDelegate MyNotifyDelage;


        public CustomClass()
        {
            MyTimer.Elapsed += MyTimer_Elapsed;
            MyTimer.Interval = 6000;
            MyTimer.Start();
        }

        private void MyTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Debug.WriteLine($"MyTimer_Elapsed threadID={System.Threading.Thread.CurrentThread.ManagedThreadId}");

            //以MainThread觸發事件
            System.Windows.Forms.Application.OpenForms[0].Invoke(MyNotifyDelage,this,"TEST");
        }
    }
}
