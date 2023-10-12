using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using MySample.Factory;

namespace MySample
{
    internal static class Program
    {
        internal static Stopwatch Watch { get; } = new Stopwatch();

        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Watch.Start();
            Application.SetCompatibleTextRenderingDefault(false);
            var _serviceProvider = new ServiceCollection()
                .AddTransient<IFormFactory, FormFactory>()          
                .AddSingleton<IDataProvider, MyDataProviderA>()     
                .AddTransient<IApiProvider, MyApi>()                //在每次開啟新視窗時，這個IApiProvider才會每次注入新實例
                .AddSingleton<IPersonalAction, PersonalAction>()    //在本示例中，AddSingleton 與 AddScoped 並無差異
                .AddTransient<MainForm>()
                .AddTransient<Form2>()      //每次開啟都是新實例視窗
                .AddSingleton<Form1>()      //每次開啟都是同一個實例視窗
                .BuildServiceProvider();

            // 使用自訂的Factory來創建視窗
            var mainFormFactory = _serviceProvider.GetRequiredService<MainForm>();
             
            Application.Run(mainFormFactory);
        }
    }
}
