using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAN_EVENT
{

    public class MyTimerDoSomething<T>
    {
        System.Timers.Timer f_MyTimer;
        public delegate void MyEventHandler(MyEventDo<T> e);

        public event MyEventHandler EventTriggered;
        /// <summary>
        /// 要送出的資料
        /// </summary>
        private Queue<T> f_SendDataItems;
        public MyTimerDoSomething()
        {
            f_MyTimer = new System.Timers.Timer();
            f_MyTimer.Elapsed += F_MyTimer_Elapsed;
            f_MyTimer.Interval = 100;
            f_MyTimer.Enabled = true;
            f_MyTimer.Stop();
            
        }
        //填入要送出的資料
        public void FillData(Queue<T> list)
        {
            f_SendDataItems = list;
            f_MyTimer.Start();
        }

        private void F_MyTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (f_SendDataItems != null && f_SendDataItems.Count > 0)
            {
                T data = f_SendDataItems.Dequeue();
                MyEventDo<T> sendData = new MyEventDo<T>(data);
                EventTriggered?.Invoke(sendData);
            }
        }
    }
    public class MyEventDo<T> : EventArgs
    {
        private T f_data;
        public MyEventDo(T data)
        {
            f_data = data;
        }
        public T MyData
        {
            get { return f_data; }
            set { f_data = value; }
        }

    }
}

