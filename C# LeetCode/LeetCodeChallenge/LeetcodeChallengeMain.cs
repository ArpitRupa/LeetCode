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

        //ValidateBST testcases
        Console.WriteLine("----Validate--BST----");
        BinarySearchTree test1 = new(new List<int?> { 2, 1, 3 }, true);
        test1.PrintInOrderTraversal();
        validateBST.Test(test1.root, true);
        BinarySearchTree test2 = new(new List<int?> { 5, 1, 4, null, null, 3, 6 }, true);
        test2.PrintInOrderTraversal();
        validateBST.Test(test2.root, false);

        //BST Functionality testcases
        Console.WriteLine("----BST--Functionality----");
        BinarySearchTree testBST = new(new List<int?> { 8, 5, 10, 3, 7, 12, 2, 4 }, false);
        testBST.PrintInOrderTraversal();
        Console.WriteLine(testBST.GetMaximumNode().val);
        Console.WriteLine(testBST.GetMinimumNode().val);
        testBST.DeleteNodeByValue(5);
        testBST.PrintInOrderTraversal();
        Console.WriteLine(testBST.GetMaximumNode().val);
        Console.WriteLine(testBST.GetMinimumNode().val);

        //InsertionSort testcases
        Console.WriteLine("----Insertion--Sort----");
        InsertionSort insSort = new(intList: new List<int> { 4, 2, 1, 3 });
        insSort.PrintLinkedList();
        insSort.Sort();
        insSort.PrintLinkedList("Expected: 1 2 3 4");
        Console.WriteLine(insSort.CheckSorted());

        //LongestCommonSubSeq testcases
        Console.WriteLine("----Longest--Common--Subseq----");
        LongestCommonSubseq subSeq = new();
        subSeq.Test(("ace", "abcde"), 3);
        subSeq.PrintMatrix();

    }
}