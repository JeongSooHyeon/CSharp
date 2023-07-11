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
        // [클라이언트 소켓 코드 작성]
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        EndPoint serverEP = new IPEndPoint(IPAddress.Loopback, 11200);

        socket.Connect(serverEP);

        string request = "GET / HTTP /1.0\r\nHost: www.naver.com\r\n\r\n";
        byte[] sendBuffer = Encoding.UTF8.GetBytes(request);

        // 네이버 웹 서버로 HTTP 요청을 전송
        socket.Send(sendBuffer);

        // HTTP 요청이 전달됐으므로 네이버 웹 서버로부터 응답을 수신
        MemoryStream ms = new MemoryStream();
        while (true)
        {
            byte[] rcvBuffer = new byte[4096];

            int nRecv = socket.Receive(rcvBuffer);
            if (nRecv == 0)
            {
                // 서버 측으로부터 더 이상 받을 데이터가 없으면 0을 반환
                break;
            }

            ms.Write(rcvBuffer, 0, nRecv);
        }
        socket.Close();

        string response = Encoding.UTF8.GetString(ms.GetBuffer(), 0, (int)ms.Length);

        Console.WriteLine(response);
        // 서버 측에서 받은 HTML 데이터를 파일로 저장
        File.WriteAllText("naverpage.html", response);
        Console.WriteLine(Environment.CurrentDirectory);
    }
}