using System;
using System.Collections.Generic;
using System.Text;

namespace Map
{
    interface MapInterface<K,V>
    {
        void Add(K key, V value);
        V Remove(K key);
        void Set(K key, V value);
        V Get(K key);
        bool Contain(K key);
        int GetSize();
        bool IsEmpty();
    }
}
