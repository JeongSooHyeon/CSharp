

class Point
{
    public int X;
    public int Y;

    public override string ToString() => $"({X}, {Y})";
}

class Program
{
    static void Main(string[] args)
    {
        Func<Point, bool> detectZeroOR = (pt) =>
        {
            switch (pt)
            {
                case var pt1 when pt1.X == 0:
                case var pt2 when pt2.Y == 0:
                    return true;
            }
            return false;
        };

        Point pt = new Point { X = 10, Y = 20 };
        Console.WriteLine(detectZeroOR(pt));


        // 속성 패턴 사용
        Func<Point, bool> detectZeroOR1 = (pt) =>
        {
            switch (pt)
            {
                // case { X: 0, Y: 0}:
                case { X: 0 }:
                case { Y: 0 }:
                    return true;
            }
            return false;
        };

        Func<Point, bool> detectZeroOR2 = (pt) =>
        pt switch
        {
            // { X: 0, Y: 0 } => true,
            { X: 0 } => true,
            { Y: 0}=>true,
            _ => false,
        };


        
        // is 연산자에서 when 조건을 지원하지 않으므로 컴파일 오류 발생
        /*
        if(pt is Point when pt.X == 500){
            Console.WriteLine(pt);
        }*/

        // 대신 속성 패턴을 이용하면 다음과 같이 구현 가능
        if(pt is {  X: 500 })
        {
            Console.WriteLine(pt.X + " == 500");
        }

        if(pt is { X: 10, Y: 0 })
        {
            Console.WriteLine(pt.X + " == 10");
        }

    }
}