// Given the root of a binary tree, determine if it is a valid binary search tree (BST).
// A valid BST is defined as follows:
//     The left subtree of a node contains only nodes with keys less than the node's key.
//     The right subtree of a node contains only nodes with keys greater than the node's key.
//     Both the left and right subtrees must also be binary search trees.
// 
// Constraints:
//     The number of nodes in the tree is in the range [1, 104].
//     -231 <= Node.val <= 231 - 1

using System.Reflection.Metadata.Ecma335;
using LeetcodeSolutions;

class ValidateBST : SolutionClass<TreeNode, bool>
{

    // Initialize the list as an instance variable
    private List<int> inOrderTree = new List<int>();

    //run recursively on each sub tree
    protected override bool Solution(TreeNode root)
    {
        //in order traversal and if it is not "in order" return false
        inOrderTree.Clear();

        InOrderTraversal(root);

        for (int i = 1; i < inOrderTree.Count; i++)
        {
            if (inOrderTree[i] <= inOrderTree[i - 1])
            {
                return false;
            }
        }

        return true;
    }

    private void InOrderTraversal(TreeNode node)
    {
        //if null return empty list
        if (node == null)
        {
            return;
        }

        // Recursion for left sub-tree
        InOrderTraversal(node.left);

        // Process the current node
        inOrderTree.Add(node.val);

        // Recursion for right sub-tree
        InOrderTraversal(node.right);
    }
}