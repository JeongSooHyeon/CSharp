
using System;
using System.Runtime.CompilerServices;

class Program
{
    [SkipLocalsInit]
    unsafe static void Main(string[] args)
    {
        // 변수 i는 미리 0으로 초기화되지 않은 공간, 개발자 코드에 의해 5로 초기화
        int i = 5;
        Console.WriteLine(i);
    }

    // stackalloc에 적용 시, 요소의 수와 해당 메서드의 호출 횟수에 따라 성능 높일 여지 충분
    [SkipLocalsInitAttribute]
    unsafe static void LocalsInitStackAlloc()
          
    {
        var arr = stackalloc int[1000];

        for(int i=0; i<1000; i++)
        {
            // 이전에는 0 출력, 이후 값 예측할 수 없음
            Console.Write($"{arr[i]},");
        }
    }
}

