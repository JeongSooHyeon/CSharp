
public struct Person
{
    string name;
    public string Name => name;

    public Person()
    {
        name = "John";
    }
}

// record struct, 기본 생성자를 기존의 record와 동일한 문법 체계로 지원
record struct Vector(int X, int Y)
{
    // 기존 record (class)와 마찬가지로
    // 매개변수가 있는 생성자로 this 구문을 활용해 초깃값 전달
    public Vector() : this(-1, -1) { }
    public Vector(int x) : this(x, -1) { }
}


class Program
{
    static void Main(string[] args)
    {

        // 기본 생성자 정의 가능
        Person p1 = new Person();   // 기본 생성자 호출
        Console.WriteLine(p1.Name);



        // 매개변수를 갖는 생성자를 호출하는 것도 가능하지만,
        Point pt1 = new Point(5, 6);
        Console.WriteLine($"{pt1.X}, {pt1.Y}");

        // 클래스와는 달리 기본 생성자 유형도 호출 가능
        // 하지만 기본 생성자가 정의된 것은 아님
        Point pt2 = new Point();
        Console.WriteLine($"{pt2.X}, {pt2.Y}");



        // 구조체 : 기본 생성자가 없는 유형임에도 컴파일 성공
        TestStruct valueType = ObjectHelper.CreateNew<TestStruct>();

        // 클래스 : 기본 생성자가 없으므로 의도한 바에 따라 컴파일 실패
        TestClass refType = ObjectHelper.CreateNew<TestClass>();
    }
}

public struct Point
{
    int x;
    public int X => x;
    int y;
    public int Y => y;

    public Point(int x, int y) { this.x = x; this.y = y; }
}


public class ObjectHelper
{
    // T 타입은 기본 생성자를 갖는 타입으로 제약
    public static T CreateNew<T>() where T : new() => new T();
}

struct TestStruct
{
    public int i;

    public TestStruct(int i) { this.i = i; }
}

class TestClass
{
    public int i;

    public TestClass(int i)
    {
        this.i = i;
    }
}