using System;
using System.Collections.Generic;

class Person
{
    public int Age;
    public string Name;
}

 class Program
{
    static void Main(String[] args)
    {
        List<int> list = new List<int> { 3, 1, 4, 5, 2 };

        // 형변환
        IEnumerable<double> doubleList = list.Select((elem) => (double)elem);
        Array.ForEach(doubleList.ToArray(), (elem) => { Console.WriteLine(elem); });

        // 객체 반환
        IEnumerable<Person> personList = list.Select(
                                (elem) => new Person { Age = elem, Name = Guid.NewGuid().ToString() });
        Array.ForEach(personList.ToArray(), (elem) => { Console.WriteLine(elem); });

        // 익명 타입으로 구성해 반환
        var itemList = list.Select(
            (elem) => new { TypeNo = elem, CreateDate = DateTime.Now.Ticks });
        Array.ForEach(itemList.ToArray(), (elem) => { Console.WriteLine(elem); });
    }
}