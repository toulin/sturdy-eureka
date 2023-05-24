using Microsoft.EntityFrameworkCore;

namespace MyTestEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var db = new MyDbContext();
            var top10 = db.Account.Take(10).ToList();
            top10.ForEach(x => Console.WriteLine(x));

            Console.ReadLine();
        }
    }
}