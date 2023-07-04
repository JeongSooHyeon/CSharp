using System;
using System.Threading;

class MyData
{
    int number = 0;

    public int Number { get { return number; } }

    public void Increment()
    {
        number++;
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyData data = new MyData();

        Thread t1 = new Thread(threadFunc);
        Thread t2 = new Thread(threadFunc);

        t1.Start(data);
        t2.Start(data);   // 2개의 스레드를 시작하고

        t1.Join();
        t2.Join();   // 2개의 스레드 실행이 끝날 때까지 대기

        Console.WriteLine(data.Number);   // 스레드 실행 완료 후 number 필드 값 출력
    }

    static void threadFunc(Object inst)
    {
        MyData data = inst as MyData;

        for (int i = 0; i < 10000; ++i)
        {
            lock (data)
            {
                data.Increment();
            }
        }
    }
}