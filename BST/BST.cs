using System;
using System.Collections.Generic;
using System.Text;

namespace BST
{
    /// <summary>
    /// 二分搜索树
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class BST<T>where T: Comparer<T>
    {
        //树节点类
        private class Node
        {
            public T t;
            public Node left, right;

            public Node()
            {

            }

            public Node(T t,Node left = null,Node right = null)
            {
                this.left = left;
                this.right = right;
                this.t = t;
            }

        }

        //根节点
        private Node root;

        private int size;
        public int Size
        {
            get { return size; }
        }

        public BST()
        {
            root = null;
            size = 0;
        }

      

        public bool IsEmpty()
        {
            return size == 0;
        }
    }

    
}
