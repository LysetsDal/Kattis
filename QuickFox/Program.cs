using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;


// Opgave: https://open.kattis.com/problems/quickbrownfox
class Program
{
    public static void Main()
    {
        string pattern = @"^[a-z]+$";
        Regex regex = new Regex(pattern);

        int num = 0;
        if (!int.TryParse(Console.ReadLine(), out num)) { return; }

        for (int i = 0; i < num; i++)
        {
            Dictionary<char, bool> dict = Enumerable.Range('a', 26).ToDictionary(k => (char)k, v => false);

            var input = Console.ReadLine();
            var parsedInput = input ?? "";
            if (parsedInput == "") { return; }


            foreach (var c in parsedInput.ToLower())
            {
                if (regex.IsMatch(c.ToString())) { dict[c] = true; }
            }

            if (!dict.Values.Contains(false))
            {
                Console.WriteLine("pangram");
                dict.Clear();
                continue;
            }

            var strb = new StringBuilder();

            foreach (var item in dict)
            {
                if (item.Value == false) { strb.Append(item.Key); }
            }

            Console.WriteLine("missing " + strb.ToString().Trim());
            dict.Clear();
        }
    }
}