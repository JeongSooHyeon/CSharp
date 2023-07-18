using System;
using System.Net;

class Pragram {
    static void Main(string[] args)
    {

        WebClient wc = new WebClient();

        // DownloadStringAsync 동작이 완료됐을 때 호출할 이벤트 등록
        wc.DownloadStringCompleted += wc_DownloadStringCompleted;

        // DownloadString의 비동기 메서드
        wc.DownloadStringAsync(new Uri("http://microsoft.com"));
        Console.ReadLine();
    } 
    
    // 비동기를 동기 호출을 하는 것처럼 작성
    private static async void AwaitDownloadString()
    {
        WebClient wc = new WebClient();
        string text = await wc.DownloadStringTaskAsync("http://www.microsoft.com");
        Console.WriteLine(text);
    }

    static void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        Console.WriteLine(e.Result);
    }
}