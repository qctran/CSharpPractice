using System;
using System.Collections.Generic;
using System.Text;

namespace LongestStringWithoutRepeat
{
    class Program
    {
        static void Main(string[] args)
        {
            var testData = new List<string>()
            {
                "pwwkew", // 3
                "ppppp", // 1
                "abcabcbb",  // 3
                "aab", // 2 - failed
                "abb", // 2 - failed
                "abcdefghh" // 8
            };

            foreach(var s in testData)
            {
                Console.Write("\"{0}\" ", s);
                var result = LengthOfLongestSubstring(s);
                Console.WriteLine("The max non-repeated char length: {0}", result);
            }
        }

        public static int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            var charAry = s.ToCharArray();

            int max = 0;
            var count = 1;
            var sb = new StringBuilder();
            sb.Append(charAry[0]);
            for (var i = 1; i < charAry.Length; i++)
            {
                if (charAry[i] == charAry[i - 1])
                {
                    count--;
                }
                if ((charAry[i] != charAry[i - 1]) 
                    && (!sb.ToString().Contains(charAry[i].ToString())))
                {
                    //if (count == 0) count++; // Add one more count for the last char.
                    sb.Append(charAry[i]);
                    count++;
                }
                else
                {
                    max = (count > max) ? count : max;
                    sb.Clear();
                    count = 0;
                }
            }

            max = (count > max) ? count : max;
            return max;
        }
    }
}
