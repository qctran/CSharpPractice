using System;

namespace Sort012
{
    class Program
    {
        static void Main()
        {
            int[] ary012 = new[] {0, 1, 1, 0, 1, 2, 1, 2, 0, 0, 0, 1};
            var output = RunSort012(ary012);
            PrintResult(output);
        }

        private static void PrintResult(int[] output)
        {
            foreach (var elem in output)
            {
                Console.Write(elem + " ");
            }

            Console.WriteLine();
        }

        private static int[] RunSort012(int[] a)
        {
            var lo = 0;
            var mid = 0;
            var hi = a.Length - 1;
            int temp;

            while (mid <= hi)
            {
                switch (a[mid])
                {
                    case 0:
                        temp = a[lo];
                        a[lo] = a[mid];
                        a[mid] = temp;
                        lo++;
                        mid++;
                        break;
                    case 1:
                        mid++;
                        break;
                    case 2:
                        temp = a[mid];
                        a[mid] = a[hi];
                        a[hi] = temp;
                        hi--;
                        break;
                }
            }
            return a;
        }
    }
}
