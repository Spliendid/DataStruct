using System;

namespace RBTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] {  2, 5, 4, 8};

            RBTree<int, char> map = new RBTree<int, char>();

            for (int i = 0; i < array.Length; i++)
            {
                map.Add(array[i], (char)('a' + i));
            }
           // map.Remove(4);
            map.LevelOrder();

            //Console.WriteLine(map.isBalance());
            //Console.WriteLine(map.isBST());
        }
    }
}
