using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Configuration;

namespace SerilogTry
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            logger.Information("Hi..." );
            Console.ReadLine();
        }
    }
}
