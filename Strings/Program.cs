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

            // 3. 
            Console.WriteLine("\nWrite a method to replace all spaces in strings with %20");

            // Q: 1) So an input would be a string with at least one space? String with no spaces? Output would be the string with spaces replaced? Okay to manipulate the string in other ways? Do other whitespaces count as spaces? Replace a tab with multiple %20's?

            string stringWith1Space = "Hello, world!";
            string newString = ReplaceSpaces(stringWith1Space);
            Console.WriteLine($"{stringWith1Space} becomes {newString}");

            string stringWith2Spaces = "Hello, big world!";
            newString = ReplaceSpaces(stringWith2Spaces);
            Console.WriteLine($"{stringWith2Spaces} becomes {newString}");

            string stringWithNoSpaces = "OneDrive";
            newString = ReplaceSpaces(stringWithNoSpaces);
            Console.WriteLine($"{stringWithNoSpaces} becomes {newString}");

            string emptyString = string.Empty;
            newString = ReplaceSpaces(emptyString);
            Console.WriteLine($"{emptyString} becomes {newString}");

            string nullString = null;
            newString = ReplaceSpaces(nullString);
            Console.WriteLine($"{nullString} becomes {newString}");

            // #4 compression algorithm
            Console.WriteLine("\nGiven the string aaabccaaaa, implement a compression algorithm that returns the result a3b1c2a4. If the result isn't shorter than the original, return the original.");

            // Q's: Is the input always alpha? always lowercase? always a string? always return a string? What if the input is null or empty? How long could the input be?

            string input1 = "aabcccaaaa";
            string compressedString = CompressString(input1);
            Console.WriteLine($"Original is {input1}. Compressed string or original: {compressedString}");

            input1 = "aabcccaaab";
            compressedString = CompressString(input1);
            Console.WriteLine($"Original is {input1}. Compressed string or original: {compressedString}");

            input1 = "aabcccaaabbbbbc";
            compressedString = CompressString(input1);
            Console.WriteLine($"Original is {input1}. Compressed string or original: {compressedString}");

            input1 = string.Empty;
            compressedString = CompressString(input1);
            Console.WriteLine($"Original is {input1}. Compressed string or original: {compressedString}");

            input1 = null;
            compressedString = CompressString(input1);
            Console.WriteLine($"Original is {input1}. Compressed string or original: {compressedString}");

            // Shupa's question: 
            Console.WriteLine("\nIf you have an array of n elements, check if the sum of 3 elements is a constant c");
            // Q's: int array? how to handle null or empty or arrays < 3 elements? Okay if < 3 elements are needed to add to c? Are elements sorted?

            int[] arr = { 1, 2, 3 };
            int c = 6;
            bool hasSum = CheckSumOf3Items(arr, c);
            Console.WriteLine($"\nThree array elements may add to the constant: {hasSum}");

            Console.ReadKey();
        }

        // Shupa's question
        private static bool CheckSumOf3Items(int[] arr, int c)
        {
            // variables for current sum
            int currentSum = 0;
            // variable for remaining value to find
            int difference = 0;

            // handle edge cases null, less than 3 elements
            if (arr == null || arr.Length < 3)
            {
                return false;
            }

            // Determine boolean for arrays of at least 3 elements
            for (int i = 0; i < arr.Length - 1; i++)
            {
                currentSum += arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    currentSum += arr[j];
                    difference = c - currentSum;

                    // if remaining elements in array contain the difference between c and currentSum, return true
                    for (int k = 0; k < arr.Length; k++)
                    {
                        // if k is same index as i or j, continue
                        if (k == i || k == j)
                        {
                            continue;
                        }
                        else if (arr[k] == currentSum)
                        {
                            return true;
                        }
                    }
                }
            }

            // sum of c not found, so return false
            return false;
        }

        // #4
        private static string CompressString(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return s;
            }
            
            // counter
            int charCount = 1;

            // compressed string
            var sb = new StringBuilder();
            sb.Append(s[0]);
            
            // for loop, note starting at 1 
            for (int i = 1; i < s.Length; ++i)
            {
                // Check if we're at the end of the string && same char
                if (i == s.Length - 1 && s[i] == sb[sb.Length - 1])
                {
                    sb.Append(++charCount);
                }
                // check if end of string and different char
                else if (i == s.Length - 1 && s[i] != sb[sb.Length - 1])
                {
                    sb.Append(charCount);
                    sb.Append(s[i]).Append(1);
                }
                // condition where i is the same as the most recent char in s
                else if (s[i] == sb[sb.Length - 1])
                {
                    ++charCount; // just incremet charCount to be used later
                }
                // condition where i is different than the most recent char in s
                else
                {
                    sb.Append(charCount).Append(s[i]);
                    charCount = 1;
                }
            }

            // check for length            
            // return s or compressed version
            return sb.Length < s.Length ? sb.ToString() : s;
        }

        private static string ReplaceSpaces(string s)
        {
            if (s == null)
            {
                return "Can't replace characters in a null string";
            }

            // 1. How I would really write this method. 
            //return s.Replace(" ", "%20");

            // 2. If I can't alter the string except for the spaces:
            StringBuilder sw = new StringBuilder();
            foreach (char c in s)
            {
                if (c == ' ')
                {
                    sw.Append("%20");
                }
                else
                {
                    sw.Append(c);
                }
            }

            return sw.ToString();           
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
