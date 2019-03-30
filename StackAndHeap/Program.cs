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


            //LoopQueue<int> queueArray = new LoopQueue<int>();
            //for (int i = 0; i < 10000; i++)
            //{
            //    queueArray.Enqueue(i);

            //    Console.WriteLine(queueArray.ToString());
            //    if (i % 3 == 2)
            //    {
            //        queueArray.Dequeue();
            //        Console.WriteLine(queueArray.ToString()+"出列");
            //    }
            //}
            LinkedQueue<int> linkedQueue = new LinkedQueue<int>();
            QueueArray<int> queueArray = new QueueArray<int>();
            LoopQueue<int> loopQueue = new LoopQueue<int>();
            LinkerStack<int> linkerStack = new LinkerStack<int>();
            StackArray<int> stackArray = new StackArray<int>();
            //Console.WriteLine(GetT(linkerStack, 100000));

            //LinkedQueue<int> queueArray = new LinkedQueue<int>();
            //for (int i = 0; i < 10; i++)
            //{
            //    queueArray.Enqueue(i);

            //    Console.WriteLine(queueArray.ToString());
            //    if (i % 3 == 2)
            //    {
            //        queueArray.Dequeue();
            //        Console.WriteLine(queueArray.ToString() + "出列");
            //    }
            //}

            Console.WriteLine("LoopQuquq"+GetT( loopQueue,1000000));
            Console.WriteLine("LinkedQueue"+GetT(linkedQueue, 1000000));

        }

        private static double GetT(QueueInterface<int> e,int num)
        {
            long currentTicks = DateTime.Now.Ticks;

            for (int i = 0; i < num; i++)
            {
                e.Enqueue(i);
            }

            for (int i = 0; i < num; i++)
            {
                e.Dequeue();
            }

             double delta = (double)( DateTime.Now.Ticks - currentTicks)/10000000;

             return delta;
        }

        private static double GetT(StackInterface<int> e, int num)
        {
            long currentTicks = DateTime.Now.Ticks;

            for (int i = 0; i < num; i++)
            {
                e.Push(i);
            }

            for (int i = 0; i < num; i++)
            {
                e.Pop();
            }

            double delta = (double)(DateTime.Now.Ticks - currentTicks) / 10000000;

            return delta;
        }
    }
}
