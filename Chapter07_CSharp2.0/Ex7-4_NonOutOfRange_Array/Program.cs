using System;

class ArrayNoException<T>
{
    int _size;
    T[] _items;

    public ArrayNoException(int size)
    {
        _size = size;
        _items = new T[size];
    }

    public T this[int index]
    {
        get
        {
            if (index >= _size)
            {
                return default(T);
            }

            return _items[index];
        }
        set
        {
            if (index >= _size)
            {
                return;
            }

            _items[index] = value;
        }
    }
}

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 0 ~ 9 범위의 인덱스를 사용하는 배열을 생성
            ArrayNoException<int> list = new ArrayNoException<int>(10);

            list[10] = 5;   // 일반적인 배열이었다면 예외가 발생
            Console.WriteLine(list[10]);
        }
    }
}