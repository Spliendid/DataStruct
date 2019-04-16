using System;
using System.Collections.Generic;
using System.Text;
using Array;
namespace MaxHeap
{
    class MaxHeap<T> where T : IComparable<T>
    {
        private Array<T> data;

        public MaxHeap(int capacity)
        {
            data = new Array<T>(capacity);
        }

        public MaxHeap()
        {
            data = new Array<T>();
        }

        public int Size
        {
            get { return data.getSize(); }
        }

        public bool IsEmpty()
        {
            return data.isEmpty();
        }

        //返回父节点位置
        private int Parent(int index)
        {
            if (index == 0)
            {
                throw new Exception("Index-0 is doesn't have parent");
            }
            return (index-1)/2;
        }

        //返回左孩子位置
        private int LeftChild(int index)
        {
            return 2 * index + 1;
        }

        //返回右孩子位置
        private int RightChild(int index)
        {
            return 2*index + 2;
        }
    }
}
