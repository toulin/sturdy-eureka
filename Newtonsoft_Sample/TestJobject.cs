using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
                        var propertyType = property.PropertyType;;
                        if (property.Name=="Detail")
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

        /// <summary>
        /// 將欄位陣列和資料陣列透過JObject轉換成指定泛型的List集合
        /// </summary>
        /// <typeparam name="T">對集合元素的泛型</typeparam>
        /// <param name="columns">欄位名稱陣列</param>
        /// <param name="data">資料陣列</param>
        /// <returns></returns>
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
    }
}
