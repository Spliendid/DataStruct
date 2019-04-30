using System;
using System.Collections.Generic;
using System.Text;
using Map;
namespace HashTable
{
    class HashTable<K,V> where K : IComparable<K>
    {
      private  int M;
      private  int Size { get { return size; } }
      private  int size;
      private  BSTMap<K, V>[] hashtable;
      private static int UpperTol = 10;
      private static int LowerTol = 2;
      private static int Capacity = 2;
        //调用自身含参构造函数
        public HashTable():this(Capacity)
        {

        }
       
        public HashTable(int m)
        {
            this.M = m;
            size = 0;
            hashtable = new BSTMap<K, V>[M];

            for (int i = 0; i < m; i++)
            {
                hashtable[i] = new BSTMap<K, V>();
            }
        }

        //获取Hash值
        private int Hash(K k)
        {
            return (k.GetHashCode() & 0x7FFFFFFF)%M;
        }

        #region Add

        public void Add(K k,V v)
        {
            BSTMap<K, V> map =hashtable[Hash(k)];

            if (map.Contain(k))
            {
                map.Add(k,v);
            }
            else
            {
                map.Add(k, v);
                size++;
                if (size>UpperTol*M)
                {
                    Resize(2*M);
                }
            }

        }

        #endregion

        #region Remove

        public V Remove(K k)
        {
            BSTMap<K, V> map = hashtable[Hash(k)];

            V v = default(V);
            if (map.Contain(k))
            {
                v = map.Get(k);
                map.Remove(k);
                size--;
                if (size<LowerTol*M)
                {
                    Resize(M/2);
                }
            }

            return v;
        }

        #endregion

        #region Get

        public V Get(K k)
        {
            return hashtable[Hash(k)].Get(k );

        }

        #endregion

        private void Resize(int size)
        {
            BSTMap<K, V>[] old = hashtable;
            BSTMap<K, V>[] newMap = new BSTMap<K, V>[size];

            M = size;

            for (int i = 0; i < size; i++)
            {
                newMap[i] = new BSTMap<K, V>();
            }

            for (int i = 0; i < old.Length; i++)
            {
               //TODO
            }


        }
    }
}
