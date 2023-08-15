class Program
{
    static void Main(string[] args)
    {
        int a = 5;
        ref int b = ref a;  // a를 가리키는 ref 로컬 변수 b

        int c = 6;

        b = ref c;  // 새롭게 변수 c에 대한 ref를 할당
    }
}