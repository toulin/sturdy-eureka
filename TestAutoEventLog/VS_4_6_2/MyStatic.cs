using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS_4_6_2
{
    internal static class MyStatic
    {

        public static void AddEventLog(string function, string eventName)
        {
            Debug.Write($"function={function} ; event={eventName}");
        }
    }
}
