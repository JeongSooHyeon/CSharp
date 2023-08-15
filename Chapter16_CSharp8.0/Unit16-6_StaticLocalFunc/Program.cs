using System;

class Program
{
    static void Main(string[] args)
    {
        Program pg = new Program();
        pg.WriteLog("test");
    }

    private void WriteLog(string txt)
    {
        int length = txt.Length;
        WriteConsole();

        void WriteConsole()
        {
            // int length = 5;  // 로컬 함수 내에서 외부에서 사용한 같은 이름의 변수를 정의할 수 없다.

            // 로컬 함수에서 외부 변수(txt, length)에 자유롭게 접근 가능
            Console.WriteLine($"# of chars('{txt}'):{length}");
        }
    }

    private void WriteLog1(string txt)
    {
        int length = txt.Length;
        WriteConsole1(txt, length);

        static void WriteConsole1(string txt, int length)   // 외부 변수를 명시적으로 인자를 통해 받는 것으로 처리
        {
            Console.WriteLine($"# of chars('{txt}'): {length}");
        }
    }
}