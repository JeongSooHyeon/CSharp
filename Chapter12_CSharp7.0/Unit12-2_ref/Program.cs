using System;

class Program
{
    static void Main(String[] args)
    {
        IntList intList = new IntList();
/*        int[] list = intList.GetList(); // list 요소 바꾸기
        list[0] = 5;*/

        ref int item = ref intList.GetFirstItem(); // list 요소 바꾸기
        item = 5;   // 참조값이므로 값을 변경하면 원래의 int[] 배열에도 반영

        intList.Print();



        // 메서드에 값 대입
        MyMatrix matrix = new MyMatrix();
        matrix.Put(0, 0) = 1;

        // 메서드로부터 값 받음
        int result = matrix.Put(1, 1) = 1;
        Console.WriteLine(result);
    }

    public ref int RefReturnOfLocalValue()
    {
        int x = 5;
        return ref x;   // 지역 변수를 반환할 수 없음
    }

    public void changeRefLocalVar()
    {
        int a = 5;
        ref int b = ref a;

        int c = 10;
        b = ref c;  // 이미 a를 가리키는 b 참조 변수가 있음
        ref b = ref c;   // 이것도 안 됨
    }
}

class MyMatrix
{
    int[,] _matrix = new int[100, 100];

    public ref int Put(int column, int row)
    {
        return ref _matrix[column, row];
    }
}

class IntList
{
    int[] list = new int[2] { 1, 2 };

    public ref int GetFirstItem()
    {
        return ref list[0];
    }

    public int[] GetList()
    {
        return list;
    } 

    internal void Print()
    {
        Array.ForEach(list, (e) => Console.Write(e + ","));
        Console.WriteLine();
    }
}