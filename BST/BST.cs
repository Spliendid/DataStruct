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
    class BST<T>where T: IComparable<T>
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

            public override string ToString()
            {
                return t.ToString();
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
            if (t.CompareTo(node.t)>0)
            {
                node.right = Add(node.right,t);
            }
            else if (t.CompareTo(node.t) < 0)
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
            else if (t.CompareTo(node.t)>0)
            {
                return Contains(node.right, t);
            }
            else
            {
                return Contains(node.left,t);
            }
        }


        #endregion

        #region Order

        #region Preorder

        //前序遍历
        public void Preorder()
        {
            Preorder(root);
        }

        private void Preorder(Node node)
        {
            if (node == null)
            {
                return;
            }
            Console.WriteLine(node);
            Preorder(node.left);
            Preorder(node.right);
        }
        
        //前序遍历 非递归实现
        private void PreorderNR()
        {
            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);
            while (stack.Count>0)
            {
                Node node = stack.Pop();
                Console.WriteLine(node);
                if(node.right!=null)
                    stack.Push(node.right);
                if(node.left!=null)
                    stack.Push(node.left);
            }
        }
        #endregion

        #region InOrder

        public void InOrder()
        {
            InOrder(root);
        }

        private void InOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            InOrder(node.left);
            Console.WriteLine(node);
            InOrder(node.right);
        }

        #endregion

        #region PostOrder
        public void PostOrder()
        {
            PostOrder(root);
        }

        private void PostOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            PostOrder(node.left);
            PostOrder(node.right);
            Console.WriteLine(node);
        }

        #endregion

        #region LevelOrder

        public void LevelOrder()
        {
            LevelOrder(root);
        }

        private void LevelOrder(Node node)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);
            while (queue.Count>0)
            {
                Node cur = queue.Dequeue();
                Console.WriteLine(cur);
                if (cur.left!=null)
                {
                    queue.Enqueue(cur.left);
                }
                if (cur.right!=null)
                {
                    queue.Enqueue(cur.right);
                }
            }
        }

        #endregion

        #endregion

        #region Remove

        //获取最小值
        public T Minimum()
        {
            if (size == 0)
            {
                throw new Exception("BST is empty");
            }
            return Minimum(root).t;
        }

        private Node Minimum(Node node)
        {
            if (node.left == null)
            {
                return node;
            }

            return Minimum(node.left);
        }

        //删除最小点
        public T RemoveMini()
        {
            T t = Minimum();
            root = RemoveMini(root);
            return t;
        }

        //删除树的最小节点 返回新树的根节点
        private Node RemoveMini(Node node)
        {
            if (node.left == null)
            {
                Node _root = node.right;
                node.right = null;
                return _root;
            }

            node.left = RemoveMini(node.left);
            return node;
        }

        //获取最大值
        public T Maxmum()
        {
            if (size == 0)
            {
                throw new Exception("BST is empty");
            }

            return Maxmum(root).t;
        }

        private Node Maxmum(Node node)
        {
            if (node.right==null)
            {
                return node;
            }

            return Maxmum(node.right);
        }

        //删除最大节点
        public T RemoveMax()
        {
            T t = Maxmum();
            root = RemoveMax(root);
            return t;
        }

        private Node RemoveMax(Node node )
        {
            if (node.right == null)
            {
                Node _root = node.left;
                node.right = null;
                return _root;
            }

            node.right = RemoveMax(node.right);
            return node;
        }

        //删除指定节点

        public void Remove(T t)
        {

        }

        private Node 

        #endregion

        public override String ToString()
        {
            StringBuilder res = new StringBuilder();
            generateBSTString(root, 0, res);
            return res.ToString();
        }

        // 生成以node为根节点，深度为depth的描述二叉树的字符串
        private void generateBSTString(Node node, int depth, StringBuilder res)
        {

            if (node == null)
            {
                res.Append(generateDepthString(depth) + "null\n");
                return;
            }

            res.Append(generateDepthString(depth) + node.t + "\n");
            generateBSTString(node.left, depth + 1, res);
            generateBSTString(node.right, depth + 1, res);
        }

        private String generateDepthString(int depth)
        {
            StringBuilder res = new StringBuilder();
            for (int i = 0; i < depth; i++)
                res.Append("--");
            return res.ToString();
        }

    }



}
