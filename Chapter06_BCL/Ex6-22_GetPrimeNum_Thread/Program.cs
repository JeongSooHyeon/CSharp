﻿using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("입력한 숫자까지의 소수 개수 출력 (종료 : 'x' + Enter)");

        while(true)
        {
            Console.WriteLine("숫자를 입력하세요.");
            string userNumber=Console.ReadLine();

            if(userNumber.Equals("x", StringComparison.OrdinalIgnoreCase) == true)
            {
                Console.WriteLine("프로그램 종료!");
                break;
            }

            Thread t = new Thread(CountPrimeNumbers);
            t.IsBackground = true;
            t.Start(userNumber);
        }
    }

    static void CountPrimeNumbers(Object initialValue)
    {
        string value = (string)initialValue;

        int primeCandidate = int.Parse(value);

        int totalPrimes = 0;

        for (int i = 2; i <= primeCandidate; i++)
        {
            if (IsPrime(i) == true)
            {
                totalPrimes++;
            }
        }
        Console.WriteLine("숫자 {0}까지의 소수 개수 ? {1}", value, totalPrimes);
    }

    static bool IsPrime(int candidate)
    {
        if ((candidate & 1) == 0)   // 0010 & 0001
        {
            return candidate == 2;
        }

        for (int i = 3; i < candidate; i += 2)
        {

            if ((candidate % i) == 0)
                return false;
        }
        return candidate != 1;
    }
}