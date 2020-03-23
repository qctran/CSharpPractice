using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMedianOfTwoSortedArrays
{
    /* Leetcode.com
        Median of Two Sorted Arrays
        Hard

        6148

        942

        Add to List

        Share
        There are two sorted arrays nums1 and nums2 of size m and n respectively.

        Find the median of the two sorted arrays. The overall run time complexity should be O(log (m+n)).

        You may assume nums1 and nums2 cannot be both empty.

        Example 1:

        nums1 = [1, 3]
        nums2 = [2]

        The median is 2.0
        Example 2:

        nums1 = [1, 2]
        nums2 = [3, 4]

        The median is (2 + 3)/2 = 2.5
     */
    class Program
    {
        static void Main(string[] args)
        {
            var nums1 = new int[] { 1, 2 };
            var nums2 = new int[] { 3, 4 };

            //var nums1 = new int[] { 1, 3 };
            //var nums2 = new int[] { 2 };

            //var nums1 = new int[] { 1, 2, 3 };
            //var nums2 = new int[] { 3, 4 };

            Console.WriteLine("{0:0.0}", FindMedianSortedArrays(nums1, nums2));
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var mergedList = MergeArrays(nums1, nums2);

            if ((nums1.Length + nums2.Length) % 2 == 0)
            {
                var m1 = mergedList[mergedList.Count / 2];
                var m2 = mergedList[mergedList.Count / 2 + 1];
                return ((Double)m1 + (Double)m2) / 2;
            }
            
            var m = (Double)mergedList[mergedList.Count / 2];
            return m;
        }

        private static List<int> MergeArrays(int[] nums1, int[] nums2)
        {
            var mergedList = new List<int>();
            int j = 0;
            for(var i = 0; i < nums1.Length / 2 + 1; i++)
            {
                for(j = 0; j < nums2.Length / 2 + 1; j++)
                {
                    if (nums1[i] <= nums2[j])
                    {
                        mergedList.Add(nums1[i]);
                        break;
                    }
                    if (nums1[i] == nums2[j])
                    {
                        mergedList.Add(nums1[i]);
                        mergedList.Add(nums2[j]);
                        break;
                    }
                    if (nums1[i] > nums2[j])
                    {
                        mergedList.Add(nums2[j]);
                        break;
                    }
                }
            }

            while (j < nums2.Length / 2)
            {
                mergedList.Add(nums2[j++]);
            }

            return mergedList;
        }
    }
}
