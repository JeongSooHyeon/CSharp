using System;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = Assembly.LoadFrom("Ex6-61_ClassLibrary1.dll");
            Type systemInfoType = asm.GetType("Ex6_61_ClassLibrary1.SystemInfo");

            ConstructorInfo ctorInfo = systemInfoType.GetConstructor(Type.EmptyTypes);
            object objInstance = ctorInfo.Invoke(null);
            MethodInfo methodInfo = systemInfoType.GetMethod("WriteInfo");
            methodInfo.Invoke(objInstance, null);

            FieldInfo fieldInfo  = systemInfoType.GetField("_is64Bit", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo.SetValue(objInstance, !Environment.Is64BitOperatingSystem);

            methodInfo.Invoke(objInstance, null);
        }
    }
}