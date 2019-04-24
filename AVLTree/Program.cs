using System;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = new int[] { 0,2, 5, 4, 8, 7, 3, 9, 1, 6,10 };

            AVLTree<int, char> map = new AVLTree<int, char>();

            for (int i = 0; i < 9; i++)
            {
                map.Add(array[i], (char)('a' + i));
            }
            map.Remove(4);
            map.LevelOrderB();

            Console.WriteLine(map.isBalance());
            Console.WriteLine(map.isBST());
        }
    }
}
