using System;
using System.Collections.Generic;
using System.Text;
using BST;
namespace Set
{
    class BSTSet<T> : SetInterface<T> where T : IComparable<T>
    {

        private BST<T> bst;

        public BSTSet()
        {
            bst = new BST<T>();
        }

        public void Add(T t)
        {
            bst.Add(t);
        }

        public bool Contains(T t)
        {
            throw new NotImplementedException();
        }

        public int GetSize()
        {
            return bst.Size;
        }

        public bool isEmpty()
        {
            return bst.IsEmpty();
        }

        public void Remove(T t)
        {
            bst.Remove(t);
        }
    }
}
