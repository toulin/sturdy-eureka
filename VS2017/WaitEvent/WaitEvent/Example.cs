using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaitEvent
{  

    public class Example
    {
        private event EventHandler<string> Message;
        public static readonly TimeSpan MaxWait = TimeSpan.FromMilliseconds(50000);
         
        private AutoResetEvent _messageReceived;

        public Example()
        { 
            this._messageReceived = new AutoResetEvent(false);
            Message += this.MessageReceived;
        }

        public void Start()
        {
            TaskFactory factory = new TaskFactory();
            factory.StartNew(() =>
            {
                // This will wait for up to 5000 ms, then throw an exception.
                this._messageReceived.WaitOne(MaxWait);
                Debug.WriteLine("完成");
            });
        }
        public void DoSendMessage(string msg)
        {
            Debug.WriteLine("DoSendMessage");
            Message.Invoke(this, msg);
        }
        public void MessageReceived(object sender, string e)
        {
            //Do whatever you need to do with the message
            Debug.WriteLine("MessageReceived");
            this._messageReceived.Set();
        }
    }
}
