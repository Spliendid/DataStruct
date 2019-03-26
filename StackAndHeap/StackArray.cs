using System;
using Array;
using System.Text;
namespace StackAndQueue
{
    class StackArray<E> : StackInterface<E>
    {
        private Array<E> array;

        public StackArray()
        {
            array = new Array<E>();
        }

        public StackArray(int Capacity)
        {
            array = new Array<E>(Capacity);
        }

        public int GetSize()
        {
            return array.getSize();
        }

        public bool IsEmpty()
        {
            return array.isEmpty();
        }

        public E Peek()
        {
            return array[array.getSize()];
        }

        public E Pop()
        {
            return array.removeLast();
        }

        
        public void Push(E e)
        {
            array.addLast(e);
        }

        // 获取数组的容量
        public int getCapacity()
        {
            return array.getCapacity();
        }

        public String ToString()
        {

            StringBuilder res = new StringBuilder();
            res.Append(String.Format("Array: size = {0} , capacity = {1}\n", GetSize(), getCapacity()));
            res.Append('[');
            for (int i = 0; i < GetSize(); i++)
            {
                res.Append(array[i]);
                if (i != GetSize() - 1)
                    res.Append(", ");
            }
            res.Append(']');
            return res.ToString();
        }
    }
}
