
class Program
{
    public static bool Event(int n)
    {
        switch (n)
        {
            case int i when (i % 2) == 0: return true;
            default: return false;
        }
    }

    public static bool Event1(int n)
    {
        return n switch
        {
            var x when (x % 2) == 1 => false,
            _ => true
        };
    }


    // 표현식
    public static bool Event2(int n) =>
        n switch
        {
            var x when (x % 2) == 1 => false,
            _ => true
        };

    /* 또는
    public static bool Event(int n) =>
        (n % 2) switch
        {
            1 => false,
            _ => true
        };
    */



}