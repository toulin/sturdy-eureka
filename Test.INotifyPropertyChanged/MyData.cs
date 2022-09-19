using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestINotifyPropertyChanged
{
    public class MyData : INotifyPropertyChanged
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
        public string Name { get; set; }

        virtual protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            // Safely raise the event for all subscribers
            PropertyChanged?.Invoke(this, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
