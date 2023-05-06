using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace Kattis.Reverse
{
    class Reverse
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            int n;

            Int32.TryParse(input, out n);

            var list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                var temp = Console.ReadLine();
                int val;
                if (Int32.TryParse(temp, out val))
                {
                    list.Add(val);
                }
            }
            list.Reverse();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}