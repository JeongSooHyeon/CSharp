using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        AppDomain currentDomain = AppDomain.CurrentDomain;
        Console.WriteLine("Current Domain Name : " +currentDomain.FriendlyName);

        // AppDomain에 로드된 어셈블리 목록
        foreach(Assembly asm in currentDomain.GetAssemblies())
        {
            Console.WriteLine(" " + asm.FullName);

            // 어셈블리에 포함된 모든 타입 열거
            foreach(Type type in asm.GetTypes())
            {
                Console.WriteLine("    " + type.FullName);

                // 멤버
                foreach(MemberInfo memberInfo in type.GetMembers())
                {
                    Console.WriteLine("    " + memberInfo.Name);
                }

                // 멤버를 유형별로 구하기

                // 클래스에 정의된 생성자를 열거
                foreach(ConstructorInfo ctorInfo in type.GetConstructors())
                {
                    Console.WriteLine("    Ctor : " + ctorInfo.Name);
                }

                // 클래스에 정의된 이벤트를 열거
                foreach(EventInfo eventInfo in type.GetEvents())
                {
                    Console.WriteLine("    Event : " + eventInfo.Name);
                }

                // 클래스에 정의된 필드를 열거
                foreach(FieldInfo fieldInfo in type.GetFields())
                {
                    Console.WriteLine("    Field : " + fieldInfo.Name);
                }

                /// 클래스에 정의된 메서드를 열거
                foreach (MethodInfo methodInfo in type.GetMethods())
                {
                    Console.WriteLine("    Method : " + methodInfo.Name);
                }

                // 클래스에 정의된 프로퍼티를 열거
                foreach (PropertyInfo propertyInfo in type.GetProperties())
                {
                    Console.WriteLine("    Field : " + propertyInfo.Name);
                }
            }

            // 어셈블리에 포함된 모듈
            foreach(Module module in asm.GetModules())
            {
                Console.WriteLine(" " + module.FullyQualifiedName);
                
                // 각 모듈에 구현된 타입
                foreach (Type type in module.GetTypes())
                {
                    Console.WriteLine("    " + type.FullName);
                }
            }

        }

    }
}