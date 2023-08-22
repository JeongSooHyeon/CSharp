using System.Collections.Generic;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        Point pt1 = new Point(5, 6);    // 타입 모두 지정

        var pt2 = new Point(5, 6);  // new의 대상 타입을 추론해 var 결정

        Point pt3 = new(5, 6);   // 변수의 타입에 따라 new 연산자가 타입을 결정


        // 배열 및 컬렉션의 초기화 코드를 더 단순하게 만들어 줌
        var linePt = new Point[]
        {
            new(5, 6),
            new(){X=7, Y=0},
        };

        var dict = new Dictionary<Point, bool>()
        {
            [new(5, 6)] = true,
            [new(7, 3)] = false,
            [new() { X = 3, Y = 2 }] = false,
        };
    }
}

public record Point(int X, int Y)
{
    public Point() : this(0, 0) { }
}