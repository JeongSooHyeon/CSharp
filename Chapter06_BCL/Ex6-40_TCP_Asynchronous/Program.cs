using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
public class AsyncStateData
{
    public byte[] Buffer;
    public Socket Socket;
}

class Program
{
    static void Main(string[] args)
    {

    }

    private static void serverFunc(object obj)
    {
        using(Socket srvSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 11200);

            srvSocket.Bind(endPoint);

            srvSocket.Listen(10);

            while (true)
            {
                Socket clntSocket = srvSocket.Accept();

                AsyncStateData data = new AsyncStateData();
                data.Buffer = new byte[1024];
                data.Socket = clntSocket;

                clntSocket.BeginReceive(data.Buffer, 0, data.Buffer.Length, SocketFlags.None, asyncReceiveCallback, data);
            }
        }
    }

    private static void asyncReceiveCallback(IAsyncResult asyncResult)
    {
        AsyncStateData rcvData = asyncResult.AsyncState as AsyncStateData;

        int nRecv = rcvData.Socket.EndReceive(asyncResult);
        string txt = Encoding.UTF8.GetString(rcvData.Buffer, 0, nRecv);

        byte[] sendBytes = Encoding.UTF8.GetBytes("Hello : " + txt);
        rcvData.Socket.BeginSend(sendBytes, 0, sendBytes.Length, SocketFlags.None, asyncSendCallback, rcvData.Socket);
    }

    private static void asyncSendCallback(IAsyncResult asyncResult)
    {
        Socket socket = asyncResult.AsyncState as Socket;
        socket.EndSend(asyncResult);

        socket.Close();
    }
}