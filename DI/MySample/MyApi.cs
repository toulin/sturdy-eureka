using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySample
{
    internal class MyApi : IApiProvider
    {
        private readonly IDataProvider _dataProvider;


        private int thisID = 0;

        public MyApi()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            thisID = random.Next(1000);
        }

        public string GetAPI(string name)
        {
            return $"Good! {name} got {thisID} dollar, HashCode={this.GetHashCode()}";
        }
    }
}
