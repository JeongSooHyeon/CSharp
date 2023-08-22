using System;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Machine cl = new Machine();

        // 이전 : 반드시 매개변수명 나열
        cl.Run((string name, int time) => { return 0; });
        cl.Run((arg1, arg2) => { return 0; });

        // 9.0부터 사용하지 않는 매개변수 이름 생략 가능
        cl.Run((string _, int _) => { return 0; });
        cl.Run((_, _) => 5);
        cl.Run(delegate (string _, int _) { return 0; });

    }
}

public delegate int RunDelegate(string name, int time);

public class Machine
{
    void M(int _)
    {

    }

public void Run(RunDelegate runnable)
    {
        Console.WriteLine(runnable(nameof(Machine), 1));
    }
}
