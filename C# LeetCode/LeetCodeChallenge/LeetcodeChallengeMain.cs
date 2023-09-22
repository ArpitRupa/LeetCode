using LeetcodeSolutions;

public class ProgramEntryPoint
{
    public static void Main(string[] args)
    {
        //construct classes to run testcases

        LongestPaldindrome longestPaldindrome = new LongestPaldindrome();
        LongestPalindromeSubseq longestPalindromeSubseq = new LongestPalindromeSubseq();

        //LongestPalindrome testcases
        longestPaldindrome.Test("abccccdd", 7);
        longestPaldindrome.Test("a", 1);
        longestPaldindrome.Test("nolemonnomelon", 14);
        longestPaldindrome.Test("racecar", 7);
        longestPaldindrome.Test("wasitacaroracatisaw", 19);
        longestPaldindrome.Test("aA", 1);

        //LongestPalindromSubSeq testcases
        longestPalindromeSubseq.Test("bbbab", 4);
        longestPalindromeSubseq.Test("cbbd", 2);
    }
}