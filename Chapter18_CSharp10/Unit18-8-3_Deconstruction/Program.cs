

class Program
{
    static void Main(string[] args)
    {
        // 기존의 Deconstruct 메서드를 사용한 분해 구문
        var person = ValueTuple.Create("Kevin", "Arnold");  // 값이 대입될 변수를 첫 번째 사례처럼 괄호 안에 모두 선언
        (string firstName, string lastName) = person;

        // 또는
        string firstName1;  // 외부에 변수 모두 선언
        string lastName1;
        (firstName1, lastName1) = person;


        // 변수 하나는 미리 선언해 두고, 또 다른 하나는 괄호 안에 선언
        // 10부터 내/외부의 변수가 섞여서 값을 받는 것이 가능해졌다
        string firstName2;
        var person1 = ValueTuple.Create("Kevin", "Arnold");

        // 이전에 컴파일 오류
        (firstName2, string lastName2) = person;
    }
}