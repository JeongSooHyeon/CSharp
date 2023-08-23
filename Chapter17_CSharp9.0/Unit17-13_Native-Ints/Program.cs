using System;

nint x1 = 3;
nuint x2 = 4;

// nint, nuint 사용에는 unsafe 필요 없음
// sizeof 연산을 위해서만 unsafe 문맥 필요
unsafe
{
    Console.WriteLine(sizeof(nint));
    Console.WriteLine(sizeof(nuint));
}