using System;

// Opg.: https://open.kattis.com/problems/aaah 
public class Aaah
{
    static void Main()
    {
        string[] input = new string[2];

        for (int i = 0; i < 2; i++)
        {
            string temp = Console.ReadLine();
            if (temp != null)
            {
                input[i] = temp;
            }
        }

        string result = string.Empty;

        if (input[0].Length == 0 || input[1].Length == 0)
        {
            result = "no";
        }
        else if (input[0].Length >= input[1].Length)
        {
            result = "go";
        }
        else
        {
            result = "no";
        }
        Console.WriteLine(result);
    }
}
