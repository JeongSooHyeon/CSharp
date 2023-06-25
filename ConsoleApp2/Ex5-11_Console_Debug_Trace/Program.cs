using System;
using System.Diagnostics;
using System.Reflection;

// [assembly: AssemblyVersion("1.0.0.0")]

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("사용자 화면 출력");
        Debug.WriteLine("디버그 화면 출력 - Debug");
        Trace.WriteLine("디버그 화면 출력 - Trace");

        Console.WriteLine("64 bit process: " + Environment.Is64BitProcess);
    }
}