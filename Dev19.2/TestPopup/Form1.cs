using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestPopup.Model;

namespace TestPopup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<TestData> testDatas = new List<TestData>();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("T1");
            stringBuilder.AppendLine("T2");
            testDatas.Add(new TestData() { Name = "tt", Descript = stringBuilder.ToString() }); ;
            testDatas.Add(new TestData() { Name = "tt2", Descript = stringBuilder.ToString() }); 
            gridControl1.DataSource = testDatas;
        }

        private void repositoryItemPopupContainerEdit1_BeforePopup(object sender, EventArgs e)
        {
        }

        private void repositoryItemPopupContainerEdit1_Popup(object sender, EventArgs e)
        {
            
        }
    }
}
