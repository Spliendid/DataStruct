using System;

namespace SegmentTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = { -2, 0, 3, -5, 2, -1 };
            SegmentTree<int> tree = new SegmentTree<int>(data,(a,b)=>a+b);
            //Console.WriteLine(tree);
            Console.WriteLine(tree.Query(3,5));
            tree.Set(3,5);
            Console.WriteLine(tree.Query(3,5));

        }

    }
}
