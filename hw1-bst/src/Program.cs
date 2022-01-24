namespace BST
{
    public class Program
    {

        private static void displayBSTStats(BinaryTree bst)
        {
            Console.WriteLine("**********************************************************");
            Console.WriteLine($"Number of items: {bst.numItems}");
            Console.WriteLine($"Height: {bst.getNumLevels()}");
            Console.WriteLine($"Theoretical min height: {bst.theoreticalHeight()}");
            Console.WriteLine("Inorder traversal:");
            bst.inorderTraversal();
            Console.WriteLine("**********************************************************");
        }

        private static bool makeInsert(BinaryTree bst, string input)
        {
            if (input == "q")
            {
                return false;
            }
            else
            {
                uint insert = uint.Parse(input);
                bst.Insert(insert);
                return true;
            }
        }

        private static void Main()
        {
            BinaryTree bst = new BinaryTree();

            string input;
            do
            {
                displayBSTStats(bst);
                Console.Write("Enter a number to enter into the tree [q to quit]: ");
                input = Console.ReadLine();
            } while (makeInsert(bst, input));
        }
    }
}