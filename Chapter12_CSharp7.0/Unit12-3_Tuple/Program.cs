using System;

public class IntResult
{
    public bool Parsed { get; set; }
    public int Number { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Program pg = new Program();
        Tuple<bool, int> result = pg.ParseInteger("40");

        // 괄호를 이용해 다중 값 처리
        (bool, int) result1 = pg.ParseInteger1("50");
        Console.WriteLine(result1.Item1);
        Console.WriteLine(result1.Item2);

        // 이름 직접 정하기, var
        var result2 = pg.ParseInteger1("50");
        Console.WriteLine(result2.Parsed);  // 튜플의 첫 번째 인자 접근
        Console.WriteLine(result2.Number);

        // 이름이 지정되지 않은 튜플, 강제로 이름 지정
        (bool success, int n) result3 = pg.ParseInteger1("50");
        Console.WriteLine(result3.success);
        Console.WriteLine(result3.n);

        // 튜플로 받지 않고 개별 필드로 분해해서 받기
        (var success, var number) = pg.ParseInteger("50");
        Console.WriteLine(success);
        Console.WriteLine(number);

        // 생랼 기호
        (var _, var _) = pg.ParseInteger("70"); // 2개의 값을 모두 생략
        (var _, var n) = pg.ParseInteger("70"); // 마지막 값만 n으로 받음
        Console.WriteLine(n);
    }

    (bool Parsed, int Number) ParseInteger1(string text)
    {
        int number = 0;
        bool result = false;

        try
        {
            number = Int32.Parse(text);
            result = true;
        }
        catch { }

        return (result, number);
    }

    Tuple<bool, int> ParseInteger(string text)
    {
        int number = 0;
        bool result = false;

        try
        {
            number = Int32.Parse(text);
            result = true;
        }
        catch { }

        return Tuple.Create(result, number);
    }
}