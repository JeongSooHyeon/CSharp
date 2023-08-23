

class Program
{
    static void Main(string[] args)
    {
        int? n = 5;

        // 이전 컴파일 오류, 이후 컴파일 경고, nullable 형식의 ? 표시, 값 형식만 허용했다
        string? txt = "test";

        #nullable enable
        {
            // nullable 문맥 내에서 참조형의 '?' 표현은 경고 없이 허용
            string? txt1 = "test";
        }
        #nullable restore


    }



    static void CreaterArray<T>(int n)
    {
        // 이전 컴파일 오류, 범용 형식 매개변수의 타입이 값 형식일 수도, 참조 형식일 수도 있음
        var t = new T?[n];
    }

    // 값 형식인지, 참조 형식인지 명시하는 제약 필요
    static void CreateValueArray<T>(int n) where T : struct
    {
        // 값 형식이므로 nullable 표시 가능
        var t = new T?[n];
    }

#nullable enable
    static void CreateRefArray<T>(int n) where T : class
    {
        // 참조 형식이지만 nullable 문맥에서는 표시 가능
        var t= new T?[n];
    }
#nullable restore


    // 9.0부터는 제약을 지정하지 않은 경우 "where T class"를 생략한 것으로 지원
    static void CreateArray1<T>(int n) /* where T : class */
    {
        // nullable 문맥이 아닌 경우 컴파일 경고만 발생
        var t= new T?[n];   
    }

#nullable enable
    static void CreaterArray2<T>(int n) /* where T : class*/
    {
        //l nullable 문맥인 경우 경고 없이 컴파일
        var t = new T?[n];
    }
#nullable restore


    // 별도의 메서드를 정의한 것이므로 컴파일 가능
    public class GenericTest
    {
        void M<T>(T? value) where T : struct { }
        void M<T>(T? value) { } // 생략한 경우 "where T : class"이므로
    }

    // 동일한 메서드를 중복 정의
    public class GenericTest1
    {
        void M<T>(T? value) where T : class { }

        // 컴파일 오류 발생
        void M<T>(T? value) { } // 생략한 경우 "where T : class"
    }

}