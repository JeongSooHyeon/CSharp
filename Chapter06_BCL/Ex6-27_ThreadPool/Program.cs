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
    int number = 0;

    static void Main(string[] args)
    {
        MyData data = new MyData();

        ThreadPool.QueueUserWorkItem(threadFunc, data);
        ThreadPool.QueueUserWorkItem(threadFunc, data);

        Thread.Sleep(1000);

        Console.WriteLine(data.Number);   // 스레드 실행 완료 후 number 필드 값 출력
    }

    static void threadFunc(Object inst)
    {
        MyData data = inst as MyData;

        for (int i = 0; i < 10; ++i)
        {
            data.Increment();
        }
    }
}