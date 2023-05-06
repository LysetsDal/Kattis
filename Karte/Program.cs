using static System.Console;
using System.Text;

namespace MyApp;

class Program
{
    static int P = 13;
    static int K = 13;
    static int H = 13;
    static int T = 13;
    static List<string> array = new();

    // static IList<string> array;

    public static void Main(string[] args)
    {

        var input = ReadLine();
        string str = string.Empty;
        if (input is not null)
        {
            str = input;
        }

        int count = default;

        var sb = new StringBuilder();

        foreach (char c in str)
        {
            WriteLine(c);
            if (count == 3)
            {
                array.Add(sb.ToString());
                sb.Clear();
            }
            sb.Append(c);
            count++;
        }

        foreach (string s in array)
        {
            WriteLine(s);
        }

        // WriteLine($"P = {P}");
        // WriteLine($"K = {K}");
        // WriteLine($"H = {H}");
        // WriteLine($"T = {T}");




        static void DecrementCardStack(char c)
        {
            if (c == 'P') { P--; }
            else if (c == 'K') { K--; }
            else if (c == 'H') { H--; }
            else { T--; }
        }




    }
}