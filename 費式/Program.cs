using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 費式
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int anser= solution.fib(4);

        }
    }
    //參考自 https://iter01.com/511801.html

    class Solution
    {
        public int fib(int N)
        {
            if (N == 0)
            {
                return 0;
            }
            else if (N == 1)
            {
                return 1;
            }
            return fib(N - 1) + fib(N - 2);
        }
    }
}
