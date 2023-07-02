using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string txt = "Hello, World! Welcome to my world!";

        Regex regex = new Regex("world", RegexOptions.IgnoreCase);
        string result = regex.Replace(txt, funcMatch);

        Console.WriteLine(result);
    }

    static string funcMatch(Match match)
    {
        return "Universe";
    }
}