using System;

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>
        {
            new Person { Name="Tom", Age=63, Address="Korea"},
            new Person { Name="Winnie", Age=40, Address="Tibet"},
            new Person { Name="Anders", Age=47, Address="Sudan"},
            new Person { Name="Hans", Age=25, Address= "Tibet" },
            new Person { Name="Eureka", Age=32, Address="Sudan"},
            new Person { Name = "Hawk", Age = 15, Address = "Korea" },
        };

        var dateList = from person in people
                       select new { Name = person.Name, Year = DateTime.Now.AddYears(-person.Age).Year };
        foreach(var item in dateList){
            Console.WriteLine(string.Format("{0} - {1}", item.Name, item.Year));
        }

        // 튜플 사용
        var dateList1 = from person in people
                        select (person.Name, DateTime.Now.AddYears(-person.Age).Year);
        foreach(var item1 in dateList1)
        {
            Console.WriteLine(string.Format("{0} - {1}", item1.Item1, item1.Item2));
        }

        // 이름 지정
        var dateList2 = from person in people
                        select (Name: person.Name, Year: DateTime.Now.AddYears(-person.Age).Year);
        foreach(var item2 in dateList2)
        {
            Console.WriteLine(string.Format("{0} - {1}", item2.Name, item2.Year));
        }

        // 타입 추론을 통해 튜플 내에 지정된 속성의 이름
        var dateList3 = from person in people
                        select (person.Name, DateTime.Now.AddYears(-person.Age).Year);
        foreach (var item3 in dateList3)
        {
            Console.WriteLine(string.Format("{0} - {1}", item3.Name, item3.Year));
        }
    }
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
}