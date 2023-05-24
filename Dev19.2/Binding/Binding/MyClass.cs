using DevExpress.Utils.Design.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binding
{
    public class MyClass
    {
        
        public int Id { get; set; }
        public string Name { get; set; } 
        public int Second
        {
            get
            { return Time.Second; }
        }
        public DateTime Time
        {
            get;set;
        }
        public override string ToString()
        {
            return $"{Id}:{Name}- {Time.Second}";
        }
    }
}
