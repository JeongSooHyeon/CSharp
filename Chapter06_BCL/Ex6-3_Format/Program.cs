using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        string txt = "Hello {0} : {1}";

        string output = string.Format(txt, "World", "Anderson");
        Console.WriteLine(output);

        Console.WriteLine(txt, "World", "Anderson");

        txt = "{2} {0} == {0} : {1}";
        Console.WriteLine(txt, "Hello", "World", "Hi");

        txt = "{0} * {1} == {2}";
        Console.WriteLine(txt, 5, 6, 5 * 6);

        Console.WriteLine("============================");
        // 정렬 옵션 지정
        txt = "{0, -10} * {1} == {2, 10}";
        Console.WriteLine(txt, 5, 6, 5 * 6);

        Console.WriteLine("============================");
        // 형식 문자열 적용
        txt = "날짜 : {0,-20:D}, 판매 수량 : {1,15:N}";
        Console.WriteLine(txt, DateTime.Now, 267);
    }
}

