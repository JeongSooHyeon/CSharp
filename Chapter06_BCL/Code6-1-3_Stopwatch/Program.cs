using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Stopwatch st = new Stopwatch();

        st.Start();
        Sum();
        st.Stop();

        // st.ElapsedTicks 속성은 구간 사이에 흐른 타이머의 tick 수
        Console.WriteLine("Total Ticks : " + st.ElapsedTicks);

        // st.ElapsedMilliseconds 속성은 구간 사이에 흐른 시간을 밀리초로 반환
        Console.WriteLine("Millisecond : " + st.ElapsedMilliseconds);

        // 밀리초로 흐른 시간을 초로 환산
        Console.WriteLine("Second : " + st.ElapsedMilliseconds / 1000);

        // Stop.Frequency 속성이 초당 흐른 틱수를 반환하므로,
        // ElapsedTicks에 대해 나눠주면 초 단위의 시간을 잴 수 있음
        Console.WriteLine("Second : " + st.ElapsedTicks / Stopwatch.Frequency);
    }
    private static long Sum()
    {
        long sum = 0;

        for (int i = 0; i < 1000000; i++)
        {
            sum += i;
        }

        return sum;
    }
}

