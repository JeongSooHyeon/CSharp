

public partial class Computer
{
    private partial void Beep();
}

public partial class Computer
{
    // 접근 제한자를 명시했으므로 반드시 구현 코드 포함
    private partial void Beep()
    {
        System.Console.WriteLine("Beep");
    }
}