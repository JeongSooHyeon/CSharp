using System;
using System.Threading;

Thread thread = Thread.CurrentThread;
Console.WriteLine(thread.ThreadState);

Console.WriteLine(DateTime.Now);
Thread.Sleep(1000);
Console.WriteLine(DateTime.Now);
