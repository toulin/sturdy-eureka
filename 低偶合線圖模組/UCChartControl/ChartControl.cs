using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ChartInterface;

namespace UCChartControl
{
    public class ChartControl: IChart
    {
        public Control CretaeUChart()
        {
            UCChartA uCChartA = new UCChartA();
            return uCChartA;
        }
    }
}
