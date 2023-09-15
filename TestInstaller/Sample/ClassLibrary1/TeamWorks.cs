using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDetail;

namespace ClassLibrary1
{
    public class TeamWorks
    {
        public string GetName()
        {
            var person = new Person();
            return person.WhoAreYou();
        }
    }
}
