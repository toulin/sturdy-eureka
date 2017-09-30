using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Concurrent;
using System.Threading.Tasks;
 

namespace IAsync_Try
{
    public class AsyncDo
    {
        doClass f_Do = new doClass();
        BackgroundWorker f_bkWork;
        System.Timers.Timer f_Timer;

        ConcurrentQueue<string> f_Msg;
        public AsyncDo()
        {
            f_bkWork = new BackgroundWorker();
            f_bkWork.DoWork += new DoWorkEventHandler(f_bkWork_DoWork);
            f_Timer = new System.Timers.Timer(1000);
            f_Timer.Elapsed += new System.Timers.ElapsedEventHandler(f_Timer_Elapsed);
            f_Msg = new ConcurrentQueue<string>();
            f_Timer.Enabled = true;
        }

        void f_Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (f_bkWork.IsBusy == false)
                f_bkWork.RunWorkerAsync();
        }

        void f_bkWork_DoWork(object sender, DoWorkEventArgs e)
        {
            string msg;
            if (f_Msg.TryDequeue(out msg))
                MessageBox.Show(msg);
        }
         
        public void Add(string msg)
        {
            #region task方式
            //Action<object> doAdd = new Action<object>((m) =>
            //    {
            //        f_Do.Add(msg);
            //    });
            //Task.Factory.StartNew(doAdd, msg);
            #endregion
            f_Msg.Enqueue(msg);

        } 
    }
    public class doClass
    {
        public void Add(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}
