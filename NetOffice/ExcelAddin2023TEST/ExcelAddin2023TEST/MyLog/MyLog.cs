using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace ExcelAddin2023TEST.MyLog
{
    internal class MyLog: ILog
    { 
        private readonly ILogger Logger;
        public MyLog(string title)
        {
            Logger = new LoggerConfiguration()
                .WriteTo.File(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), title, "log.txt"), rollingInterval: RollingInterval.Day)
                .MinimumLevel.Debug()
                .CreateLogger();
        }

        public void Log(string message)
        {
            Logger.Debug(message);
        }
        
        public void Log(Exception exception) 
        {
            Logger.Error(exception, "Exception");
        }
    }
}
