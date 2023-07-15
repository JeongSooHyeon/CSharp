using System;
using System.Diagnostics;

// 확장 메서드는 static 클래스에 정의해야 함
static class ExtensionMethodSample
{
    // 확장 메서드는 반드시 static이어야 하고,
    // 확장하려는 타입의 매개변수를 this 예약어와 함께 명시
    public static int GetWordCount(this string txt)
    {
        return txt.Split(' ').Length;
    }
}

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello, World!";

            // 마치 string 타입의 인스턴스 메서드를 호출하듯이 확장 메서드를 호출
            Console.WriteLine("Count : " + text.GetWordCount());
            // Console.WriteLine("Count : " + ExtensionMethodSample.GetWordCount(text));
        }
    }
}