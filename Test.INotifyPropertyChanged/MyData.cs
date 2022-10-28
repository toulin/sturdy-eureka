using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestINotifyPropertyChanged
{
    public class MyData : INotifyPropertyChanged,IComparable<MyData>,IEquatable<MyData>
    {
        private long MyID;
        public long ID
        {
            get { return MyID; }
            set
            {
                MyID = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ID"));
            }
        }

        private string MyName;
        public string Name
        { 
            get
            { return MyName; }
            set
            {
                MyName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Name"));
            }
        }

        public int StamTime { get; set; }

        virtual protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            Debug.WriteLine($"{this.ID}-觸發屬性更新 {e.PropertyName} ");
            // Safely raise the event for all subscribers
            PropertyChanged?.Invoke(this, e);
        }

        public int CompareTo(MyData other)
        {
            Debug.WriteLine($"thisName={this.Name}, thisID={this.ID}");
            Debug.WriteLine($" Name={other.Name},  ID={other.ID}");
            if (this.ID < other.ID)
            { 
                return -1;
            }
            else if(this.ID> other.ID)
            {
                return 1;
            }
            else
            {
                return 0;
            }
            
        }

        public bool Equals(MyData other)
        {
            return other.ID == this.ID;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
