using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Program
{
    private static void serverFunc(object obj)
    {
        // [서버 소켓 코드 작성]
        using (Socket srvSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
        {
            IPAddress ipAddress = IPAddress.Parse("0.0.0.0");
            IPEndPoint endPoint = new IPEndPoint(ipAddress, 10200);

            srvSocket.Bind(endPoint);
            
            byte[] recvBytes = new byte[1024];
            EndPoint clientEP = new IPEndPoint(IPAddress.None, 0);

            while(true)
            {
                int nRecv = srvSocket.ReceiveFrom(recvBytes, ref clientEP);
                string txt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);

                byte[] sendBytes = Encoding.UTF8.GetBytes("Hello : " + txt);
                srvSocket.SendTo(sendBytes, clientEP);
            }
        }
    }

}