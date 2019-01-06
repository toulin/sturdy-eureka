using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRAN_EVENT
{
    public partial class Form1 : Form
    { 
        public Form1()
        {
            InitializeComponent();
            MyGlobal.DoSendMyData = new MyTimerDoSomething<MyData>();
             
            MyGlobal.DoSendMyData.EventTriggered += DoSendMyData_EventTriggered;
 
        }

        private void DoSendMyData_EventTriggered(MyEventDo<MyData> e)
        {
            Action work = new Action(() =>
            {
                long id = e.MyData.ID;
                for(int i=0;i<9999999;i++)
                {
                    id += i;
                    id -= i;
                    id++;
                    id--;
                }
                txtDisplay.Text += id.ToString() + Environment.NewLine;
            });
            txtDisplay.InvokeIfRequired(work);

            //txtDisplay.Text += e.MyData.Name + Environment.NewLine;
        }
        
        private void bReadyData_Click(object sender, EventArgs e)
        {
            MyGlobal.MyDataList.Clear();
            for(int i=0;i<100;i++)
            {
                MyGlobal.MyDataList.Add(new MyData(i, string.Format("Name_{0}", i)));
            }
            
        }

        private void bRestart_Click(object sender, EventArgs e)
        {
            Queue<MyData> queue = new Queue<MyData>();
            MyGlobal.MyDataList.ForEach(o => queue.Enqueue(o));
            MyGlobal.DoSendMyData.FillData(queue);
        }
    }
}
