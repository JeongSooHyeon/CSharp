using System;
using static System.Console;

class Person
{
    public string Name { get; set; }    
    public int Age { get; set; }

    public override string ToString()
    {
        return $"이름 : {Name}, 나이 : {Age}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person { Name = "Anders", Age = 49 };
        OutputPerson(person.Name, person.Age);

        // 클래스 Person 식별자를 naneof에 전달
        string typeName = nameof(Person);

        // 지역 변수 person의 속성 식별자를 nameof에 전달
        WriteLine($"{typeName} 속성 : {nameof(person.Name)}, {nameof(person.Age)}");

    }

    static void OutputPerson(string name, int age)
    {
        // 메서드 OutputPerson 식별자를 nameof에 전달
        string methodName = nameof(OutputPerson);

        WriteLine($"{methodName}.{nameof(name)} == {name}");
        WriteLine($"{methodName}.{nameof(age)} == {age}");

        string localName = name;
        // 지역 변수 localName 식별자를 nameof에 전달
        WriteLine($"{methodName}.{nameof(localName)} == {localName}");
    }
}