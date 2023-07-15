using System;

public class Utility
{
    public static T Max<T>(T item1, T item2) where T : IComparable
    {
        if(item1.CompareTo(item2)  >= 0)
        {
            return item1;
        }

        return item2;
    }
}

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Utility.Max(5, 6));
            Console.WriteLine(Utility.Max("Abc", "def"));
        }
    }
}