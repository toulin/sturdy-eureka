using System;
using System.Collections.Generic;
using System.Data.Common;
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
            Test();
            Test2();
        }

        /// <summary>
        /// 產生測試用的假資料 - 具有欄位名稱陣列和資料陣列
        /// </summary>
        /// <returns></returns>
        private static (string[] columns, List<string[]> dataRows) CreateFakeJsonData()
        {
            ClassB class1 = new ClassB { CellName = "C5", SheetName = "工作表1" };
            string json1 = JsonConvert.SerializeObject(class1);
            ClassB class2 = new ClassB { CellName = "B3", SheetName = "工作表2" };
            string json2 = JsonConvert.SerializeObject(class2);

            string[] columns = new string[]
                {
                    "Id", "Name", "Description", "Price", "Detail"
                };

            List<string[]> dataRows = new List<string[]>()
                {
                    new string[] { "1", "Name1", "Description1", "1.1", json1},
                    new string[] { "2", "Name2", "Description2", "2.2", json2 }
                };
            return (columns, dataRows);
        }

        private static void Test2()
        {
            var (columns, dataRows) = CreateFakeJsonData();
            var result = TestJobject.GetList<SampleClassA>(columns, dataRows);

            PrintResult("test2", result);

        }

        private static void Test()
        {
            var (columns, dataRows) = CreateFakeJsonData();

            var data3 = TestJobject.GetListV3<SampleClassA>(columns, dataRows);
            PrintResult("test" ,data3);
        }

        private static void PrintResult(string title, List<SampleClassA> data)
        {
            Console.WriteLine(title);
            foreach (var item in data)
            {                
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Description + " " + item.Price);
                Console.WriteLine($"cell={item.Detail.CellName}, sheetName={item.Detail.SheetName}");
                            
            }
            Console.ReadKey();
            const string line = "----------------------------------";
            Console.WriteLine(line);
        }
    }
}
