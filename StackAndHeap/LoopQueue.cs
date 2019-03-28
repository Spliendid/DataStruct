using System;
using System.Collections.Generic;
using System.Text;

namespace StackAndQueue
{
    class LoopQueue<E> : QueueInterface<E>
    {
        private E[] data;
        private int front,tail; //开头结尾
        private int size;//大小

        public LoopQueue()
        {
            front = tail = 0;
            size = 0;
            data = new E[10];
        }

        public LoopQueue(int capacity)
        {
            front = tail = 0;
            size = 0;
            data = new E[capacity];
        }

        //出列
        public E Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception("Can not dequeue from an empty queue");
            }
            E e = data[front];
            data[front] = default(E);
            front = (front+1)%data.Length;
            size--;
            //更改容量
            if (size == GetCapacity()/4 && GetCapacity()/2 != 0)
            {
                Resize(GetCapacity() / 2);
            }
            return e;
        }

        //排队
        public void Enqueue(E e)
        {
            if ((tail+1)%data.Length == front)
            {
                Resize(GetCapacity()*2);
            }
            data[tail] = e;
            tail = (tail+1)%data.Length;
            size++;
        }


        private void Resize(int newCapacity)
        {
           
            E[] newData = new E[newCapacity];
            for (int i = 0; i < size; i++)
            {
                newData[i] = data[(i + front) % data.Length];
            }
            data = newData;
            front = 0;
            tail = size;
        }

        public E GetFront()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException("Queue is empty.");
            }
            return data[front];
        }

        public int GetSize()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return front == tail;
        }

        public int GetCapacity()
        {
            return data.Length - 1;
        }

        public String ToString()
        {

            StringBuilder res = new StringBuilder();
            res.Append(String.Format("Queue: size = {0} , capacity = {1}\n", GetSize(), GetCapacity()));
            res.Append("Front[");
            for (int i = 0; i < GetSize(); i++)
            {
                res.Append(data[(i+front)%data.Length]);
                if (i != GetSize() - 1)
                    res.Append(", ");
            }
            res.Append("]Tail");
            return res.ToString();
        }
    }
}
