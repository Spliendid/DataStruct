﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind
{
    class UnionFind3 : UF
    {
        private int[] id;
        private int[] sz;
        public UnionFind3(int size)
        {
            id = new int[size];
            sz = new int[size];
            for (int i = 0; i < id.Length; i++)
            {
                id[i] = i;
                sz[i] = 1;
            }
        }

        public int Size => id.Length;

        private int Find(int p)
        {
            if (p >= id.Length || p < 0)
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
            else
            {
                if (sz[i]>sz[j])
                {
                    for (int k = 0; k < id.Length; k++)
                    {
                        if (id[k] == j)
                        {
                            id[k] = i;
                        }
                    }
                    sz[i] += sz[j];

                }
                else
                {
                    for (int k = 0; k < id.Length; k++)
                    {
                        if (id[k] == i)
                        {
                            id[k] = j;
                        }
                    }
                    sz[j] += sz[i];

                }

            }

        }
    }
}
