using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTreeList
{
    public class MyClass1
    {
        public MyClass1(int id,int parent,int sort,string display)
        {
            ID = id;
            PID = parent;
            OrderNum = sort;
            Display = display;
        }
        public int ID { get; set; }
        public int PID { get; set; }
        public int OrderNum { get; set; }
        public string Display { get; set; }
    }
}
