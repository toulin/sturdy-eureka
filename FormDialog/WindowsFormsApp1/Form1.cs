﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Form2 F2 = new Form2();
        private void button1_Click(object sender, EventArgs e)
        {
            if(F2.ShowDialog()==DialogResult.OK)
            {
                button1.Text = "OK";
            }
            else
            {
                button1.Text = "Cancel";
            }
        }
    }
}
