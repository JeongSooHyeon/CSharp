

public class Point
{
    // get / private set 조합으로 정의하거나
    public int X { get; }
    public int Y { get; }

    /* 또는 필드와 속성을 분리해 정의
     readonly int _x;
    readonly int _y;

    public int X => _x;
    public int Y => _y;
    */

    public Point(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
}

public class Point1
{
    public int X { get; init; }
    public int Y { get; init; }
}

#if !NET5_0
    // .NET 5 환경이 아닌 경우 IsExternalInit 클래스를 별도로 정의해서 컴파일 가능하게 만듦
    namespace System.Runtime.Comp8ilerServies
{
    public class IsExternalInit { }
}
#endif

class Program
{
    Point1 pt = new Point1() { X = 3, Y = 5 };  // 개체 초기화 구문에서 값 설정 허용

}

// 값을 담는 class, 불변 타입
public record Point2
{
    public int X { get; init; }
    public int Y { get; init; }
}



// 타입을 생성자와 함께 정의하는 것처럼 지원하는 구문
public record Point3(int X, int Y) { }

/*
생성자와 Deconstruct 메서드 자동 구현
*/

// 생성자 및 기타 메서드 정의 가능
public record Point4(int X, int Y) {
    // 기본 생성자 추가
    public Point4() : this(0, 0) { }
}

// init도 블록을 사용해 원하는 코드를 추가할 수 있다.
public class PointF
{
    public int Y
    {
        get => Y;
        init
        {
            Y = value;
        }
    }
}