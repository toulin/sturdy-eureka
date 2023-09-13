
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySample
{
    internal class MyDataProviderA:IDataProvider
    {
        private int thisID = 0;

        public MyDataProviderA() 
        {
            Random random = new Random(DateTime.Now.Millisecond);
            thisID = random.Next(999);
        }

        public string GetData(string name)
        {
            return $"Hello {name}, My id is {thisID} , HashCode={this.GetHashCode()}";
        }
    }
}
