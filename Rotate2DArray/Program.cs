using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotate2DArray
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            var matrix = new int[n][];
            matrix[0] = new int[n] { 11, 12, 13, 14, 15 };
            matrix[1] = new int[n] { 21, 22, 23, 24, 25 };
            matrix[2] = new int[n] { 31, 32, 33, 34, 35 };
            matrix[3] = new int[n] { 41, 42, 43, 44, 45 };
            matrix[4] = new int[n] { 51, 52, 53, 54, 55 };
            Print(matrix);
           
            rotate(matrix);
            Print(matrix);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void Print(int[][] matrix)
        {
            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
        private static void rotate(int[][] matrix)
        {
            var n = matrix.Length;
            var m = n + 1;
            for (var i = 0; i < n / 2 + n % 2; i++)
            {
                for (var j = 0; j < n / 2; j++)
                {
                    var temp = new int[m];
                    var row = i;
                    var col = j;
                    for (var k = 0; k < m; k++)
                    {
                        temp[k] = matrix[row][col];
                        int x = row;
                        row = col;
                        col = n - 1 - x;
                    }

                    for (var k = 0; k < m; k++)
                    {
                        matrix[row][col] = temp[(k + 3) % (m)];
                        int x = row;
                        row = col;
                        col = n - 1 - x;
                    }
                }
            }
        }
    }
}
