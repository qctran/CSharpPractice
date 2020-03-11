using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortedArray
{
    class Program
    {
        /*
         https://leetcode.com/
         Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.
         Note:  The number of elements initialized in nums1 and nums2 are m and n respectively.
            You may assume that nums1 has enough space (size that is greater or equal to m + n) 
            to hold additional elements from nums2.

            Input:
            nums1 = [1,2,3,0,0,0], m = 3
            nums2 = [2,5,6],       n = 3

            Output: [1,2,2,3,5,6]
         */
        static void Main(string[] args)
        {
            int[] nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
            int[] nums2 = new int[] { 4, 5, 6 };
            Print(nums1);
            Merge(nums1, 3, nums2, 3);
            Print(nums1);
        }

        private static void Print(int[] a)
        {
            foreach (var n in a)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
        }
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            MergeRec(nums1, m, 0, nums2, n, 0);
        }

        public static void MergeRec(int[] nums1, int m, int idx1, int[] nums2, int n, int idx2)
        {
            if (n == 0 || idx1 >= nums1.Length) return;

            for (var i2 = idx2; i2 < n; i2++) 
            {
                for (var i1 = idx1; i1 < nums1.Length; i1++)
                {
                    if (i1 < m)
                    {
                        if (nums1[i1] > nums2[i2])
                        {
                            var temp = nums1[i1];
                            nums1[i1] = nums2[i2];
                            nums2[i2] = temp;
                            MergeRec(nums1, m, ++i1, nums2, n, ++i2);
                        }
                    }
                    else
                    {
                        nums1[i1] = nums2[i2];
                        continue;
                        //for(var j = 1; j < nums2.Length; j++)
                        //{
                        //    nums2[j - 1] = nums2[j];
                        //}
                        //n--;
                    }
                    //Print(nums1);
                    //Print(nums2);
                    
                }
            }
        }
    }
}
