using System;
using System.Collections.Generic;
using System.Text;

namespace Trie.Leetcode
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace Trie
    {
        public class Trie
        {
            private class Node
            {
                public bool isWord;
                public Dictionary<char, Node> next;

                public Node(bool isword)
                {
                    this.isWord = isword;
                    next = new Dictionary<char, Node>();
                }

                public Node()
                {
                    this.isWord = false;
                    next = new Dictionary<char, Node>();
                }

            }

            private Node root;

            //字典中存储单词的个数
            private int size;
            public int Size { get { return size; } }

            public Trie()
            {
                root = new Node();
                size = 0;
            }

            //递归写法
            private Node Add(int index, string word, Node node)
            {


                if (index == word.Length - 1)
                {
                    if (!node.isWord)
                    {
                        size++;
                    }
                }

                char c = word[index];

                if (node == null)
                {
                    node = new Node();
                }

                if (!node.next.ContainsKey(c))
                {
                    node.next.Add(c, Add(++index, word, null));
                }
                else
                {
                    Add(c, word, node.next[c]);
                }

                return node;
            }

            public void Insert(string word)
            {
                Node cur = root;
                for (int i = 0; i < word.Length; i++)
                {
                    char c = word[i];

                    if (!cur.next.ContainsKey(c))
                        cur.next.Add(c, new Node());

                    cur = cur.next[c];
                }

                if (!cur.isWord)
                {
                    cur.isWord = true;
                    size++;
                }
            }

            public bool Search(string word)
            {
                Node cur = root;
                for (int i = 0; i < word.Length; i++)
                {
                    char c = word[i];
                    if (!cur.next.ContainsKey(c))
                    {
                        return false;
                    }
                    cur = cur.next[c];
                }
                return cur.isWord;
            }

            public bool StartsWith(string prefix)
            {
                Node cur = root;

                for (int i = 0; i < prefix.Length; i++)
                {
                    char c = prefix[i];
                    if (!cur.next.ContainsKey(c))
                    {
                        return false;
                    }
                    cur = cur.next[c];
                }

                return true;

            }
        }
    }

}
