using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;


// Opgave: https://open.kattis.com/problems/mult
class Program
{
    public static void Main()
    {

        int count = 0;
        if (!int.TryParse(Console.ReadLine(), out count)) { return; }
        int[] input = new int[count];

        for (int i = 0; i < count; i++)
        {
            if (int.TryParse(Console.ReadLine(), out input[i])) { }
        }


        int mult = 0;
        bool flag = false;

        for (int i = 0; i < input.Length; i++)
        {
            if (i == 0) { mult = input[i]; continue; }
            if (flag == true) { mult = input[i]; flag = false; continue;}

            int tmp = input[i];

            if (tmp % mult == 0)
            {
                Console.WriteLine(tmp);
                flag = true;
                continue;
            }

        }
    }
}