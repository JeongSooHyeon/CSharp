using System.Xml.Serialization;

readonly struct Vector
{
    readonly public int X;
    readonly public int Y;

    public Vector(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
}

struct Matrix2x2
{
    public Vector V1;
    public Vector V2;

    public void Deconstruct(out Vector v1, out Vector v2) => (v1, v2) = (V1, V2);
}

enum MatrixType
{
    Any, Zero, Identity, Row1Zero,
}

class Program
{
    static void Main(string[] args)
    {
        static MatrixType GetMatrixType(Matrix2x2 mat)
        {
            switch (mat)
            {
                case Matrix2x2 m when m.V1.X == 0
                    && m.V1.Y == 0
                    && m.V2.X == 0
                    && m.V2.Y == 0:
                    return MatrixType.Zero;

                case Matrix2x2 m when m.V1.X == 0 && m.V1.Y == 0:
                    return MatrixType.Row1Zero;

                default: return MatrixType.Any;
            }
        }

        // 속성 패턴을 재귀적으로 적용
        static MatrixType GetMatrixType1(Matrix2x2 mat)
        {
            switch (mat)
            {
                case { V1: { X: 0, Y: 0 }, V2: { X: 0, Y: 0 } }:
                    return MatrixType.Zero;

                case { V1: { X: 0, Y: 0 }, V2: _ }:
                    return MatrixType.Row1Zero;

                default: return MatrixType.Any;
            }
        }

        // Deconstruct 정의 후, 위치 패턴을 재귀적으로 도입
        static MatrixType GetMatrixType2(Matrix2x2 mat)
        {
            switch (mat)
            {
                case ((0, 0), (0, 0)):
                    return MatrixType.Zero;

                case ((1, 0), (0, 1)):
                    return MatrixType.Identity;

                case ((0, 0), _):
                    return MatrixType.Row1Zero;

                default: return MatrixType.Any;
            }
        }

        // 또는
        static MatrixType GetMatrixType3(Matrix2x2 mat) =>
            mat switch
            {
                ((0, 0), (0, 0)) => MatrixType.Zero,
                ((1, 0), (0, 1)) => MatrixType.Identity,
                ((0, 0), _) => MatrixType.Row1Zero,
                _ => MatrixType.Any
            };


        // is 연산자
        Matrix2x2 mat = new Matrix2x2 { V1 = new Vector(0, 0), V2 = new Vector(0, 0) };

        if(mat is ((0,0), (0, 0)))
        {
            Console.WriteLine("Zero");
        }
    }
}