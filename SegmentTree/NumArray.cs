using System;
using System.Collections.Generic;
using System.Text;

namespace SegmentTree
{
    class NumArray
    {
        private int[] sums;
        public NumArray(int[] nums)
        {
            if (nums == null)
            {
                return;
            }
            sums = new int[nums.Length+1];
            sums[0] = 0;
            for (int i = 1; i <=nums.Length; i ++)
            {
                sums[i] = nums[i - 1] + sums[i-1];
            }
        }

        public int SumRange(int i, int j)
        {
            return sums[j+1] - sums[i];
        }
    }

    public class NumArray2
    {
        SegmentTree<int> tree;

        public NumArray2(int[] nums)
        {
            if (nums == nums)
            {
                return;
            }
            tree = new SegmentTree<int>(nums,(a,b)=>a+b);
        }

        public void Update(int i, int val)
        {
            tree.Set(i,val);
        }

        public int SumRange(int i, int j)
        {
            return tree.Query(i, j);
        }
    }

}
