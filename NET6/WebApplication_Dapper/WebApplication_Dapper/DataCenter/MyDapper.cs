using System.Data;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Data.SqlClient;
using Dapper;
using WebApplication_Dapper.Model;
using System.Xml;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace WebApplication_Dapper.DataCenter
{
    public class MyDapper
    {
        public DataDto GetData(string sql)
        {
            var data = GetDataTable(sql);
            DataDto result = new DataDto();
            string[] rows = new string[data.Rows.Count];
            for(int i=0;i<rows.Length; i++)
            {
                DataRow row = data.Rows[i];
                string rowString = string.Join(",", row.ItemArray.Select(o => o.ToString()));
                rows[i]= rowString;
            }
            result.Columns = data.Columns.Cast<DataColumn>().Select(o=>new MyColumn(o)).ToArray();
            result.data = rows;
            return result;
        }

        private DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            string connectionString = "Data Source=192.168.10.24;Initial Catalog=northwind;Persist Security Info=True;User ID=pcteamapplication;Password=pcteamapplication;Application Name=ToulinTest";
            // 宣告資料庫連線
            using (var connection = new SqlConnection(connectionString))
            {
                var dr = connection.ExecuteReader(sql);
                dt.Load(dr);
            }
            return dt;
        }
    }
}
