using System;

namespace Ex9_2_OptionalParameter
{
    class Person
    {
        public void Output(string name, int age = 0, string address = "Korea")
        {
            Console.WriteLine(string.Format("{0} : {1} in {2}", name, age, address));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();

            p.Output("Anders");
            p.Output("Winnie", 46);
            p.Output("Tom", 28, "Tibet");

            // 명명된 인수(named argument)
            // p.Output("Tom", "Tibet");   // 컴파일 오류
            p.Output("Tom", address: "Tibet");  // address 매개변수를 지정해서 값을 전달        
        }
    }
}
