using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TryParser
{
    class Program
    {
        static void Main(string[] args)
        {
            
            TEST();
            TestA();
        }
        private static void TestA()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string s = "100";
            int parserI;
            for (int i = 0; i < 100000; i++)
            {
                parserI = int.Parse(s);
            }
            Console.WriteLine($"int.Parse spend {stopwatch.ElapsedMilliseconds}");
            stopwatch.Restart();
            for (int i = 0; i < 100000; i++)
            {
                parserI = Parse<int>(s);
            }
            Console.WriteLine($"int.Parse spend {stopwatch.ElapsedMilliseconds}");
            Console.ReadLine();
        }

        /// <summary>
        /// 效率不如 指定的轉換(如int.Parser
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        private static  T Parse<T>(object value)
        {
            if (value == null) return default(T);
            var converter = TypeDescriptor.GetConverter(type: typeof(T));
            return (T)converter.ConvertFrom(value);
        }

        private static MyDataA CreateData()
        {
            MyDataA a = new MyDataA
            {
                ID = 1,
                CreateTime = DateTime.Now,
                Name = "t1",
                NullableValue = 11,
                Value = 222,
                Value2 = 1.1
            };
            return a;
        }
        private static void TEST()
        {
            MyDataA A = CreateData();
            MyDataA B = CreateData();
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("ID", "3");
            values.Add("CreateTime", "2022/9/9 11:33:11");
            values.Add("Name", "TEST Name");
            values.Add("NullableValue", "");
            values.Add("Value", "3.3");
            values.Add("Value2", "4.3");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 100000; i++)
            {
                A.SetValue(values);
            }
            Console.WriteLine($"TypeConvert spend {stopwatch.ElapsedMilliseconds}");
            stopwatch.Restart();
            
            for (int i = 0; i < 100000; i++)
            {
                B.SetValue2(values);
            }
            Console.WriteLine($"if else spend {stopwatch.ElapsedMilliseconds}");
            Console.ReadLine();
        }
    }
}
