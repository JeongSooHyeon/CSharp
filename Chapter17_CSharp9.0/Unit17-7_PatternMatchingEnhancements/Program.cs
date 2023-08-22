

var t = (args.Length, "# of Args");

// 이전 : 반드시 변수명을 설정하거나 밑줄을 이용한 무시 지정
if (t is (int n1, string _)) { }

// 9.0 : 변수명을 생략해 타입만 지정 가능
if (t is (int, string)) { }

object objValue = args.Length;

// switch 구문에서도 타입만 지정 가능
switch (objValue)
{
    case int:break;
    case System.String:break;
}


// 관계 연산
// is 패턴에서의 관계 연산
static bool GreaterThan10(int number) =>
    number is > 10;

// switch 패턴에서의 관계 연산
static bool GreaterThan102(int number) =>
    number switch
    {
        > 10 => true,
        _ => false,
    };


// is 패턴(상수 비교가 아닌 경우)
static bool GreaterThyanTarget(int number, int target) =>
    number is int value && (value > target);

// 이번 예제에서의 is 패턴은 오히려 사용하지 않는 코드가 더 효율적이다.
// static bool GreaterThanTarget(int number, int target) => number > target;

// switch 패턴(상수 비교가 아닌 경우)
static bool GreaterThanTarget(int number, int target) =>
    number switch
    {
        // 상수 제약에 걸려 불가능한 표현은
        // > target => true,

        // 기존처럼 when을 이용해 비교
        int value when value > target => true,

        _ => false
    };


// not, and, or
// is 패턴
static bool IsLetter(char c) =>
    c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';

// switch 패턴
static bool IsLetter1(char c) =>
    c switch
    {
        >= 'a' and <= 'z' or >= 'A' and <= 'Z' => true,
        _ => false
    };

// not은 기존에 not null 조건을 테스트하는 is 패턴에서 유용
object objValue1 = null;

// 이전 not null 조건 테스트
if(!(objValue1 is null)) { }

// 9.0의 조건 테스트
if (objValue is not null) { }

// 괄호의 도입
static bool IsLetter2(char c) =>
    c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z');