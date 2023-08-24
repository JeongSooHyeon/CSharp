

// 전역 네임스페이스 선언

// C# 프로젝트에 아래의 내용을 담은 Helpers.cs 파일이 있다고 가정
global using System;
global using System.Linq;


// 같은 프로젝트 내의 다른 소스 코드 파일에서 별다른 네임스페이스 선언 없이 사용
// Helpers.cs 파일과 동일한 프로젝트에 있는 Program.cs 파일이라고 가정
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(args.Count());    // Console 타입과 Linq 확장 메서드 사용 가능
    }
}




// 파일 범위 네임스페이스
// 해당 파일에 정의한 전체 타입에 적용
namespace ConsoleApplication1;

public static class Program
{
    public static void Main(params string[] args)
    {
        Console.WriteLine();
    }
}