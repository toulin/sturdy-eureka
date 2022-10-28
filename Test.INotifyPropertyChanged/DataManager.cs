using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestINotifyPropertyChanged
{
    public class DataManager<T> where T : IComparable<T>, IEquatable<T>, INotifyPropertyChanged
    {
        private BindingList<T> AllData;
        public DataManager()
        {
            AllData = new BindingList<T>();
        }
        public BindingList<T> Data
        {
            get
            {
                return AllData;
            }
            set
            {
                AllData = value;
            }
        }
        public void AsignData(T data)
        {
            try
            {
                var findData = AllData.FirstOrDefault(o => o.Equals(data));
                if (findData == null)
                {
                    //取得第一個比data大的項目，並插入該項目前面
                    var test = AllData.SkipWhile(o => o.CompareTo(data) == -1);
                    var indexItem = AllData.SkipWhile(o => o.CompareTo(data) == -1).FirstOrDefault();
                    if (indexItem == null)
                    {
                        AllData.Add(data);
                    }
                    else
                    {
                        int index = AllData.IndexOf(indexItem);
                        AllData.Insert(index, data);
                    }
                }
                else
                {
                    int index = AllData.IndexOf(findData);
                    foreach (var propety in findData.GetType().GetProperties())
                    {
                        var value = data.GetType().GetProperty(propety.Name).GetValue(data);
                        propety.SetValue(findData, value);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"AsignData - {ex.Message}");
            }
        }
    }
}
