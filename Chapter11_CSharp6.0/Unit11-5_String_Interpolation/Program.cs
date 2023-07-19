
using System.Net.Cache;
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        //return $"이름 : {Name}, 나이 : {Age}";
       // return $"이름 : {Name.ToUpper()}, 나이 : {(Age > 19 ? "성년" : "미성년")}";
        return $"이름 : {Name,-10}, 나이 : {Age,0:X}";
        // 컴파일 후 아래의 코드로 변경됨
        // return string.Format("이름 {0}, 나이 : {1}", Name, Age);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person();
        Console.WriteLine(person);
    }
}



