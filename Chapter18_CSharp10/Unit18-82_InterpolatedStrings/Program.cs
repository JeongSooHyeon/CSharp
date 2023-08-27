
public class Program
{

    // 9.0이전 문자열 보간 
    public static string FormatVersion(int major, int minor, int build, int rev) =>
        $"{major}.{minor}.{build}.{rev}";
    // string.Format을 이용하는 코드로 컴파일
    public static string FormatVersion1(int major, int minor, int build, int revision)
    {
        var array = new object[4];
        array[0] = major;   // 박싱 발생
        array[1] = minor;   // 박싱 발생
        array[2] = build;   // 박싱 발생
        array[3] = revision;   // 박싱 발생

        // 내부에서 각각 ToString을 호출해 문자열 힙 할당 발생
        return string.Format("{0}.{1}.{2}.{3}", array);
    }


    // 동일한 코드를 10에서는 GC 힙 메모리 사용을 줄이는 코드로 컴파일 !!

}