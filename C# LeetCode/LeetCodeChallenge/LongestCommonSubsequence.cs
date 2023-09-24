// Given two strings text1 and text2, return the length of their longest common subsequence. If there is no common subsequence, return 0.
// A subsequence of a string is a new string generated from the original string with some characters (can be none) deleted without changing the relative order of the remaining characters.
//     For example, "ace" is a subsequence of "abcde".
// A common subsequence of two strings is a subsequence that is common to both strings.
//
// Constraints:
//     1 <= text1.length, text2.length <= 1000
//     text1 and text2 consist of only lowercase English characters.

namespace LeetcodeSolutions
{
    public class LongestCommonSubseq : SolutionClass<string, int>
    {
        protected override int Solution(string s)
        {
            // int maxSeqLength = 0;

            Dictionary<char, int> charCountDict = new Dictionary<char, int>();

            foreach (var character in s)
            {
                // if (charCountDict.ContainsKey(character))
                // {
                //     charCountDict[character] += 1;
                // }
                // else
                // {
                //     charCountDict[character] = 1;
                // }

                charCountDict[character] = charCountDict.ContainsKey(character) ? charCountDict[character] + 1 : 1;
            }

            return 0;
        }

    }
}
