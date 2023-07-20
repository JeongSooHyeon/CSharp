using System;

public class IntResult
{
    public bool Parsed { get; set; }
    public int Number { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Program pg = new Program();
        IntResult result = pg.ParseInteger("15");

        dynamic result1 = ParseInteger1("20");

        Console.WriteLine(result1.Parsed);
        Console.WriteLine(result1.Number);
    }

    static dynamic ParseInteger1(string text)
    {
        int number = 0;

        try
        {
            number = Int32.Parse(text);
            return new { Number = number, Parsed = true };
        }
        catch
        {
            return new { Number = number, Parsed = false };
        }
    }


    IntResult ParseInteger(string text)
    {
        IntResult result = new IntResult();

        try
        {
            result.Number = Int32.Parse(text);
            result.Parsed = true;
        }
        catch
        {
            result.Parsed = false;
        }

        return result;
    }
}