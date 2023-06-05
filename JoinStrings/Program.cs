using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

// https://open.kattis.com/problems/joinstrings
// works on the test cases i have made my self.
// gets a compile error on Kattis :(

#nullable enable

class Program
{
    public static void Main()
    {
        // Stream reader because of extensive input files.
        var stream = Console.OpenStandardInput();
        var bufferedStream = new BufferedStream(stream);
        var reader = new StreamReader(bufferedStream);

        var num = int.TryParse(reader.ReadLine(), out var x) ? x : 0;
        // if (num < 1 || num > 100000) { return; }

        var words = new Index[num];

        for (int i = 0; i < num; i++)
        {
            var temp = reader.ReadLine();
            String word = temp ?? "";
            if (word == "") { return; }
            words[i] = new Index(word);
        }

        Index current;
        Index next;
        int[] arr = new int[2];
        for (int i = 0; i < num - 1; i++)
        {
            var temp = reader.ReadLine();
            string cmd = temp ?? "";
            if (cmd == "") { return; }
            var test = cmd.Split(" ", 2);

            // (parse - 1) to transpose for 0-indexed arr
            arr[0] = int.TryParse(test[0], out var s) ? s : 0;
            arr[1] = int.TryParse(test[1], out var t) ? t : 0; 

            current = words[arr[0] - 1];
            next = words[arr[1] - 1];

            // A way to check it the word is not the first word in the sequence.
            // if its not the first, link with the next.
            if (current.before != null) { current.before.after = next; }

            // if current is first in sequence, after is set to the next.
            current.after = (current.before == null)
            ? next
            : current.after;

            // If next has non-null reference, it means next is not the last word
            // in the seq. current.before set to next.
            current.before = (next.after != null)
            ? next.before
            : next;

        }

        var result = new StringBuilder();

        for (current = words[arr[0] - 1]; current != null; current = current.after!)
        {

            result.Append(current.word);
        }

        Console.WriteLine(result.ToString().Trim());

    }

    // Custom linked-list implementation.
    public record Index
    {
        public Index? before { get; set; }
        public Index? after { get; set; }
        public string word { get; set; } = "";

        public Index(Index _before, Index _after)
        {
            word = string.Empty;
            before = _before;
            after = _after;
        }
        // Overloaded constructor.
        public Index(string _word)
        {
            word = _word ?? throw new ArgumentNullException(nameof(_word));

        }
    }
}