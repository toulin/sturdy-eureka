using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDetail;

namespace ClassLibrary2
{
    public class Contury
    {
        /// <summary>
        /// 市長
        /// </summary>
        public string MayorName
        {
            get
            {
                var person = new Person();
                return person.WhoAreYou();
            }
        }
    }
}
