using System;
using System.Collections.Generic;
using System.Text;

namespace SetAndMap
{
    interface SetInterface<T>
    {
        void Add(T t);
        void Remove(T t);
        bool Contains(T t);
        int GetSize();
        bool isEmpty();
    }
}
