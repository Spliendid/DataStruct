using System;
namespace Trie
{
    class Program
    {
        static void Main(string[] args)
        {

            Trie trie = new Trie();
            string[] words = {"Hello","We","Are","Family" ,"Father"};
            for (int i = 0; i < words.Length; i++)
            {
                trie.Add(words[i]);
            }
            Console.WriteLine(trie.Contains("Are"));
            Console.WriteLine(trie.Contains("Fam"));
            Console.WriteLine(trie.IsPrefix("Fa"));
        }
    }
}
