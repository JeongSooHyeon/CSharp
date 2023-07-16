using System;

namespace Ex9_3_Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic d = 5;

            d.CallTest();   // 정수 타입에는 CallTest 메서드가 없지만 컴파일 오류가 발생하지 않음
        }
    }
}
