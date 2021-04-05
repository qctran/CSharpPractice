using System;

namespace FindAllPermutationString
{
    class Program
    {
        static void Main(string[] args)
        {
            var testString = "abc";
            
            var ary = testString.ToCharArray();
            var i = 0;
            var n = ary.Length;
            GetPermuStrings(testString, i, n-1);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void GetPermuStrings(string str, int i, int n)
        {
            // base case
            if (i == n)
            {
                Console.WriteLine($"{str}");
            }
            else
            {
                // iterate through the array
                for (var j = i; j <= n; j++)
                {
                    str = Swap(str, i, j);

                    GetPermuStrings(str, i + 1, n);

                    str = Swap(str, i, j);
                }
            }
        }

        private static string Swap(string str, int i, int j)
        {
            if (i == j) return str;

            Console.WriteLine($"swap [{i}] & [{j}]");
            var ary = str.ToCharArray();
            var temp = ary[i];
            ary[i] = ary[j];
            ary[j] = temp;

            var result = new string(ary);
            
            return result;
        }
    }
}
