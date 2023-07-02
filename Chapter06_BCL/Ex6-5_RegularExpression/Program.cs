using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string email = "tester@test.com";
        Console.WriteLine(IsEmail2(email));
    }

    static bool IsEmail2(string email)
    {
        Regex regex = new Regex(@"^([0-9a-zA-Z]+)@([0-9a-zA-Z]+)(\.[0-9a-zA-Z]+){1,}$");
        return regex.IsMatch(email);
        }
 }