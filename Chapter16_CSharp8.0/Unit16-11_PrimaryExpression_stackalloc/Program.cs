using System;

class Program
{
    static unsafe void Main(string[] args)
    {
        Span<int> arr = stackalloc int[] { 0, 1, 2 };

        PrintArray(arr);
        PrintArray(stackalloc int[] { 2, 3, 4 });   // 직접 전달

        int length = (stackalloc int[] { 1, 2, 3 }).Length; // stackalloc 문법적으로 식이 됨

        if (stackalloc int[10] == stackalloc int[10]) { }
    }

    private static void PrintArray(Span<int> arr)
    {
        foreach (int item in arr)
        {
            Console.WriteLine(item + ',');
        }
    }
}