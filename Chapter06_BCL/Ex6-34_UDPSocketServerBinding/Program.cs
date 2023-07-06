using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

class Program
{
    private static void serverFunc(object obj)
    {
        // [서버 소켓 코드 작성]
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        // IPAddress ipAddress = GetCurrentIPAddress();
        //if (ipAddress == null)
        //{
        //    Console.WriteLine("IPv4용 랜 카드가 없습니다.");
        //    return;
        //}

        //IPAddress ipAddress = IPAddress.Parse("0.0.0.0");
        //IPEndPoint endPoint = new IPEndPoint(ipAddress, 10200);

        IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 10200);

        socket.Bind(endPoint);
    }

    // 현재 컴퓨터에 장착된 네트워크 어댑터의 IPv4 주소를 반환
    private static IPAddress GetCurrentIPAddress()
    {
        IPAddress[] addrs = Dns.GetHostEntry(Dns.GetHostName()).AddressList;

        foreach (IPAddress ipAddr in addrs)
        {
            if (ipAddr.AddressFamily == AddressFamily.InterNetwork)
            {
                return ipAddr;

            }
        }
        return null;
    }
}