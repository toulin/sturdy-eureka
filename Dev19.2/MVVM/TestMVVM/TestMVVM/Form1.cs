using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestMVVM.UserControls;
using TestMVVM.ViewModels;

namespace TestMVVM
{
    public partial class Form1 : Form
    {
        ViewsTree ViewsControl;
        ViewModels.ViewsTreeViewModel TreeViewModel;

        FieldView FieldViewControl;
        ViewModels.FieldViewModel FieldViewModel;

        public Form1()
        {
            InitializeComponent();
            //UI、ViewModel初始化
            TreeViewModel = new ViewModels.ViewsTreeViewModel();
            ViewsControl = new ViewsTree(TreeViewModel);
            ViewsControl.Parent = TreePanel;
            ViewsControl.Visible = true;
            ViewsControl.Dock = DockStyle.Fill;
            TreeViewModel.MyTreeListControl = ViewsControl;

            FieldViewModel = new FieldViewModel();
            FieldViewModel.Fields = new System.Collections.ObjectModel.ObservableCollection<Models.ColItem>();
            FieldViewControl = new FieldView(FieldViewModel);
            FieldViewControl.Parent = ListPanel;
            FieldViewControl.Visible = true;
            FieldViewControl.Dock = DockStyle.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //載入資料
            TreeViewModel.LoadViews("M001");

            FieldViewModel.LoadFields("M001");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TreeViewModel.LoadViews("M002");
            FieldViewModel.LoadFields("M002");
        }
    }
}
