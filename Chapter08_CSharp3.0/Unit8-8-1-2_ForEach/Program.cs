
List<int> list = new List<int> { 3, 1, 4, 5, 2 };

// 기존 컬렉션 요소 열람
foreach(var item in list)
{
    Console.WriteLine(item + " * 2 == " + (item * 2));
}

// Array 또는 List<T>의 컬렉션에 추가된 ForEach 메서드 사용
list.ForEach((elem) => { Console.WriteLine(elem + " * 2 == " + (elem * 2)); });
Array.ForEach(list.ToArray(), (elem) => { Console.WriteLine(elem + " * 2 == " + (elem * 2)); });

// 또는 람다 식이 아닌 익명 메서드로 나타낼 수 있음
list.ForEach(
    delegate (int elem) { Console.WriteLine(elem + " * 2 == " + (elem * 2)); }
    );
