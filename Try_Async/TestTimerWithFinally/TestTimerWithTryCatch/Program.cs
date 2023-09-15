using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTimerWithTryCatch
{
    class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("Sample A: Timer Restart without finally");
            Console.ReadKey();
            TestTimerWithoutFinally testTimerWithoutFinally = new TestTimerWithoutFinally();
            testTimerWithoutFinally.Start();

            Console.ReadKey();
            Console.WriteLine("Sample B: Timer Restart using finally ");
            TestTimerUsingFinally testTimerUsingFinally = new TestTimerUsingFinally();
            testTimerUsingFinally.Start();

            Console.ReadKey();
        }

    }
}
