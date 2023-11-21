using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;

namespace TestMVVM.UserControls
{
    public partial class ViewsTree : DevExpress.XtraEditors.XtraUserControl, ITreeListControl
    {
        public ViewsTree(ViewModels.ViewsTreeViewModel model)
        {
            InitializeComponent();
            treeList1.KeyFieldName = nameof(Models.TreeNodeData.Id);
            treeList1.ParentFieldName = nameof(Models.TreeNodeData.ParentId);
            treeList1.RootValue = null;

            mvvmContext1.SetViewModel(typeof(ViewModels.ViewsTreeViewModel), model);
            
            var fluent = mvvmContext1.OfType<ViewModels.ViewsTreeViewModel>();
            var test = fluent.ViewModel;
            fluent.SetBinding(treeList1, c => c.DataSource, x => x.ViewTreeData);
            fluent.WithEvent<DevExpress.XtraTreeList.FocusedNodeChangedEventArgs>(treeList1, "FocusedNodeChanged")
                .EventToCommand(x => x.FocusedNodeChanged);

        }


        public void RefreshDataSource()
        {
            treeList1.RefreshDataSource();
        }
    }
}
