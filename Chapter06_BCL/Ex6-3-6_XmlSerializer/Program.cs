﻿using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

public class Person
{
    public int Age;
    public string Name;

    public Person() { }

    public Person(int age, string name)
    {
        this.Age = age;
        this.Name = name;
    }

    public override string ToString()
    {
        return string.Format("{0} {1}", this.Age, this.Name);
    }
}
class Program
{
    static void Main(string[] args)
    {
        MemoryStream ms = new MemoryStream();
        XmlSerializer xs = new XmlSerializer(typeof(Person));

        Person person = new Person(36, "Anderson");

        // MemoryStream에 문자열로 person 객체를 직렬화
        xs.Serialize(ms, person);

        ms.Position = 0;

        // MemoryStream으로부터 역직렬화해서 복원
        Person clone = xs.Deserialize(ms) as Person;

        Console.WriteLine(clone);

        byte[] buf = ms.ToArray();
        Console.WriteLine(Encoding.UTF8.GetString(buf));
    }
}