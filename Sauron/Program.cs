using System;

// Opgave: 
// https://open.kattis.com/problems/eyeofsauron 
class Program
{
    public static void Main()
    {
        string input;

        while ((input = Console.ReadLine()) != null)
        {
            int count = 0;
            bool flag = false;

            if (input != null)
            {
                foreach (char c in input)
                {
                    if (c == ')') { flag = true; }

                    if (c == '|' && flag == false)
                    {
                        count++;
                    }
                    if (c == '|' && flag == true)
                    {
                        count--;
                    }
                }
            }

            if (count == 0)
            {
                Console.WriteLine("correct");
                return;
            }
            else
            {
                Console.WriteLine("fix");
                return;
            }
        }
    }
}

 