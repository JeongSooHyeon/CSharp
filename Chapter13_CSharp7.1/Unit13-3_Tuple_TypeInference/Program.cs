using System;

class Program
{
    static void Main(string[] args)
    {
        int age = 20;
        string name = "Kevin Arnold";

        (int, string) person = (age, name);
        Console.WriteLine($"{person.Item1}, {person.Item2}");


        // 병수명 타입 추론, 자동으로 붙여줌
        var t = (age, name);
        Console.WriteLine($"{t.age}, {t.name}");

        // 추론이 안 되는 필드
        var person1 = new { Age = 30, Name = "Winnie Cooper" };
        var t1 = (25, person1.Name);
        Console.WriteLine($"{t1.Item1}, {t1.Name}");
    }

}