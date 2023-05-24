using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestEFCore
{
    public class MyDbContext : DbContext
    {
        public DbSet<Account> Account { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Data Source=192.168.99.24;Initial Catalog=TESTDB;Persist Security Info=True;User ID=pcteamapplication;Password=pcteamapplication";
            optionsBuilder.UseSqlite(connection);
        }
    }
}
