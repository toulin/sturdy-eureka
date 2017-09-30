using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAsync_Try
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        AsyncDo f_Do = new AsyncDo();
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                f_Do.Add(i.ToString());
            }

            MessageBox.Show("完成 ");
        }
    }
}
