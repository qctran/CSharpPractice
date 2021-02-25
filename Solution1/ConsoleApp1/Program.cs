using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 0; i < 10; i++)
            {
                var r = f(i);
                Console.WriteLine(r);
            }

        }

        static int f(int x)
        {
            if (x < 1) return 1;
            else return f(x - 1) + g(x);
        }

        static int g(int x)
        {
            if (x < 2) return 1;
            else return f(x - 1) + g(x / 2);
        }
        static int Func(int n)
        {
            if (n == 4)
                return 2;
            else
                return 2 * Func(n + 1);
        }
    }
}
