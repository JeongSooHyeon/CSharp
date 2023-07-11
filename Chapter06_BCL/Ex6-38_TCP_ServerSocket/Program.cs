using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
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
                srvSocket.Send(sendBytes);
                clntSocket.Close();
            }
        }
    }
}