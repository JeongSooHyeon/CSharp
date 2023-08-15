#nullable enable

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using static System.Console;

// AllowNull : 명시적인 널 가능 타입이 아니어도 호출 측에서 null을 전달할 수 있다는 힌트 부여
public class AllowAttrTest
{
    public AllowAttrTest()
    {
        GetLengthOfText(null);  // null 대입 가능
    }

    public int GetLengthOfText([AllowNull] string text)
    {
        return text.Length;
    }
}

// DisallowNull : 명시적인 널 가능 타입이어도 호출 측에서 null을 전달할 수 없다는 힌트 부여
public class DisallowAttrTest
{
    public DisallowAttrTest()
    {
        GetLengthOfText(null);  // null 대입 시 컴파일 경고
    }

    public int GetLengthOfText([DisallowNull] string? text)
    {
        return text!.Length;
    }
}

// DoesNotReturn : 특성이 적용된 메서드는 실행을 반환하지 않는다고 컴파일러에게 힌트를 부여
public class DoesNotReturnTest
{
    // 원래 경고가 발생하지만, DoesNotReturn 특성으로 인해 경고가 제거됨
    public DoesNotReturnTest()
    {
        string text = Environment.GetEnvironmentVariable("TEST");
        if(text == null)
        {
            LogAndThrowNullArg($"{nameof(text)}");
        }

        Console.WriteLine(text.Length);
    }

    [DoesNotReturn]
    private void LogAndThrowNullArg(string name)
    {
        throw new ArgumentException(name);
    }

    // DoesNotReturn 메서드는 정상적인 반환을 허용하지 않으므로
    // 아래의 코드는 경고 발생
    [DoesNotReturn]
    public void EnsureNotNull(string? text)
    {
        if(text == null)
        {
            throw new ApplicationException("NULL-REF");
        }
    }  
}

// DoesNotReturnIf : 특성이 적용된 인자의 bool 조건에 따라 해당 메서드는 실행을 반환하지 않는다고 컴파일러에게 힌트 부여
public class DoesNotReturnIfTest
{
    public int GetLengthOf(string? text)
    {
        // 원래는 text.Length에서 경고가 발생하지만
        // DoesNotReturnIf 특성이 적용된 메서드의 조건으로 
        // 컴파일 경고가 제거됨
        EnsureNotNull(text == null);
        return text.Length;
    }

    public void EnsureNotNull([DoesNotReturnIf(true)] bool isNull)
    {
        if(isNull == true)
        {
            throw new ApplicationException("NULL-REF");
        }
    }
}

// MaybeNull : 널 가능하지 않은 참조 타입이어도 null을 담고 있을 가능성 존재 힌트 부여
public class MaybeNullTest<T>
{
    public MaybeNullTest()
    {
        // 원래는 GetText가 string을 반환하므로
        // 그 결과 또한 널 가능하지 않은 참조 타입으로
        // 받을 수 있지만, MaybeNull 특성으로 인해
        // string?으로 처리
        string? text = GetText();
    }

    [return: MaybeNull]
    public string GetText()
    {
        string text = StringFromSomeWhere();
        return text;
    }

    List<T> list = new List<T>();

    [return:MaybeNull]
    public T Get()
    {
        return list.FirstOrDefault<T>();
    }
}

// MaybeNullWhen : 적용된 ref/out 인자가 널 가능하지 않는 참조 타입이어도 반환 값의 bool 값에 따라 null을 담고 있다는 힌트 부여
public class MaybeNullWhenTest
{
    public MaybeNullWhenTest()
    {
        // 원래는 text.Length에서 경고가 발생하겠지만, 
        // MaybeNullWhen 특성의 적용으로 경고를 제거
        if(GetText(out string? text))
        {
            Console.WriteLine(text.Length);
        }
    }

    List<string> list = new List<string>();

    public bool GetText([MaybeNullWhen(false)] out string text)
    {
        text = list.FirstOrDefault();
        return text != null;
    }
}

// NotNullIfNotNull : 지정된 인자가 null이 아니라면 반환 값 역시 null이 아니라는 힌트를 부여
public class NotNullIfNotNullTest
{
    public NotNullIfNotNullTest()
    {
        string? input = "test";
        string? result = GetText(input);

        // 원래는 result에 대해 null 체크 코드를 추가해야 하지만
        // NotNullIfNotNull의 특성으로 인해 input과 result의
        // null 상태가 동일하므로 input 하나로 체크 처리 가능
        if(input == null)
        {
            return;
        }

        Console.WriteLine(result.Length);
    }

    [return: NotNullIfNotNull("text")]
    public string? GetText(string? text)
    {
        return text + "";
    }
}