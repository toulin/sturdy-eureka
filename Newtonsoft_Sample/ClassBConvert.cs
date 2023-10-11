using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Newtonsoft_Sample
{
    public class ClassBConverter : JsonConverter<ClassB>
    {
        public override ClassB ReadJson(JsonReader reader, Type objectType, ClassB existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            Console.WriteLine(token.ToString());
            return JsonConvert.DeserializeObject<ClassB>(token.ToString());
        }

        public override void WriteJson(JsonWriter writer, ClassB value, JsonSerializer serializer)
        {
            var token = JToken.FromObject(value);
            token.WriteTo(writer);
        }
    }
}
