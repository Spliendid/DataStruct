using System;
using System.Collections.Generic;
namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            //int a = -24;
            //string b = "24";
            //A aa = new A(24, 12, 1);
            //float f = 3.14f;
            //Console.WriteLine(a.GetHashCode());
            //Console.WriteLine(b.GetHashCode());
            //Console.WriteLine(aa.GetHashCode());
            //Console.WriteLine(f.GetHashCode());

            HashSet<A> ahs = new HashSet<A>();
            A a = new A(1, 2, 3);
            A b = new A(3,2,1);
            ahs.Add(a);
            ahs.Add(b);
            ahs.Add(a);
            Console.WriteLine(ahs.Contains(a));
            Console.WriteLine(ahs.Count);

        }
    }

    class A
    {
        public int id;
        public int old;
        public int score;
        public A(int id,int old,int s)
        {
            this.id = id;
            this.old = old;
            this.score = s;
        }

        public override int GetHashCode()
        {
            int B = 2;
            int hash = 0;
            hash = B *hash+ id;
            hash = B * hash + old;
            hash = B * hash + Math.Abs(score);
            return hash;
        }
    }
}
