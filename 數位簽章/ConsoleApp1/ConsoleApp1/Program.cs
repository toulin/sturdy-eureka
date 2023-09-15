using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CMoney2.Kernel.Standard;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> test = new List<string> { "1", "2", "3" };
            var ts = test.Where(o => o == "4");
            var list = ts.ToList();
            bool b = list.Count==0;
        }


        internal string HMACSHA256(string key, string data)
        {
            byte[] keyByte = Encoding.UTF8.GetBytes(key);
            byte[] dataByte = Encoding.UTF8.GetBytes(data);

            HMACSHA256 hmac = new HMACSHA256(keyByte);
            byte[] result = hmac.ComputeHash(dataByte);

            return Convert.ToBase64String(result);
        }
    }
}
