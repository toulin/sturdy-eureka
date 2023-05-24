using System.Data;

namespace WebApplication_Dapper.Model
{
    public class DataDto
    {
        public MyColumn[] Columns { get; set; }  
        public string[] data { get; set; }  
    }
}
