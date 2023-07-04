using System.Net;

IPAddress ipAddr = IPAddress.Parse("202.179.177.21");
Console.WriteLine(ipAddr);

IPAddress ipAddr2 = new IPAddress(new byte[] { 202, 179, 177, 21 });
Console.WriteLine(ipAddr2);