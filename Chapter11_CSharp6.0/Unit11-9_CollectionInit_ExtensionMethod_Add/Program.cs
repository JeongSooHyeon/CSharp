using System;
using System.Collections;
using System.Collections.Generic;

// 확장 메서드로 정의한 Add
public static class NaturalNumberExtension
{
    public static void Add(this NaturalNumber instance, int number)
    {
        instance.Numbers.Add(number);
    }
}

public class NaturalNumber : IEnumerable
{
    List<int> numbers = new List<int>();
    public List<int> Numbers
    {
        get { return numbers; }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return numbers.GetEnumerator();
    }
}

class Program
{
    static void Main(string[] args)
    {
        NaturalNumber numbers = new NaturalNumber() { 0, 1, 2, 3, 4 };  // C# 5.0 컴파일 오류, Add 정의 포함되어 있지 않음

         foreach(var item in numbers)
        {
            Console.WriteLine(item);
        }
    }
}