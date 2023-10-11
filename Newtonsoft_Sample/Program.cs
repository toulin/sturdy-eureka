using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Newtonsoft_Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test2();
        }

        private static void Test3()
        {
            ClassB class1 = new ClassB { CellName = "C5", SheetName = "工作表1" };
            string json1 = JsonConvert.SerializeObject(class1);
            ClassB class2 = new ClassB { CellName = "B3", SheetName = "工作表2" };
            string json2 = JsonConvert.SerializeObject(class2);

            var result = TestJobject.GetListV3<SampleClassA>(
                new string[]
                {
                    "Id", "Name", "Description", "Price", "Detail"
                },
                new List<string[]>()
                {
                    new string[] { "1", "Name1", "Description1", "1.1", json1},
                    new string[] { "2", "Name2", "Description2", "2.2", json2 }
                });



            foreach (var item in result)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Description + " " + item.Price);
                Console.WriteLine($"cell={item.Detail.CellName}, sheetName={item.Detail.SheetName}");
            }
            Console.ReadKey();

        }

        private static void Test2()
        {
            ClassB class1 = new ClassB { CellName = "C5", SheetName = "工作表1" };
            string json1 = JsonConvert.SerializeObject(class1);
            ClassB class2 = new ClassB { CellName = "B3", SheetName = "工作表2" };
            string json2 = JsonConvert.SerializeObject(class2);

            var result = TestJobject.GetList<SampleClassA>(
                new string[] 
                {
                    "Id", "Name", "Description", "Price", "Detail"
                },
                new List<string[]>()
                { 
                    new string[] { "1", "Name1", "Description1", "1.1", json1}, 
                    new string[] { "2", "Name2", "Description2", "2.2", json2 }
                });



            foreach (var item in result)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Description + " " + item.Price);
                Console.WriteLine($"cell={item.Detail.CellName}, sheetName={item.Detail.SheetName}");
            }
            Console.ReadKey();

        }

        private void Test()
        {
            var result = TestJobject.GetList<SampleClassA>(
                new string[] { "Id", "Name", "Description", "Price", "CellName", "Detail.SheetName" },
                new List<string[]>() { new string[] { "1", "Name1", "Description1", "1.1", "A22", "工作表1" }, new string[] { "2", "Name2", "Description2", "2.2", "C6", "工作表2" } });



            foreach (var item in result)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Description + " " + item.Price);
                Console.WriteLine($"cell={item.Detail.CellName}, sheetName={item.Detail.SheetName}");
            }
            Console.ReadKey();

            var result2 = TestJobject.GetList2<SampleClassA>(
                new string[] { "Id", "Name", "Description", "Price", "CellName", "Detail.SheetName" },
                new List<string[]>() { new string[] { "1", "Name1", "Description1", "1.1", "A22", "工作表1" }, new string[] { "2", "Name2", "Description2", "2.2", "C6", "工作表2" } });

            foreach (var item in result)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Description + " " + item.Price);
                Console.WriteLine($"cell={item.Detail.CellName}, sheetName={item.Detail.SheetName}");
            }
            Console.ReadKey();
        }
    }
}
