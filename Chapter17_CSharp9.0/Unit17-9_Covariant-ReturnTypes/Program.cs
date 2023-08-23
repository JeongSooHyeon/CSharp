

// 메서드를 이름과 매개변수의 타입으로 구분(반환 타입 포함하지 않음)
public class TestClass
{
    public short MyMethod(int count) { return 0; }
    // public int MyMethod(int count) { return 0;}  // 컴파일 에러
}


class Program
{
    static void Main(string[] args)
    {
        Product prd = new Headset().GetDevice();
        Headset hds = new Headset().GetDevice();
    }
}

public class Product
{
    public virtual Product GetDevice() { return this; }
}

public class Headset : Product
{
    // 이전 컴파일 오류
    public override Headset GetDevice()
    {
        return this;
    }
}