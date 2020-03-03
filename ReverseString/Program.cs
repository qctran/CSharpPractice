using System;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintReverseString("Hello");
            //var s = "amanaP :lanac  a,nalp a ,nam A";
            var s1 = "A man, a plan, a canal: Panama";
            ReverseString(s1);
        }

        private static void PrintReverseString(string msg)
        {
            var stringAry = msg.ToCharArray();
            Console.WriteLine(msg);
            PrintReverseString(stringAry, stringAry.Length - 1);
            Console.WriteLine();
        }

        private static void PrintReverseString(char[] stringAry, int index)
        {
            if (index < 0)
                return;

            Console.Write(stringAry[index--]);
            
            PrintReverseString(stringAry, index);
        }

        private static void ReverseString(string s)
        {
            var ary = s.ToCharArray();
            Console.WriteLine(s);
            ReverseString(ary, 0);
            PrintArray(ary);

            ary = s.ToCharArray();
            ReverseString(ary, 0, ary.Length-1);
            PrintArray(ary);
        }

        private static void PrintArray(char[] ary)
        {
            foreach (var a in ary)
            {
                Console.Write(a);
            }
            Console.WriteLine();
        }

        private static void ReverseString(char[] s, int index)
        {
            // Must include the last pair
            if (index >= s.Length / 2) return;

            var temp = s[index];
            s[index] = s[s.Length - (index + 1)];
            s[s.Length - (index + 1)] = temp;
            ReverseString(s, ++index);
        }

        private static void ReverseString(char[] s, int left, int right)
        {
            if (left > right) return;

            var temp = s[left];
            s[left++] = s[right];
            s[right--] = temp;
            ReverseString(s, left, right);
        }
    }
}
