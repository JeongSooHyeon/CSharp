using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        TcpListener listener = new TcpListener(IPAddress.Any, 11200);
        listener.Start();

        while (true)
        {
            var client = listener.AcceptTcpClient();
            ProcessTcpClient(client);
        }
    }

    // 비동기 호출
    private static async void ProcessTcpClient(TcpClient client)
    {
        NetworkStream ns = client.GetStream();

        byte[] buffer = new byte[1024];
        int received = await ns.ReadAsync(buffer, 0, buffer.Length);

        string txt = Encoding.UTF8.GetString(buffer, 0, received);

        byte[] sendBuffer = Encoding.UTF8.GetBytes("Hello : " + txt);
        await ns.WriteAsync(sendBuffer, 0, sendBuffer.Length);
        ns.Close();
    }
}