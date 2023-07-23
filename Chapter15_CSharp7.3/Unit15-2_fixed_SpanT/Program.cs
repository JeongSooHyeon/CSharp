using System;
using System.Runtime.InteropServices;

class Program
{
 private unsafe static void FixedSpan()
    {
        {
            // (fixed될 필요가 없는) 스택을 기반으로 하든,
            Span<int> span = stackalloc int[500];

            fixed(int *pSpan = span)
            {
                Console.WriteLine(*(pSpan + 1));
            }
        }

        {
            // 관리 힙을 기반으로 하든,
            Span<int> span = new int[500];

            fixed(int* pSpan = span)
            {
                Console.WriteLine(*(pSpan + 1));
            }
        }

        {
            // (fixed될 필요가 없는) 비관리 힙을 기반으로 하든지에 상관없이 일관성 있는 fixed 구문을 제공
            int elemLen = 500;
            int allocLen = sizeof(int) * elemLen;
            Span<int> span = new Span<int>((void*)Marshal.AllocCoTaskMem(allocLen), elemLen);

            fixed (int* pSpan = span)
            {
                Console.WriteLine(*(pSpan + 1));
            }
    }


    static void Main(string[] args)
    {


    }
}


