﻿using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        ThreadPool.QueueUserWorkItem(readCompleted);

        // QueueUserWorkItem 메서드 호출은 곧바로 제어를 반환하기 때문에
        // 이곳에서 자유롭게 다른 연산을 동시에 진행할 수 있다.
        Console.ReadLine();
    }

    // 읽기 작업을 스레드 풀에 대행한다.
    static void readCompleted(object state)
    {
        using (FileStream fs = new FileStream(@"C:\windows\system32\drivers\etc\HOSTS",
            FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            byte[] buf = new byte[fs.Length];
            fs.Read(buf, 0, buf.Length);

            string txt = Encoding.UTF8.GetString(buf);
            Console.WriteLine(txt);
        }
    }
}