using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var testAry = new int[] { 12, 17, 7, 2 };
            var result = TwoSum(testAry, 9);
            if (result.Length > 1)
            {
                Console.WriteLine("[{0},{1}]", result[0], result[1]);
            }
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            var result = new int[2];
            for (var i = 0; i < nums.Length - 1; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        result[0] = i;
                        result[1] = j;
                        return result;
                    }
                }
            }
            return result;
        }
    }
}
