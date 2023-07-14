using System;
using System.Reflection;
namespace ConsoleApp1
{
    public class SystemInfo
    {
        bool _is64Bit;

        public SystemInfo()
        {
            _is64Bit = Environment.Is64BitOperatingSystem;
            Console.WriteLine("SystemInfo created.");
        }

        public void WriteInfo()
        {
            Console.WriteLine("OS == {0}bits", (_is64Bit == true) ? "64" : "32");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SystemInfo sysInfo = new SystemInfo();
            sysInfo.WriteInfo();

            /////////////////////////////////////////////////////////////////////////////
            // 리플랙션으로 위 작업 수행
            Type systemInfoType = Type.GetType("ConsoleApp1.SystemInfo");
            // Type 정보만으로 객체 생성
            // object objInstance = Activator.CreateInstance(systemInfoType);  

            // 타입의 생성자를 리플랙션으로 구해 직접 호출
            ConstructorInfo ctorInfo = systemInfoType.GetConstructor(Type.EmptyTypes);
            object objInstance1 = ctorInfo.Invoke(null);    // 생성자 호출

            // 메서드 호출
            MethodInfo methodInfo = systemInfoType.GetMethod("WriteInfo");
            methodInfo.Invoke(objInstance1, null);

            // 리플랙션으로 private 속성 접근
            FieldInfo fieldInfo = systemInfoType.GetField("_is64Bit", BindingFlags.NonPublic | BindingFlags.Instance);
            // 기존 값을 구하고,
            object oldValue = fieldInfo.GetValue(objInstance1);
            // 새로운 값을 쓴다.
            fieldInfo.SetValue(objInstance1, !Environment.Is64BitOperatingSystem);
            // 확인을 위해 WriteInfo 메서드 호출
            methodInfo.Invoke(objInstance1, null);
        }
    }
}