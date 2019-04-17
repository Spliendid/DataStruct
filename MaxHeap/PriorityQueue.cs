using System;
using System.Collections.Generic;
using System.Text;
using StackAndQueue;
namespace MaxHeap
{
    class PriorityQueue<T> : QueueInterface<T> where T:IComparable<T>
    {
        private MaxHeap<T> heap ;

        public PriorityQueue()
        {
            heap = new MaxHeap<T>();
        }

        public T Dequeue()
        {
            return heap.ExtractMax();
        }

        public void Enqueue(T e)
        {
            heap.Add(e);
        }

        public T GetFront()
        {
            return heap.FindMax();
        }

        public int GetSize()
        {
            return heap.Size;
        }

        public bool IsEmpty()
        {
            return heap.IsEmpty();
        }
    }
}
