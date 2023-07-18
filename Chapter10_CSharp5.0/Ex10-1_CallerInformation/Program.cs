using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        LogMessage("테스트 로그");
    }

    static void LogMessage(string text,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        Console.WriteLine("텍스트 : " + text);
        Console.WriteLine("LogMessage를 호출한 메서드 이름 : " + memberName);
        Console.WriteLine("LogMessage를 호출한 소스코드의 파일명 : " + filePath);
        Console.WriteLine("LogMessage를 호출한 소스코드의 라인 번호 : " + lineNumber);
    }
}