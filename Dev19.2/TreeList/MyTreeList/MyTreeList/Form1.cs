using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTreeList
{
    public partial class Form1 : Form
    {
        private MyList MyDataSource = new MyList();
        public Form1()
        {
            InitializeComponent();
            LoadingData();
        }
        private void LoadingData()
        {
            MyDataSource.Add(new MyClass1(6, 0, 0, "A1"));
            MyDataSource.Add(new MyClass1(7, 0, 1, "A2"));
            MyDataSource.Add(new MyClass1(8, 0,2, "B3"));
            MyDataSource.Add(new MyClass1(4, 0, 3, "B4"));
            MyDataSource.Add(new MyClass1(5, 0, 4, "C5"));
            MyDataSource.Add(new MyClass1(1, 0, 5, "C6"));

            treeList1.OptionsBehavior.Editable = false; 
            treeList1.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.Single;
            treeList1.OptionsDragAndDrop.DropNodesMode = DevExpress.XtraTreeList.DropNodesMode.Standard;
            treeList1.DataSource = MyDataSource;
            treeList1.ParentFieldName = "PID";
            treeList1.KeyFieldName = "ID";
            
        }

        private DragDropEffects GetDragDropEffect(TreeList tl, TreeListNode dragNode)
        {
            TreeListNode targetNode;
            Point p = tl.PointToClient(MousePosition);
            targetNode = tl.CalcHitInfo(p).Node;

            if (dragNode != null && targetNode != null
                && dragNode != targetNode
                && dragNode.ParentNode == targetNode.ParentNode)
            {
                //Debug.WriteLine($"{dragNode.GetValue("ID")}");
                return DragDropEffects.Move;
            }
            else
            {
                return DragDropEffects.None;
            }
        }
         

        private void treeList1_DragOver(object sender, DragEventArgs e)
        {
            

            //TreeListNode dragNode = e.Data.GetData(typeof(TreeListNode)) as TreeListNode;
            //e.Effect = GetDragDropEffect(sender as TreeList, dragNode);
        }

        private void treeList1_DragDrop(object sender, DragEventArgs e)
        {
            //e.Effect = DragDropEffects.None;

            //TreeListNode dragNode, targetNode;
            //TreeList tl = sender as TreeList;
            //Point p = tl.PointToClient(new Point(e.X, e.Y));

            //dragNode = e.Data.GetData(typeof(TreeListNode)) as TreeListNode;

            //targetNode = tl.CalcHitInfo(p).Node;

            //int dragSort = (int)dragNode.GetValue("OrderNum");
            //int targetSort = (int)targetNode.GetValue("OrderNum");
            //dragNode.SetValue("OrderNum", targetSort);
            //targetNode.SetValue("OrderNum", dragSort);

            TreeListNode dragNode, targetNode;
            TreeList tl = sender as TreeList;
            Point p = tl.PointToClient(new Point(e.X, e.Y));

            dragNode = e.Data.GetData(typeof(TreeListNode)) as TreeListNode;
            targetNode = tl.CalcHitInfo(p).Node;

            

            tl.SetNodeIndex(dragNode, tl.GetNodeIndex(targetNode));
            e.Effect = DragDropEffects.None;  
        }

        private void treeList1_DragEnter(object sender, DragEventArgs e)
        {
            TreeListNode dragNode;
            dragNode = e.Data.GetData(typeof(TreeListNode)) as TreeListNode;
            Debug.WriteLine($"{dragNode.GetValue("ID")}");
        }

        private void treeList1_BeforeDragNode(object sender, BeforeDragNodeEventArgs e)
        {
            SortTree.SortOrder = SortOrder.None;
        }

        private void treeList1_AfterDragNode(object sender, AfterDragNodeEventArgs e)
        {
            TreeList tl = sender as TreeList;
            foreach(TreeListNode node in tl.Nodes)
            {
                node.SetValue("OrderNum",tl.GetNodeIndex(node));
            }
            
            var newOrder = MyDataSource.OrderBy(o => o.OrderNum);
            tl.DataSource = newOrder.ToList();
            SortTree.SortOrder = SortOrder.Ascending;
        }
    }
}
