using System;
using System.Collections.Generic;
using System.Text;
using LinkedList;
namespace StackAndQueue
{
    class LinkerStack<E> : StackInterface<E>
    {
        private LinkedList.LinkedList<E> list;

        public LinkerStack()
        {
            list = new LinkedList.LinkedList<E>();
        }

        public int GetSize()
        {
            return list.GetSize();
        }

        public bool IsEmpty()
        {
            return list.IsEmpty();
        }

        public E Peek()
        {
            return list.GetFirst();
        }

        public E Pop()
        {
            return list.RemoveFirst();
        }

        public void Push(E e)
        {
             list.AddFirst(e);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("StackTop");
            sb.Append(list);
            return sb.ToString();
        }
    }
}
