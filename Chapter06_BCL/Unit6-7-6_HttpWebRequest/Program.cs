using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // 서버 소켓이 동작하는 스레드
        Thread serverThread = new Thread(serverFunc);
        serverThread.IsBackground = true;
        serverThread.Start();
        Thread.Sleep(500);  // 소케 서버용 스레드가 실행될 시간을 주기 위해

        // 클라이언트 소켓이 동작하는 스레드
        // 다중 UDP 클라이언트 실행
        Thread clientThread = new Thread(clientFunc);
        clientThread.IsBackground = true;
        clientThread.Start();
        Thread.Sleep(3000);

        Console.WriteLine("종료하려면 아무 키나 누르세요...");
        Console.ReadLine();
    }

    private static void serverFunc(object obj)
    {
        // [서버 소켓 코드 작성]
        using (Socket srvSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 11200);

            srvSocket.Bind(endPoint);
            srvSocket.Listen(10);

            while (true)
            {
                Socket clntSocket = srvSocket.Accept();

                byte[] recvBytes = new byte[1024];

                int nRecv = clntSocket.Receive(recvBytes);
                string txt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);

                byte[] sendBytes = Encoding.UTF8.GetBytes("Hello : " + txt);
                clntSocket.Send(sendBytes);
                clntSocket.Close();
            }
        }
    }
    private static void clientFunc(object obj)
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        EndPoint serverEP = new IPEndPoint(IPAddress.Loopback, 11200);

        socket.Connect(serverEP);

        // HttpWebRequest 타입은 내부적으로 TCP 소켓을 생성하고
        HttpWebRequest req = WebRequest.Create("http://www.naver.com") as HttpWebRequest;
        // GetResponse 호출 단계에서 지정된 웹 서버로 HTTP 요청을 보내고 응답을 받는다.
        HttpWebResponse resp = req.GetResponse() as HttpWebResponse;

        // 응답 내용을 담고 있는 Stream으로부터 문자열을 반환해서 출력한다.
        using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
        {
            string responseText = sr.ReadToEnd();
            Console.WriteLine(responseText);
            File.WriteAllText("naverpage.html", responseText);
        }
    }
}