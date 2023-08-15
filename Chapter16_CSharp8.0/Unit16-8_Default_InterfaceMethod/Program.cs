using System;
using System.IO;

public interface ILog
{
    void Log(string txt) => WriteConsole(txt);

    static void WriteConsole(string txt)
    {
        Console.WriteLine(txt);
    }

    void WriteFile(string txt)
    {
        File.WriteAllText(LogFilePath, txt);
    }

    string LogFilePath
    {
        get
        {
            return Path.Combine(DefaultPath, DefaultFileName);
        }
    }

    static string DefaultPath = @"C:\temp";
    static string DefaultFileName = "app.log";
}

// 상속한 ILog는 모든 메서드를 구현하고 있으므로
public class ConsoleLogger : ILog
{

}

// ILog는 또한 인터페이스이므로 일부 메서드를 재정의하는 것도 가능
public class FileLogger : ILog
{
    string _filePath;

    public string LogFilePath
    {
        get { return _filePath; }
    }

    public FileLogger(String filePath)
    {
        _filePath = filePath;
    }

    public void Log(String txt)
    {
        (this as ILog).WriteFile(txt);
    }
}

class Program
{
    static void Main(string[] args)
    {
        ConsoleLogger x = new ConsoleLogger();
        // ConsoleLogger 클래스는 Log 메서드를 구현하지 않았으므로
        // ILog 인터페이스로 형변환해 호출
        (x as ILog).Log("test");

        // 인터페이스 타입의 변수로 선언해 사용
        ILog x1 = new ConsoleLogger();
        x1.Log("test");

        var x2 = new FileLogger(@"c:\tmp\my.log");
        // FileLogger 클래스는 Log 메서드를 구현했으므로
        x2.Log("test");
    }

}