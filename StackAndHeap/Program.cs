using System;

namespace StackAndQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            StackArray<int> sa = new StackArray<int>();
            for (int i = 0; i < 10; i++)
            {
                sa.Push(i);
            }
            Console.WriteLine(sa.ToString());
            Console.WriteLine(sa.Pop());
            Console.WriteLine(sa.ToString());
        }
    }
}
