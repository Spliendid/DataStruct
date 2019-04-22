using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind
{
    interface UF
    {
       void UnionElements(int p, int q);
       bool isConnected(int p, int q);
       int Size { get; }
    }
}
