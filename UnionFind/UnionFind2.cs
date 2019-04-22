using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind
{
    class UnionFind2 : UF
    {
        private int[] id;

        public UnionFind2(int size)
        {
            id = new int[size];

            for (int i = 0; i < id.Length; i++)
            {
                id[i] = i;
            }

        }

        public int Size => id.Length;

        public int Find(int i)
        {
            if (i<0||i>= id.Length)
            {
                throw new Exception("I is out of index");
            }

            int parent = id[i];
            while (parent!=id[parent])
            {
                parent = id[parent];
            }

            return parent;

        }

        public bool isConnected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        public void UnionElements(int p, int q)
        {
            int rp = Find(p);
            int rq = Find(q);
            if (rp!=rq)
            {
                id[rp] = rq;
            }
        }
    }
}
