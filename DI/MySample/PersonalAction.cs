using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySample
{
    internal class PersonalAction :IPersonalAction
    {
        private double CreateSeconds = 0;

        public PersonalAction()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            CreateSeconds = Program.Watch.Elapsed.TotalSeconds;
        }

        public string Information(string name)
        {
            return $"Good! {name}  , PersonalAction's HashCode={this.GetHashCode()} ,{CreateSeconds}";
        }
    }
}
