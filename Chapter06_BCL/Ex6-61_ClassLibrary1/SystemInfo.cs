using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex6_61_ClassLibrary1
{
    internal class SystemInfo
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
}
