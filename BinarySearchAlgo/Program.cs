using System;
using static System.Console;

namespace BinarySearchAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            var theValue = 43;
            var array = new int[] {11, 43, 22, 54, 57, 59, 62, 78};
            WriteLine("Our array contains: ");
            Array.ForEach(array, x => Write(x + " "));

            Array.Sort(array);
            WriteLine("Our sorted array contains: ");
            Array.ForEach(array, x => Write(x + " "));

            Write($"\n\nThe index of a binary search for {theValue} is: ");
            WriteLine(BinarySearch(array, theValue));
        }

        /// <summary>
        /// a = array
        /// x = what we're searching for
        /// p = first index
        /// q = midpoint
        /// r = last index
        /// </summary>
        /// <param name="a"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        private static int BinarySearch(int[] a, int x)
        {
            var p = 0;  // Beginning of the range
            var r = a.Length - 1;  // End of the range

            while (p <= r)
            {
                var q = (p + r) / 2; // find the midpoint
                if (x < a[q])
                {
                    r = q - 1;  // set r to mid point.  We narrowed to 1st
                                // half of the array in the case x is less
                                // the data in slot q

                }
                else if (x > a[q])
                {
                    p = q + 1;  // the opposite occurs.  We bring p to the 
                                // right of the array
                       
                }
                else
                {
                    return q;
                }
            }
            return -1;
        }
    }
}
