
using System.Runtime.CompilerServices;

public static class Program
{
    public static void Main(string[] args)
    {
        // MyDebug.Assert(args.Length >= 1, "args.Length >= 1");
        MyDebug.Assert(args.Length >= 1);
        Console.WriteLine(args[0]);
    }
}

public static class MyDebug
{
    //public static void Assert(bool cond, string msg)
    // 컴파일러가 특성을 인식하고,
    // 자동으로 cond 매개변수에 전달한 식을 문자열로 변환해 msg 매개변수로 전달
    public static void Assert(bool cond, [CallerArgumentExpression("cond")] string msg = null)
    {
        if(cond == false)
        {
            Console.WriteLine($"Assert failed : {msg}");
            Environment.Exit(1);    // 프로그램 종료
        }
    }
}