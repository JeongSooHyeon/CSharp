
class Program
{
    static void Main()
    {

        // 특성 허용
        var list = new List<String> { "Anders", "Kevin" };

        // 람다 식에 특성 허용
        list.ForEach([MyMethod()] (elem) => Console.WriteLine(elem));

        // 리턴 값에도 특성 적용
        Func<int> f1 = [return: MyReturn] () => 1;

        // 매개변수에도 특성 적용
        Action<string> action = static ([MyParameter] elem) => Console.WriteLine(elem);


        // 특성이 없으면 매개변수가 하나인 경우 괄호를 생략할 수 있지만
        list.ForEach(elem => Console.WriteLine(elem));

        // 괄호 없이 특성을 지정하면 컴파일 오류 발생
        // list.ForEach([MyMethod()] elem => Console.WriteLine(elem));



        // 반환 타입 지정
        // 반환 타입을 명시적으로 short로 지정, 매개변수가 하나라도 x를 괄호에 포함
        Func<int, short> f2 = short (x) => 1;

        // ref 반환도 지정 가능
        MethodRefDelegate f3 = ref int (ref int x) => ref x;

        // 반환 타입이 없어도 모두 컴파일 가능
        Func<int, short> f4 = x => 1;
        MethodRefDelegate f5 = (ref int x) => ref x;


        // 람다 식의 var 추론
        // var f6 = x => { };  // 매개변수 타입의 모호
        var f6 = (int x) => { };    // 매개변수의 타입을 지정했으므로 var 추론 가능
                                    // Action<int> f6 = (int x) => { };

        // var f7 = () => default; // 반환 타입의 모호
        var f7 = int () => default; // 반환 타입 명시
                                    // Func<int> f7 = int () => default;
        // var f8 = x => x;    // 반환 및 매개변수 타입의 모호
        var f8 = int (int x) => x;  // 반환 매개변수 타입 명시
                                    // Func<int, int> f8 = int (int x) => x;
    }
}

public delegate ref int MethodRefDelegate(ref int arg);

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class MyMethodAttribute : Attribute
{

}

[AttributeUsage(AttributeTargets.ReturnValue, AllowMultiple = true)]
public class MyReturnAttribute : Attribute
{

}

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class MyParameterAttribute : Attribute
{

}


public class MyType<T>
{
    public void Print()
    {
        // 제네릭 반환 지정도 가능
        Func<T?> f = T? () => default;
        Console.WriteLine($"T Result: {f()}");

        // 반환 타입 없어도 컴파일 가능
        Func<T?> f1 = () => default;
    }
}
