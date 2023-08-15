class Program
{
    static void Main(string[] args)
    {
        var tuple = (13, "Kevin");

        bool result1 = tuple == (13, "Winnie");
        // bool result1 = (tuple.Item1 == 13) && (tuple.Item2 == "Winnie"); // 컴파일러가 확장 비교 수행

        bool result2 = tuple != (13, "Winnie");
    }
}