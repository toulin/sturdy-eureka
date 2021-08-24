using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TestDictionary
{
    public partial class Form1 : Form
    {
        Dictionary<int, MyClass> TestData = new Dictionary<int, MyClass>();
        Dictionary<ushort, MyClass> TestData2 = new Dictionary<ushort, MyClass>();

        public Form1()
        {
            InitializeComponent();
            for(int i=0;i<10;i++)
            {
                TestData.Add(i, new MyClass { Id = i, Name = "TEST" + i });
            }
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (int key in TestData.Keys) 
            {
                MyClass myClass = TestData[key];
                for (int i= 0;i<99999;i++)
                {
                    myClass.Add(i);
                }
            }

            Debug.WriteLine($"事先取出該類別 spend = {stopwatch.ElapsedTicks}");
             
            foreach (int key in TestData.Keys)
            { 
                for (int i = 0; i < 99999; i++)
                {
                    TestData[key].Add(i);
                }
            }
            Debug.WriteLine($"每次都從字典取該類別 spend = {stopwatch.ElapsedTicks}");

        }



        private void button2_Click(object sender, EventArgs e)
        {
            DoA();
            DoB();
        }
        private void DoA()
        {
            DoSomethingC<int,MyClass>(TestData);
            MessageBox.Show(TestData.Count.ToString());
            DoSomethingC<ushort, MyClass>(TestData2);
        }

        private void DoB()
        {
            Form2 form2 = new Form2();
            form2.Message = TestData2.Count.ToString();
            form2.Show();
        }

        //private void DoSomethingA(Dictionary<int, MyClass> data)
        //{
        //    foreach(var myData in  data.Values.ToList())
        //    {
        //        myData.Value += 1;
        //    }
        //}

        //private void DoSomethingB(Dictionary<ushort, MyClass> data)
        //{
        //    foreach (var myData in data.Values.ToList())
        //    {
        //        myData.Value += 1;
        //    }
        //}

        private void DoSomethingC<T,U>(Dictionary<T, U> data)
        {
            foreach (var myData in data.Values.ToList())
            {
                if (myData is MyClass classA)
                {
                    classA.Value += 1;
                }
            }
        }
    }
}
