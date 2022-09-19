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
        Timer MyTimer = new Timer();
        MDataItems CustomDatas = new MDataItems();
        private bool IsAdd { get; set; }
        public Form1()
        {
            InitializeComponent();
            IsAdd = true;
            MyTimer.Interval = 1000;
            MyTimer.Tick += MyTimer_Tick;
            gridControl1.DataSource = CustomDatas;
            dataGridView1.DataSource = CustomDatas;
        }
        private int Count;
        private void MyTimer_Tick(object sender, EventArgs e)
        {
            if (IsAdd)
            {
                Count += 1;
                MyData myData = new MyData { ID = Count, Name = DateTime.Now.ToString() };
                var data = new CustomData(myData);
                data.CustomeID = $"M{Count}";
                CustomDatas.Add(data);
            }
            else
            {
                foreach(var item in CustomDatas)
                {
                    item.Id = item.Id + 1;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyTimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IsAdd = !IsAdd;
        }
    }
}
