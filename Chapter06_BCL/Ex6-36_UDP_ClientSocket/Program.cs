using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        clientFunc(null);
    }
    private static void clientFunc(object obj)
    {
        Socket clntSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        EndPoint serverEP = new IPEndPoint(IPAddress.Loopback, 10200);
        EndPoint senderEP = new IPEndPoint(IPAddress.None, 0);

        int nTimes = 5;

        while (nTimes-- > 0)
        {
            byte[] buf = Encoding.UTF8.GetBytes(DateTime.Now.ToString());
            clntSocket.SendTo(buf, serverEP);

            byte[] recvBytes = new byte[1024];
            int nRecv = clntSocket.ReceiveFrom(recvBytes, ref senderEP);
            string txt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);

            Console.WriteLine(txt);
            Thread.Sleep(1000);



            // EndPoint serverEP = new IPEndPoint(GetCurrentIPAddress(), 10200);

            // IPAddress localAddress = IPAddress.Parse("127.0.0.1");
            // EndPoint serverEP = new IPEndPoint(localAddress, 10200);
        }
        clntSocket.Close();
        Console.WriteLine("UDP Client socket : Closed");
    }
}