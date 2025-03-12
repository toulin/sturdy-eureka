using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskRun
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                Console.WriteLine("A");
                await Test1();
                Console.WriteLine("B");

                await Test2();
                Console.WriteLine("C");
            });
            Console.WriteLine("D");
            Console.ReadLine();
        }


        static Task Test1()
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Test1 1");
                Task.Delay(1000).Wait();
                Console.WriteLine("Test1 2");
            });
        }

        static Task Test2()
        {
            return Task.Run(async() =>
            {
                Console.WriteLine("Test2 1");
                await Task.Delay(1000);
                Console.WriteLine("Test2 2");
            });
        }
    }
}
