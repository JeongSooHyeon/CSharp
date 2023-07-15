class YieldNaturalNumber
{
    public static IEnumerable<int> Next(int max)
    {
        int _start = 0;

        while (true)
        {
            _start++;
            if(max < _start)
            {
                yield break;    // max만큼만 루프를 수행한 후 열거를 중지
            }

            yield return _start;
        }
    }
}

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(int n in YieldNaturalNumber.Next(100000))
            {
                Console.WriteLine(n);
            }
        }
    }
}