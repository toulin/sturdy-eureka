using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Utils.Drawing;

namespace TestMVVM.Models
{
    public class ViewInfo
    {
        private ObservableCollection<ColItem> MyFields;

        public string DispName { get; set; }

        public ObservableCollection<ColItem> Fields
        {
            get=> MyFields;
            set=> MyFields = value;
        }

    }
}
