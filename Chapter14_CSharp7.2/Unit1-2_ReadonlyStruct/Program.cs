using Microsoft.Win32.SafeHandles;
using System;
using System.Numerics;

class Program
{
    readonly Vector v1 = new Vector();

    static void Main(string[] args)
    {
        Program pg = new Program();
        // pg.v1.X = 5;    // 컴파일 오류
        pg.v1.Increment();  // 메서드 호출은 허용
        Console.WriteLine(pg.v1.X + ", " + pg.v1.Y);
    }

}

struct Vector
{
    public int X;
    public int Y;

    public void Increment() // 메서드 내부에서 값을 변경하는 코드는 유효
    {
        X++;
        Y++;
    }
}

readonly struct Vector1
{
    readonly public int X;
    readonly public int Y;

    // readonly 필드의 값을 유일하게 변경할 수 있으므로 생성자 추가
    public Vector1(int x, int y)
    {
        X = x;
        Y = y;
    }

    // 값을 변경하려면 반드시 값을 복사한 인스턴스를 새로 생성
    public Vector1 Increment(int x, int y)
    {
        return new Vector1(X + x, Y + y);
    }
}