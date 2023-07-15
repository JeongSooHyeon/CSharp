using System;

class Program
{
    static void Main(string[] args)
    {
        Action<string> logOut =
             (txt) =>
             {
                 Console.WriteLine(DateTime.Now + " : " + txt);
             };

        logOut("This is my world");

        Func<double> pi = () => 3.141592;

        Func<int, int, int> myFunc = (a, b) => a + b;

        Console.WriteLine(pi());
    }
}