using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                linkedList.AddFirst(i);
            }
            Console.WriteLine(linkedList.ToString());


            linkedList.Add(2, 22);

            Console.WriteLine(linkedList.ToString());

            linkedList.Remove(2);
            Console.WriteLine(linkedList.ToString());
        }
    }
}
