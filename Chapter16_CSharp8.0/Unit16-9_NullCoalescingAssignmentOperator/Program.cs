

// 참조 객체가 null인 경우, 기본값 할당
string txt1 = null;
if (txt1 == null)
{
    txt1 = "(기본값)";
}

// 널 병합 할당 연산자
txt1 ??= "";

{
    string txt = null;

    txt = txt ?? "test";
    txt ??= "test";

    string result = txt ??= "test";
}