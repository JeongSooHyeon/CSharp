

/*public struct Language
{
    // 컴파일 에러
    // 필드에 설정한 값들의 실제 코드는 생성자에 포함되므로
    // 기본 생성자 지원 필수
    public string Author = "John";
    public string Name { get; private set; } = "C#";

}*/


public struct Language1
{
    public string Author = "John";
    public string Name { get; private set; } = "C#";

    public Language1(string name)
    {
        this.Name = name;
    }

    public Language1()
    {

    }
}


// 컴파일러는 필드 초기화 코드를 생성자에 병합하는 식으로 처리
public struct Language2
{
    public string Author;
    public string Name { get; private set; }

    public Language2(string name)
    {
        // 필드 초기화 코드가 생성자에 병합
        this.Author = "John";
        this.Name = "C#";
        this.Name = name;
    }
}


class Program
{
    static void Main(string[] args)
    {
        TestStruct t = new TestStruct();    // 기본 생성자를 이용한 구조체 초기화
        Console.WriteLine(t.i);
    }
}

struct TestStruct
{
    public int i = 10;  // 필드 초기화는 사용자가 정의한 생성자에만 병합
    public TestStruct(int i) { this.i = i; }
}



// 9.0 
record Student()
{
    // 참조 형식에서는 자연스러운 필드 초기화
    public string Name { get; init; } = "John";

    public int Id { get; init; } = 20;
}

// 10 참조 형식의 record 타입을 record struct로 자연스럽게 마이그레이션 할 수 있게 됨
record struct Student1()
{
    // 기본 생성자와 필드 초기화를 추가했기 때문에 가능한 record struct
    public string Name { get; init; } = "John";
    public int Id { get; init; } = 20;
}

