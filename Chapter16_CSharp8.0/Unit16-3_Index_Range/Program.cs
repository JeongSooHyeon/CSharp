using System;

class Program
{
    static void Main(string[] args)
    {
        string txt = "this";

        Console.WriteLine(txt[^1]);
        Console.WriteLine(txt[^2]);
        Console.WriteLine(txt[^3]);

        int i = 4;
        System.Index firstWord = ^i;
        Console.WriteLine(txt[firstWord]);

        System.Index firstWord1 = new Index(0, false);  // 두 번째 인자의 의미 : fromEnd
        Console.WriteLine(txt[firstWord1]);

        System.Range full = 0..^0;  // == Range.All()
        string copy = txt[full];
        Console.WriteLine(copy);

        string copy1 = txt[..];  // 기본값 범위 == 0..^0
        Console.WriteLine(copy1);
        Console.WriteLine(txt[..2]);
        Console.WriteLine(txt[1..]);


        string txt1 = "(this)";
        PrintText(txt1);
    }

    private static void PrintText(string txt)
    {
        if (txt.Length >= 2 && txt[0] == '(' && txt[txt.Length-1]== ')')
        {
            txt = txt.Substring(1, txt.Length - 2);
        }

        Console.WriteLine(txt);
    }

    private static void PrintText1(string txt)
    {
        if(txt.Length>=2 && txt[0] == '(' && txt[^1] == ')')
        {
            txt = txt[1..^1];
            // txt = txt[Range.Create(new Index(1, false), new Index(1, true))];
        }

        Console.WriteLine(txt);
    }
}