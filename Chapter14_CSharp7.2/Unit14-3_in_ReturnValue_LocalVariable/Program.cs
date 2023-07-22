using System;
using System.Numerics;

class Program
{
    readonly Vector v1 = new Vector();

    static void Main(string[] args)
    {
        Program pg = new Program();
        // StructParam(pg.GetVector());    // 반환 값의 값 복사 부하 발생
        StructParam(in pg.GetVector()); // in 변경자를 적용

        ref readonly Vector v2 = ref pg.GetVector();    // 로컬 변수에 적용
    
    }

    private static void StructParam(in Vector v)
    {
        v.Increment(1, 1);
    }

    private ref readonly Vector GetVector()
    {
        return ref v1;  // v1 인스턴스의 값 복사가 발생하지 않도록 ref 반환
    }

}

readonly struct Vector
{
    readonly public int X;
    readonly public int Y;

    public Vector(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Vector Increment(int x, int y)
    {
        return new Vector(X + x, Y + y);
    }
}