using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestVirtual
{
    internal class MyClassA :MyBase
    {
        internal override int Do(int i)
        {
            return i * i;
        }
    }
}
