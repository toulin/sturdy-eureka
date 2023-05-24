using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VS_4_6_2.Model;

namespace VS_4_6_2
{
    public partial class UserControl1 : UserControl
    {
        private List<MyData> MyDatas;
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            MyDatas = new List<MyData>();
            for (int i = 1; i < 10000; i++)
            {
                MyDatas.Add(new MyData { ID = i, Name = i.ToString(), EMail = "xxxxxx@gmail.com" });
            }
            dataGridView1.DataSource = MyDatas;
        }
    }
}
