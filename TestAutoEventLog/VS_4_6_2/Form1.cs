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

namespace VS_4_6_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var tabpage in tabControl1.TabPages)
            {
                InitUserControl1(tabpage as TabPage);
            }
            foreach (var tabpage in tabControl2.TabPages)
            {
                InitUserControl1(tabpage as TabPage);
            }
            foreach (var tabpage in tabControl3.TabPages)
            {
                InitUserControl1(tabpage as TabPage);
            }
        }
        private void InitUserControl1(Control panel)
        {
            UserControl1 userControl1 = new UserControl1();
            userControl1.Parent = panel;
            userControl1.Dock = DockStyle.Fill;
            userControl1.Visible = true;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Debug.WriteLine(Program.Watch.ElapsedMilliseconds);
        }

    }
}
