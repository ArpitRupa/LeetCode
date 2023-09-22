// Given a string s which consists of lowercase or uppercase letters, return the length of the longest palindrome that can be built with those letters.

// Letters are case sensitive, for example, "Aa" is not considered a palindrome here.

// Constraints:

//     1 <= s.length <= 2000
//     s consists of lowercase and/or uppercase English letters only.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LongestPaldindrome
{
    public class Solution
    {
        private int LongestPalindrome(string s)
        {
            //store the count for palindrom length
            int maxPalindromeLength = 0;

            //dictionary for count of each char in string
            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            //loop to count chars
            foreach (var character in s)
            {
                if (dictionary.ContainsKey(character))
                {
                    dictionary[character] += 1;
                }
                else
                {
                    dictionary[character] = 1;
                }
            }

            //loop dict to 
            foreach (var kvp in dictionary)
            {
                int pairCount = (int)Math.Floor((double)kvp.Value / 2);
                maxPalindromeLength += 2 * pairCount;
                //mod to see if we add 1 to palindrom length at end
                if (kvp.Value % 2 == 0)
                {
                    dictionary.Remove(kvp.Key);
                }
            }
            if (dictionary.Count > 0)
            {
                maxPalindromeLength += 1;
            }
            return maxPalindromeLength;
        }

        private static void Test(string testCase, int expected)
        {
            Solution solution = new Solution();
            int result = solution.LongestPalindrome(testCase);
            Console.WriteLine($"{result}, expected: {expected}");
        }

        private static void Main()
        {

            Test("abccccdd", 7);
            Test("a", 1);
            Test("nolemonnomelon", 14);
            Test("racecar", 7);
            Test("wasitacaroracatisaw", 19);
            Test("aA", 1);
        }

    }
}