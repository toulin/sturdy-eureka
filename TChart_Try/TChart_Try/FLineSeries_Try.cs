using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Steema.TeeChart;
using Steema.TeeChart.Styles;

namespace TChart_Try
{
    public partial class FLineSeries_Try : Form
    {
        TChart f_Chart = null;
        Series f_Series1;

        Random f_Random = null;
        public FLineSeries_Try()
        {
            InitializeComponent();
            f_Random = new Random(DateTime.Now.Second);
             
            f_Chart = new TChart();
            f_Series1 = new FastLine();
            f_Chart.Series.Add(f_Series1);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            f_Chart.Parent = bodyPanel;
            f_Chart.Dock = DockStyle.Fill;
            f_Chart.Legend.LegendStyle = LegendStyles.Series;
            
            f_Chart.Axes.Bottom.SetMinMax(0, 200);
            //f_Chart.Panel.MarginTop = 10;
            f_Chart.Axes.Left.SetMinMax(90, 110);
        } 

        private void bRun_Click(object sender, EventArgs e)
        { 
            f_Series1.Add(GetNextNumber());
        }

        private int GetNextNumber()
        {

            return f_Random.Next(97, 107);
            
        }
    }
}
