using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

[Serializable]
class Person
{
    public int Age;
    public string Name;

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
        DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(Person));

        MemoryStream ms = new MemoryStream();

        Person person = new Person(36, "Anderson");

        // MemoryStream에 문자열로 person 객체를 직렬화
        dcjs.WriteObject(ms, person);

        ms.Position = 0;

        // MemoryStream으로부터 객체를 역직렬화해서 복원
        Person clone = dcjs.ReadObject(ms) as Person;

        Console.WriteLine(clone);

        byte[] buf = ms.ToArray();
        Console.WriteLine(Encoding.UTF8.GetString(buf));
    }
}
