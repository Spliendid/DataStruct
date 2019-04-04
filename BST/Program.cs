using System;

namespace BST
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            BST<int> bst = new BST<int>();
            for (int i = 0; i < 10; i++)
            {
                int num = random.Next(20);
                bst.Add(num);
                Console.WriteLine(num);
            }
            Console.WriteLine("--------------------");
            Console.WriteLine(bst);
            //bst.Preorder();
            //bst.InOrder();
            //bst.PostOrder();
            bst.LevelOrder();
        }
    }
}
