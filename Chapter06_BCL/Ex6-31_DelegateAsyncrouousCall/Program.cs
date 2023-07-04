﻿using System;
using System.IO;
using System.Text;

public class Calc
{
    public static long Cumsum(int start, int end)
    {
        long sum = 0;

        for (int i = start; i <= end; i++)
        {
            sum += i;
        }

        return sum;
    }
}

class Program
{
    public delegate long CalcMethod(int start, int end);

    static void Main(string[] args)
    {
        CalcMethod calc = new CalcMethod(Calc.Cumsum);

        calc.BeginInvoke(1, 100, calcCompleted, calc);

        Console.ReadLine();
    }

    static void calcCompleted(IAsyncResult ar)
    {
        CalcMethod calc = ar.AsyncState as CalcMethod;
        long result = calc.EndInvoke(ar);

        Console.WriteLine(result);
    }
}