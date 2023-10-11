using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Newtonsoft_Sample
{
    public class SampleClassA
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        [JsonConverter(typeof(ClassBConverter))]
        public ClassB Detail { get; set; } = new ClassB();
    }
}
