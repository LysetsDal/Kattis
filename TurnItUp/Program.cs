using System;
// Opgave: 
// https://open.kattis.com/problems/skruop 
class Program
{
    public static void Main()
    {
        int volume = 7;
        int num;

        if (int.TryParse(Console.ReadLine(), out num))
        {
            for (int i = 0; i < num; i++)
            {
                string command = Console.ReadLine().ToLower();
                if (command == "skru op!" && volume < 10) { volume++; }
                if (command == "skru ned!" && volume > 0) { volume--; }
            }
            Console.WriteLine(volume);
        }
    }
}