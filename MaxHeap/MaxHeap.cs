using System;
using System.Collections.Generic;
using System.Text;
using Array;
namespace MaxHeap
{
    class MaxHeap<T> where T : IComparable<T>
    {
        private Array<T> data;

        //Heapify
        public MaxHeap(T[] array)
        {
            data = new Array<T>(array);

            for (int i = Parent( array.Length-1); i >=0; i--)
                ShiftDown(i);
        }

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

        #region Add

        public void Add(T t)
        {
            data.addLast(t);
            ShiftUp(data.getSize()-1);
        }

        #endregion

        #region Get

        public T FindMax()
        {
            if (IsEmpty())
            {
                throw new Exception("Can not FindMax when heap is empty.");
            }
            return data[0];
        }

        public T ExtractMax()
        {
            T temp = FindMax();
            data.Swap(0,data.getSize()-1);
            data.removeLast();
            ShiftDown(0);
            return temp;
        }

        #endregion

        #region ShiftUp

        private void ShiftUp(int index)
        {
            while (index > 0&&data[index].CompareTo(data[Parent(index)])>0)
            {
                data.Swap(index, Parent(index));
                index = Parent(index);
            }
        }

        #endregion

        #region ShiftDown
        private void ShiftDown(int index)
        {
            while (LeftChild(index)<Size)
            {
                int j = LeftChild(index);

                //获取最大孩子的位置
                if (j+1<Size)
                {
                    if (data[j].CompareTo(data[j+1])<0)
                    {
                        j++;
                    }
                }

                if (data[index].CompareTo(data[j]) >= 0)
                {
                    break;
                }
                data.Swap(index,j);
                index = j;
            }
        }

        #endregion

        #region Replace
        /// <summary>
        /// 取出堆中最大元素 并替换成指定值
        /// </summary>
        /// <param name="t"></param>
        public T Replace(T t)
        {
            T temp = FindMax();
            data.set(0, t);
            ShiftDown(0);
            return temp;
        }
        #endregion

        #region Order

        public void LevelOrder()
        {
            if (IsEmpty())
            {
                return;
            }
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            while (queue.Count>0)
            {
                int index = queue.Dequeue();
                Console.WriteLine(data[index]);
                if (LeftChild(index)<Size)
                {
                    queue.Enqueue(LeftChild(index));
                }

                if (RightChild(index) < Size)
                {
                    queue.Enqueue(RightChild(index));
                }
            }

        }

        #endregion

    }
}
