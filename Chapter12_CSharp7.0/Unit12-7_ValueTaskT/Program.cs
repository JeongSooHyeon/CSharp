using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

class Prgogram
{
    static void Main(string[] args)
    {
        /*        Task<(string, int tid)> result =
                    FileReadAsync(@"C:\windows\system32\drivers\etc\HOSTS");
                int tid = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine($"MainThreadID : {tid}, AsyncThreadID : {result.Result.tid}");*/

/*        Task<(string, int)> result1 =
            FileReadAsync1(@"C:\windows\system32\drivers\etc\HOSTS");   // await의 호출로 비동기 처리
        int tid1 = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine($"MainThreadID : {tid1}, AsyncThreadID : {result1.Result.Item2}");

        Task<(string, int)> result2 =
            FileReadAsync1(@"C:\windows\system32\drivers\etc\HOSTS");   // 동기 방식으로 호출
        int tid2 = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine($"MainThreadID : {tid1}, AsyncThreadID : {result2.Result.Item2}");*/


        // C# 7.0 버전
        ValueTask<(string, int tid)> result3 =
            FileReadAsync2(@"C:\windows\system32\drivers\etc\HOSTS");
        int tid3 = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine($"MainThreadID : {tid3}, AsyncThreadID : {result3.Result.Item2}");
        ValueTask<(string, int tid)> result4 =
    FileReadAsync2(@"C:\windows\system32\drivers\etc\HOSTS");
        int tid4 = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine($"MainThreadID : {tid4}, AsyncThreadID : {result4.Result.Item2}");
    }


    // async 메서드에서 값 반환하기
    private static async Task<(string, int)> FileReadAsync(string filePath)
    {
        string fileText = await ReadAllTextAsync(filePath);
        return (fileText, Thread.CurrentThread.ManagedThreadId);
    }

    // 고치기
    static string _fileContents = string.Empty;
    private static async Task<(string, int)> FileReadAsync1(string filePath)
    {
        if (string.IsNullOrEmpty(_fileContents) == false)
        {
            return (_fileContents, Thread.CurrentThread.ManagedThreadId);
        }

        _fileContents = await ReadAllTextAsync(filePath);
        return (_fileContents, Thread.CurrentThread.ManagedThreadId);
    }

    // C# 7.0 버전
    private static async ValueTask<(string, int)> FileReadAsync2(string filePath)
    {
        if (string.IsNullOrEmpty(_fileContents) == false)
        {
            return (_fileContents, Thread.CurrentThread.ManagedThreadId);
        }

        _fileContents = await ReadAllTextAsync(filePath);
        return (_fileContents, Thread.CurrentThread.ManagedThreadId);
    }
    

    static Task<string> ReadAllTextAsync(string filePath)
    {
        return Task.Factory.StartNew(() =>
        {
            return File.ReadAllText(filePath);
        });
    }
}