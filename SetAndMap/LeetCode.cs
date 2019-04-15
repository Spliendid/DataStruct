using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Set
{
    public class Solution
    {
        public int UniqueMorseRepresentations(string[] words)
        {
            string[] strArray = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
            HashSet<string> set = new HashSet<string>();
            StringBuilder sb = new StringBuilder();
            for (int i=0;i<words.Length;i++)
            {
                for (int j=0; j<words[i].Length;j++)
                {
                    sb.Append(strArray[words[i][j]-'a']);
                }
                set.Add(sb.ToString());
                sb.Clear();
            }
            return set.Count;
        }


    }
    /*
     * https://leetcode-cn.com/problems/intersection-of-two-arrays/
     */
    public class Solution2
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            HashSet<int> hashSet = new HashSet<int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                hashSet.Add(nums1[i]);
            }
            List<int> list = new List<int>();
            
            for (int i = 0; i < nums2.Length; i++)
            {
                if (hashSet.Contains(nums2[i]))
                {
                    if (list.Contains(nums2[i]))
                    {
                        continue;
                    }
                    list.Add(nums2[i]);
                    hashSet.Remove(nums2[i]);
                }
            }
            return list.ToArray();
        }


    }

    /*
    * https://leetcode-cn.com/problems/intersection-of-two-arrays-ii/
    */
    public class Solution3
    {
        public static int[] Intersection(int[] nums1, int[] nums2)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                list.Add(nums1[i]);
            }
            List<int> list2 = new List<int>();

            for (int i = 0; i < nums2.Length; i++)
            {
                if (list.Contains(nums2[i]))
                {
                 
                    list2.Add(nums2[i]);
                    list.Remove(nums2[i]);
                }
            }
            return list2.ToArray();
        }


    }
}
