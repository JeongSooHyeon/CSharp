using System;

class Program
{
    delegate int MyAdd(int a, int b);

    static void Main(string[] args)
    {
        MyAdd myFunc = (a, b) => a + b;

        Console.WriteLine("10 + 2 == " + myFunc(10, 2));
    }
}