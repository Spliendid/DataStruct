using System;
using System.Collections.Generic;
using System.Text;

namespace StackAndQueue
{
    class LinkedQueue<E>:QueueInterface<E>
    {
        /// <summary>
        /// 节点类
        /// </summary>
        private class Node
        {
            public E e;
            public Node next;

            public Node(E e, Node next)
            {
                this.e = e;
                this.next = next;
            }

            public Node(E e)
            {
                this.e = e;
                this.next = null;
            }

            public Node()
            {

            }

            public override string ToString()
            {
                return e.ToString();
            }
        }

        private Node head, tail;

        private int size;

        public LinkedQueue()
        {
            head =tail = null;
            size = 0;
        }

        public E Dequeue()
        {
            if (IsEmpty())
            {
                throw new NullReferenceException("Dequeue failed. Queue is empty.");
            }

            Node node = head;
            head = head.next;
            node.next = null;
            if (head == null)
            {
                tail = null;
            }
            size--;
            return node.e;
        }

        //排队，在队位加入
        public void Enqueue(E e)
        {
            if (tail!=null)
            {
                tail.next = new Node(e);
                tail = tail.next;
            }
            else
            {
                tail = new Node(e);
                head = tail;
            }

            size++;
        }

        public E GetFront()
        {
            if (IsEmpty())
            {
                throw new NullReferenceException("GetFront failed. Queue is empty.");
            }
            return head.e;
        }

        public int GetSize()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public String ToString()
        {

            StringBuilder res = new StringBuilder();
            res.Append("LinkedQueue Front[");
            Node cur = head;
            while (cur!=null)
            {
                res.Append(cur.e+",");
                cur = cur.next;
            }
            res.Append("]Tail");
            return res.ToString();
        }


    }
}
