using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChartInterface;

namespace UCDevChart
{
    public class ChartControl : IChart
    {
        public Control CretaeUChart()
        {
            UCChartDev_1 uCChartA = new UCChartDev_1();
            return uCChartA;
        }
    }
}
