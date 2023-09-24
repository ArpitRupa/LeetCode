using System.Xml;
using LeetcodeSolutions;


public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class BinarySearchTree
{
    public TreeNode root;
    //root node of tree

    public BinarySearchTree(List<int?> values)
    {
        //list cant be empty, or null; and root value must be non-null
        if (values == null || values.Count == 0 || values[0] == null)
        {
            throw new ArgumentException("Invalid input list");
        }

        root = ConstructBST(values, 0);
    }

    private TreeNode ConstructBST(List<int?> values, int index)
    {
        //check if index is out of bounds of list, or if the current index is null
        if (index >= values.Count || values[index] == null)
        {
            return null;
        }

        //recursively create left and right subtrees
        TreeNode node = new TreeNode(values[index].Value);
        node.left = ConstructBST(values, 2 * index + 1);
        node.right = ConstructBST(values, 2 * index + 2);

        return node;
    }

    //public method to call private inorder
    public void PrintInOrderTraversal()
    {
        string output = InOrderTraversal(root);
        Console.WriteLine(output);
    }

    //recursive method to output tree In-Order
    private string InOrderTraversal(TreeNode node)
    {
        if (node != null)
        {
            string leftOutput = InOrderTraversal(node.left);
            string mid_output = node.val + " ";
            string rightOutput = InOrderTraversal(node.right);
            return leftOutput + mid_output + rightOutput;
        }
        return "";
    }

    public void InsertNode(TreeNode node)
    {

    }

    public void DeleteNode(TreeNode node)
    {

    }

    public int GetMaximum()
    {
        return 1;
    }

    public int GetMinimum()
    {
        return 0;
    }

    public int GetSize()
    {
        return 1;
    }
    public int GetHeight(TreeNode node)
    {
        if (node == null)
        {
            return 0; // Height of an empty subtree is 0
        }

        // Recursively calculate the height of the left and right subtrees
        int leftHeight = GetHeight(node.left);
        int rightHeight = GetHeight(node.right);

        // Return the maximum height of the left and right subtrees, plus 1 for the current node
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}