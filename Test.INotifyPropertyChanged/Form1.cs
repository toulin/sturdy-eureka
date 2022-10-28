using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestINotifyPropertyChanged
{
    public partial class Form1 : Form
    {
        //Timer MyTimer = new Timer();
        MDataItems CustomDatas = new MDataItems();
        private DateTime lastTime = DateTime.Now; 
        private Timer LogTimer = new Timer();
        private StringBuilder LogBuilder = new StringBuilder();
        DataManager<MyData> DataManager = new DataManager<MyData>();

        public Form1()
        {
            InitializeComponent();
            gridControl1.DataSource = DataManager.Data; // DataManager.Data;
            LogTimer.Tick += LogTimer_Tick;
            LogTimer.Interval = 1000;
            LogTimer.Start();
        }

        private void LogTimer_Tick(object sender, EventArgs e)
        {
            if (LogBuilder.Length > 0)
            {
                MsgText.Text += LogBuilder.ToString();
                LogBuilder.Clear();
            }
        }

        private void AddLog(string msg)
        {
            LogBuilder.AppendLine(msg);
        }

        private int Count; 

        private void Form1_Load(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                do
                {
                    var gap = (DateTime.Now - lastTime);
                    if (gap.TotalSeconds <= 1)
                    {
                        continue;
                    }
                    lastTime = DateTime.Now;
                    Add2();

                    
                } while (Count < 100);

            });
        }
        private void Add()
        {
            try
            { 
                Count += 1;
                MyData myData = new MyData { ID = Count, Name = DateTime.Now.ToString() };
                var data = new CustomData(myData);
                data.CustomeID = $"M{Count}";
                CustomDatas.Add(data);
            }
            catch (Exception ex)
            {
                AddLog(ex.Message);
            }
        }

        private void Add2()
        {
            try
            {
                Count += 1;
                MyData myData = new MyData { ID = Count, Name = DateTime.Now.ToString() };
                var data = new CustomData(myData);
                data.CustomeID = $"M{Count}";
                DataManager.AsignData(myData);
            }
            catch (Exception ex)
            {
                AddLog(ex.Message);
            }
        }

        
        List<MyData> MyDatas = new List<MyData>();
        private void TestInsert()
        { 
            
            MyDatas.Add(new MyData { ID = 1, Name = "TEST1", StamTime = 1000 });
            MyDatas.Add(new MyData { ID = 2, Name = "TEST2", StamTime = 1000 });
            MyDatas.Add(new MyData { ID = 5, Name = "TEST3", StamTime = 1000 });
            MyDatas.Add(new MyData { ID = 6, Name = "TEST4", StamTime = 1000 });

            //覆寫資料
            MyDatas.Add(new MyData { ID = 1, Name = "UpdateA", StamTime = 999 });
            MyDatas.Add(new MyData { ID = 4, Name = "InsertB", StamTime = 333 }); 

           
        }
    }
}
