using System;

namespace FourSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            var nums = new[] {1, 0, -1, 0, -2, 2};
            var target = 0;

            sln.FourSum(nums, target);
        }
    }
}
