using System;

namespace Set
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a1 = { 1, 2, 2, 1 };
            int[] a2 = { 2, 2 };
            Console.WriteLine( Solution3.Intersection(a1,a2).Length);

            LinkedListSet<int> set = new LinkedListSet<int>();
            set.Add(2);
            for (int i = 0; i < 10; i++)
            {
                set.Add(i);
            }
            Console.WriteLine(set.ToString());
            set.Remove(2);
            Console.WriteLine(set);
        }
    }
}
