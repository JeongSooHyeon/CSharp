using System;
using System.Net;

class Program
{
    static async Task Main(string[] args)
    {
        // 이전에 우회해서 사용
        MainAsync().GetAwaiter().GetResult();

        // Main 메소드에 async 허용
        WebClient wc = new WebClient();
        string text = await wc.DownloadStringTaskAsync("http://www.microsoft.com");
        Console.WriteLine(text);
    }

    private static async Task MainAsync()
    {
        WebClient wc = new WebClient();
        string text = await wc.DownloadStringTaskAsync("http://www.microsoft.com");
        Console.WriteLine(text);
    }
}