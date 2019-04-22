using System;

namespace UnionFind
{
    class Program
    {
        static void Main(string[] args)
        {
            GetT(()=> {
                Test(new UnionFind1(50000));
            });
            GetT(() => {
                Test(new UnionFind2(50000));
            });
            GetT(() => {
                Test(new UnionFind3(50000));
            });
            GetT(() => {
                Test(new UnionFind4(50000));
            });

            GetT(() => {
                Test(new UnionFind5(50000));
            });
        }


        public static double GetT(System.Action ac)
        {
            long currentTicks = DateTime.Now.Ticks;

            ac();

            double delta = (double)(DateTime.Now.Ticks - currentTicks) / 10000000;
            Console.WriteLine(delta);
            return delta;
        }

        public static void Test(UF uf)
        {
            int size = uf.Size;
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                int p = random.Next(0,size);
                int q = random.Next(0,size);
                uf.UnionElements(p, q);
            }

            for (int i = 0; i < size; i++)
            {
                int p = random.Next(0, size);
                int q = random.Next(0, size);
                uf.isConnected(p,q);
            }


        }
    }
}
