using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace MySample
{
    internal static class Program
    {
        internal static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var _serviceProvider = new ServiceCollection()
                .AddTransient<MainForm>() 
               .AddSingleton<IDataProvider, MyDataProviderA>() 
               .AddScoped<IApiProvider,MyApi>()
               .BuildServiceProvider();
            ServiceProvider = _serviceProvider;

            // 使用工厂创建窗体
            var mainFormFactory = _serviceProvider.GetRequiredService<MainForm>();
             
            Application.Run(mainFormFactory);
        }
    }
}
