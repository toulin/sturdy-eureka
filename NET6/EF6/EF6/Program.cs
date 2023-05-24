using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EF6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("讀取最新帳號編號");
            int lastestAccountID;
            //Read la
            using (var context = new MyDbContext())
            {
                var account = context.Account.OrderByDescending(x => x.AccountID).FirstOrDefault();
                lastestAccountID = account.AccountID;
                Console.WriteLine($"Id: {account.AccountID}, Name: {account.Name}, Age: {account.Age}");
            }


            Console.WriteLine($"即將新增一筆 ID={lastestAccountID+1}的資料");
            Console.ReadLine();
            //AddNew
            using (var context = new MyDbContext())
            {
                var account = new Account()
                {
                    AccountID = lastestAccountID+1,
                    Name = "ToulinTest",
                    Age = 30
                };

                context.Account.Add(account);
                context.SaveChanges();
            }

            Console.WriteLine($"即將更新 ID={lastestAccountID}的資料");
            Console.ReadLine();

            //update lastestAccountID
            using (var context = new MyDbContext())
            {
                var account = new Account();
                account.AccountID = lastestAccountID;
                context.Account.Attach(account);
                account.Name = "ToulinTestUpdate";
                context.SaveChanges();
            }
            Console.WriteLine("更新完畢");
            Console.ReadLine();

            //批次更新
            using (var context = new MyDbContext())
            {
                var whereAccount = context.Account.Where(o => o.AccountID > 10);
                whereAccount.ToList().ForEach(o => o.Name = $"Test-{o.Age}");
                context.SaveChanges();
            }
            Console.ReadLine();
            Console.WriteLine("批次更新完成");
        }
    }
}