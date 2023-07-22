using System;

class Program
{
    static void Main(string[] args)
    {
        int part1 = 5;
        int part2 = 6;

        // 3항 연산자의 결과를 받는 ref 로컬 변수를 정의할 수 없음
        //ref int result = (part1 != 0) ? part1 : part2;  // 컴파일 오류

        ref int result1 = ref (part1 != 0) ? ref part1 : ref part2;

        ((part1 != 0) ? ref part1 : ref part2) = 15;
        Console.WriteLine(part1);
    }
}