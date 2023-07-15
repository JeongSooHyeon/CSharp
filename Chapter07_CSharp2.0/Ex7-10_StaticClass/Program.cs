using System;
using System.Threading;

static class StaticOnly
{
    static string _name;    // 정적 필드
    public static string Name   // 정적 속성
    {
        get { return _name; }   
        set { _name = value; }  
    }

    public static void WriteNameAsync() // 정적 메서드
    {
        ThreadPool.QueueUserWorkItem(delegate(object objState)
        {
            Console.WriteLine(_name);
        }
        );
    }
}

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            StaticOnly.Name = "Anders";

            StaticOnly.WriteNameAsync();

            Thread.Sleep(1000);
        }
    }
}