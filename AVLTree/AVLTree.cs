using System;
using System.Collections.Generic;
using System.Text;
using Map;
namespace AVLTree
{
    class AVLTree<K, V> : MapInterface<K, V> where K : IComparable<K>
    {

        #region Node

        /// <summary>
        /// 节点类
        /// </summary>
        private class Node
        {
            public K key;
            public V value;
            public int Height;
            public Node leftNode;
            public Node rightNode;

            public Node(K key, V value, Node left, Node right)
            {
                this.key = key;
                this.value = value;
                this.leftNode = left;
                this.rightNode = right;
                Height = 1;
            }

            public Node(K key, V value)
            {
                this.key = key;
                this.value = value;
                Height = 1;
            }

            public Node(K key)
            {
                this.key = key;
                this.value = default(V);
                Height = 1;
            }

            public Node()
            {
                this.key = default(K);
                this.value = default(V);
                Height = 1;
            }

            public override string ToString()
            {
                return string.Format("[Key : {0}\tValue : {1}]", key, value);
            }
        }
        #endregion

        private int size;

        public int Size { get { return size; } }

        private Node root;

        public AVLTree()
        {
            size = 0;
            root = null;
        }

        #region Node

        private int GetHeight(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            return node.Height;
        }

        private int GetBalance(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            return GetHeight(node.leftNode) - GetHeight(node.rightNode);
        }

        private bool isBalanceNode(Node node)
        {
            return  Math.Abs( GetBalance(node) )<= 1;
        }

        private bool isBSTNode(Node node)
        {
            if (node.leftNode != null)
            {
                if (node.leftNode.key.CompareTo(node.key) > 0)
                {
                    return false;
                }
            }
            if (node.rightNode != null)
            {
                if (node.rightNode.key.CompareTo(node.key) < 0)
                {
                    return false;
                }
            }

            return true;
        }


        #endregion

        #region Add


        public void Add(K key, V value)
        {
            root = Add(root, key, value);
        }

        private Node Add(Node node, K key, V value)
        {
            if (node == null)
            {
                node = new Node(key, value);
            }

            if (node.key.CompareTo(key) > 0)
            {
                node.leftNode = Add(node.leftNode, key, value);
            }
            else if (node.key.CompareTo(key) < 0)
            {
                node.rightNode = Add(node.rightNode, key, value);
            }
            node.Height = Math.Max(GetHeight(node.leftNode), GetHeight(node.rightNode)) + 1;

            int balance = GetBalance(node);

            //LL
            if (balance > 1 && GetBalance(node.leftNode)>=0)
            {
                node = RightRotate(node);
            }

            //LR
            if (balance >1&& GetBalance(node.leftNode)<0)
            {
                //1.先将node.left 左旋
                node.leftNode = LeftRotate(node.leftNode);

                //2.转变为LL
                node = RightRotate(node);
            }

            //RR
            if (balance<-1 && GetBalance(node.rightNode)<=0)
            {
                node = LeftRotate(node);
            }

            //RL
            if (balance < -1 && GetBalance(node.rightNode) > 0)
            {
                //1.先将node.right右旋
                node.rightNode = RightRotate(node.rightNode);

                //2.转变为RR
                node = LeftRotate(node);
            }

            return node;
        }

        // 对节点y进行向右旋转操作，返回旋转后新的根节点x
        //        y                                      x
        //       / \                                    /  \
        //      x   T4     向右旋转 (y)        z     y
        //     / \       - - - - - - - ->        / \   / \
        //    z   T3                            T1 T2 T3 T4
        //   / \
        // T1   T2
        private Node RightRotate(Node y)
        {
            //旋转
            Node x = y.leftNode;
            Node T3 = x.rightNode;
            x.rightNode = y;
            y.leftNode = T3;

            //维护深度
            y.Height = Math.Max(GetHeight(y.leftNode),GetHeight(y.rightNode))+1;
            x.Height = Math.Max(GetHeight(x.leftNode),GetHeight(x.rightNode))+1;

            return x;

        }

        // 对节点y进行向左旋转操作，返回旋转后新的根节点x
        //         y                                             x
        //       /  \                                          /  \
        //      T1   x              向左旋转 (y)       y     z
        //            / \           - - - - - - - ->     / \    / \
        //          T2  z                                T1 T2 T3 T4
        //                / \
        //              T3 T4
        private Node LeftRotate(Node y)
        {
            Node x = y.rightNode;
            Node T2 = x.leftNode;

            //旋转
            x.leftNode = y;
            y.rightNode = T2;

            //维护深度
            y.Height = Math.Max(GetHeight(y.leftNode), GetHeight(y.rightNode)) + 1;
            x.Height = Math.Max(GetHeight(x.leftNode), GetHeight(x.rightNode)) + 1;

            return x;
        }

        #endregion

        #region Remove

        public K RemoveMax()
        {
            Node node = GetMax(root);
            root = RemoveMax(root);
            return node.key;
        }

        private Node RemoveMax(Node node)
        {
            if (node.rightNode != null)
            {
                node.rightNode = RemoveMax(node.rightNode);

            }
            else
            {
                Node leftNode = node.leftNode;
                node.leftNode = null;
                size--;
                return leftNode;
            }
            return node;
        }

        public K RemoveMin()
        {
            Node node = GetMin(root);
            root = RemoveMin(root);
            return node.key;
        }

        private Node RemoveMin(Node node)
        {
            if (node.leftNode == null)
            {
                Node rightNode = node.rightNode;
                rightNode = null;
                size--;
                return rightNode;
            }

            node.leftNode = RemoveMin(node.leftNode);

            return node;
        }

        public V Remove(K key)
        {
            Node node = GetNode(root, key);
            root = Remove(root, key);
            return node.value;
        }

        private Node Remove(Node node, K key)
        {
            if (node == null)
            {
                return null;
            }

            Node renode = node;
            if (key.CompareTo(node.key) > 0)
            {
                if (node.rightNode != null)
                {
                    node.rightNode = Remove(node.rightNode, key);
                }
            }
            else if (key.CompareTo(node.key) < 0)
            {
                if (node.leftNode != null)
                {
                    node.leftNode = Remove(node.leftNode, key);
                }
            }
            else//就是要删除的节点时
            {
                //如果左子树为空
                if (node.leftNode == null)
                {
                    Node rightNode = node.rightNode;
                    node.rightNode = null;
                    size--;
                    renode = rightNode;
                }

                //如果右子树为空
               else if (node.rightNode == null)
                {
                    Node leftNode = node.leftNode;
                    node.leftNode = null;
                    size--;
                    renode = leftNode;
                }
                else
                {
                    //比被删节点大的最小节点
                    Node _node = GetMin(node.rightNode);
                   // RemoveMin(node.rightNode);
                    _node.rightNode = Remove(node.rightNode,_node.key);
                    _node.leftNode = node.leftNode;
                    node.leftNode = node.rightNode = null;
                    renode = _node;
                }

              

            }
            if (renode == null)
            {
                return null;
            }

            //更新height
            renode.Height = Math.Max(GetHeight(renode.leftNode), GetHeight(renode.rightNode)) + 1;
            //平衡维护
            int balance = GetBalance(renode);
            Console.WriteLine($"{renode} B:{balance}");

            //LL
            if (balance > 1 && GetBalance(renode.leftNode) >= 0)
            {
                renode = RightRotate(renode);
            }

            //LR
            if (balance > 1 && GetBalance(renode.leftNode) < 0)
            {
                //1.先将node.left 左旋
                renode.leftNode = LeftRotate(renode.leftNode);

                //2.转变为LL
                renode = RightRotate(renode);
            }

            //RR
            if (balance < -1 && GetBalance(renode.rightNode) <= 0)
            {
                renode = LeftRotate(renode);
            }

            //RL
            if (balance < -1 && GetBalance(renode.rightNode) > 0)
            {
                //1.先将node.right右旋
                renode.rightNode = RightRotate(renode.rightNode);

                //2.转变为RR
                renode = LeftRotate(renode);
            }
            return renode;
        }

        #endregion

        #region Set

        public void Set(K key, V value)
        {
            Node node = GetNode(root, key);
            if (node == null)
            {
                throw new Exception("Get key failed.Key was not found");
            }
            node.value = value;
        }

        #endregion

        #region Get

        public bool Contain(K key)
        {
            Node node = GetNode(root, key);
            return node != null;
        }

        public V Get(K key)
        {
            Node node = GetNode(root, key);
            if (node == null)
            {
                throw new Exception("Get key failed.Key was not found");
            }
            return node.value;
        }

        private Node GetNode(Node node, K key)
        {
            if (node == null)
            {
                return null;
            }

            if (node.key.Equals(key))
            {
                return node;
            }
            if (key.CompareTo(node.key) > 0)
            {

                return GetNode(node.rightNode, key);

            }
            else
            {

                return GetNode(node.leftNode, key);

            }


        }


        public K GetMin()
        {
            return GetMin(root).key;
        }

        private Node GetMin(Node node)
        {
            if (node.leftNode != null)
            {
                return GetMin(node.leftNode);
            }
            else
            {
                return node;
            }
        }

        public K GetMax()
        {
            return GetMax(root).key;
        }

        private Node GetMax(Node node)
        {
            if (node.rightNode != null)
            {
                return GetMax(node.rightNode);
            }
            else
            {
                return node;
            }
        }

        #endregion

        #region Order

        public void PreOrder()
        {
            PreOrder(root);
        }

        private void PreOrder(Node node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine($"[{node.key}:{node.value}]");
            PreOrder(node.leftNode);
            PreOrder(node.rightNode);
        }


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

            InOrder(node.leftNode);
            Console.WriteLine($"[{node.key}:{node.value}]");
            InOrder(node.rightNode);
        }

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

            PostOrder(node.leftNode);
            PostOrder(node.rightNode);
            Console.WriteLine($"[{node.key}:{node.value}]");
        }

        public void LevelOrder()
        {
            LevelOrder(root);
        }

        private void LevelOrder(Node node)
        {
            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                Node _node = queue.Dequeue();

                Console.WriteLine($"[{_node.key}:{_node.value}]");

                if (_node.leftNode != null)
                    queue.Enqueue(_node.leftNode);
                if (_node.rightNode != null)
                    queue.Enqueue(_node.rightNode);
            }
        }

        public void LevelOrderB()
        {
            LevelOrderB(root);
        }

        private void LevelOrderB(Node node)
        {
            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                Node _node = queue.Dequeue();

                Console.WriteLine($"[{_node.key}:{_node.value}-->{_node.Height}]");

                if (_node.leftNode != null)
                    queue.Enqueue(_node.leftNode);
                if (_node.rightNode != null)
                    queue.Enqueue(_node.rightNode);
            }
        }

        #endregion

        public bool isBalance()
        {
            return isBalance(root);
        }

        private bool isBalance(Node node)
        {
            if (node == null)
            {
                return true;
            }
            if (isBalanceNode(node))
            {
                return isBalance(node.leftNode) && isBalance(node.rightNode);
            }
            else
            {
                return false;
            }
        }

        public bool isBST()
        {
            return isBST(root);
        }

        private bool isBST(Node node)
        {
            if (node == null)
            {
                return true;
            }

            if (isBSTNode(node))
            {
                return isBST(node.leftNode)&&isBST(node.rightNode);
            }
            else
            {
                return false;
            }
        }

        public int GetSize()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }
    }
}
