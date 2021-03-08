using System;
using System.Collections.Generic;

/*
Leetcode.com Canonical Path

Given an absolute path for a file (Unix-style), simplify it. Or in other words, convert it to the canonical path.
In a UNIX-style file system, a period . refers to the current directory. Furthermore, a double period .. moves the 
directory up a level. For more information, see: Absolute path vs relative path in Linux/Unix
Note that the returned canonical path must always begin with a slash /, and there must be only a single slash / 
between two directory names. The last directory name (if it exists) must not end with a trailing /. Also, the 
canonical path must be the shortest string representing the absolute path.

Example 1:
Input: "/home/"
Output: "/home"
Explanation: Note that there is no trailing slash after the last directory name.

Example 2:
Input: "/../"
Output: "/"
Explanation: Going one level up from the root directory is a no-op, as the root level is the highest level you can go.

Example 3:
Input: "/home//foo/"
Output: "/home/foo"
Explanation: In the canonical path, multiple consecutive slashes are replaced by a single one.

Example 4:
Input: "/a/./b/../../c/"
Output: "/c"

Example 5:
Input: "/a/../../b/../c//.//"
Output: "/c"

Example 6:
Input: "/a//b////c/d//././/.."
Output: "/a/b/c"
 */
namespace GetCanonicalPath
{
    class Program
    {
        static void Main(string[] args)
        {
            var testData = new List<string>()
            {
                "/home/",
                "/../",
                "/home//fool/",
                "/a/./b/../../c/",
                "/a/../../b/../c//.//",
                "/a//b////c/d//././/.."
            };

            foreach( var path in testData)
            {
                Console.Write(path + " -> ");
                Console.WriteLine(SimplifyPath(path));
            }
            
        }

        public static string SimplifyPath(string path)
        {
            path = path.Trim();

            var folders = path.Split('/');
            var myStack = new Stack<string>();
            for(var i = 0; i < folders.Length; i++)
            {
                if (string.IsNullOrEmpty(folders[i])) continue;
                if (folders[i] == "/" && i > 1)
                {
                    continue;
                }

                if ((string.Compare(folders[i], "..", true) == 0) && (myStack.Count > 0))
                {
                    myStack.Pop();
                }
                else if ((string.Compare(folders[i], "..", true) != 0) &&
                    (string.Compare(folders[i], ".", true) != 0) &&
                    (string.Compare(folders[i], "//", true) != 0))
                {
                    myStack.Push(folders[i]);
                }
            }

            var result = string.Empty;
            while (myStack.Count > 0)
            {
                var temp = myStack.Pop();
                result = string.Format("{0}/{1}", temp, result);
            }

            result = string.Format("/" + result);
            if (result.Length > 1)
            {
                result = result.Remove(result.Length - 1, 1);
            }
            return result;
        }
    }
}
