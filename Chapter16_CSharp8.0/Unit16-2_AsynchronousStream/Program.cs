using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        ObjectSequence seq = new ObjectSequence(10);


        foreach(object obj in seq)
        {
            Console.WriteLine(obj);
        }
    }
}

class ObjectSequence : IEnumerable
{
    int _count = 0;

    public ObjectSequence(int count)
    {
        _count = count;
    }

    public IEnumerator GetEnumerator()
    {
        return new ObjectSequenceEnumerator(_count);
    }

    class ObjectSequenceEnumerator : IEnumerator
    {
        int _i = 0;
        int _count = 0;

        public ObjectSequenceEnumerator(int count)
        {
            _count = count;
        }

        public object Current
        {
            get
            {
                Thread.Sleep(100);  // 이것을 Thread.Sleep이 아닌 대략 100ms가 소요되는 무거운, 느린 작업이라고 가정
                return _i++;
            }
        }

        public bool MoveNext() => _i >= _count ? false : true;
        public void Reset() { }
    }
}

class ProgramYield
{
    static async Task Main(string[] args)
    {
        await foreach(int value in GenerateSequence(10))
        {
            Console.WriteLine($"{value} (tid:{Thread.CurrentThread.ManagedThreadId}");
        }

        Console.WriteLine($"Completed (tid : {Thread.CurrentThread.ManagedThreadId}");
        
        


        // while문 구현
        var enumerator = GenerateSequence(10).GetAsyncEnumerator();
        try
        {
            while(await enumerator.MoveNextAsync())
            {
                int item = enumerator.Current;
                Console.WriteLine($"{item} (tid: {Thread.CurrentThread.ManagedThreadId})");
            }
            Console.WriteLine($"Completed (tid: {Thread.CurrentThread.ManagedThreadId})");
        }
        finally
        {
            await enumerator.DisposeAsync();    
        }
    }

    public static async IAsyncEnumerable<int> GenerateSequence(int count)
    {
        for(int i=0; i<count; i++)
        {
            await Task.Run(() => Thread.Sleep(100));
            yield return i;
        }
    }
}