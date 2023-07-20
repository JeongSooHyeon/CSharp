using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // 기존 예외 처리 구문, 동일한 예외 타입의 catch 문 여러개 불가능
        try
        {
            throw new FileNotFoundException("test.txt");
        }
        catch(FileNotFoundException e) { }
        // catch(FileNotFoundException e) { }   // 컴파일 오류


        // 예외 필터의 중복 사용
        try
        {
            throw new FileNotFoundException("test.txt");
        }
        catch(FileNotFoundException e) when (Log(e))
        {
            Console.WriteLine("1");
        }
        catch(FileNotFoundException e) when (Log(e))    // 동일한 예외 필터도 가능
        {
            Console.WriteLine("2");
        }
        catch (FileNotFoundException)   // 필터가 없는 예외 타입과 함께 사용 가능
        {
            Console.WriteLine("3");
        }
    }

    private static bool Log(Exception e)
    {
        return false;
    }
}