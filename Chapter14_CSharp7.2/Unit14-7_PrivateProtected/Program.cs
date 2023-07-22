using System;

class Program
{
    static void Main(string[] args)
    {




    }
}

public class Base
{
    private protected void PP()
    {
        Console.WriteLine("From Base.PP()");
    }

    internal protected void IP()
    {
        Console.WriteLine("From Base.IP()");
    }
}

// Derived 클래스가 Base 클래스와 같은 어셈블리에 정의된 경우
public class Derived : Base
{
    public void My()
    {
        base.PP();  // 컴파일 정상 : Derived 타입이 동일한 어셈블리 내의 자식 클래스이기 때문
        base.IP();
    }
}

// Another 클래스가 Base 클래스와 같은 어셈블리에 정의된 경우
public class Another
{
    public void My()
    {
        Base b = new Base();

        b.PP(); // 동일한 어셈블리 내에 정의, Base의 자식 클래스가 아님 XXX
        b.IP(); // 동일한 어셈블리 내 정의
    }
}