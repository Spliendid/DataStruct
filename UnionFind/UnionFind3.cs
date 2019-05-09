using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind
{
    /// <summary>
    /// Size优化，快速查找并查集
    /// 融合：把两个节点中连接少的那个遍历赋值
    /// </summary>
    class UnionFind3 : UF
    {
        private int[] id;
        private int[] sz;//该节点下，节点的个数
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
