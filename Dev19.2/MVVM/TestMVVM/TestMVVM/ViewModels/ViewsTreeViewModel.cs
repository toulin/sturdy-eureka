using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Native;
using TestMVVM.Models;

namespace TestMVVM.ViewModels
{
    [POCOViewModel]
    public class ViewsTreeViewModel: INotifyPropertyChanged
    {
        /// <summary>
        /// 樹狀控制項(View清單)介面
        /// </summary>
        public ITreeListControl MyTreeListControl { get; set; }

        public ViewsTreeViewModel()
        {
            MyViewTreeData = new ObservableCollection<TreeNodeData>();
            MyViewTreeData.CollectionChanged += MyViewTreeData_CollectionChanged;
        }

        private void MyViewTreeData_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine("MyViewTreeData_CollectionChanged Changed");
            MyTreeListControl.RefreshDataSource();
        }

        /// <summary>
        /// 目錄清單
        /// </summary>
        private ObservableCollection<TreeNodeData> MyViewTreeData;


        /// <summary>
        /// 目錄清單
        /// </summary>
        public ObservableCollection<TreeNodeData> ViewTreeData
        {
            get => MyViewTreeData;
            set
            {
                MyViewTreeData = value;
                Debug.WriteLine("ViewTreeData Changed");
                RaisePropertyChanged(nameof(ViewTreeData));
            }
        }

        public void LoadViews(string CMenuID)
        {
            MyViewTreeData.Clear();
            if (CMenuID == "M002")
            {
                ViewTreeData.Add(new Models.TreeNodeData(1, 0, new Models.DocItem(RandInt(), RandString(), "#")));
                ViewTreeData.Add(new Models.TreeNodeData(2, 0, new Models.DocItem(RandInt(), RandString(), "E")));
                ViewTreeData.Add(new Models.TreeNodeData(3, 2, new Models.DocItem(RandInt(), RandString(), "S")));
                ViewTreeData.Add(new Models.TreeNodeData(4, 2, new Models.DocItem(RandInt(), RandString(), "S")));
                ViewTreeData.Add(new Models.TreeNodeData(5, 2, new Models.DocItem(RandInt(), RandString(), "Z")));

            }
            else
            {
                ViewTreeData.Add(new Models.TreeNodeData(1, 0, new Models.DocItem(RandInt(), RandString(), "#")));
                ViewTreeData.Add(new Models.TreeNodeData(2, 0, new Models.DocItem(RandInt(), RandString(), "E")));
                ViewTreeData.Add(new Models.TreeNodeData(3, 0, new Models.DocItem(RandInt(), RandString(), "S")));
                ViewTreeData.Add(new Models.TreeNodeData(4, 1, new Models.DocItem(RandInt(), RandString(), "S")));
                ViewTreeData.Add(new Models.TreeNodeData(5, 1, new Models.DocItem(RandInt(), RandString(), "Z")));
            }
        }

        Random MyRandom = new Random(DateTime.Now.Millisecond);

        private string RandString()
        {
            
            return MyRandom.Next(1000, 9999).ToString();
        }

        private int RandInt()
        {
            return MyRandom.Next(1000, 9999);
        }


        public void FocusedNodeChanged(DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            var node = e.Node;
            var item= node.GetValue(nameof(Models.TreeNodeData.Item));
            var docItem = item as Models.DocItem;
            Debug.WriteLine($"{e.Node.Id}, DocName= {docItem.DocName}");
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        
    }
}
