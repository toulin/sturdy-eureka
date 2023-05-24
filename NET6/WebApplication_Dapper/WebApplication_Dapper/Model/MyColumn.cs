using System.Data;

namespace WebApplication_Dapper.Model
{
    public class MyColumn
    {
        public string Name { get; set; }
        public string DataType { get; set; }

        public MyColumn(DataColumn column)
        {
            Name = column.ColumnName;
            DataType = column.DataType.ToString();
        }
    }
}
