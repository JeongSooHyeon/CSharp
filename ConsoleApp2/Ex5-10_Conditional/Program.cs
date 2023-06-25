using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        OutputText();
    }

    [Conditional("DEBUG")]  // Conditaional 특성의 생성자로 전달된 전처리 상수가 정의돼 있는 경우 실행 파일에 포함
    static void OutputText()
    {
        Console.WriteLine("디버그 빌드");
    }
}


