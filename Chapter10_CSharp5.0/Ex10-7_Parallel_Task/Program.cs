using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Task를 이용해 병렬 수행
        var task3 = Method3Async();
        var task5 = Method5Async();

        // task3 작업과 task5 작업이 완료될 때까지 현재 스레드를 대기
        Task.WaitAll(task3, task5);

        Console.WriteLine(task3.Result + task5.Result);
    }
    private static Task<int> Method3Async()
    {
        return Task.Factory.StartNew(() =>
        {
            Thread.Sleep(3000);
            return 3;
        });
    }

    private static Task<int> Method5Async()
    {
        return Task.Factory.StartNew(() =>
        {
            Thread.Sleep(5000);
            return 5;
        });
    }
}