using System;
using System.Collections.Generic;
using System.Text;

namespace Map
{
    public class LinkedListMap<K, V> : MapInterface<K, V> 
    {
        #region Node

        /// <summary>
        /// 节点类
        /// </summary>
        private class Node
        {
            public K key;
            public V value;

            public Node next;

            public Node(K key,V value, Node next)
            {
                this.key = key;
                this.value = value;
                this.next = next;
            }

            public Node(K key, V value)
            {
                this.key = key;
                this.value = value;
                this.next = null;
            }

            public Node(K key)
            {
                this.key = key;
                this.value = default(V);
                this.next = null;
            }

            public Node()
            {
                this.key = default(K);
                this.value = default(V);
                this.next = null;
            }

            public override string ToString()
            {
                return string.Format("[Key : {0}\tValue : {1}]",key,value);
            }
        }
        #endregion

        private Node dummyHead;//虚拟头结点

        private int size;

        public LinkedListMap()
        {
            dummyHead = new Node();
            size = 0;
        }

        public void Add(K key, V value)
        {
            if (Contain(key))
            {
                throw new Exception("Add failed.Key was exist");
            }
            Node current = dummyHead;
            while (current.next!=null)
            {
                current = current.next;
            }
            current.next = new Node(key,value);
            size++;
        }

        public bool Contain(K key)
        {
            Node current = dummyHead.next;
            while (current!=null)
            {
                if (current.key.Equals( key))
                {
                    return true;
                }
                current = current.next;
            }

            return false;
        }

        private Node GetNode(K key)
        {
            Node current = dummyHead.next;
            while (current != null)
            {
                if (current.key.Equals(key))
                {
                    return current;
                }
                current = current.next;
            }

            throw new KeyNotFoundException("Key was not found in map.");
        }

        public V Get(K key)
        {
            return GetNode(key).value;
        }

        public int GetSize()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public V Remove(K key)
        {
            Node preNode = dummyHead;
            while (preNode.next != null)
            {
                if (preNode.next.key.Equals(key))
                {
                    Node node = preNode.next;
                    preNode.next = node.next;
                    node.next = null;
                    size--;
                    return node.value;
                }
                preNode = preNode.next;
            }

            return default(V);
        }

        public void Set(K key, V value)
        {
            GetNode(key).value = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node current = dummyHead.next;
            while (current!=null)
            {
                sb.Append(current+"-->\n");
                current = current.next;
            }
            sb.Append("NULL");

            return sb.ToString();
        }


    }
}
