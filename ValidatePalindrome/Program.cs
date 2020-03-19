using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidatePalindrome
{
    /* LeetCode.com
        Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.

        Note: For the purpose of this problem, we define empty string as valid palindrome.

        Example 1:

        Input: "A man, a plan, a canal: Panama"
        Output: true
        Example 2:

        Input: "race a car"
        Output: false
     */
    class Program
    {
        static void Main(string[] args)
        {
            var testData = new List<string>
            {
                "A man, a plan, a canal: Panama",
                "This is a car",
                "",
                "a",
                "ab,ba",
                "abcBA"
            };

            foreach(var s in testData)
            {
                Console.Write("\"" + s + "\" is a palindrom = ");
                Console.WriteLine(IsPalindrome(s));
            }
        }

        public static bool IsPalindrome(string s)
        {
            if (String.IsNullOrEmpty(s)) return true;

            s = s.ToLower();
            s = s.Replace(" ", "");
            s = s.Replace(",", "");
            s = s.Replace(".", "");
            s = s.Replace(":", "");
            var midPt = s.Length / 2;
            var a = s.ToArray();
            for (var i = 0; i < midPt; i++)
            {
                if (a[i] != a[s.Length - 1 - i]) return false;
            }
            return true;
        }
    }
}
