using System;
using System.Collections.Generic;
using System.Collections;
namespace C_SharpDataStructTypeStudy
{
    class Program
    {
        static void Main(string[] args)
        {
             
            int[] array = new int[] { };
            Array a = array;
            List<int> list = new List<int>();
            //List<object> olist =;
            Action<Player> ac = new Action<Player>(aa);
            Console.WriteLine(a);
            //Queue<int>
            //Dictionary<int ,int >
        }

        static void aa(object p)
        {
        }
    }
    class Player { }

    class Man :Player{ }
}
