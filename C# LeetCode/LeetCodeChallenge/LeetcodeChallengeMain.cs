using LeetcodeSolutions;

public class ProgramEntryPoint
{
    public static void Main(string[] args)
    {
        //construct classes to run testcases

        LongestPaldindrome longestPaldindrome = new();
        LongestCommonSubseq longestCommonSubseq = new();
        ValidateBST validateBST = new();

        //LongestCommon testcases
        Console.WriteLine("----Longest--Palindrome----");
        longestPaldindrome.Test("abccccdd", 7);
        longestPaldindrome.Test("a", 1);
        longestPaldindrome.Test("nolemonnomelon", 14);
        longestPaldindrome.Test("racecar", 7);
        longestPaldindrome.Test("wasitacaroracatisaw", 19);
        longestPaldindrome.Test("aA", 1);

        //LongestCommonSubSeq testcases
        Console.WriteLine("----LCS----");
        longestCommonSubseq.Test("bbbab", 4);
        longestCommonSubseq.Test("cbbd", 2);

        //ValidateBST testcases
        Console.WriteLine("----Validate--BST----");
        BinarySearchTree test1 = new(new List<int?> { 2, 1, 3 });
        test1.PrintInOrderTraversal();
        validateBST.Test(test1.root, true);
        BinarySearchTree test2 = new(new List<int?> { 5, 1, 4, null, null, 3, 6 });
        test2.PrintInOrderTraversal();
        validateBST.Test(test2.root, false);
    }
}