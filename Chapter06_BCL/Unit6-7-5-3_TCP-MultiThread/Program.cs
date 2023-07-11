using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    private static void serverFunc(object obj)
    {
        using (Socket srvSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 11200);

            srvSocket.Bind(endPoint);

            srvSocket.Listen(10);

            while (true)
            {
                Socket clntSocket = srvSocket.Accept();
                ThreadPool.QueueUserWorkItem((WaitCallback)clientSocketProcess, clntSocket);
            }
        }
    }

    // 서버 소켓이 Accept로 반환받은 클라이언트의 처리를 별도의 스레드에 맡겨서 처리
    private static void clientSocketProcess(object state)
    {
        Socket clntSocket = state as Socket;

        byte[] recvBytes = new byte[1024];

        int nRecv = clntSocket.Receive(recvBytes);
        string txt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);

        byte[] sendBytes = Encoding.UTF8.GetBytes("Hello : " + txt);
        clntSocket.Send(sendBytes);
        clntSocket.Close();
    }
}