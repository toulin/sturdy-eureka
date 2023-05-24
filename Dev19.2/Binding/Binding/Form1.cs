using DevExpress.Utils.DirectXPaint.Svg;
using DevExpress.Utils.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binding
{
    public partial class Form1 : Form
    {
        private Timer MyTimer = new Timer();
        private MyClass MyData = new MyClass();
        public Form1()
        {
            InitializeComponent();
            MyData.Id = 9;
            MyData.Name = "TestName";
            MyTimer.Tick += MyTimer_Tick;
            MyTimer.Interval = 500;
            MyLabel.Text = MyData.ToString();

            BindingTest();
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            MyData.Time = DateTime.Now;
            Debug.WriteLine(MyData.Second);
        }
        private void BindingTest()
        {
            BindingContext context = new BindingContext();

            MyLabel.DataBindings.Add("Text", MyData, "Second"); 
            myClassBindingSource.DataSource = MyData;



        }
        private void DoSomething_Click(object sender, EventArgs e)
        {
            MyTimer.Start();
        }
    }
}
