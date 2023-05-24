using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelAddin2023TEST.MyLog
{
    public interface ILog
    {
        void Log(string message);
        void Log(Exception exception);
    }
}
