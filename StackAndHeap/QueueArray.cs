using System;
using System.Text;
using Array;

namespace StackAndQueue
{
    class QueueArray<E> : QueueInterface<E>
    {
        private Array<E> array;

        //构造函数
        public QueueArray()
        {
            array = new Array<E>();
        }

        public QueueArray(int capacity)
        {
            array = new Array<E>(capacity);
        }

        //离队
        public virtual E Dequeue()
        {
            return array.removeFirst();
        }

        //排队
        public virtual void Enqueue(E e)
        {
            array.addLast(e);
        }

        //获取第一个
        public virtual E GetFront()
        {
            return array.get(0);
        }

        public int GetSize()
        {
            return array.getSize();
        }

        public bool IsEmpty()
        {
            return array.isEmpty();
        }

        //获取容量
        public virtual int GetCapacity()
        {
            return array.getCapacity();
        }

        public override  String ToString()
        {

            StringBuilder res = new StringBuilder();
            res.Append(String.Format("Queue: size = {0} , capacity = {1}\n", GetSize(), GetCapacity()));
            res.Append("Front[");
            for (int i = 0; i < GetSize(); i++)
            {
                res.Append(array[i]);
                if (i != GetSize() - 1)
                    res.Append(", ");
            }
            res.Append("]Tail");
            return res.ToString();
        }
    }
}
