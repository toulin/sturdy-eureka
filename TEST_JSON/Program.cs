using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using TEST_JSON.Models;

namespace TEST_JSON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"D:\我的GitHub\sturdy-eureka\TEST_JSON\sample.txt");
            Console.WriteLine($"{text.Length} 字");
            Console.ReadKey();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var data= Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseDataDto>(text);
            stopwatch.Stop();
            int count = data.datas.Count();
            Console.WriteLine($"Newtonsoft 耗時:{stopwatch.ElapsedMilliseconds} ms, 資料筆數={count}");
            Console.ReadKey();

            //using json.net to deserialize json string
            stopwatch.Restart();
            var data2 = Json.Net.JsonNet.Deserialize<ResponseDataDto>(text);
            stopwatch.Stop();
            count = data2.datas.Count();            
            Console.WriteLine($"Json.Net 耗時:{stopwatch.ElapsedMilliseconds} ms, 資料筆數={count}");
            Console.ReadKey();

            //using fastjson to deserialize json string
            stopwatch.Restart();
            var data3 = fastJSON.JSON.ToObject<ResponseDataDto>(text);
            stopwatch.Stop();
            count = data3.datas.Count();
            Console.WriteLine($"fastJSON 耗時:{stopwatch.ElapsedMilliseconds} ms, 資料筆數={count}");
            Console.ReadKey();

            //using Jil to deserialize json string
            stopwatch.Restart();
            var data4 = Jil.JSON.Deserialize<ResponseDataDto>(text);
            stopwatch.Stop();
            count = data4.datas.Count();
            Console.WriteLine($"Jil 耗時:{stopwatch.ElapsedMilliseconds} ms, 資料筆數={count}");
            Console.ReadKey();

            //Newtonsoft 資料序列化
            stopwatch.Restart();
            var newtonsoftText= Newtonsoft.Json.JsonConvert.SerializeObject(data);
            stopwatch.Stop();
            Console.WriteLine($"Newtonsoft 序列化耗時:{stopwatch.ElapsedMilliseconds} ms");
            Console.ReadKey();

            //Json.Net 資料序列化
            stopwatch.Restart();
            var jsonNetText = Json.Net.JsonNet.Serialize(data2);
            stopwatch.Stop();
            Console.WriteLine($"Json.Net 序列化耗時:{stopwatch.ElapsedMilliseconds} ms");
            Console.ReadKey();

            //fastJSON 資料序列化
            stopwatch.Restart();
            var fastJsonText = fastJSON.JSON.ToJSON(data3);
            stopwatch.Stop();
            Console.WriteLine($"fastJSON 序列化耗時:{stopwatch.ElapsedMilliseconds} ms");
            Console.ReadKey();

            //Jil 資料序列化
            stopwatch.Restart();
            var jilText = Jil.JSON.Serialize(data4);
            stopwatch.Stop();
            Console.WriteLine($"Jil 序列化耗時:{stopwatch.ElapsedMilliseconds} ms");
            Console.ReadKey();


            //校對，以Newtonsoft為基準
            Console.WriteLine(checkData(data, data2) ? "Json.Net 與Newtonsoft校對OK" : "Json.Net 校對NG");
            Console.WriteLine(checkData(data, data3) ? "fastJSON 與Newtonsoft校對OK" : "fastJSON 校對NG");
            Console.WriteLine(checkData(data, data4) ? "Jil 與Newtonsoft校對OK" : "Jil 校對NG");
            Console.ReadKey();
        }

        private static bool checkData(ResponseDataDto data, ResponseDataDto data2)
        {
            if(data.columns.Count() != data2.columns.Count())
            {
                return false;
            }
            for(int i=0;i<data.columns.Count();i++)
            {
                if (!data.columns[i].Equals(data2.columns[i]))
                {
                    return false;
                }
            }
            if (data.datas.Count() != data2.datas.Count())
            {
                return false;
            }
            for (int i = 0; i < data.datas.Count(); i++)
            {
                var list1 = data.datas[i];
                var list2= data2.datas[i];
                if (list1.Count() != list2.Count())
                {
                    return false;
                }
                for(int j=0;j<list1.Count();j++)
                {
                    if (!list1[j].ToString().Equals(list2[j].ToString()))
                    {
                        Console.WriteLine($"data1.list[{j}]={list1[j].ToString()} ; data2.list[{j}]={list2[j].ToString()}");
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
