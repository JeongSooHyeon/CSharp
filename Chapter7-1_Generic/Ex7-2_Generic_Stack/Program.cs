using System;

public class NewStack<T>
{
    T[] _objList;
    int _pos;

    public NewStack(int size)
    {
        _objList = new T[size];
    }

    public void Push(T newValue)
    {
        _objList[_pos] = newValue;
        _pos++;
    }

    public T Pop()
    {
        _pos--;
        return _objList[_pos];
    }
}

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            NewStack<int> intStack = new NewStack<int>(10);
            intStack.Push(1);
            intStack.Push(2);
            intStack.Push(3);

            Console.WriteLine(intStack.Pop());
            Console.WriteLine(intStack.Pop());
            Console.WriteLine(intStack.Pop());
        }
    }
}