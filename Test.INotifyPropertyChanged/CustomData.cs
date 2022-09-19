using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestINotifyPropertyChanged
{
    public class CustomData: INotifyPropertyChanged
    {
        private MyData Data;
        public CustomData(MyData data)
        {
            Data = data;
        }

        public string CustomeID { get; set; }
        public long Id
        {
            get
            {
                if (Data == null)
                {
                    return -1;
                }
                else
                {
                    return Data.ID;
                }
            }
            set
            {
                Data.ID = value;
                OnPropertyChanged("Id");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raise the event when property value changed.
        /// </summary>
        /// <param name="Name">Property name</param>
        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
