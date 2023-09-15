
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySample
{
    internal class MyDataProviderA:IDataProvider
    {
        private double CreateSeconds = 0;

        public MyDataProviderA() 
        {
            Random random = new Random(DateTime.Now.Millisecond);
            CreateSeconds = Program.Watch.Elapsed.TotalSeconds;
        }

        public string GetData(string name)
        {
            return $"Hello {name},   MyDataProviderA's HashCode={this.GetHashCode()}, {CreateSeconds}";
        }
    }
}
