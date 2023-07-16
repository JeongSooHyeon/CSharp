
List<int> list = new List<int> { 3, 1, 4, 5, 2 };

// 기존 if문으로 짝수로 구성된 List<T> 반환
List<int> evenList = new List<int>();
foreach(var item in list)
{
    if (item % 2 == 0)
    {
        evenList.Add(item);
    }
}

foreach(var item in evenList)
{
    Console.WriteLine(item + ",");
}

// FindAll 메서드 사용
List<int> evenList2 = list.FindAll((elem) => elem % 2 == 0);
evenList2.ForEach((elem) => { Console.Write(elem + ","); });

