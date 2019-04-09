using System;
using System.Text;
namespace LinkedList
{
    public class LinkedList<E>
    {
        /// <summary>
        /// 节点类
        /// </summary>
        private class Node
        {
            public E e;
            public Node next;

            public Node(E e,Node next)
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

        //虚拟头结点
        private Node dummyHead;

        private int size;

        public LinkedList()
        {
            dummyHead = new Node();
            size = 0;
        }

        public int GetSize()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        #region Add


        //在index处添加一个新元素e
        //真正使用链表时很少用
        public void Add(int index,E e)
        {
           
            if (index<0|| index>size)
            {
                throw new IndexOutOfRangeException("Add Failed.Illegal index");
            }

          

            Node preNode = dummyHead;
            for (int i = 0; i < index; i++)
            {
                preNode = preNode.next;
            }
            //Node _node= new Node(e);
            //_node.next = preNode.next;
            //preNode.next = _node;
            preNode.next = new Node(e, preNode.next);
            size++;
        }

        public void AddFirst(E e)
        {
            Add(0,e);
        }
        public void AddLast(E e)
        {
            Add(size,e);
        }

        #endregion

        #region Get

        public E Get(int index)
        {
            if (index <0 || index >=size)
            {
                throw new IndexOutOfRangeException("Get failed. Illegal index.");
            }

            Node node = dummyHead;
            for (int i = 0; i <= index; i++)
            {
                node = node.next;
            }

            return node.e;
        }

        public E GetFirst()
        {
            return Get(0);
        }

        public E GetLast()
        {
            return Get(size -1);
        }

        #endregion

        #region Set

        public void Set(int index,E e)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Set failed. Illegal index.");
            }

            Node node = dummyHead.next;

            for (int i = 0; i < index; i++)
            {
                node = node.next;
            }

            node.e = e;
        }

        public bool Contains(E e)
        {
            Node cur = dummyHead.next;
            //for (int i = 0; i < size; i++)
            //{
            //    cur = cur.next;
            //    if (cur.e.Equals(e))
            //    {
            //        return true;
            //    }
            //}

            while (cur!=null)
            {
                if (cur.e.Equals(e))
                        return true;
                cur = cur.next;
            }

            return false;
        }

     
        #endregion

        #region Remove

        public E Remove(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Set failed. Illegal index.");
            }

            Node pre = dummyHead;
            for (int i = 0; i < index; i++)
            {
                pre = pre.next;
            }
            Node node = pre.next;
            pre.next = node.next;
            node.next = null;
            size--;
            return node.e;
        }

        public void RemoveElement(E e)
        {
            Node pre = dummyHead;
            while (pre.next!=null)
            { 
                if (pre.next.e.Equals(e))
                {
                    Node node = pre.next;
                    pre.next = pre.next.next;
                    node.next = null;
                    size--;
                    return;
                }
                else
                {
                    pre = pre.next;
                }
            }

        }

        public E RemoveFirst()
        {
            return Remove(0);
        }

        public E RemoveLast()
        {
            return Remove(size -1);
        }

        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node cur = dummyHead.next;
            while (cur != null)
            {
                sb.Append(cur.ToString() + "-->");
                cur = cur.next;
            }

            sb.Append("NULL");

            return sb.ToString();
        }
    }
}
