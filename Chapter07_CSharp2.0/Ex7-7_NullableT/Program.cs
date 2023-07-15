
class Program
{
    static void Main(string[] args)
    {
        Nullable<int> intValue = 10;

        // Nullable<T>에서 T로 대입
        int target = intValue.Value;

        // T에서 Nullable<T>로 대입
        intValue = target;

        // Nullable<T>에 null 값을 대입
        double? temp = null;

        Console.WriteLine(temp.HasValue);

        temp = 3.141592;
        Console.WriteLine(temp.HasValue);
        Console.WriteLine(temp.Value);
    }
}