using System;
using System.Collections;
using System.Collections.Generic;

// 물론 이 예제는 int 범위의 자연수만 표현한다.
// 좀 더 큰 자연수가 필요하다면 ulong을 쓰거나 BigInteger를 사용한다.

public class NaturalNumber : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator()
    {
        return new NaturalNumberEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new NaturalNumberEnumerator();
    }

    public class NaturalNumberEnumerator : IEnumerator<int>
    {
        int _current;

        public int Current
        {
            get { return _current; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose() { }

        public bool MoveNext()
        {
            _current++;
            return true;
        }

        public void Reset()
        {
            _current = 0;
        }
    }
}

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            NaturalNumber number = new NaturalNumber();
            foreach (int n in number)   
            {
                Console.WriteLine(n);
            }
        }
    }
}