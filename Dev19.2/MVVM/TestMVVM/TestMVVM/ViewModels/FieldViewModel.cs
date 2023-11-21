using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using TestMVVM.Models;

namespace TestMVVM.ViewModels
{
    /// <summary>
    /// 欄位選單的ViewModel
    /// </summary>
    public class FieldViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// 欄位清單
        /// </summary>
        private ObservableCollection<ColItem> MyFields;

        private ViewInfo MyViewInfo;
        /// <summary>
        /// View物件
        /// </summary>
        public ViewInfo ViewInfo
        {
            get => MyViewInfo;
            set
            {
                MyViewInfo = value;
                //異動表格名稱
                RaisePropertyChanged("DispName");
            }
        }

        /// <summary>
        /// 資料表名稱
        /// </summary>        
        public string DispName
        {
            get => ViewInfo?.DispName;
        }

        /// <summary>
        /// 欄位清單
        /// </summary>
        public ObservableCollection<ColItem> Fields
        {
            get => MyFields;
            set => MyFields = value;
        }

        /// <summary>
        /// 屬性異動通知
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 通知屬性異動
        /// </summary>
        /// <param name="propertyName"></param>
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void LoadFields(string CMenuID)
        {
            if (CMenuID == "M002")
            {
                MyFields.Clear();
                for(int i = 0; i < 5; i++)
                {
                    MyFields.Add(new ColItem { Name = RandString() });
                }
                
            }
            else
            {
                MyFields.Clear();
                for (int i = 0; i < 3; i++)
                {
                    MyFields.Add(new ColItem { Name = RandString() });
                }
            }
        }

        private Random MyRandom = new Random(DateTime.Now.Millisecond);
        private string RandString()
        {

            return MyRandom.Next(1000, 9999).ToString();
        }

        private int RandInt()
        {
            return MyRandom.Next(1000, 9999);
        }
    }
}
