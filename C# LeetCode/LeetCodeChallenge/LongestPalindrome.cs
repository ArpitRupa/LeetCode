// Given a string s which consists of lowercase or uppercase letters, return the length of the longest palindrome that can be built with those letters.

// Letters are case sensitive, for example, "Aa" is not considered a palindrome here.

// Constraints:

//     1 <= s.length <= 2000
//     s consists of lowercase and/or uppercase English letters only.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeetcodeSolutions
{
    public class LongestPaldindrome : SolutionClass
    {
        protected override int Solution(string s)
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

            //loop dict to get length from pairs of letters
            foreach (var kvp in dictionary)
            {
                //floor division by 2 then *2 to get true pair count
                int pairCount = (int)Math.Floor((double)kvp.Value / 2);
                maxPalindromeLength += 2 * pairCount;
                //mod to see if we add 1 to palindrome length at end
                if (kvp.Value % 2 == 0)
                {
                    dictionary.Remove(kvp.Key);
                }
            }
            //dict cannot be empty in order to add one to count
            if (dictionary.Count > 0)
            {
                maxPalindromeLength += 1;
            }
            return maxPalindromeLength;
        }

    }
}