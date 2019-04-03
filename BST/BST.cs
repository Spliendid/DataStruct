using System;
using System.Collections.Generic;
using System.Text;
/*
 * 二分搜索树性质
 * 1.二分搜索每个节点的值不同
 * 2.每个节点的值大于左子树所有节点的值，小于右子树所有节点的值
 * 3.每个子树也是二分搜索树
 */
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

        #region Add


        public void Add(T t)
        {
            root = Add(root, t);
        }

        private Node Add(Node node,T t)
        {
            //增加自身
            if (node == null)
            {
                return new Node(t);
            }
           
            //添加子节点
            if (t.Compare(t,node.t)>0)
            {
                node.right = Add(node.right,t);
            }
            else if (t.Compare(t, node.t) < 0)
            {
                node.left = Add(node.left,t);
            }

            return node;
        }
        #endregion

        #region Find

        public bool Contains(T t)
        {
            return Contains(root,t);
        }

        private bool Contains(Node node, T t)
        {

            if (node == null)
            {
                return false;
            }

            if (node.t.Equals(t))
            {
                return true;
            }
            else if (t.Compare(t,node.t)>0)
            {
                return Contains(node.right, t);
            }
            else
            {
                return Contains(node.left,t);
            }
        }


        #endregion

        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();

        //}
    }



}
