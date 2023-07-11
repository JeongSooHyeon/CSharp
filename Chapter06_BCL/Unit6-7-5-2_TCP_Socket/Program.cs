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
        for (int i = 0; i < 3; i++)
        {
            Thread clientThread = new Thread(clientFunc);
            clientThread.IsBackground = true;
            clientThread.Start();
            Thread.Sleep(3000);  
        }

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

        byte[] buf = Encoding.UTF8.GetBytes(DateTime.Now.ToString());
        socket.Send(buf);
        
        // 예외 처리
        try
        {
            byte[] recvBytes = new byte[1024];
            int nRecv = socket.Receive(recvBytes);
            string txt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);

            Console.WriteLine(txt);
        }
        catch (SocketException)
        {
        }

        socket.Close();
        Console.WriteLine("UDP Client socket : Closed");
    }
}