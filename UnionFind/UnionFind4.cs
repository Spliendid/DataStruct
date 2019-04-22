using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind
{
    class UnionFind4 : UF
    {
        private int[] id;
        private int[] rank;

        public UnionFind4(int size)
        {
            id = new int[size];
            rank = new int[size];
            for (int i = 0; i < id.Length; i++)
            {
                rank[i] = 1;
                id[i] = i;
            }

        }

        public int Size => id.Length;

        public int Find(int i)
        {
            if (i < 0 || i >= id.Length)
            {
                throw new Exception("I is out of index");
            }

            int parent = id[i];
            while (parent != id[parent])
            {
                id[parent] = id[id[parent]];//路径压缩
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
            if (rp != rq)
            {
                if (rank[rp] < rank[rq])
                {
                    id[rp] = rq;
                  //  rank[rq] += rank[rp];
                }
                else if (rank[rp] >rank[rq])
                {
                    id[rq] = rp;
                    //rank[rp] += rank[rq];
                }
                else
                {
                    id[rq] = rp;
                    rank[rp] += 1;
                }
                
             
            }
        }
    }
}
