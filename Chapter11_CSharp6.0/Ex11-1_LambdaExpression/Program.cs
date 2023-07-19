
public class Vector
{
    double x;
    double y;
    public double Angle => Math.Atan2(y, x);    // get만 자동 정의되고 set 기능은 제공되지 않는다.

    // 인덱서의 get 접근자를 표현식으로 정의
    // 복잡해도 결국 식이기만 하면 표현식 적용 가능
    public double this[string angleType]=>
        angleType == "radian" ? this.Angle : 
        angleType == "degree" ? RadianToDegree(this.Angle) : double.NaN;

    static double RadianToDegree(double angle) => angle * (100.0 / Math.PI);

    public Vector(double x, double y)
    {
        this.x = x; this.y = y;
    }

    /*public Vector Move(double dx, double dy)
    {
        return new Vector(x + dx, y + dy);
    }*/

    public Vector Move(double dx, double dy) => new Vector(x + dx, y + dy);

    /*public void PrintIt()
    {
        Console.WriteLine(this);
    }*/

    public void PrintIt() => Console.WriteLine(this);

    /*public override string ToString()
    {
        return string.Format("x = {0}, y = {1}", x, y);
    }*/

    public override string ToString() => string.Format("x = {0}, y = {1}", x, y);
}