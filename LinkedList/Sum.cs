using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    class Sum
    {
        public static int ArraySum(int[] array)
        {
            if (array.Length == 0)
            {
                return 0;
            }
            int[] carray = new int[array.Length-1];
            Array.Copy(array,1, carray,0,carray.Length);
            return array[0] + ArraySum(carray);

        }
    }
}
