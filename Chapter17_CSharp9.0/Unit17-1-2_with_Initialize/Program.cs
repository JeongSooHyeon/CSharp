

using System.Security.Cryptography.X509Certificates;

public record Point
{
    public int X { get; init; }
    public int Y { get; init; }

    public Point(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public Point Move(int x, int y)
    {
        return new Point(this.X + x, this.Y + y);
    }
}


// record + init의 조합으로 별도의 메서드를 정의하지 않고 처리 가능
public record Point1(int X, int Y)
{
    public Point1() : this(0, 0) { }
}

class Program
{
    static void Main(string[] args)
    {
        // 이전, 문법으로 불변 타입을 만들었을 때, 기존 인스턴스의 값을 변경하는 코드 작성 시
        Point pt1 = new Point(5, 10);

        // 1. 생성자 이용
        Point pt2 = new Point(pt1.X + 1, pt1.Y + 2);

        // 2. 메서드를 이용
        Point pt3 = pt1.Move(1, 2);


        // record + init의 조합으로 별도의 메서드를 정의하지 않고 처리 가능
        Point1 pt4 = new Point1(5, 10);

        // 기존 인스턴스의 값을 변경한 새로운 인스턴스를 반환

        // 1) 개체 초기화 구문 사용
        Point1 pt5 = new Point1() { X = pt4.X + 1, Y = pt4.Y + 2 };

        // 2) 생성자 사용
        Point1 pt6 = new Point1(pt4.X + 1, pt4.Y + 2);


        // with 예약어를 이용해 속성 초기화
        Point1 pt7 = new Point1(5, 10);

        // record로 정의한 타입의 인스턴스인 경우에만 허용
        // pt1 인스턴스의 기존 값에서 Y만 변경한 새로운 인스턴스를 반환
        Point1 pt8 = pt7 with { Y = pt7.Y + 2 };

        Point1 pt9 = pt7 with { X = pt7.X + 2 };
        Point1 pt10 = pt7 with { X = pt7.X + 2, Y = pt7.Y + 3 };
    }

}

