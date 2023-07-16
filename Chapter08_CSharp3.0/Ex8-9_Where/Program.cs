using System;

static class Program {
    static void Main(String[] args) {
        List<int> list = new List<int> { 3, 1, 4, 5, 2 };

        // Where 메서드를 사용해 특정 조건을 만족하는 요소 반환
        IEnumerable<int> enumList = list.Where((elem) => elem % 2 == 0);
        Array.ForEach(enumList.ToArray(), (elem) => { Console.WriteLine(elem); });

        // yield 사용
        IEnumerable<int> enumList2 = list.WhereFunc();
        Array.ForEach(enumList2.ToArray(), (elem) => { Console.WriteLine(elem); });
    }

    private static IEnumerable<int> WhereFunc(this IEnumerable<int> inst)
    {
        foreach (var item in inst)
        {
            if (item % 2 == 0)
            {
                yield return item;
            }
        }
    }
}