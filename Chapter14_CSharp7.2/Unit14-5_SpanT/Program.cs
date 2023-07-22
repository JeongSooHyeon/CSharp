using System;
using System.Text;
using System.Runtime.InteropServices;
class Program
{
    static void Main(string[] args)
    {
        var arr = new byte[] { 0, 1, 2, 3, 4, 5, 6 };

        Span<byte> view = arr;
        // 또는
        // Span<byte> view = new Span<byte>(arr);
        Console.WriteLine(view[5]);

        view[5] = 17;   // Span<T> 인스턴스의 값을 변경
        Console.WriteLine(arr[5]);

        arr[5] = 15;    // 원본의 값을 변경
        Console.WriteLine(view[5]);


        // 배열을 이등분해 다른 메서드에 전달
        var arr1 = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 };

        var arrLeft = arr1.Take(4).ToArray();    // 앞의 4개 요소를 분리
        var arrRight = arr1.Skip(4).ToArray();   // 뒤의 4개 요소를 분리

        Print(arrLeft);
        Print(arrRight);

        // Span<T>으로 중복 문제 해결
        Span<byte> view1 = arr1;

        // 힙에 어떤 공간도 할당하지 않음
        Span<byte> viewLeft1 = view1.Slice(0, 4);
        var viewRight = view1.Slice(4);

        Print(viewLeft1);
        Print(viewRight);


        // 문자열 조작
        string input = "100,200";   // 원본 문자열 힙 할당
        int pos = input.IndexOf(',');

        string v1 = input.Substring(0, pos);    // "100" 문자열 힙 할당
        string v2 = input.Substring(pos + 1);   // "200" 문자열 힙 할당

        {
            Console.WriteLine(int.Parse(v1));
            Console.WriteLine(int.Parse(v2));
        }

        // Span<T>
        ReadOnlySpan<char> view2 = input.AsSpan();

        ReadOnlySpan<char> v3 = view2.Slice(0, pos);    // 힙 할당 없음
        ReadOnlySpan<char> v4 = view2.Slice(pos + 1);
        {
            Console.WriteLine(int.Parse(v3));
            Console.WriteLine(int.Parse(v4));
        }



        // 스택 배열
        {
            Span<byte> bytes = stackalloc byte[10]; // 스택 배열
            bytes[0] = 100;
            Print(bytes);
        }

        unsafe
        {
            int size = 10;
            IntPtr ptr = Marshal.AllocCoTaskMem(size);  // 비관리 메모리의 배열

            try
            {
                Span<byte> bytes = new Span<byte>(ptr.ToPointer(), size);
                bytes[9] = 100;

                Print(bytes);
            }
            finally
            {
                Marshal.FreeCoTaskMem(ptr);
            }
        }

    }

    private static void Print(Span<byte> view)
    {
        foreach(byte elem in view)
        {
            Console.Write(elem + ",");
        }
        Console.WriteLine();
    }
}