using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace EF6
{
    public class MyDbContext : DbContext
    {
        public DbSet<Account> Account { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Data Source=192.168.99.24;Initial Catalog=TESTDB;Persist Security Info=True;TrustServerCertificate=true;User ID=pcteamapplication;Password=pcteamapplication;Application Name=Test";
            optionsBuilder.UseSqlServer(connection); 
        }

        public void TestDapperInsertBySQL(Account account)
        {
            using (var trn = Database.BeginTransaction())
            {                 
                // 呼叫 Database.GetDbConnection() 取得 IDbConnection 物件
                var cn = Database.GetDbConnection();
                // using Microsoft.EntityFrameworkCore.Storage 以取得 GetDbTransaction() 擴充方法
                // 取得 IDbTransaction 物件作為 cn.Execute 或 cn.Query 參數
                cn.Execute("Update Account SET Name=@name, Age=@age WHERE AccountID=@accountID ", new
                {
                    accountID = account.AccountID,
                    name = account.Name,
                    age = account.Age
                },trn.GetDbTransaction());
                trn.Commit();
            }
        }
    }
}
