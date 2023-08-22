using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading;

#nullable enable

class Program
{
    static void Main(string[] args)
    {
        Log("Main");
        Log(null);


        // 이전 : conditional, AllowNull 등의 특성 사용으로 컴파이 오류
        [Conditional("DEBUG")]
        static void Log([AllowNull] string text)
        {
            string logText = $"[{Thread.CurrentThread.ManagedThreadId}] {text}";
            Console.WriteLine(logText);
        }


        // 로컬 함수로는 extern 유형을 정의할 수 없었던 문제 자연스럽게 해결
        MessageBox(IntPtr.Zero, "message", "title", 0);

        // 특성을 붇여할 수 있으므로 extern P/Invoke 정의를 로컬 함수로도 가능
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        static extern int MessageBox(IntPtr h, string m, string c, int type);
    }
}

namespace System.Diagnostics.CodeAnalysis
{
#if !NETCOREAPP
[AttributeUsage(AttributeTargetsField | AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue, AllowMultiple = true]
public sealed class AllowNullAttribute : Attribute{}
#endif
}