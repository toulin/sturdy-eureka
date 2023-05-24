using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestVirtual
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, MyBase> keyValuePairs = new Dictionary<int, MyBase>();
            keyValuePairs.Add(1, new MyBase { Count = 2 });
            if (keyValuePairs.TryGetValue(1, out MyBase myBase1))
            {
                myBase1.Count = 100;
            }

            MyBase myBase = new MyBase();
            Debug.WriteLine(myBase.Do(2));
            MyClassA myClassA = new MyClassA();
            
            Debug.WriteLine((myClassA as MyBase).Do(2));
            Debug.WriteLine(myClassA.Do(2));
        }
    }
}
