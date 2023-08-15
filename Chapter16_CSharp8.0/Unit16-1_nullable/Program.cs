#nullable enable

using System.Diagnostics.CodeAnalysis;
using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        var miguel = new Person();
        int length = GetLengthOfName(miguel);
        WriteLine(length);
    }

    static int GetLengthOfName(Person person)
    {
        if(person.Name == null) // null 참조 예외를 막을 수 있도록 자연스럽게 예방 코드 추가
        {
            return 0;
        }

        return person.Name.Length;  
    }

    static int GetLengthOfNameNullCheck(NullablePerson person)
    {
        // IsNull 메서드가 null 체크를 한 것에 해당하므로 컴파일 경고 없다.
        if (IsNull(person.Name))
        {
            return 0;
        }

        return person.Name.Length;
    }

    // NotNullWhen 특성의 생성자에 전달된 false에 따라
    // IsNull 메서드가 false를 반환하면 null이라고 C# 컴파일러가 인지
    static bool IsNull([NotNullWhen(false)] string? value)
    {
        if(value == null)
        {
            return true;
        }

        return false;
    }

    static int GetLengthOfName(Person person)
    {
        return person.Name!.Length; // null 경고를 무시
    }
}


public class Person
{
    /*
    // non-nullable reference type
    public string Name { get; set; } = "";  // 기본 생성자 대신 값 초기화
 
    public Person() { } // 컴파일 경고 발생, null 가능성 있음

    public Person(string name)
    {
        Name = name;
    }

    public void Method()
    {
        Name = null;    // 개발자가 실수라도 null로 만드는 것을 방지하기 위해 컴파일 경고 발생
    }

    */

    // nullable reference type
    public string? Name { get; set; }

    public Person() { } // null일 수 있으므로 허용

    public Person(string name)
    {
        Name = name;
    }

    public void Method()
    {
        Name = null;    // null일 수 잇으므로 허용
    }

    
}