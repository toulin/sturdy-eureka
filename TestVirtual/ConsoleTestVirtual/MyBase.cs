using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestVirtual
{
    internal class MyBase
    {
        internal virtual int Do(int i)
        {
            return i += 1;
        }
        internal long Count { get; set; }
    }
}
