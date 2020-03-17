using System;
using System.Collections.Generic;

namespace MergeSortThreeArray
{
    /*
     Given three integer arrays arr1, arr2 and arr3 sorted in strictly increasing order, return a sorted array of only the integers that appeared in all three arrays.

        Example 1:
        Input: arr1 = [1,2,3,4,5], arr2 = [1,2,5,7,9], arr3 = [1,3,4,5,8]
        Output: [1,5]
        Explanation: Only 1 and 5 appeared in the three arrays.

        Constraints:

        1 <= arr1.length, arr2.length, arr3.length <= 1000
        1 <= arr1[i], arr2[i], arr3[i] <= 2000
     */
    class Program
    {
        static void Main(string[] args)
        {
            var arr1 = new int[] { 1, 2, 3, 4, 5 };
            var arr2 = new int[] { 1, 2, 5, 7, 9 };
            var arr3 = new int[] { 1, 3, 4, 5, 8 };
            var result = ArraysIntersection(arr1, arr2, arr3);

            Console.Write("[ ");
            foreach(var a in result)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine("]");
        }

        public static IList<int> ArraysIntersection(int[] arr1, int[] arr2, int[] arr3)
        {
            var result = new List<int>();
            result = TwoArrayIntersection(arr1, arr2);
            result = TwoArrayIntersection(arr3, result.ToArray());

            return result;
        }

        private static List<int> TwoArrayIntersection(int[] arr1, int[] arr2)
        {
            var result = new List<int>();
            for (var i = 0; i < arr1.Length; i++)
            {
                for (var j = 0; j < arr2.Length; j++)
                {
                    if (arr1[i] == arr2[j])
                    {
                        result.Add(arr1[i]);
                    }
                }
            }

            return result;
        }
    }
}
