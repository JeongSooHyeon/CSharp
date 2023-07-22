using System;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        int intValue = default; // int로 대입된다는 것을 알 수 있으므로
        BigInteger bigIntValue = default;

        Console.WriteLine(intValue);
        Console.WriteLine(bigIntValue);

        string txt = default;
        Console.WriteLine(txt ?? "(null)");


        GenericTest<int> t = new GenericTest<int>();
        Console.WriteLine(t.GetDefaultValue());
    }

    class GenericTest<T>
    {
        public T GetDefaultValue()
        {
            return default; // 제네릭 인자에 사용
        }
    }
}