using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    private static void clientFunc(object obj)
    {
        // [클라이언트 소켓 코드 작성]
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        EndPoint serverEP = new IPEndPoint(IPAddress.Loopback, 11200);

        socket.Connect(serverEP);

        byte[] buf = Encoding.UTF8.GetBytes(DateTime.Now.ToString());
        socket.Send(buf);

        byte[] recvBytes = new byte[1024];
        int nRecv = socket.Receive(recvBytes);
        string txt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);

        Console.WriteLine(txt);

        socket.Close();
        Console.WriteLine("UDP Client socket : Closed");
    }
}