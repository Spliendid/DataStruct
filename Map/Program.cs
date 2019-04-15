using System;

namespace Map
{
    class Program
    {
        static void Main(string[] args)
        {
          

            

            int[] array = new int[] { 2, 5, 4, 8, 7, 3, 9, 1, 6 };

            BSTMap<int, char > map = new BSTMap<int, char>();

            for (int i = 0; i < 9; i++)
            {
                map.Add(array[i],(char)('a'+i));
            }



            //Console.WriteLine(map.GetSize());
            //Console.WriteLine(map.IsEmpty());
            //Console.WriteLine(map.Contain(2));

            //Console.WriteLine(map.Remove(0));
            //map.Set(1,'#');
            Console.WriteLine(map.Get(1));
            //Console.WriteLine(map);

            map.Remove(4);
            map.LevelOrder();
        }
    }
}
