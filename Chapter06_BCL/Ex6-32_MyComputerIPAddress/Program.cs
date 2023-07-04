using System.Net;

string myComputer = Dns.GetHostName();

Console.WriteLine("컴퓨터 이름 : " + myComputer);

IPHostEntry entry = Dns.GetHostEntry(myComputer);
foreach(IPAddress ipAddress in entry.AddressList)
{
    Console.WriteLine(ipAddress.AddressFamily + " : " + ipAddress);
}