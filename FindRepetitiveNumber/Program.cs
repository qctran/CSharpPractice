using System;
using System.Collections.Generic;
using System.Linq;

namespace FindRepetitiveNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new[] {0, 1, 2, 5, 2, 6, 2, 3, 9};
            var dict = new Dictionary<int, int>();

            for (var i = 0; i < a.Length; i++)
            {
                int value;
                if (dict.ContainsKey(a[i]))
                {
                    dict.TryGetValue(a[i], out value);
                    value++;
                    dict[a[i]] = value;
                }
                else
                {
                    dict.Add(a[i], 1);
                }
            }

            Console.WriteLine(dict.Values.Max());
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
