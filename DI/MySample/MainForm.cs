using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySample
{
    public partial class MainForm : Form
    {
        private readonly IDataProvider Provider;
        
        private readonly IApiProvider ApiProvider;

        public MainForm(IDataProvider provider,IApiProvider apiProvider)
        {
            Provider = provider;
            ApiProvider = apiProvider;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var response = Provider.GetData("Peter");

            textBox1.Text += response + Environment.NewLine;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var response = ApiProvider.GetAPI("Peter");

            textBox1.Text += response + Environment.NewLine;
        }
    }
}
