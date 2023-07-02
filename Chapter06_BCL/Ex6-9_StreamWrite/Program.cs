using System;
using System.Text;

MemoryStream ms = new MemoryStream();

StreamWriter sw = new StreamWriter(ms, Encoding.UTF8);
sw.WriteLine("Hello World");
sw.WriteLine("Anderson");
sw.Write(32000);
sw.Flush();

// 원래는 Stream에 문자열 데이터 쓰려면 Encoding 타입을 이용해 바이트 배열로 직접 변환
/*MemoryStream ms = new MemoryStream();

byte[] buf = Encoding.UTF8.GetBytes("Hello World");
ms.Write(buf, 0, buf.Length);*/

ms.Position = 0;    // Position 꼭 돌려놓기

StreamReader sr = new StreamReader(ms, Encoding.UTF8);
string txt = sr.ReadToEnd();
Console.WriteLine(txt);