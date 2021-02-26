using System;

namespace TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            //var testAry = new int[] { 2, 7, 7, 2 };
            //var testAry = new int[] { 2, 7 };
            var testAry = new int[] { 1, 7, 7, 10, 9, 11, 2 };
            //var testAry = new int[] { 12, 17, 7, 2 };
            //var testAry = new int[] { 12, 17, 7, 1 };
            var sumValue = 9;
            var result = TwoSum(testAry, sumValue);

            if (result == null)
            {
                Console.WriteLine($"No pair of integer found to add up to {sumValue}");
            }
            else if (result.Length > 1)
            {
                Console.WriteLine($"Values of the index [{result[0]}] and [{result[1]}] add up to {sumValue}");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
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
            return null;
        }
    }
}
