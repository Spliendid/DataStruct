using System;

namespace StackAndQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            //StackArray<int> sa = new StackArray<int>();
            //for (int i = 0; i < 10; i++)
            //{
            //    sa.Push(i);
            //}
            //Console.WriteLine(sa.ToString());
            //Console.WriteLine(sa.Pop());
            //Console.WriteLine(sa.ToString());
            LoopQueue<int> queueArray = new LoopQueue<int>();
            for (int i = 0; i < 10; i++)
            {
                queueArray.Enqueue(i);
               
                Console.WriteLine(queueArray.ToString());
                if (i % 3 == 2)
                {
                    queueArray.Dequeue();
                    Console.WriteLine(queueArray.ToString()+"出列");
                }
            }

        }
    }
}
