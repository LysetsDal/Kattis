using System;
using System.Collections.Generic;
using System.Linq;

// https://open.kattis.com/problems/gandalfsspell

class Program
{
    public static void Main()
    {
        var mapping = new Dictionary<char, string>();

        string charters = Console.ReadLine();
        string spell = Console.ReadLine();

        string parsedCharters = charters ?? "";
        if (parsedCharters == "") { return; }

        string parsedWords = spell ?? "";
        if (parsedWords == "") { return; }


        char[] chars = parsedCharters.ToCharArray();
        string[] words = parsedWords.Trim().Split(" ");

        if (chars.Length != words.Length)
        {
            Console.WriteLine("False");
            return;
        }

        for (int i = 0; i < chars.Length; i++)
        {
            char key = chars[i];
            string word = words[i];

            if (mapping.ContainsKey(key) && mapping[key] != word)
            {
                Console.WriteLine("False");
                return;
            }

            mapping[key] = word;
        }

        if (!(mapping.Values.Distinct().Count() == mapping.Keys.Distinct().Count()))
        {
            Console.WriteLine("False");
            return;
        }

        Console.WriteLine("True");
        return;
    }
}
