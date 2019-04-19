using System;
using System.Collections.Generic;
using System.Text;

namespace SegmentTree
{
    interface Merger<T>
    {
        T Merger(T t1,T t2);
    }

}
