using System;

class Program
{
/*    public bool Assert(bool result) =>
    #if DEBUG
            // result = true ? result : throw new ApplicationException("ASSERT");   // 컴파일 에러
        result == true ? result : AssertException("ASSERT");    // throw를 포함한 별도의 메서드 호출
    #else
            result;
    #endif*/

    // 7.0부터 바뀜
    public void Assert(bool result) =>
    #if DEBUG
        _ = result == true ? result : throw new ApplicationException("ASSERT");
    #else
        _ = result;
    #endif

    public bool AssertException(string msg)
    {
        throw new ApplicationException(msg);
    }

}

class Person
{
    public string Name { get; }

    // null 병합 연산자(??)에서 throw 사용
    public Person(string name) => Name = name ??
                                throw new ArgumentNullException(nameof(name));

    // 람다 식으로 정의된 메서드에서 사용
    public string GetLastName() => throw new NotImplementedException();

    public void Print()
    {
        // 단일 람다 식을 이용한 델리게이트 정의에서 사용
        Action action = () => throw new Exception();
        action();
    }
}