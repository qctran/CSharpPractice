using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            else
            {
                result = Fib(n - 1) + Fib(n - 2);
            }
            
            _cache.Add(n, result);
            
            return result;
        }
    }
}
