using System;

namespace BST
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] array = new int[] { 2,5,4,8,7,3,9,1,6}; 
            BST<int> bst = new BST<int>();
            for (int i = 0; i < array.Length; i++)
            {
                bst.Add(array[i]);
            }

            bst.Remove(3);

            Console.WriteLine(bst);


            //for (int i = 0; i < 10; i++)
            //{
            //    int num = random.Next(20);
            //    bst.Add(num);
            //    Console.WriteLine(num);
            //}

            //Console.WriteLine("--------------------");
            //Console.WriteLine(bst);
            ////bst.Preorder();
            ////bst.InOrder();
            ////bst.PostOrder();
            //bst.LevelOrder();
        }
    }
}
