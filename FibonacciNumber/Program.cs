using System;
using System.Collections.Generic;

namespace FibonacciNumber
{
    class Program
    {
        static Dictionary<int, int> _cache = new Dictionary<int, int>();
        static void Main(string[] args)
        {
            for (var i = 0; i < 20; i++)
            {
                var result = Fib(i);
                Console.WriteLine("n: " + i + " value: " + result);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static int Fib(int n)
        {
            if (_cache.ContainsKey(n))
            {
                int value;
                _cache.TryGetValue(n, out value);
                return value;
            }

            int result;
            if (n < 2)
            {
                return n;
            }

            result = Fib(n - 1) + Fib(n - 2);

            _cache.Add(n, result);
            
            return result;
        }
    }
}
