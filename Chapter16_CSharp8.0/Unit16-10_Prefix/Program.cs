using System;

class Program
{
    static void Main(string[] args)
    {
        string path = @"c\temp";

        // 컴파일 가능
        string filePath1 = $@"{path}\file.log";

        // 가능
        string filePath2 = @$"{path}\file.log";
    }
}