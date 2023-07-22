using System;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        Program pg = new Program();

        Vector v1 = new Vector();
        pg.StructParam(v1); // 값 전달에 의해 내용 복사
        pg.StructParam(ref v1); // v1 인스턴스의 주소만 복사


        pg.StructParam1(in v1);  // v1 인스턴스의 주소만 복사
    }

    void StructParam(Vector vector) // x, y 값이 스택에 복사
    {

    }
    void StructParam(ref Vector vector) // 값 복사 없음
    {

    }

    void StructParam1(in Vector vector)  // ref + readonly 의미
    {
        vector.x = 5;   // 읽기 전용 변수이므로 할당할 수 없다
    }
}

struct Vector
{
    public int x;
    public int y;
}