using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind
{
    /// <summary>
    /// 快速查找并查集 
    /// </summary>
    class UnionFind1 : UF
    {
        private int[] id;

        public UnionFind1(int size)
        {
            id = new int[size];
            for (int i = 0; i < id.Length; i++)
            {
                id[i] = i;
            }
        }

        public int Size => id.Length;

        private int Find(int p)
        {
            if (p>= id.Length || p<0)
            {
                throw new Exception("P is illegal.");
            }
            return id[p];
        }

        public bool isConnected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        public void UnionElements(int p, int q)
        {
            int i = id[p];
            int j = id[q];
            if (i == j)
            {
                return;
            }
            else {
                for (int k = 0; k < id.Length; k++)
                {
                    if (id[k] == i)
                    {
                        id[k] = j;
                    }
                }
            }

        }
    }
}
