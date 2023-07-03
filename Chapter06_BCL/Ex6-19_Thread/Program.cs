using System;
using System.Threading;
class Program
{
    static void Main(string[] args)
    {
        Thread t = new Thread(threadFunc);
        // t.IsBackground = true;
        t.Start();
    }
    static void threadFunc()
    {
        Console.WriteLine("threadFunc run!");
    }
}

