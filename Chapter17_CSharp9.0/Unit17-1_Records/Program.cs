

// 컴파일 시 public class Point로 바뀜                                                             
public record Point1
{
    public int X;
    public int Y;
}

public class Point
{
    public int X;
    public int Y;

    public override int GetHashCode()
    {
        return X ^ Y;
    }

    public override bool Equals(object obj)
    {
        return this.Equals(obj as Point);
    }

    public virtual bool Equals(Point other)
    {
        if(object.ReferenceEquals(other, null))
        {
            return false;
        }

        return (this.X == other.X && this.Y == other.Y);
    }

    public static bool operator == (Point r1, Point r2)
    {
        if(object.ReferenceEquals (r1, null))
        {
            if(object.ReferenceEquals(r2, null))
            {
                return true;
            }
            return false;
        }
        return r1.Equals (r2);
    }

    public static bool operator !=(Point r1, Point r2)
    {
        return !r1.Equals(r2);
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} {{ X = {X}, Y = {Y} }}";
    }
}