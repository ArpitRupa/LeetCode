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

    /// <summary>
    /// Constructor for BinarySearchTree;
    /// </summary>
    /// <param name="values">List of values to be added to construct BST</param>
    /// <param name="challenge">boolean to check if the BST is for the leetcode challenge</param>
    public BinarySearchTree(List<int?> values, bool challenge)
    {
        //list cant be empty, or null; and root value must be non-null
        if (values == null || values.Count == 0 || values[0] == null)
        {
            throw new ArgumentException("Invalid input list");
        }

        //call for leetcode challenge
        if (challenge)
        {
            this.root = ConstructBSTChallenge(values, 0);
        }
        //custom call for any list
        else
        {
            List<int> nonNullValues = values
                .Where(items => items.HasValue) // Filter out null values
                .Select(item => item.Value)     // Select the integer values
                .ToList();                               // Convert to List<int>

            //set root to first value in the list
            this.root = new TreeNode(val: nonNullValues[0]);
            //construct BST with non-null values
            ConstructBST(nonNullValues);
        }

    }

    ///
    /// <summary>
    /// Recursive method for Leetcode challenge; Constructs BST from list of values
    /// </summary>
    /// <param name="values">List of values to be added to construct BST</param>
    /// <param name="index">Current index in list</param>
    private TreeNode? ConstructBSTChallenge(List<int?> values, int index)
    {
        //check if index is out of bounds of list, or if the current index is null
        if (index >= values.Count || values[index] == null)
        {
            return null;
        }

        //recursively create left and right subtrees
        TreeNode node = new(values[index].Value)
        {
            left = ConstructBSTChallenge(values, 2 * index + 1),
            right = ConstructBSTChallenge(values, 2 * index + 2)
        };

        return node;
    }

    ///method for custom implementation (works with any list of numbers)
    private void ConstructBST(List<int> values)
    {
        //have to start at 1 since we already made the root
        for (int i = 1; i < values.Count; i++)
        {
            //create node from current value
            TreeNode tmpNode = new(val: values[i]);
            InsertNode(tmpNode);
        }
    }

    /// <summary>
    /// Prints the tree in In-Order-Traversal
    /// </summary>
    public void PrintInOrderTraversal()
    {
        string output = InOrderTraversal(root);
        Console.WriteLine(output);
    }


    /// <summary>
    /// Recursive method to output tree In-Order
    /// </summary>
    /// <param name="node">Current node in the recursive functiuon</param>
    /// <returns>In-order-traversal of tree as a string</returns>
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

    /// <summary>
    /// Validates the tree as a BST
    /// </summary>
    /// <returns>Boolean for if the tree is a valid BST or not</returns>
    private bool ValidateBST()
    {

        string inOrderString = InOrderTraversal(this.root);
        string[] inOrderTree = inOrderString.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        for (int i = 1; i < inOrderTree.Length; i++)
        {
            if (int.Parse(inOrderTree[i]) <= int.Parse(inOrderTree[i - 1]))
            {
                return false;
            }
        }

        return true;

    }

    /// <summary>
    /// Inserts a node in the BST
    /// </summary>
    /// <param name="node">Node to be inserted in BST</param>
    public void InsertNode(TreeNode node)
    {
        TreeNode tmpNode = this.root;
        while (true)
        {
            if (node.val > tmpNode.val)
            {
                if (tmpNode.right == null)
                {
                    tmpNode.right = node;
                    break;
                }
                tmpNode = tmpNode.right;
            }
            else
            {
                if (tmpNode.left == null)
                {
                    tmpNode.left = node;
                    break;
                }
                tmpNode = tmpNode.left;
            }

        }
    }

    /// <summary>
    /// Deletes a node in the BST by value
    /// </summary>
    /// <param name="val">int value of node to be Deleted in BST</param>
    public void DeleteNodeByValue(int val)
    {
        // ensure its a valid BST
        ValidateBST();

        // node for parent node, and node to find
        TreeNode current = this.root;
        TreeNode parent = null;

        // find node with the given value and its parent
        while (current != null && current.val != val)
        {
            parent = current;

            if (val < current.val)
            {
                current = current.left;
            }
            else
            {
                current = current.right;
            }
        }

        // throw exception if node of value "val" is not found
        if (current == null)
        {
            throw new ArgumentException($"Node of value {val} not found in tree.");
        }

        // Case 1: node is a leaf (has no children)
        if (current.left == null && current.right == null)
        {
            if (parent == null)
            {
                // if node is root and leaf; set root to null
                this.root = null;
            }
            else if (parent.left == current)
            {
                // node is left child of parent
                parent.left = null;
            }
            else
            {
                // node is right child of parent
                parent.right = null;
            }
        }
        // Case 2: node has one child
        else if (current.left == null || current.right == null)
        {
            //set child to non-null child of node
            TreeNode child = (current.left != null) ? current.left : current.right;

            if (parent == null)
            {
                //node to delete is the root and has one child; set root to the child
                this.root = child;
            }
            else if (parent.left == current)
            {
                //node is the left child of its parent
                parent.left = child;
            }
            else
            {
                // node is right child of parent
                parent.right = child;
            }
        }
        // Case 3: node has two children
        else
        {
            //hold root to run max on subtree
            TreeNode temp = this.root;
            this.root = current.left;


            // find successor of current node
            TreeNode successor = GetMaximumNode();

            Console.WriteLine($"deleting...{val}");
            Console.WriteLine($"successor: {successor.val}");
            //restore root
            this.root = temp;

            // Delete the successor node
            DeleteNodeByValue(successor.val);

            // replace current node val with child
            current.val = successor.val;
        }
    }


    /// <summary>
    /// Finds a TreeNode in the tree by value if it exists
    /// </summary>
    /// <param name="val">int value to find in the tree</param>
    /// <returns>Returns first TreeNode found that matches the value</returns>
    private TreeNode FindNode(int val)
    {
        TreeNode temp = this.root;

        while (temp != null)
        {
            if (temp.val == val)
            {
                return temp;
            }
            //which way do we traverse the tree?
            temp = (temp.val > val) ? temp.right : temp.left;
        }
        throw new ArgumentException("Node not found in tree.");
    }

    /// <summary>
    /// Returns the maximum valued node from tree
    /// </summary>
    /// <returns>The TreeNode with the maximum value in the BST</returns>
    public TreeNode GetMaximumNode()
    {
        if (ValidateBST())
        {
            TreeNode node = this.root;

            //traverse tree to right most value to find max of tree
            while (node.right != null)
            {
                node = node.right;
            }

            return node;

        }
        //Throw excpetion if not valid BST
        throw new InvalidOperationException("The tree is not a valid BST.");
    }

    /// <summary>
    /// Returns the minimum valued node from tree
    /// </summary>
    /// <returns>The TreeNode with the minimum value in the BST</returns>
    public TreeNode GetMinimumNode()
    {
        if (ValidateBST())
        {
            TreeNode node = this.root;

            //traverse tree to left most value to find max of tree
            while (node.left != null)
            {
                node = node.left;
            }

            return node;

        }
        //Throw excpetion if not valid BST
        throw new InvalidOperationException("The tree is not a valid BST.");
    }

    /// <summary>
    /// Returns total size (num of nodes) of tree
    /// </summary>
    /// <returns>The num of nodes as an int</returns>
    public int GetSize()
    {
        return GetSizeRecursive(this.root);
    }

    /// <summary>
    /// Recursive helper method for GetSize()
    /// </summary>
    private int GetSizeRecursive(TreeNode node)
    {
        //base case
        if (node == null)
        {
            return 0;
        }

        int left = GetSizeRecursive(node.left);
        int right = GetSizeRecursive(node.right);

        return left + 1 + right;
    }


    /// <summary>
    /// Finds like height of the tree from the node (recursively)
    /// </summary>
    /// <param name="node">Node to calculate the height of the tree from.</param>
    /// <returns>The height of the tree from the node as an int</returns>
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