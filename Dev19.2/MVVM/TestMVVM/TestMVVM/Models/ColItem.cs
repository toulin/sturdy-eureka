using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVVM.Models
{
    public class ColItem
    {
        public string Name { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
