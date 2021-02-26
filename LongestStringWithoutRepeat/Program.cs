using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestStringWithoutRepeat
{
    class Program
    {
        static void Main(string[] args)
        {
            var testData = new List<string>()
            {
                "", // empty
                "a", // 1
                "aabb", // 2
                "abb", // 2
                "aab", // 2
                "abcabcbb",  // 3
                "pwwkew", // 3
                "ppppp", // 1
                "abccdefghh" // 8
            };

            foreach(var s in testData)
            {
                Console.Write("\"{0}\" ", s);
                FindLongestSubstring(s);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void FindLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                Console.WriteLine("- empty string");
                return;
            }

            var ary = s.ToCharArray();
            var storage = new Dictionary<string, int>();

            var sb = new StringBuilder();
            sb.Append(ary[0]);
            for (var i = 1; i < ary.Length; i++)
            {
                if (ary[i] == ary[i - 1])
                {
                    sb.Append(ary[i]);
                }
                else
                {
                    if (!storage.ContainsKey(sb.ToString()))
                    {
                        var x = sb.ToString();
                        storage.Add(x, x.Length);
                    }

                    sb.Clear();
                    sb.Append(ary[i]);
                }
            }

            // Add the last string
            if (!storage.ContainsKey(sb.ToString()))
            {
                storage.Add(sb.ToString(), sb.ToString().Length);
            }

            var max = storage.Values.Max();
            Console.WriteLine($"- the longest string has {max} characters.");
        }
    }
}
