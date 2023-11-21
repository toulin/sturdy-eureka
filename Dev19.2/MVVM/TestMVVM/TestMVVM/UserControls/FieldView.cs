using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TestMVVM.UserControls
{
    public partial class FieldView : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// 建構式
        /// </summary>
        public FieldView(ViewModels.FieldViewModel model)
        {
            InitializeComponent();
            mvvmContext1.SetViewModel(typeof(ViewModels.FieldViewModel), model);
            var fluent = mvvmContext1.OfType<ViewModels.FieldViewModel>();
            fluent.SetBinding(listBoxControl1, c => c.DataSource, x => x.Fields);
            //binding a label's Text to a property of the ViewModel
            fluent.SetBinding(groupControl1, c => c.Text, x => x.DispName);
        }
    }
}
