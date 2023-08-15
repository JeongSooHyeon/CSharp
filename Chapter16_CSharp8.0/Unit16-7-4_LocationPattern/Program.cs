using System.Drawing;

// 튜플이 아닌 타입도 원하는 속성으로 튜플을 임시로 구성
Func<Point, bool> detectZeroOR = (pt) =>
(pt.X, pt.Y) switch
{
    (0, 0) => true,
    (0, _) => true,
    (_, 0) => true,
    _ => false,
};


// 위치 패턴 사용 시, 즉석에서 튜플을 생성하지 않고 직접 다루는 것 가능
Func<Point, bool> detectZeroOR1 = (pt) =>
pt switch
{
    (0, 0) => true,
    (0, _) => true,
    (_, 0) => true,
    _ => false,
};
class Point
{
    public int X;
    public int Y;

    public override string ToString() => $"({X}, {Y})";

    public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
        
}

bool zeroDetectd = (pt is (0, 0) || pt is (0, _) || pt is (_, 0));
