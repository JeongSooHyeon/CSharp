using System.Xml.Linq;

Name n1 = new Name("Anders", "Hejlsberg");
Name n2 = new Name("Kevin", "Arnold");
Name[] names = new Name[] {n1, n2 };

foreach(Name name in names)
{
    if(name is { LastName: "Arnold"} arnold)
    {
        Console.WriteLine($"{nameof(arnold)} == {name.FirstName}");
    }
}




Person p1 = new(n1, 60);
Person p2 = new(n2, 15);

Person[] people = new Person[] {p1, p2};

foreach(Person p in people)
{
    if (p is { Name: { LastName: "Arnold" } } arnold) // 중괄호 깊어짐
    {
        Console.WriteLine(arnold);
    }
}


// . 연산자 사용 멤버 접근
foreach (Person p in people)
{
    if (p is { Name.LastName: "Arnold" } arnold) // 중괄호 깊어짐
    {
        Console.WriteLine(arnold);
    }
}

// null 체크 겸비하여 패턴 매칭에서는 고려할 필요 없음
foreach (Person p in people)
{
    // null 체크 직접
    if (p == null) continue;
    if (p.Name == null) continue;

    if(p.Name.LastName == "Arnold")
    {
        Console.WriteLine(p.Name.LastName);
    }

    // 또는 null 조건 연산자를 함께 사용
    if(p?.Name?.LastName == "Arnold")
    {
        Console.WriteLine(p?.Name?.LastName);
    }
}


record class Name(string FirstName, string LastName);

record class Person(Name Name, int Age);



