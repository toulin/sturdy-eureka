using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDictionary
{
    internal class MyClass
    {
        internal string Name { get; set; }
        internal int Id { get; set; }

        internal long Value { get; set; }

        internal void Add(int i)
        {
            Value += i;
        }

    }
}
