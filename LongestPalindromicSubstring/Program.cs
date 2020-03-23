using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestPalindromicSubstring
{
    /*  Leetcode.com - Medium
        Given a string s, find the first palindromic substring in s. 
        You may assume that the maximum length of s is 1000.

        Example 1:

        Input: "babad"
        Output: "bab"
        Note: "aba" is also a valid answer.
        Example 2:

        Input: "cbbd"
        Output: "bb"
     */
    class Program
    {
        static void Main(string[] args)
        {
            var testData = new List<string>()
            {
                "a",
                "aa",
                "aaaaaaaa",
                "ab",
                "abba",
                "abccba",
                "12345abccba54321",
                "12345abccba50321",
                "ab12345abccba54321",
                "12345abccba54321ab",
                "aba",
                "ccc",
                "abcba",
                "babab",
                "12babab",
                "babab12",
                "12345abcba54321",
                "12345abcba50321",
                "abcde"
            };

            foreach(var s in testData)
            {
                Console.Write(s + " : ");
                var result = FirstPalindrome(s);
                Console.WriteLine(result);
            }
            
        }

        public static string FirstPalindrome(string s)
        {
            if (String.IsNullOrEmpty(s))
                return string.Empty;

            var ary = s.ToArray();
            string result = string.Empty;

            if (ary.Length == 1) return ary[0].ToString();
            if (ary.Length == 2)
            {
                if (ary[0] == ary[1]) return s;
                else return ary[0].ToString();
            }
            else
            {
                // there are 3 or more elements in the ary.
                for (var i = 1; i < ary.Length; i++)
                {
                    if (ary[i] == ary[i-1])
                    {
                        // Case: aaaaaa
                        for(var n = i; n < ary.Length; n++)
                        {
                            if (ary[i] == ary[n])
                            {
                                result = string.Format("{0}{1}", result, ary[n]);
                            }
                        }
                        if (result.Length > 0)
                        {
                            result = string.Format("{0}{1}", ary[i - 1], result);
                            return result;
                        }

                        // Case: caab
                        result = string.Format("{0}{1}", ary[i], ary[i - 1]);
                        var k = 3;
                        for(var j = i + 1; j < ary.Length; j++)
                        {
                            if (j > ary.Length - 1 || j - k < 0)
                            {
                                if (ary[j] == ary[j - 2])
                                {
                                    result = string.Format("{0}{1}{2}", ary[j - 2], ary[i], ary[j]);
                                }
                                //else
                                //{
                                //    return result;
                                //}
                                return result;
                            }
                            else
                            {
                                if (ary[j] == ary[j-k])
                                {
                                    result = string.Format("{0}{1}{2}", ary[j], result.ToString(), ary[j]);
                                }
                                else
                                {
                                    return result;
                                }
                            }
                            k += 2;
                        }
                    }
                    else
                    {
                        // Case: aba
                        var k = 2;
                        for (var j = i + 1; j < ary.Length; j++)
                        {
                            if (j - k >= 0)
                            {
                                if (ary[j] == ary[j - k])
                                {
                                    if (string.IsNullOrEmpty(result))
                                    {
                                        result = string.Format("{0}{1}{2}", ary[j - k], ary[i], ary[j]);
                                    }
                                    else
                                    {
                                        //if (result.EndsWith(","))
                                        //{
                                        //    result = string.Format("{0}{1}{2}{3}", result, ary[j - k], ary[i], result, ary[j]);
                                        //}
                                        //else
                                        //{
                                        //    result = string.Format("{0}{1}{2}", ary[j - k], result, ary[j]);
                                        //}
                                        result = string.Format("{0}{1}{2}", ary[j - k], result, ary[j]);
                                    }
                                    k += 2;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                return result;
                                //result = string.Format("{0},", result);
                                //continue;
                            }
                        }
                    }
                }
            }

            if (result.Length > 0)
            {
                return result;
            }
            else
            {
                return ary[0].ToString();
            }
        }
    }
}
