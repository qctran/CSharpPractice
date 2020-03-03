using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Sum(123456789));
        }

        private static int Sum(int n)
        {
            if (n == 0)
                return 0;
            else
            {
                return n % 10 + Sum(n / 10);
            }
        }
    }
}
