

namespace BST
{
    public class BST
    {

        private Node root;
        uint numItems;

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

        public BST(string data)
        {
            this.numItems = 0;
            string[] dataArray = data.Split(' ');
            foreach (string s in dataArray)
            {
                // Insert(uint.Parse(s));
            }
        }

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
}