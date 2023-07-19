using System;


List<int> list = GetList();
if(list != null)
{
    Console.WriteLine(list.Count);
}

// null 조건 연산자
Console.Write(list?.Count);


if(list != null)
{
    for(int i=0; i<list.Count; i++)
    {
        // 목록 요소 처리
    }
}

for (int i = 0; list != null && i < list.Count; i++)
{
    // 목록 요소 처리
}

// null 조건 연산자
for(int? i=0; i<list?.Count; i++)
{
    // 목록 요소 처리
}


// ?? dustkswk
int count = list?.Count ?? 0;   // null을 반환하면 0을 반환

