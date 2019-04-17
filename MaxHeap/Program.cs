using System;

namespace MaxHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] array = new int[] { 2, 5, 4, 8, 7, 3, 9, 1, 6 };

            // MaxHeap<int> heap = new MaxHeap<int>(array);

            //// heap.LevelOrder();

            // while (heap.Size>0)
            // {
            //     Console.WriteLine(heap.ExtractMax());
            // }
            Random random = new Random();

            int[] array = new int[100000];

            for (int i = 0; i < 100000; i++)
            {
                array[i] = random.Next();
            }

            Console.WriteLine(GetT(()=> {
                MaxHeap<int> heap = new MaxHeap<int>(array);
            }));

            Console.WriteLine(GetT(()=> {
                MaxHeap<int> heap = new MaxHeap<int>(array.Length);
                for (int i = 0; i < array.Length; i++)
                {
                    heap.Add(array[i]);
                }
            }));
        }

        public static double GetT(System.Action ac)
        {
            long currentTicks = DateTime.Now.Ticks;

            ac();

            double delta = (double)(DateTime.Now.Ticks - currentTicks) / 10000000;

            return delta;
        }
    }
}
