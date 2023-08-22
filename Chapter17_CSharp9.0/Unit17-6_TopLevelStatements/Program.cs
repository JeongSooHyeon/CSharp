using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

System.Console.WriteLine("Hello World");

Console.WriteLine("dfd");


int argLen = args.Length;   // 최상위 문에서 동이랗게 명령행 인자에 접근 가능
Console.WriteLine(args[0]);


// 최상위 문에서도 곧바로 P/Invoke 선언 가능
[DllImport("User32.dll", CharSet = CharSet.Unicode)]
static extern int MessageBox(IntPtr h, string m, string c, int type);

MessageBox(IntPtr.Zero, "C# 9.0", "Top-level statements", 0);

Log("Hello World");

// 최상위 문에서 로컬 함수를 일반 메서드처럼 다루는 것이 가능
[Conditional("DEBUG")]
static void Log(string text)
{
    File.WriteAllText($"test.log", text);
}