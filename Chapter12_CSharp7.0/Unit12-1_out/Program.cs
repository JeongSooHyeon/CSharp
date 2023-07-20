
// 변수를 미리 선언
// int result; 
// int.TryParse("5", out result);

// 변수 선언 없이 변수의 타입과 함께 out 예약어 사용
int.TryParse("5", out int result);
int.TryParse("5", out int result);  // 컴파일 오류, 컴파일러가 바꾼 구문에서 중복 변수 선언

int.TryParse("5", out var result1);  // var 예약어 사용 가능

// 값이 필요하지 않은 상황, 값을 무시하는 구문 추가, 변수명 생랼
int.TryParse("5", out int _);
int.TryParse("5", out var _);
int.TryParse("5", out _);   // 타입까지 생략 가능