using System;
class Program
{
    static void Main(string[] args)
    {
#if DEBUG   // 전처리 지시자
        Console.WriteLine("디버그 빌드");
#endif
    }
}