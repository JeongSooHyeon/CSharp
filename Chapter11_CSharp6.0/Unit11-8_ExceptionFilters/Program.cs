using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = @"c:\temp\text.txt";
        try
        {
            string txt = File.ReadAllText(filePath);
        }
        /*        catch(FileNotFoundException e) when(filePath.IndexOf("temp") != -1) // 파일 경로가 temp를 포함하는 경우만 예외 처리
                {
                    Console.WriteLine(e.ToString());
                }*/
        catch (FileNotFoundException e) when (SwallowWhenTempFile(filePath))
        {
            Console.WriteLine(e.ToString());
        }

        // c#으로 구현, 부가적인 작업 수행
        try
        {
            // 코드
        }
        catch (Exception e)
        {
            Log(e);
            throw;
        }


        // Process 메서드 두번 호출
        try
        {
            throw new FileNotFoundException("text.txt");
        }
        catch (FileNotFoundException e) when (Process(e)) { }
        catch (Exception e) when (Process(e)) { }

        // C# 구문으로 흉내
        try
        {
            try
            {
                throw new FileNotFoundException("test.txt");
            }
            catch (FileNotFoundException e)
            {
                Process(e);
                throw;
            }
        }
        catch (Exception e)
        {
            Process(e);
            throw;
        }
    }

    private static bool Process(Exception e)
    {
        Console.WriteLine(e.ToString());
        return false;
    }

    private static void Log(Exception e)
    {
        Console.WriteLine(e.ToString());
    }
    static bool SwallowWhenTempFile(string filePath) // 메서드로 분리
    {
        return filePath.IndexOf("temp") != -1;
    }


    // 기존 예외 처리 구조에 영향을 주지 않고도 부가적인 작업 수행
    void SomeMethod()
    {
        try
        {
            // 코드
        }
        catch(Exception e) when (Log(e))
        {
        // 이 예외 핸들러는 절대로 선택되지 않는다.
        }
    }
    bool Log(Exception e)
    {
        Console.WriteLine(e.ToString());    // 발생한 예외 인스털스를 다룰 수 있다.
        return false;

    }


}