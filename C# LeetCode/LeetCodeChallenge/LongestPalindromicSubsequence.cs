// Given a string s, find the longest palindromic subsequence's length in s.
// A subsequence is a sequence that can be derived from another sequence by deleting some or no elements without changing the order of the remaining elements.
//
// Constraints:
//     1 <= s.length <= 1000
//     s consists only of lowercase English letters.

namespace LeetcodeSolutions
{
    public class LongestPalindromeSubseq
    {
        private int Solution(string s)
        {
            return 0;
        }

        public void Test(string testCase, int expected)
        {
            LongestPalindromeSubseq solution = new LongestPalindromeSubseq();
            int result = solution.Solution(testCase);
            Console.WriteLine($"{result}, expected: {expected}");
        }


    }
}
