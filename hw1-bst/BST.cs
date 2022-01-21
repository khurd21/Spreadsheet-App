

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

    }
}