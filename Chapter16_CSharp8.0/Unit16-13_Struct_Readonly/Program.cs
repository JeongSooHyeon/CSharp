using System;

public struct Vector2
{
    public float x;
    public float y;

    public (float x, float y) ToTuple()
    {
        return (x, y);
    }

    // readonly 예약어 적용
    public readonly(float x, float y) ToTuple1()
    {
        return (x, y);
    }

    // 속성 property
    public readonly float LengthSquared
    {
        get { return (x * x) + (y * y); }
    }

    // 자동 구현 속성의 경우 get에 대해서만 readonly 적용 가능
    public float Z { readonly get; set; }

    // 람다 식으로 정의한 메서드
    public readonly float GetLength => (x * x) + (y * y);
}

class Program
{
    static void Main(string[] args)
    {
        Vector2 v = new Vector2 { x = 5, y = 6 };
        OutputInfo(v);
    }

    static void OutputInfo(in Vector2 v2)
    {
        (float x, float y) = v2.ToTuple(); // 방어 복사본 생성
        Console.WriteLine($"({x},{y})");
    }
}