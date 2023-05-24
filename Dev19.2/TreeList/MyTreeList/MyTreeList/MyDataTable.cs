using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyTreeList
{
    public class MyDataTable
    {
        private DataTable MyData;
        public MyDataTable()
        {
            CreateData();
        }
        public DataTable Data
        {
            get
            { return MyData; }
            set
            { MyData = value; }
        }
        private void CreateData()
        {
            MyData = new DataTable();
            MyData.Columns.Add("ID", typeof(int));
            MyData.Columns.Add("PID", typeof(int));
            MyData.Columns.Add("OrderNum", typeof(int));
            MyData.Columns.Add("Display", typeof(string));

            MyData.Rows.Add(new object[] { 2, 0, 1, "D1" });
            MyData.Rows.Add(new object[] { 3, 0, 2, "E2" });
            MyData.Rows.Add(new object[] { 4, 0, 3, "F3" });
            MyData.Rows.Add(new object[] { 5, 0, 4, "G4" });
            MyData.Rows.Add(new object[] { 6, 0, 5, "H5" });
            MyData.Rows.Add(new object[] { 1, 0, 6, "I6" });
            MyData.AcceptChanges();
        }
    }
}
