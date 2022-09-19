using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TryParser
{
    public class MyDataA
    {
        public long ID { get; set; }
        public decimal Value { get; set; }
        public double Value2 { get; set; }

        public DateTime CreateTime { get; set; }

        public decimal? NullableValue { get; set; }

        public string Name { get; set; }


        private T Parse<T>(object value)
        {
            if (value == null) return default(T);
            var converter = TypeDescriptor.GetConverter(type: typeof(T));
            return (T)converter.ConvertFrom(value); 
        }

        /// <summary>
        /// 指定屬性名，寫入值
        /// </summary>
        /// <param name="values">key 屬性名 , value 值</param>
        public void SetValue(Dictionary<string, string> values)
        {
            foreach(string key in values.Keys)
            {
                var p = this.GetType().GetProperty(key);
                var value = values[key];
                var converter = TypeDescriptor.GetConverter(p.PropertyType);
                var result = converter.ConvertFrom(value);
                p.SetValue(this, result);
            }
        }

        /// <summary>
        /// 指定屬性名，寫入值
        /// </summary>
        /// <param name="values">key 屬性名 , value 值</param>
        public void SetValue2(Dictionary<string, string> values)
        {
            foreach (string key in values.Keys)
            {
                var p = this.GetType().GetProperty(key);
                var value = values[key];
                var nullable = Nullable.GetUnderlyingType(p.PropertyType);
                if (nullable != null)
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        p.SetValue(this, null);
                    }
                    else
                    {
                        SetStringValue(p, nullable.BaseType , value);
                    }
                } 
                else
                {
                    SetStringValue(p, p.PropertyType, value);
                } 
            }
        }

        private void SetStringValue(PropertyInfo propertyInfo, Type type, string value)
        {
            if (type.Equals(typeof(string)))
            {
                propertyInfo.SetValue(this, value);
            }
            else if (type.Equals(typeof(int)))
            {
                if (int.TryParse(value, out int valueInt))
                {
                    propertyInfo.SetValue(this, valueInt);
                }
            }
            else if (type.Equals(typeof(long)))
            {
                if (long.TryParse(value, out long valueLong))
                {
                    propertyInfo.SetValue(this, valueLong);
                }
            }
            else if (type.Equals(typeof(decimal)))
            {
                if (decimal.TryParse(value, out decimal valuedecimal))
                {
                    propertyInfo.SetValue(this, valuedecimal);
                }
            }
            else if (type.Equals(typeof(double)))
            {
                if (double.TryParse(value, out double valuedouble))
                {
                    propertyInfo.SetValue(this, valuedouble);
                }
            }
            else if (type.Equals(typeof(DateTime)))
            {
                if (DateTime.TryParse(value, out DateTime time))
                {
                    propertyInfo.SetValue(this, time);
                }
            }
            else
            {
                propertyInfo.SetValue(this, value);
            }
        }
    }
}
