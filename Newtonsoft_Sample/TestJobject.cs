using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft_Sample.MyAttribute;

namespace Newtonsoft_Sample
{
    internal static class TestJobject
    {
        public static List<T> GetListV3<T>(string[] columnNames, List<string[]> data)
        {
            var result = new List<T>();
            foreach (var row in data)
            {
                var obj = Activator.CreateInstance<T>();
                for (int i = 0; i < columnNames.Length; i++)
                {
                    var propertyName = columnNames[i];
                    
                    var property = typeof(T).GetProperty(propertyName);
                    if (property != null)
                    {
                        var customConvert= property.GetCustomAttribute<CustomConvertAttribute>();
                        var propertyType = property.PropertyType;;
                        if (customConvert!=null)
                        {
                            // 使用自定義的反序列化邏輯
                            property.SetValue(obj, JsonConvert.DeserializeObject<ClassB>(row[i],new ClassBConverter()));
                        }
                        else
                        {
                            property.SetValue(obj, Convert.ChangeType(row[i], propertyType));
                        }
                    }
                }
                result.Add(obj);
            }
            return result;
        }
        public static List<T> GetList<T>(string[] columns, List<string[]> data)
        {
            List<T> list = new List<T>();
            foreach (var item in data)
            {
                JObject jObject = new JObject();
                for (int i = 0; i < columns.Length; i++)
                {
                    jObject.Add(columns[i], item[i]);
                }
                list.Add(jObject.ToObject<T>());
            }
            return list;
        }

        public static List<T> GetList2<T>(string[] columns, List<string[]> data)
        {
            //columns to Dictionary
            Dictionary<string, string> columnsDic = new Dictionary<string, string>();
            foreach (var item in columns)
            {
                columnsDic.Add(item, item);
            }
            // 將欄位陣列和資料陣列轉換成JSON格式的字串
            string json = JsonConvert.SerializeObject(columnsDic);
            // 解析JSON字串成List<SampleClassA>
            List<T> sampleList = JsonConvert.DeserializeObject<List<T>>(json);
            return sampleList;
        }
    }
}
