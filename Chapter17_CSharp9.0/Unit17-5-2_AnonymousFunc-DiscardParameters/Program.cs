

// 변수명이나 메서드 이름을 밑줄만으로 구성 가능
public class Class1
{
    void M(int _)   // 1개는 유효한 식별자 이름
    { 
    }

    public void M()
    {
        int _;
        _ = 5;
        Console.WriteLine(_);
    }

    // 2개 이상은 동일한 식별자를 사용한 것이므로 컴파일 오류
    void M(int _, int _)
    {

    }
}

public class class2
{
    void _()
    {

    }
}



// out 인자의 밑줄은 무시 구문으로 다뤄짐
class Program
{
    static void Main(string[] args)
    {
        Class3 cl = new Class3();
        cl.TryParse("5", out _, out _); // 식별자가 아니므로 2개 이상도 가능
    }
}

public class Class3
{
    public bool TryParse(string txt, out int n, out System.Net.IPAddress address)
    {
        n = 0;
        address = System.Net.IPAddress.Any;

        return true;
    }
}
