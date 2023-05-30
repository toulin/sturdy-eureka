using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 獲取作業系統版本
            var osDescription = System.Runtime.InteropServices.RuntimeInformation.OSDescription;

            // 輸出作業系統版本
            Console.WriteLine("作業系統版本：" + osDescription);

            // 進行作業系統版本比較
            if (osDescription.Contains("Windows 10"))
            {
                Console.WriteLine("您目前運行的是 Windows 10 或更新的作業系統版本。");
            }
            else if (osDescription.Contains("Windows 8.1"))
            {
                Console.WriteLine("您目前運行的是 Windows 8.1 或 Windows Server 2012 R2 作業系統版本。");
            }
            else if (osDescription.Contains("Windows 8"))
            {
                Console.WriteLine("您目前運行的是 Windows 8 或 Windows Server 2012 作業系統版本。");
            }
            else if (osDescription.Contains("Windows 7"))
            {
                Console.WriteLine("您目前運行的是 Windows 7 或 Windows Server 2008 R2 作業系統版本。");
            }
            else
            {
                Console.WriteLine("無法識別您目前運行的作業系統版本。");
            }
            Console.ReadKey();
        }
        static string GetWindowsVersion()
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
            {
                if (key != null)
                {
                    return key.GetValue("CurrentVersion").ToString();
                }
            }
            return string.Empty;
        }
    }
}
