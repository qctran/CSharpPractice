using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSum
{
    public class Solution
    {
        private int _max;
        public List<List<int>> FourSum(int[] nums, int target)
        {
            var result = new List<List<int>>();
            _max = nums.Length - 1; // zero base

            for (var i = 0; i < _max; i++)
            {
                Console.Write($"{i}: ");
                var jList = new List<int>();
                var j = i;
                for (var x = 1; x < 4; x++)
                {
                    j = GetNextJ(j);
                    jList.Add(j);
                }

                if (jList[2] < i)
                {
                    if (!ValidateJ(i, jList))
                    {
                        Console.WriteLine(" - invalid.");
                        continue;
                    }

                    Console.WriteLine(" - valid");
                }
            }

            Console.ReadKey();
            return result;
        }

        private bool ValidateJ(int i, List<int> jList)
        {
            foreach (var j in jList)
            {
                Console.Write($"{j} ");
                if (j == i) return false;
            }

            return true;
        }

        private int GetNextJ(int i)
        {
            var j = i + 1;

            if (j > _max)
            {
                j = 0;
            }

            return j;
        }
    }
}
