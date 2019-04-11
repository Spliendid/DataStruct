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
}
