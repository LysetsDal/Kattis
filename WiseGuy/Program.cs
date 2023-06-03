using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace WiseGuy;
// Opg.: 
// https://open.kattis.com/problems/wiseguy 
class Program
{
    public static void Main()
    {

        var tree = new BinaryTree();

        int[] vals = { 3, 5, 6, 7, 8, 9, 11 };

        for (int i = 0; i < vals.Length; i++)
        {
            var val = vals[i];
            tree.Put(val);
            Console.WriteLine($"Added: {val}");
            i++;
        }

        tree.PrintTree();
    }

}
