using System;

namespace Set
{
    class Program
    {
        static void Main(string[] args)
        {
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
