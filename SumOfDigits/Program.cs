using System;

namespace SumOfDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Sum(123456789));

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
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
