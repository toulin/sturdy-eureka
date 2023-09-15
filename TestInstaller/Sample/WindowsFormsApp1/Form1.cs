using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
using ClassLibrary2;

//示範 在安裝檔如何檢查與排除 組件參考版本問題

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var t = DateTime.Now.ToString("yyyyMMdd hhmm");
            timer1.Interval = 10000;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var teamworks = new TeamWorks();
            textBox1.Text = teamworks.GetName();

            var contury = new Contury();
            textBox2.Text = contury.MayorName;

            //Form2 form2 = new Form2();
            //form2.TopMost = true;
            //form2.Show();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {            
            
        }
        Form3 form3;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            form3.Hide();
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            timer1.Start();
            form3 = new Form3();
            form3.ShowDialog();
        }
    }
}
