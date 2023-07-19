using System;
using static MyDay;
using static BitMode;
using static System.Console;

public enum MyDay
{
    Saturday, Sunday,   // enum 필드의 내부 구현은 static 속성을 갖는다.
}

public class BitMode
{
    // const 필드의 내부 구현은 static 속성을 갖는다.
    public const int ON = 1;
    public const int OFF = 0;
}

class Prgram
{
    static void Main(string[] args)
    {
        MyDay day = Saturday;   // "using static MyDay"로 인해 타입명 생략
        int bit = ON;

        WriteLine(day);
        WriteLine(bit);
    }
}