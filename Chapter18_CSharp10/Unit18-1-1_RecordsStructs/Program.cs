

// 9.0부터 가능했던 참조 형식의 record
record Vector(int X, int Y);

// 10부터 가능한 값 형식의 records
// 컴파일 시 "public struct Point"로 대체
record struct Point(int X, int Y);

// record 정의가 참조 형식임을 명시 "record class"
record class Person(string Name, int Age);


// ToString, GetHashCode 재정의 가능
record Vector2D(float x, float y)
{
    public override string ToString()   // 재정의 가능
    {
        return $"2D({x}{y})";
    }

    public override int GetHashCode()   // 재정의 가능
    {
        return base.GetHashCode() ;
    }

    // 컴파일 오류 - Equals 메서드는 재정의할 수 없음
    public override bool Equals(object obj)
    {
        return base.Equals(obj) ;
    }
}

// 상속 클래스에서의 재정의를 막는 sealed 예약어
// ToString 메서드에 적용 가능
record Vector2D1(float x, float y)
{
    public sealed override string ToString()
    {
        return $"2D({x}, {y})";
    }
}