using System;
using System.Collections.Generic;
using System.Linq;

// https://open.kattis.com/problems/mia

class Program
{
    public static void Main()
    {
        string p1Won = "Player 1 wins.";
        string p2Won = "Player 2 wins.";
        bool end = false;

        while (!end)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) { return; }

            char[] diceRolls = input.Trim().ToCharArray();
            diceRolls = diceRolls.Where(c => !Char.IsWhiteSpace(c)).ToArray();

            if (diceRolls.Length != 4) { return; }

            var hand1 = highestNumerical(diceRolls[0], diceRolls[1]);
            var hand2 = highestNumerical(diceRolls[2], diceRolls[3]);

            if (hand1 == 0 || hand2 == 0) { end = true; return; }
            if (hand1 == hand2) { Console.WriteLine("Tie."); continue; }
            else if (hand1 == 21)
            {
                Console.WriteLine(p1Won);
                continue;
            }
            else if (hand2 == 21)
            {
                Console.WriteLine(p2Won);
                continue;
            }
            else if (isDoubles(hand1) && isDoubles(hand2))
            {
                if (hand1 > hand2) { Console.WriteLine(p1Won); }
                if (hand1 < hand2) { Console.WriteLine(p2Won); }
                continue;
            }
            else if (isDoubles(hand1) ^ isDoubles(hand2))
            {
                if (isDoubles(hand1)) { Console.WriteLine(p1Won); }
                if (isDoubles(hand2)) { Console.WriteLine(p2Won); }
                continue;
            }
            else if (hand1 > hand2)
            {
                Console.WriteLine(p1Won);
            }
            else
            {
                Console.WriteLine(p2Won);
            }
        }
    }

    public static int highestNumerical(char a, char b)
    {
        int optionA = 0;
        Int32.TryParse(String.Concat(a, b), out optionA);
        int optionB = 0;
        Int32.TryParse(String.Concat(b, a), out optionB);
        if (optionA == optionB) { return optionA; }
        return optionA < optionB ? optionB : optionA;
    }

    public static bool isDoubles(int num)
    {
        var tmp = num.ToString();
        if (tmp.Length < 2) { return false; }
        return tmp[0] == tmp[1];
    }
}