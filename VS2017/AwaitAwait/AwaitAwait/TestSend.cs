using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AwaitAwait
{
    public class TestSend
    {
        HttpClient Client = new HttpClient();
        private string html = "";
        public async Task Test()
        {
            await TestGet1Async();
            await TestGet2Async();
        }
        public async Task TestGet1Async()
        {
            //參考 https://blog.darkthread.net/blog/await-task-block-deadlock/
            var message = await Client.GetAsync("http://yahoo.com.tw").ConfigureAwait(false);
            html = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
            Debug.WriteLine(html);
        }
        public async Task TestGet2Async()
        {
            var message = await Client.GetAsync("http://google.com.tw");
            html = await message.Content.ReadAsStringAsync();
            Debug.WriteLine(html);
        }
    }
}
