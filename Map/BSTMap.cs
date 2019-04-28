using System;
using System.Collections.Generic;
using System.Text;

namespace Map
{
    class BSTMap<K, V> : MapInterface<K, V> where K:IComparable<K>
    {

        #region Node

        /// <summary>
        /// 节点类
        /// </summary>
        private class Node
        {
            public K key;
            public V value;

            public Node leftNode;
            public Node rightNode;

            public Node(K key, V value, Node left,Node right)
            {
                this.key = key;
                this.value = value;
                this.leftNode = left;
                this.rightNode = right;
            }

            public Node(K key, V value)
            {
                this.key = key;
                this.value = value;
            }

            public Node(K key)
            {
                this.key = key;
                this.value = default(V);
            }

            public Node()
            {
                this.key = default(K);
                this.value = default(V);
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

        public BSTMap()
        {
            size = 0;
            root = null;
        }

        #region Add


        public void Add(K key, V value)
        {
           root = Add(root,key,value);
        }

        private Node Add(Node node, K key, V value)
        {
            if (node == null)
            {
                node = new Node( key,value);
                size++;
                return node;
            }

            if (node.key.CompareTo(key)>0)
            {
                node.leftNode =  Add(node.leftNode,key,value);
            }
            else if (node.key.CompareTo(key) < 0)
            {
                node.rightNode = Add(node.rightNode,key,value);
            }

            return node;
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
            if (node.rightNode!=null)
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
            Node node = GetNode(root,key);
            root =  Remove(root,key);
            return node.value;
        }

        private Node Remove(Node node, K key)
        {
            if (key.CompareTo(node.key)>0)
            {
                if (node.rightNode!=null)
                {
                    node.rightNode = Remove(node.rightNode,key);
                }
            }
            else if(key.CompareTo(node.key)<0)
            {
                if (node.leftNode!=null)
                {
                    node.leftNode = Remove(node.leftNode,key);
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
                    return rightNode;
                }

                //如果右子树为空
                if (node.rightNode == null)
                {
                    Node leftNode = node.leftNode;
                    node.leftNode = null;
                    size--;
                    return leftNode;
                }

                //比被删节点大的最小节点
                Node _node = GetMin(node.rightNode);
                RemoveMin(node.rightNode);
                _node.leftNode = node.leftNode;
                _node.rightNode = node.rightNode;
                node.leftNode = node.rightNode = null;
                return _node;

            }

            return node;
        }

        #endregion

        #region Set

        public void Set(K key, V value)
        {
            Node node = GetNode(root,key);
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
            Node node = GetNode(root, key );
            if (node == null)
            {
                throw new Exception("Get key failed.Key was not found");
            }
            return node.value;
        }

        private Node GetNode( Node node, K key)
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

                return GetNode(node.rightNode,key);

            }
            else
            {

                return GetNode( node.leftNode,key);

            }


        }


        public K GetMin()
        {
            return GetMin(root).key;
        }

        private Node GetMin(Node node)
        {
            if (node.leftNode!=null)
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

            while (queue.Count>0)
            {
                Node _node = queue.Dequeue();

                Console.WriteLine($"[{_node.key}:{_node.value}]");

                if (_node.leftNode != null)
                    queue.Enqueue(_node.leftNode);
                if (_node.rightNode != null)
                    queue.Enqueue(_node.rightNode);
            }
        }

        #endregion

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
