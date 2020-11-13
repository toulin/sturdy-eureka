using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChartInterface;
namespace MainApp
{
    public partial class Form1 : Form
    {
        IChart IChart_TeeChart;
        IChart IChart_Dev;
        UCChartControl.ChartControl ChartControlTeeChart = new UCChartControl.ChartControl();
        UCDevChart.ChartControl ChartControlDevexpress = new UCDevChart.ChartControl();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IChart_TeeChart = ChartControlTeeChart as IChart;

            Control chart = IChart_TeeChart.CretaeUChart();
            panel1.Controls.Clear();
            chart.Parent = panel1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IChart_Dev = ChartControlDevexpress as IChart;
            Control chart = IChart_Dev.CretaeUChart();
            panel1.Controls.Clear();
            chart.Parent = panel1;
        }
    }
}
