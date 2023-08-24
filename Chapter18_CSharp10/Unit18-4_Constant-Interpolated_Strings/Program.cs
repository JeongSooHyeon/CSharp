using System;
using System.Diagnostics;

namespace ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        const string Author = "Anders";

        // 9이하에서 컴파일 오류
        const string text = $"C# : {Author}";


        // 상수 문자열 외의 상수는 지원하지 않음
        // 숫자형은 컴파일 오류
        const float PI = 3.14f;
        const string output = $"nameof{PI} == {PI}"; ;
    }

}


// 9.0 이하에서는 이렇게 처리하던 것을
// [DebuggerDisplay("class" + nameof(ConsoleApp) + "." + nameof(Program))]

// 10부터 직접 보간식 사용 가능
[DebuggerDisplay($"class {nameof(ConsoleApp)}.{nameof(Program)}")]

internal class Program1
{

}