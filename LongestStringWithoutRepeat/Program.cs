using System;
using System.Text;

namespace LongestStringWithoutRepeat
{
    class Program
    {
        static void Main(string[] args)
        {
            //var result = LengthOfLongestSubstring("pwwkew"); // 3
            //var result = LengthOfLongestSubstring("ppppp"); // 1
            //var result = LengthOfLongestSubstring("abcabcbb"); // 3
            //var result = LengthOfLongestSubstring("aab"); // 2 - failed
            //var result = LengthOfLongestSubstring("abb"); // 2 - failed
            var result = LengthOfLongestSubstring("abcdefghh"); // 8
            Console.WriteLine("The max non-repeated char length: {0}", result);
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
