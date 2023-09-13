using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MySample
{
    public class Form1Factory
    {
        private readonly IServiceProvider _serviceProvider;

        public Form1Factory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public MainForm Create()
        {
            return _serviceProvider.GetRequiredService<MainForm>();
        }
    }
}
