using System;
using System.Collections.Generic;
using System.Text;

namespace SegmentTree
{
    class SegmentTree<T>
    {
        private T[] array;//原始数组
        private T[] tree;//线段树

        public delegate T Merger(T t1,T t2);
        private Merger merger;
        public SegmentTree(T[] array,Merger merger)
        {
            this.array = array;
            //需要4*length的空间
            tree = new T[4*array.Length];
            this.merger = merger;
            BuildSegmentTree(0,0,array.Length-1);
        }

        /// <summary>
        /// 创建线段树
        /// </summary>
        /// <param name="index">在index位置创建线段树</param>
        /// <param name="l">区间的开始位置</param>
        /// <param name="r">区间的结束位置</param>
        private void BuildSegmentTree(int index,int l,int r)
        {
            if (l == r)
            {
                tree[index] = array[l];
                return;
            }

            int leftIndex = LeftChild(index);
            int rightIndex = RightChild(index);

            int mid = (l + r) / 2;

            BuildSegmentTree(leftIndex,l,mid);
            BuildSegmentTree(rightIndex,mid+1,r);

            tree[index] = merger( tree[leftIndex] ,tree[rightIndex]);

        }

        //查询l~r 区间的和
        public T Query(int l,int r)
        {
            if (l<0||r>=array.Length||l>r)
            {
                throw new Exception("l or r is illegal.");
            }
           return Query(0, l, r,0,array.Length-1);
        }

        //在index节点（代表区间为[lq,rq]） 查询 [r,l]区间的和 
        private T Query(int index,int l,int r,int lq,int rq) 
        {
            if (l == r)
            {
                return array[l];
            }

            //Console.WriteLine($"[{l},{r}]");

            int leftC = LeftChild(index);
            int rightC = RightChild(index);

          
            int mid = (lq+rq) / 2;

            Console.WriteLine($"{index}:[{lq},{rq}]");


            if (l > mid)
                return Query(rightC, l, r,mid+1,rq);
            if (r < mid + 1)
                return Query(leftC, l, r,lq,mid);

            T Left = Query(leftC, l, mid,lq,mid);
            T Right = Query(rightC, mid + 1, r,mid+1,rq);

            return merger(Left, Right);
        }

        //查询 index位置 l~r 区间的和
        private T Query(int index,int l,int r)
        {
            if (l == r)
            {
                return array[l];
            }

            //Console.WriteLine($"[{l},{r}]");

            int leftC = LeftChild(index);
            int rightC = RightChild(index);

            var query = GetQuery(index);
            int mid = (query[0] + query[1]) / 2;

            Console.WriteLine($"{index}:[{query[0]},{query[1]}]");


            if (l > mid)
                return Query(rightC,l,r);
            if (r < mid + 1)
                return Query(leftC,l,r);
            T Left = Query(leftC,l,mid);
            T Right = Query(rightC,mid+1,r);

            return merger(Left, Right);
        }

        //获取tree index 位置代表的区间
        private int[] GetQuery(int index)
        {

            int left=-1,right = -1;

            if (index == 0)
                return new int[] { 0, array.Length-1};
            
            //index为奇数为左节点 index为偶数 为右节点

            int parent = Parent(index);
            var _array= GetQuery(parent);
            int mid = (_array[0] + _array[1]) / 2;

            //右节点
            if (index%2 == 0)
            {
                left = mid + 1;
                right = _array[1];
            }
            //左节点
            else
            {
                left = _array[0];
                right = mid;
            }
            return new int[]{ left,right};
        }


        public int Size { get { return array.Length; } }

       public T this[int index]
        {
            get { return array[index]; }
        }

        public int Parent(int index)
        {
            return (index - 1) / 2;
        }

        public int LeftChild(int index)
        {
            int i = 2 * index + 1;
            if (i>=tree.Length-1)
            {
                throw new Exception("LeftChild is NULL.");
            }
            return i;
        }

        public int RightChild(int index)
        {
            int i = 2 * index + 2;
            if (i >= tree.Length - 1)
            {
                throw new Exception("RightChild is NULL.");
            }
            return i;
        }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.Append('[');
            for (int i = 0; i < tree.Length; i++)
            {
                if (tree[i] != null)
                    res.Append(tree[i]);
                else
                    res.Append("null");

                if (i != tree.Length - 1)
                    res.Append(", ");
            }
            res.Append(']');
            return res.ToString();
        }
    }
}
