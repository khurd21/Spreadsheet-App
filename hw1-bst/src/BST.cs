

namespace BST;

/// <summary>
/// <c>BinaryTree</c> class implementation.
/// BinaryTree implements a basic version of a binary search tree
/// in which data is stored in a <c>Node</c> object and Insert method
/// is only provided.
/// </summary>
public class BinaryTree
{

    public Node root {get; private set;}
    public uint numItems {get; private set;}

    public class Node
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
            if (s != "")
            {
                uint num = uint.Parse(s);
                this.Insert(num);
            }
        }
    }

    /// <summary>
    /// Calculates the height of the tree and returns its value.
    /// Input: None.
    /// Output: The height of the tree.
    /// </summary>
    public uint getNumLevels()
    {
        return getNumLevels(this.root);
    }

    /// <summary>
    /// Calculates the height of the tree and returns its value.
    /// Input: a <c>Node</c> object.
    /// Output: the height of the tree.
    /// </summary>
    private uint getNumLevels(Node node)
    {
        if (node == null)
        {
            return 0;
        }
        else
        {
            uint leftLevel = getNumLevels(node.left);
            uint rightLevel = getNumLevels(node.right);
            return 1 + Math.Max(leftLevel, rightLevel);
        }
    }

    /// <summary>
    /// Returns the minimum possible height the tree can be if
    /// all nodes were perfectly balanced.
    /// Input: None.
    /// Output: The minimum possible height of the tree.
    /// </summary>
    public uint theoreticalHeight()
    {
        return (uint)Math.Floor(Math.Log2(numItems));
    }

    /// <summary>
    /// Writes the contents of the tree to the console in ascending order.
    /// </summary>
    public void inorderTraversal()
    {
        if (root == null)
        {
            Console.WriteLine("Empty tree");
        }
        else
        {
            inorderTraversal(root);
            Console.Write("\r\n");
        }
    }

    /// <summary>
    /// Writes the contents of the tree to the console in ascending order.
    /// Input: the node in which to begin the inorder traversal.
    /// </summary>
    private void inorderTraversal(Node node)
    {
        if (node == null)
        {
            return;
        }
        inorderTraversal(node.left);
        Console.Write($"{node.data} ");
        inorderTraversal(node.right);
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
            if (node.left != null)
            {
                Insert(node.left, data);
            }
            else
            {
                node.left = new Node(data);
                ++numItems;
            }
        }
        else if (data > node.data)
        {
            if (node.right != null)
            {
                Insert(node.right, data);
            }
            else
            {
                node.right = new Node(data);
                ++numItems;
            }
        }
        else
        {
            Console.WriteLine($"Duplicate value {data}");
            return false;
        }
        return true;
    }
}