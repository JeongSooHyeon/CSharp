using System.Net;

IPAddress ipAddr = IPAddress.Parse("192.168.1.10");
IPEndPoint endpoint = new IPEndPoint(ipAddr, 9000);
Console.WriteLine(endpoint);