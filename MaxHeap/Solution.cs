using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace MaxHeap
{
    public class Solution
    {
        private class nf{
            public int number;
            public int frequence;
            public nf(int n,int f)
            {
                number = n;
                frequence = f;
            }
        }
        public IList<int> TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int key = nums[i];
                if (dic.ContainsKey(key))
                {
                    dic[key]++;
                }
                else
                {
                    dic.Add(key,1);
                }
            }

            List<nf> list = new List<nf>();
            foreach (KeyValuePair<int,int>kv in dic)
            {
                list.Add(new nf(kv.Key,kv.Value));
            }
            list.Sort((a,b)=>a.frequence.CompareTo(b.frequence));
            int[] _array = new int[k];
            for (int i = 0; i < k; i++)
            {
                _array[i] = list[i].number;
            }
            return _array;
        }
    }
}
