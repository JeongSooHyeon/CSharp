

class Program
{
    static void Main(string[] args)
    {
        Notebook note = new Notebook();
        Desktop desk = new Desktop();

        // 이전 컴파일 오류
        Computer prd = (note != null) ? note : desk;    // 두 타입이 서로 암시적 형변환이 불가능

        // 이전 오류 없이 사용하기 위해 형변환 연산자 사용
        Computer prd1 = (note != null) ? (Computer)note : desk;



        // string과 int의 대상 타입인 object로 암시적 형변환 가능
        object retValue = (args.Length == 0) ? "(empty)" : 1;

        // int와 null의 대상 타입인 int?로 암시적 형변환 가능
        int? result = (args.Length != 0) ? 1 : null;
    }
}

public class Computer { }

public class Notebook : Computer { }

public class Desktop : Computer { }