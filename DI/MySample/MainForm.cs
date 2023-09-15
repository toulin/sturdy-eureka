using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySample.Factory;

namespace MySample
{
    public partial class MainForm : Form
    {
        private readonly IDataProvider Provider;
        
        private readonly IApiProvider ApiProvider;

        private readonly IFormFactory FormFactory;

        public MainForm(IFormFactory formFactory, IDataProvider provider,IApiProvider apiProvider)
        {
            Provider = provider;
            ApiProvider = apiProvider;
            FormFactory = formFactory;
            InitializeComponent();

            textBox1.Text += $"Create from {Program.Watch.Elapsed.TotalSeconds} {Environment.NewLine}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var response = Provider.GetData("Peter");

            textBox1.Text += response + Environment.NewLine;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form2 = FormFactory.Create<Form2>();
            form2?.Show("T1");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form1 = FormFactory.Create<Form1>();
            form1?.Show("Single");
        }
    }
}
