using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwaitTest
{
    internal static class Program
    {

        internal static Form1 form1;
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Task.Run(async () =>
            //{
            //    TestCall testCall = new TestCall();
            //    await testCall.T1();
            //    Debug.WriteLine("Main Done");
            //});
            form1 = new Form1();
            Application.Run(form1);
        }
    }
}
