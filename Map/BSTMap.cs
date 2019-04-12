using System;
using System.Collections.Generic;
using System.Text;

namespace Map
{
    class BSTMap<K, V> : MapInterface<K, V> where K:IComparable<K>
    {
        public void Add(K key, V value)
        {
            throw new NotImplementedException();
        }

        public bool Contain(K key)
        {
            throw new NotImplementedException();
        }

        public V Get(K key)
        {
            throw new NotImplementedException();
        }

        public int GetSize()
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public V Remove(K key)
        {
            throw new NotImplementedException();
        }

        public void Set(K key, V value)
        {
            throw new NotImplementedException();
        }
    }
}
