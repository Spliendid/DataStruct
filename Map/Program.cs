using System;

namespace Map
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListMap<int, char > map = new LinkedListMap<int, char>();

            for (int i = 0; i < 10; i++)
            {
                map.Add(i,(char)('a'+i));
            }



            //Console.WriteLine(map.GetSize());
            //Console.WriteLine(map.IsEmpty());
            //Console.WriteLine(map.Contain(2));

            Console.WriteLine(map.Remove(0));
            map.Set(1,'#');
            Console.WriteLine(map.Get(1));
            Console.WriteLine(map);
        }
    }
}
