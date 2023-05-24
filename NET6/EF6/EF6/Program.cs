using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EF6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            int lastestAccountID;
            //Read
            using (var context = new MyDbContext())
            {
                var account = context.Account.OrderByDescending(x => x.AccountID).FirstOrDefault();
                lastestAccountID = account.AccountID;
                Console.WriteLine($"Id: {account.AccountID}, Name: {account.Name}, Age: {account.Age}");
            }
            Console.ReadLine();

            //write 
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
        }
    }
}