using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EnvironmentPj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bRun_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            foreach(System.Collections.DictionaryEntry item in Environment.GetEnvironmentVariables())
            {
                list.Add(string.Format("{0} => {1}", item.Key, item.Value));
            }
            textBox1.Text = string.Join(Environment.NewLine, list);            
        }
    }
}
