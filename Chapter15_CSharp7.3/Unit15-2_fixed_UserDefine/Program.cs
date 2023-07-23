using System;

class Program
{
    public class Point
    {
        public int X;
        public int Y;

        public ref int GetPinnableReference()
        {
            return ref X;
        }
    }

    private unsafe static void FixedUserClassType()
    {
        Point pt = new Point();

        // 사용자 타입인 Point는 fixed의 대상이 될 수 없다.
        // 컴파일 에러
        fixed (int* pPoint = pt)
        {

        }
    }


    static void Main(string[] args)
    {

        unsafe
        {
            Point pt = new Point { X = 5, Y = 6 };
            fixed (int* pX = &pt.X)
            fixed (int* pY = &pt.Y)
            {
                Console.WriteLine($"{*pX}, {*pY}");
            }


            // fixed 구문 사용
            Point pt1 = new Point();
            // GetpinnableReferenece 메서드 자동 호출
            fixed (int* pPoint = pt1)
            {
                Console.WriteLine(*pPoint);
            }
        }
    }
}


