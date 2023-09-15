using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySample
{
    internal class MyApi : IApiProvider
    { 
        private readonly double CreateSeconds;

        public MyApi()
        {
            Random random = new Random(DateTime.Now.Millisecond); 
            CreateSeconds = Program.Watch.Elapsed.TotalSeconds;
        }

        public string GetAPI(string name)
        {
            return $"Good! {name}   MyApi's HashCode={this.GetHashCode()}, {CreateSeconds}";
        }
    }
}
