

namespace BST;

/// <summary>
/// <c>BinaryTree</c> class implementation.
/// BinaryTree implements a basic version of a binary search tree
/// in which data is stored in a <c>Node</c> object and Insert method
/// is only provided.
/// </summary>
public class BinaryTree
{

    private Node root;
    public uint numItems {get; private set;}

    private class Node
    {
        public uint data;
        public Node left;
        public Node right;

        public Node(uint data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }

    /// <summary>
    /// Constructor for the <c>BinaryTree</c> class.
    /// Input: a string of unsigned integers separated by spaces.
    ///        The string is by default empty.
    /// </summary>
    public BinaryTree(string data="")
    {
        this.numItems = 0;
        string[] dataArray = data.Split(' ');
        foreach (string s in dataArray)
        {
            // Insert(uint.Parse(s));
        }
    }

    /// <summary>
    /// Inserts a new value into the <c>BinaryTree</c>.
    /// Input: a uint value to be inserted into the <c>BinaryTree</c>.
    /// Output: true if the value was inserted, false otherwise.
    /// </summary>
    public bool Insert(uint data)
    {
        if (root == null)
        {
            root = new Node(data);
            ++numItems;
            return true;
        }
        return Insert(root, data);
    }
    
    /// <summary>
    /// Recursive helper method for the <c>Insert</c> method.
    /// Input: a <c>Node</c> object and a uint value to be inserted.
    /// Output: true if the value was inserted, false otherwise.
    /// </summary>
    private bool Insert(Node node, uint data)
    {
        if (node == null)
        {
            node = new Node(data);
            ++numItems;
        }
        else if (data < node.data)
        {
            Insert(node.left, data);
        }
        else if (data > node.data)
        {
            Insert(node.right, data);
        }
        else
        {
            Console.WriteLine($"Duplicate value {data}");
            return false;
        }
        return true;
    }
}