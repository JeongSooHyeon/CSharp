
[Serializable]
public class Foo
{
    [NonSerialized] // 이 특성을 부여하기 위해 자동 구현 속성 코드 재작성
    string _mySecret;

    public string MySecret
    {
        get { return _mySecret; }
        set { _mySecret = value; }
    }

}

// 자동 생성 필드의 특성 지정
[Serializable]
public class Foo1
{
    [field:NonSerialized] // 자동 생성된 필드에 특성이 적용됨
    public string MySecret { get; set; }
}