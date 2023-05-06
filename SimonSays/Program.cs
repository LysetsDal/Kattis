using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

// Opgave: 
// https://open.kattis.com/problems/simonsays 
class Program
{
    public static void Main()
    {
        string simon = "Simon";
        StringBuilder strb = new StringBuilder();

        var output = new List<string>();

        int num = 0;
        if (!int.TryParse(Console.ReadLine(), out num))
        {
            Console.WriteLine("Entered null check");
            return;
        }

        for (int i = 0; i < num; i++)
        {
            var input = Console.ReadLine();
            if (input == null) { continue; }

            List<string> list = input.Trim().Split(" ").ToList();

            if (list.Count < 3) { continue; }

            // If not 'simon says' exit.
            if (!(list.FirstOrDefault() == simon))
            {
                continue;
            }
            // They fucked us without this:
            if (!(list[1] == "says")) { continue; }

            var subList = list
                .Where((word, index) => index > 1 && index <= list.Count)
                .ToList();

            subList.ForEach(word => strb.Append(word + " "));

            output.Add(strb.ToString().Trim());
            strb.Clear();
        }
        // Console.WriteLine("==== Output: ====");

        foreach (var command in output)
        {
            Console.WriteLine(command);
        }
    }
}