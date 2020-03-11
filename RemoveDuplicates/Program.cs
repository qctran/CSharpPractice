using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Given a sorted array nums, remove the duplicates in-place such that each element 
                appear only once and return the new length.

                Do not allocate extra space for another array, you must do this by modifying the 
                input array in-place with O(1) extra memory.

                E.g.
                Given nums = [1,1,2],
                Your function should return length = 2, with the first two elements of nums being 
                1 and 2 respectively.
                It doesn't matter what you leave beyond the returned length.
             */

            /*
                Success
                Details 
                Runtime: 256 ms, faster than 41.21% of C# online submissions for Remove Duplicates from Sorted Array.
                Memory Usage: 33.3 MB, less than 5.56% of C# online submissions for Remove Duplicates from Sorted Array.
             */
            var a = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            var newLen = RemoveDup(a);
            Console.WriteLine("New length is " + newLen);
            DisplayNewArray(a, newLen);
        }

        private static void DisplayNewArray(int[] a, int newLen)
        {
            Console.Write("[");
            for(var i = 0; i < newLen; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine("]");
        }

        public static int RemoveDup(int[] nums)
        {
            if (nums.Length < 2) return nums.Length;

            var i = 0;
            
            for(var j = 1; j < nums.Length; j++)
            {
                if (nums[i] != nums[j])
                {
                    i++;
                    nums[i] = nums[j];

                }
            }

            return i+1;
        }
    }
}
