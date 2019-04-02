using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public ListNode RemoveElements(ListNode head, int val)
        {
            ListNode header = new ListNode(-1);
            header.next = head;
            ListNode cur = header;

            while (cur.next!=null)
            {
                if (cur.next.val ==val)
                {
                    cur.next = cur.next.next;
                }
                else
                {
                    cur = cur.next;
                }
            }
            return header.next;
        }
    }

    class Solution4
    {

        public ListNode removeElements(ListNode head, int val)
        {

            if (head == null)
                return head;

            ListNode res = removeElements(head.next, val);
            if (head.val == val)
                return res;
            else
            {
                head.next = res;
                return head;
            }
        }

      
    }
}