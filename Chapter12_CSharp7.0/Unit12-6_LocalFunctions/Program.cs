using System;

class Program
{
    delegate (bool, int) MyDivide(int a, int b);    // 사용할 익명 메서드에 대한 델리게이트 정의
    delegate (bool, int) MyDivide1(int a, int b);    // 사용할 람다 식에 대한 델리게이트 정의

    static void Main(string[] args)
    {
        MyDivide func = delegate (int a, int b)
        {
            if (b == 0) { return (false, 0); }
            return (true, a / b);
        };

        MyDivide1 func1 = (a, b) =>
        {
            if (b == 0) { return (false, 0); }
            return (true, a / b);
        };

        Console.WriteLine(func(10, 5));
        Console.WriteLine(func(10, 0));

        Console.WriteLine(func1(10, 5));


        // 로컬 함수로 구현
        (bool, int) func3(int a, int b)
        {
            if(b== 0) { return (false, 0); }
            return (true, a / b);
        };

        // 람다 식으로 정의
        (bool, int) func4(int a, int b) => (b == 0) ? (false, 0) : (true, a / b);

        Console.WriteLine(func3(10, 5));
        Console.WriteLine(func4(10, 5));


    }
}