using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidateMathExpression
{
    /*
     Microsoft interview question
     Given a mathematical expression as string, can you write a function to check if it is a valid expression or not.
        Example: 
        3*4+1 is a valid
        3*4+1 is valid
        3*4++1 is not valid
        +1 this is not valid
        3**4 is not valid
        3//4+9 is not valid
     */
    class Program
    {
        static void Main()
        {
            var testData = new List<string>()
            {
                "56*22/18",
                "123-32",
                "3*4+1",
                "3*4++1",
                "+1",
                "3**4",
                "3/*4+9",
                "(3*3)+4",
                "((5+1",
                "(11+2))",
                ")123-9",
                "(44/2))",
                "44+",
                "ab"
            };

            foreach(var s in testData)
            {
                Console.Write(s + " ");
                Console.WriteLine(IsValidExpression(s) ? "valid" : "invalid");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static char[] _operators = new char[] { '*', '/', '+', '-' };
        private static char _leftQuo = '(';
        private static char _rightQuo = ')';
        private static Stack<char> _quoStack = new Stack<char>();

        private static bool IsValidExpression(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;
            if (_operators.Contains(data[0]) || (data[0] == _rightQuo)) return false;

            var ary = data.ToArray();
            for(var i = 0; i < ary.Length; i++)
            {
                if (ary[i] == _leftQuo)
                {
                    _quoStack.Push(ary[i]);
                }
                else if (ary[i] == _rightQuo)
                {
                    if (_quoStack.Count < 1) return false; // We need at least one left quote

                    _quoStack.Pop(); // Pop a left quote
                    _quoStack.Push(ary[i]); // Push a right quote
                }

                if (_operators.Contains(ary[i]))
                {
                    if (i + 1 >= ary.Length) return false;

                    if (_operators.Contains(ary[i+1]))
                    {
                        return false;
                    }
                }

                if (!char.IsDigit(ary[i])) return false;
            }

            if (_quoStack.Count > 0) return false;

            return true;
        }
    }
}
