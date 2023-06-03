using System;
using System.Linq;

// https://open.kattis.com/problems/bits 

class Program
{
    public static void Main()
    {
        uint testCases = 0;
        if (!uint.TryParse(Console.ReadLine(), out testCases))
        {
            return;
        }


        for (int i = 0; i < testCases; i++)
        {
            uint num = 0;
            if (!uint.TryParse(Console.ReadLine(), out num))
            {
                return;
            }
            if (num < 0u) { Console.WriteLine(0u); } // Negative
            string intBin = Convert.ToString(num, 2);
            if (intBin == String.Empty) { Console.WriteLine(0u); } // Bad input


            uint oneCount = 0;
            foreach (char c in intBin)
            {
                if (c == '1') { oneCount++; }
            }

            Console.WriteLine(oneCount);
        }

    }

}