using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Implement an algorithm to determine if a string has all unique characters. What if you cannot use additional data structures?

            // Questions: 1) Is input a string? 2) Is the output a boolean? 3) Does a string count as an additional data structure? 4) Can the string have non-alphanumeric characters? 5) How to handle null or empty strings? 6) Assume non-sorted characters in string? 7) ASCII only?

            Console.WriteLine("\nImplement an algorithm to determine if a string has all unique characters. What if you cannot use additional data structures?");

            string s1 = "abc123!?*`";
            string s2 = "aabbcc112233!?**";
            string s3 = null;
            string s4 = string.Empty;

            bool hasAllUniqueChars = HasAllUniqueChars(s1);
            Console.WriteLine($"Does {s1} contain all unique characters? {hasAllUniqueChars}");

            hasAllUniqueChars = HasAllUniqueChars(s2);
            Console.WriteLine($"Does {s2} contain all unique characters? {hasAllUniqueChars}");

            //hasAllUniqueChars = HasAllUniqueChars(s3);
            //Console.WriteLine($"Does {s3} contain all unique characters? {hasAllUniqueChars}");

            //hasAllUniqueChars = HasAllUniqueChars(s4);
            //Console.WriteLine($"Does {s4} contain all unique characters? {hasAllUniqueChars}");

            Console.ReadKey();
        }

        private static bool HasAllUniqueChars(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                throw new ArgumentException("Parameter is null or whitespace");
            }

            // 1st answer uses LINQ, but isn't my own algorithm, so time complexity???
            //var newString = s.Distinct();

            //return s.Length == newString.Count();

            // 2nd answer still uses a bool[]. O(n) = n.
            //bool[] arr = new bool[256]; // What about Unicode? That's larger than 256

            //bool[] arr = new bool[1114112]; // Unicode has 1,114,112 possible characters

            //foreach (char c in s)
            //{
            //    if (arr[c])
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        arr[c] = true;
            //    }                    
            //}                

            //return true;

            // 3rd try. Use of nested for loop gives n-squared time complexity, but no additional data structure is needed.

            for (int i = 0; i < s.Length; ++i)
            {
                for (int j = 0; j < s.Length; ++j)
                {
                    if (s[i] == s[j] && i != j)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
