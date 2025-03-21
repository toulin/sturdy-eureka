﻿using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MyTreeList
{
    public partial class Form1 : Form
    {
        private MyList MyDataSource = new MyList();
        private MyDataTable MyTableSource = new MyDataTable();
        public Form1()
        {
            InitializeComponent();
            LoadingData();
            treeList1.OptionsBehavior.Editable = false;
            treeList1.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.Single;
            treeList1.OptionsDragAndDrop.DropNodesMode = DevExpress.XtraTreeList.DropNodesMode.Standard;
            treeList1.DataSource = MyDataSource;
            treeList1.ParentFieldName = "PID";
            treeList1.KeyFieldName = "ID";

            treeList2.OptionsBehavior.Editable = false;
            treeList2.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.Single;
            treeList2.OptionsDragAndDrop.DropNodesMode = DevExpress.XtraTreeList.DropNodesMode.Standard;
            treeList2.DataSource = MyTableSource.Data;
            treeList2.ParentFieldName = "PID";
            treeList2.KeyFieldName = "ID";
        }
        private void LoadingData()
        {
            MyDataSource.Add(new MyClass1(6, 0, 0, "A1"));
            MyDataSource.Add(new MyClass1(7, 0, 1, "A2"));
            MyDataSource.Add(new MyClass1(8, 0,2, "B3"));
            MyDataSource.Add(new MyClass1(4, 0, 3, "B4"));
            MyDataSource.Add(new MyClass1(5, 0, 4, "C5"));
            MyDataSource.Add(new MyClass1(1, 0, 5, "C6"));

            
            
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
        }

        private void treeList_DragDrop(object sender, DragEventArgs e)
        {
            TreeListNode dragNode, targetNode;
            TreeList tl = sender as TreeList;
            Point p = tl.PointToClient(new Point(e.X, e.Y));

            dragNode = e.Data.GetData(typeof(TreeListNode)) as TreeListNode;
            targetNode = tl.CalcHitInfo(p).Node;
            tl.SetNodeIndex(dragNode, tl.GetNodeIndex(targetNode));
            e.Effect = DragDropEffects.None;  
        }

        private void treeList_AfterDragNode(object sender, AfterDragNodeEventArgs e)
        {
            TreeList tl = sender as TreeList;

            //依目前索引重設所有資料的「排序」欄位值
            foreach (TreeListNode node in tl.Nodes)
            {
                node.SetValue("OrderNum", tl.GetNodeIndex(node));
            }
            tl.EndSort();
        }

        private void treeList1_BeforeDragNode(object sender, BeforeDragNodeEventArgs e)
        {
            treeList1.BeginSort();
        }


        private void treeList2_BeforeDragNode(object sender, BeforeDragNodeEventArgs e)
        {
            treeList2.BeginSort();
        }
    }
}
