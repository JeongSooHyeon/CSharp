using System;
using System.Numerics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger int1 = BigInteger.Parse("12345678901234567890");
            BigInteger int2 = BigInteger.Parse("98765432109876543210");

            Console.WriteLine(int1 + int2);
        }
    }
}