using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitTest
{
    internal class CallAP
    {
        HttpClient Client = new HttpClient();
        public async Task<string> GetDataNo()
        {
            Debug.WriteLine($"GetData Start(), threadID= {Thread.CurrentThread.ManagedThreadId}");
            string contentString = "{\"ViewName\":\"sysdbase\"}\"}";
            string url = "http://192.168.112.131/CMoneyDataEngineApi/api/Command/Read/7/TableBinary";
            var content = new StringContent(contentString, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(url, content);
            Debug.WriteLine($"response Done , threadID= {Thread.CurrentThread.ManagedThreadId}");
            var result = await response.Content.ReadAsStringAsync();
            Debug.WriteLine($"Done(Lenght ={result.Length}), threadID= {Thread.CurrentThread.ManagedThreadId}");
            return result;
        }

        public async Task<string> GetData(string no)
        {
            //假的非同步工作

            Debug.WriteLine($"GetData Start({no}), threadID= {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(1000);

            Debug.WriteLine($"GetData Done({no}), threadID= {Thread.CurrentThread.ManagedThreadId}");
            return "Done";
        }
    }
}
