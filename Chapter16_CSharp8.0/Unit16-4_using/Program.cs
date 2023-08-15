using System;

class Program
{
    static void Main(string[] args)
    {
        using(var file = new System.IO.StreamReader("test.txt"))
        {
            string txt = file.ReadToEnd();
            Console.WriteLine(txt);
        }
    }

    static void Main1(string[] args)
    {
        using var file = new System.IO.StreamReader("test.txt");

        string txt = file.ReadToEnd();
        Console.WriteLine(txt);
    }

    static void Main2(string[] args)
    {
        if(args.Length == 0)
        {
            using var file = new System.IO.StreamReader("test.txt");

            string txt = file.ReadToEnd();
            Console.WriteLine(txt);
        }
    }
}