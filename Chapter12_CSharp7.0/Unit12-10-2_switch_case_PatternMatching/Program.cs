using System;
using System.Collections;
using System.ComponentModel;
using System.Net;
using System.Text;

class Program
{
    static void Main(String[] args)
    {
        object[] objList = new object[] { 100, null, DateTime.Now, new ArrayList() };

        foreach (object item in objList)
        {
            switch (item)
            {
                case 100:   // 상수 패턴
                    break;

                case null: // 상수 패턴
                    break;

                case DateTime dt: // 타입 패턴(값 형식) - 필요 없다면 dt 변수명을 밑줄(_)로 생략 가능
                    break;

                case ArrayList arr: // 타입 패턴(참조 형식) - 필요 없다면 dt 변수명을 밑줄(_)로 생략 가능
                    break;

                case var elem:  // Var 패턴 (default와 동일)
                    break;
            }
        }

        int j = GetIntegerResult();

        if(j > 300)
        { }
        else{ }

        switch (j)
        {
            case int i when i > 300:    // 조건 한 번 더 검사
                break;

            default:
                break;
        }




        // Var 패턴 매칭, 사용자 정의 패턴 매칭 구현
        string text = "......";

        switch (text)
        {
            case var item when (ContainsAt(item, "http://www.naver.com")):
                Console.WriteLine("In Naver");
                break;

            case var item when (ContainsAt(item, "http://www.daum.net")):
                Console.WriteLine("In Daum");
                break;

            default:
                Console.WriteLine("None");
                break;
        }

        // Zero found
        Action<(int, int)> detectZeroOR = (arg) =>
        {
            switch (arg)
            {
                case var r when r.Equals((0, 0)):
                case var r1 when r1.Item1 == 0:
                case var r2 when r2.Item2 == 0:
                    Console.WriteLine("Zero found.");
                    return;
            }
            Console.WriteLine("Both nonzero");
        };

        detectZeroOR((0, 0));
    }

    private static bool ContainsAt(string item, string url)
    {
        WebClient wc = new WebClient();
        wc.Encoding = Encoding.UTF8;
        string text = wc.DownloadString(url);

        return text.IndexOf(item) != -1;
    }

    static int GetIntegerResult()
    {
        return 0;
    }
}