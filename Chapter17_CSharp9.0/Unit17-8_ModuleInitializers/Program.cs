using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Run at Main");
    }
}

class Module
{
    [ModuleInitializer] // 특성 정적 메서드에 부여
    internal static void DllMain()
    {
        Console.WriteLine("Run at ModuleInitializer");
    }
}

#if !NET5_0
// .NET 5.0 BCL에 포함됐고, 그 외의 환경에서는 ModuleInitializerAttribute 클래스를 별도로 정의해서 컴파일 가능
namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class ModuleInitialzerAttribute : Attribute { }
}
#endif