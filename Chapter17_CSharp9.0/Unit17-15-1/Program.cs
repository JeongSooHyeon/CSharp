using System;

// 이전 nullable 타입에 대한 형식 매개변수를 값 형식과 참조 형식으로 나누는 경우
public class Base
{
    public virtual void M<T>(T? t) where T : struct
    {
        Console.WriteLine("Base.M.struct");
    }

#nullable enable
    public virtual void M<T>(T? t) where T : class
    {
        Console.WriteLine("Base.M.class");
    }
#nullable restore
}


// 8.0 이러한 클래스를 상속받아 정의한 하위 클래스에서는 제약 조건 없는 형식 매개변수 주석 허용,
// 그런 경우 "where T : struct"가 생략된 유형으로 판단
public class Derived : Base
{
    // 이후의 9.0과 다르게 "where T : struct"로 연결
    public override void M<T>(T? t)
    {
        Console.WriteLine("Derived.M.struct");
    }

#nullable enable
    public override void M<T>(T? t) where T : class
    {
        Console.WriteLine("Derived.M.Class");
    }
#nullable restore
}


// 9.0부터 명시적으로 "제약 조건 없는 형식 매개변수"는 "where T : class"가 생략된 유형으로 제공
public class Base1
{
    public virtual void M<T>(T? t) where T : struct
    {
        Console.WriteLine("Base.M.struct");
    }

    public virtual void M<T>(T? t)
    {
        Console.WriteLine("Base.M.class");
    }
}


// 9.0에서도 상속한 하위 클래스의 "제 조 형 매 주"는 "where T : struct"로 유지
public class Derived1 : Base1
{
    public override void M<T>(T? t) /* where T : struct 재정의 */
    {
        Console.WriteLine("Derived.M.struct");
    }
}


// 상위 클래스의 "제조없" 메서드를 재정의하려면 "where T : class" 제약을 대신하는 deault 제약 
public class Derived2 : Base1
{
    public override void M<T>(T? t)
    {
        Console.WriteLine("Derived.M.struct");
    }

    public override void M<T>(T? t) where T : default
    {
        Console.WriteLine("Derived.M.class");
    }
}