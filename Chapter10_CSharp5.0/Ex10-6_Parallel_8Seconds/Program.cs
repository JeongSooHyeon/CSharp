using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Thread를 이용해 병렬 수행

        Dictionary<string, int> dict = new Dictionary<string, int>();

        Thread t3 = new Thread((result) =>
        {
            Thread.Sleep(3000);
            dict.Add("t3Result", 3);
        });

        Thread t5 = new Thread((result) =>
        {
            Thread.Sleep(5000);
            dict.Add("t5Result", 5);
        });

        t3.Start();
        t5.Start();

        t3.Join();  // 3초짜리 작업이 완료되기를 대기
        t5.Join();  // 5초짜리 작업이 완료되기를 대기

        // 약 5초 후에 모든 결괏값을 얻어 처리 가능
        Console.WriteLine(dict["t3Result"] + dict["t5Result"]);

/*
        int result3 = Method3();
        int result5 = Method5();

        Console.WriteLine(result3 + result5);*/
    }

    private static int Method3()
    {
        Thread.Sleep(3000);
        return 3;
    }

    private static int Method5()
    {
        Thread.Sleep(5000);
        return 5;
    }
}