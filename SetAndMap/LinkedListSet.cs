using System;
using System.Collections.Generic;
using System.Text;
using LinkedList;
namespace SetAndMap
{
    class LinkedListSet<T> : SetInterface<T>
    {
        private LinkedList.LinkedList<T> list;

        public LinkedListSet()
        {
            list = new LinkedList.LinkedList<T>();
        }

        public void Add(T t)
        {
            if (Contains(t))
            {
                return;
            }
            list.AddFirst(t);
        }

        public bool Contains(T t)
        {
            return list.Contains(t);
        }

        public int GetSize()
        {
            return list.GetSize();
        }

        public bool isEmpty()
        {
            return list.IsEmpty();
        }

        public void Remove(T t)
        {
            list.RemoveElement(t);
        }

        public override string ToString()
        {
            return list.ToString();
        }
    }
}
